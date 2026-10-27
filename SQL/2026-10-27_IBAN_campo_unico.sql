/* =====================================================================
   Proyecto Antonio Luis - IBAN en un solo campo (27-10-2026)
   ---------------------------------------------------------------------
   Hasta ahora el IBAN se guardaba en 6 columnas de 4 caracteres
   (iban1cliente ... iban6cliente), así que como mucho cabían 24.
   Un IBAN puede tener hasta 34 caracteres (letras y números).

   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - NO borra ni modifica ninguna columna existente. Las 6 columnas
       antiguas se quedan exactamente como están.
     - Solo AÑADE dos columnas nuevas (vacías) y las rellena uniendo los
       6 bloques antiguos. Solo rellena las que estén vacías: nunca
       sobrescribe un IBAN que ya esté en la columna nueva.
     - Todo va en transacción: si algo falla, se deshace y se para.
     - Se puede ejecutar más de una vez sin problema.

   Qué cambia:
     1. Clientes: columna nueva ibancliente nvarchar(34).
     2. Facturas: columna nueva factiban nvarchar(34)
        (cada factura guarda su IBAN y la remesa lo lee de ahí).
     3. Al final lista, solo para revisarlos, los clientes cuyo IBAN
        no tiene 24 caracteres (posible IBAN incompleto o mal escrito).

   Cómo ejecutarlo: SQL Server Management Studio, conectado a la
   instancia SQLEXPRESS, abrir este fichero y pulsar Ejecutar.
   Leer los mensajes de la pestaña "Mensajes" al terminar.
   ===================================================================== */

USE AdministracionAntonio;
GO

SET ANSI_WARNINGS ON;
SET XACT_ABORT ON;
SET NOCOUNT ON;
GO

/* ---------- 0. Copia de seguridad completa antes de tocar nada ---------- */
DECLARE @fichero nvarchar(400) =
    N'C:\ByMartin\Historico\AntesDeIbanUnico_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de IBAN en un solo campo';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    PRINT 'Comprueba que existe la carpeta C:\ByMartin\Historico.';
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 1. Comprobación: las columnas antiguas deben ser de texto ---------- */
DECLARE @Antiguas TABLE (tabla sysname, columna sysname);
INSERT INTO @Antiguas VALUES
    (N'Clientes', N'iban1cliente'), (N'Clientes', N'iban2cliente'), (N'Clientes', N'iban3cliente'),
    (N'Clientes', N'iban4cliente'), (N'Clientes', N'iban5cliente'), (N'Clientes', N'iban6cliente'),
    (N'Facturas', N'factiban1'),    (N'Facturas', N'factiban2'),    (N'Facturas', N'factiban3'),
    (N'Facturas', N'factiban4'),    (N'Facturas', N'factiban5'),    (N'Facturas', N'factiban6');

IF EXISTS (SELECT 1
           FROM @Antiguas a
           LEFT JOIN INFORMATION_SCHEMA.COLUMNS c
             ON c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = a.tabla AND c.COLUMN_NAME = a.columna
           WHERE c.COLUMN_NAME IS NULL
              OR c.DATA_TYPE NOT IN ('char', 'nchar', 'varchar', 'nvarchar'))
BEGIN
    PRINT 'ATENCIÓN: las columnas del IBAN no son como se esperaba. NO SE HA CAMBIADO NADA.';
    SELECT a.tabla, a.columna, c.DATA_TYPE AS tipo_actual
    FROM @Antiguas a
    LEFT JOIN INFORMATION_SCHEMA.COLUMNS c
      ON c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = a.tabla AND c.COLUMN_NAME = a.columna;
    SET NOEXEC ON;
END
ELSE
    PRINT 'Comprobación correcta: columnas antiguas del IBAN encontradas.';
GO

