/* =====================================================================
   Proyecto Antonio Luis - Retenciones de IRPF (27-10-2026)
   ---------------------------------------------------------------------
   Prepara la base de datos para aplicar retención de IRPF en las
   facturas de los clientes que la tengan marcada en su ficha.

   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Solo CREA una tabla nueva y AÑADE columnas nuevas vacías.
       No modifica ni borra ningún dato existente.
     - Las facturas ya emitidas no cambian (sus columnas nuevas quedan
       vacías = sin retención).
     - Se puede ejecutar más de una vez sin problema.

   Qué cambia:
     1. Tabla nueva Retenciones: tipos de retención (concepto y %) y cuál
        es la que se aplica. Si está vacía, se dan de alta dos tipos:
        "General" 15 % (la que se aplica) e "Inicio de actividad" 7 %.
        Se pueden cambiar en Impuestos.
     2. Clientes: columna nueva retencioncliente (casilla "Retención IRPF").
     3. Facturas: columnas nuevas factretencionporc (% aplicado) y
        factretencion (importe retenido).

   Cómo ejecutarlo: SQL Server Management Studio, conectado a la
   instancia SQLEXPRESS, abrir este fichero y pulsar Ejecutar.
   ===================================================================== */

USE AdministracionAntonio;
GO

SET XACT_ABORT ON;
SET NOCOUNT ON;
GO

/* ---------- 0. Copia de seguridad completa antes de tocar nada ---------- */
DECLARE @fichero nvarchar(400) =
    N'C:\ByMartin\Historico\AntesDeRetenciones_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de retenciones IRPF';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    PRINT 'Comprueba que existe la carpeta C:\ByMartin\Historico.';
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 1. Tabla, columnas nuevas y tipos iniciales ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @filasClientes int = (SELECT COUNT(*) FROM dbo.Clientes);
    DECLARE @filasFacturas int = (SELECT COUNT(*) FROM dbo.Facturas);

    IF OBJECT_ID(N'dbo.Retenciones', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.Retenciones (
            numerador     numeric(18,0) NOT NULL CONSTRAINT PK_Retenciones PRIMARY KEY,
            retconcepto   nvarchar(50)  NOT NULL,
            retporciento  numeric(4,2)  NOT NULL,
            retpordefecto bit           NOT NULL CONSTRAINT DF_Retenciones_pordefecto DEFAULT (0)
        );
        PRINT 'Tabla Retenciones creada.';
    END
    ELSE
        PRINT 'La tabla Retenciones ya existía (no se toca).';

    IF COL_LENGTH(N'dbo.Clientes', N'retencioncliente') IS NULL
    BEGIN
        ALTER TABLE dbo.Clientes ADD retencioncliente bit NULL;
        PRINT 'Columna Clientes.retencioncliente creada.';
    END;

    IF COL_LENGTH(N'dbo.Facturas', N'factretencionporc') IS NULL
    BEGIN
        ALTER TABLE dbo.Facturas ADD factretencionporc decimal(4,2) NULL;
        PRINT 'Columna Facturas.factretencionporc creada.';
    END;

    IF COL_LENGTH(N'dbo.Facturas', N'factretencion') IS NULL
    BEGIN
        ALTER TABLE dbo.Facturas ADD factretencion decimal(18,2) NULL;
        PRINT 'Columna Facturas.factretencion creada.';
    END;

    IF (SELECT COUNT(*) FROM dbo.Clientes) <> @filasClientes
       OR (SELECT COUNT(*) FROM dbo.Facturas) <> @filasFacturas
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al crear la tabla o las columnas. SE HA DESHECHO TODO.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 2. Tipos iniciales (solo si la tabla está vacía) ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Retenciones)
BEGIN
    INSERT INTO dbo.Retenciones (numerador, retconcepto, retporciento, retpordefecto) VALUES
        (1, N'General',             15.00, 1),
        (2, N'Inicio de actividad',  7.00, 0);
    PRINT 'Tipos de retención iniciales dados de alta (General 15 %, Inicio de actividad 7 %).';
END;
GO

SELECT numerador, retconcepto, retporciento, retpordefecto FROM dbo.Retenciones ORDER BY numerador;
PRINT 'Script terminado correctamente.';
GO

SET NOEXEC OFF;
GO
