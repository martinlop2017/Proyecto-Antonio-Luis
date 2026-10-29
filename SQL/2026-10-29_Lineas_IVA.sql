/* =====================================================================
   Proyecto Antonio Luis - IVA por línea de factura (29-10-2026)
   ---------------------------------------------------------------------
   Cada línea de factura lleva su propio tipo de IVA (21, 10, 4, 0...)
   y, si el cliente tiene recargo de equivalencia, su tipo de recargo.

   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Solo AÑADE columnas nuevas y las rellena donde estén vacías.
       No modifica ni borra nada existente.
     - Se puede ejecutar más de una vez sin problema.

   Qué cambia:
     1. FacturaLineas: tipoiva y tiporecargo. En las líneas que ya existen
        se pone el tipo de IVA de su factura (los suplidos quedan sin IVA).
     2. Facturas: factimporterecargo (importe del recargo de equivalencia).
     3. Si no existe, crea el control de números de factura únicos por
        serie y año (solo si no hay números repetidos).

   Ejecutar DESPUÉS de 2026-10-28_Facturacion_series_lineas.sql.
   ===================================================================== */

USE AdministracionAntonio;
GO

SET XACT_ABORT ON;
SET NOCOUNT ON;
GO

/* ---------- 0. Copia de seguridad ---------- */
DECLARE @fichero nvarchar(400) =
    N'C:\ByMartin\Historico\AntesDeLineasIva_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de IVA por línea';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

IF OBJECT_ID(N'dbo.FacturaLineas', N'U') IS NULL
BEGIN
    PRINT 'ERROR: falta la tabla FacturaLineas. Ejecuta antes 2026-10-28_Facturacion_series_lineas.sql. NO SE HA CAMBIADO NADA.';
    SET NOEXEC ON;
END;
GO

/* ---------- 1. Columnas nuevas ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    IF COL_LENGTH(N'dbo.FacturaLineas', N'tipoiva') IS NULL
        ALTER TABLE dbo.FacturaLineas ADD tipoiva decimal(5,2) NULL;
    IF COL_LENGTH(N'dbo.FacturaLineas', N'tiporecargo') IS NULL
        ALTER TABLE dbo.FacturaLineas ADD tiporecargo decimal(5,2) NULL;
    IF COL_LENGTH(N'dbo.Facturas', N'factimporterecargo') IS NULL
        ALTER TABLE dbo.Facturas ADD factimporterecargo decimal(18,2) NULL;

    COMMIT TRANSACTION;
    PRINT 'Columnas nuevas preparadas.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al añadir las columnas. SE HA DESHECHO TODO.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 2. Rellenar en las líneas existentes ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @lineas int = (SELECT COUNT(*) FROM dbo.FacturaLineas);

    EXEC sp_executesql N'
        UPDATE l
        SET l.tipoiva = f.facttipoiva, l.tiporecargo = 0
        FROM dbo.FacturaLineas l
        JOIN dbo.Facturas f ON f.factcontador = l.factcontador
        WHERE l.sujetoiva = 1 AND l.tipoiva IS NULL;

        UPDATE dbo.FacturaLineas
        SET tiporecargo = 0
        WHERE tiporecargo IS NULL;';

    IF (SELECT COUNT(*) FROM dbo.FacturaLineas) <> @lineas
    BEGIN
        ;THROW 50001, 'El número de líneas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
    PRINT 'Tipo de IVA copiado a las líneas existentes.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al rellenar las líneas. Se ha deshecho el relleno.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 3. Números de factura únicos por serie y año ---------- */
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_Facturas_serie_numero'
           AND object_id = OBJECT_ID(N'dbo.Facturas'))
    PRINT 'El control de números únicos ya existe.';
ELSE IF EXISTS (SELECT factserie, factejercicio, factnumerofact
                FROM dbo.Facturas
                WHERE factserie IS NOT NULL AND factejercicio IS NOT NULL AND factnumerofact IS NOT NULL
                GROUP BY factserie, factejercicio, factnumerofact HAVING COUNT(*) > 1)
    PRINT 'AVISO: hay números de factura repetidos en la misma serie y año; no se crea el control de números únicos.';
ELSE
BEGIN
    CREATE UNIQUE INDEX UX_Facturas_serie_numero
        ON dbo.Facturas (factserie, factejercicio, factnumerofact)
        WHERE factserie IS NOT NULL AND factejercicio IS NOT NULL AND factnumerofact IS NOT NULL;
    PRINT 'Control de números de factura únicos por serie y año creado.';
END;
GO

SELECT tipoiva, sujetoiva, COUNT(*) AS lineas, SUM(importe) AS importe
FROM dbo.FacturaLineas GROUP BY tipoiva, sujetoiva ORDER BY sujetoiva DESC, tipoiva DESC;
PRINT 'Script terminado correctamente.';
GO

SET NOEXEC OFF;
GO