/* ---------- 2. Añadir las columnas nuevas (vacías) ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    IF COL_LENGTH(N'dbo.Clientes', N'ibancliente') IS NULL
    BEGIN
        ALTER TABLE dbo.Clientes ADD ibancliente nvarchar(34) NULL;
        PRINT 'Columna Clientes.ibancliente creada.';
    END
    ELSE
        PRINT 'La columna Clientes.ibancliente ya existía (no se toca).';

    IF COL_LENGTH(N'dbo.Facturas', N'factiban') IS NULL
    BEGIN
        ALTER TABLE dbo.Facturas ADD factiban nvarchar(34) NULL;
        PRINT 'Columna Facturas.factiban creada.';
    END
    ELSE
        PRINT 'La columna Facturas.factiban ya existía (no se toca).';

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al añadir las columnas. SE HA DESHECHO TODO.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 3. Rellenar las columnas nuevas uniendo los 6 bloques ----------
   Solo donde la columna nueva está vacía. Se quitan los espacios.
   Las columnas antiguas NO se modifican.                                    */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @filasClientes int = (SELECT COUNT(*) FROM dbo.Clientes);
    DECLARE @filasFacturas int = (SELECT COUNT(*) FROM dbo.Facturas);
    DECLARE @rellenosClientes int, @rellenosFacturas int;

    -- (se ejecuta con sp_executesql porque las columnas nuevas acaban de crearse)
    EXEC sp_executesql N'
        UPDATE dbo.Clientes
        SET ibancliente = UPPER(REPLACE(
                ISNULL(iban1cliente, N'''') + ISNULL(iban2cliente, N'''') + ISNULL(iban3cliente, N'''') +
                ISNULL(iban4cliente, N'''') + ISNULL(iban5cliente, N'''') + ISNULL(iban6cliente, N''''),
                N'' '', N''''))
        WHERE ibancliente IS NULL;
        SET @n = @@ROWCOUNT;',
        N'@n int OUTPUT', @n = @rellenosClientes OUTPUT;

    EXEC sp_executesql N'
        UPDATE dbo.Facturas
        SET factiban = UPPER(REPLACE(
                ISNULL(factiban1, N'''') + ISNULL(factiban2, N'''') + ISNULL(factiban3, N'''') +
                ISNULL(factiban4, N'''') + ISNULL(factiban5, N'''') + ISNULL(factiban6, N''''),
                N'' '', N''''))
        WHERE factiban IS NULL;
        SET @n = @@ROWCOUNT;',
        N'@n int OUTPUT', @n = @rellenosFacturas OUTPUT;

    -- Control final: el número de filas no puede haber cambiado
    IF (SELECT COUNT(*) FROM dbo.Clientes) <> @filasClientes
       OR (SELECT COUNT(*) FROM dbo.Facturas) <> @filasFacturas
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
    PRINT 'IBAN copiado a la columna nueva: ' + CAST(@rellenosClientes AS varchar(10)) + ' clientes y ' +
          CAST(@rellenosFacturas AS varchar(10)) + ' facturas.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al copiar el IBAN. SE HA DESHECHO EL RELLENO (las columnas nuevas quedan vacías).';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 4. Para revisar (solo informa, no cambia nada) ---------- */
EXEC sp_executesql N'
IF EXISTS (SELECT 1 FROM dbo.Clientes
           WHERE ibancliente <> N'''' AND LEN(ibancliente) <> 24)
BEGIN
    PRINT ''AVISO: estos clientes tienen un IBAN que no mide 24 caracteres. Revísalos en su ficha:'';
    SELECT codcliente, nombrecliente, ibancliente, LEN(ibancliente) AS caracteres
    FROM dbo.Clientes
    WHERE ibancliente <> N'''' AND LEN(ibancliente) <> 24
    ORDER BY codcliente;
END
ELSE
    PRINT ''Todos los IBAN de clientes miden 24 caracteres (o están vacíos).'';';
GO

PRINT 'Script terminado correctamente.';
GO

SET NOEXEC OFF;
GO
