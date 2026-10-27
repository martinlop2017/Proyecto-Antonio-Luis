/* =====================================================================
   Proyecto Antonio Luis - Tabla Propios / "Mis datos" (27-10-2026)
   ---------------------------------------------------------------------
   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Comprueba que ningún campo se va a quedar más pequeño de lo que es
       ahora. Si alguno se quedara más pequeño, se para sin tocar nada.
     - Solo AMPLÍA columnas y AÑADE una nueva. No borra filas ni columnas
       y no recorta ningún dato.
     - Lo único que "limpia" es el relleno de espacios por la derecha que
       añadía el tipo nchar (no es dato, es relleno).
     - Las 6 columnas antiguas del IBAN (miiban1..miiban6) no se tocan.
     - Todo va en transacción: si algo falla, se deshace y se para.
     - Se puede ejecutar más de una vez sin problema.

   Qué cambia:
     1. Propios: pasa los textos de nchar a nvarchar y amplía nombre,
        NIF, CP, contacto, email y ruta del logo.
     2. Propios: columna nueva miiban nvarchar(34) con el IBAN completo,
        rellenada uniendo los 6 bloques de 4.

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
    N'C:\ByMartin\Historico\AntesDePropios_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de ampliar Propios';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    PRINT 'Comprueba que existe la carpeta C:\ByMartin\Historico.';
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 1. Comprobación: ningún campo puede quedar más pequeño ---------- */
DECLARE @Destino TABLE (columna sysname, largo int);
INSERT INTO @Destino VALUES
    (N'minombre',                150),
    (N'micif',                    20),
    (N'midireccion',             200),
    (N'mipoblacion',             100),
    (N'miprovincia',             100),
    (N'micp',                     20),
    (N'mitelefono1',              20),
    (N'mitelefono2',              20),
    (N'mifax',                    20),
    (N'micontacto',              100),
    (N'mimail',                  100),
    (N'milogo',                  260),
    (N'miidentificadorbancario',  15),
    (N'mibic',                    15),
    (N'miiban1', NULL), (N'miiban2', NULL), (N'miiban3', NULL),
    (N'miiban4', NULL), (N'miiban5', NULL), (N'miiban6', NULL);

IF EXISTS (SELECT 1
           FROM @Destino d
           LEFT JOIN INFORMATION_SCHEMA.COLUMNS c
             ON c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = 'Propios' AND c.COLUMN_NAME = d.columna
           WHERE c.COLUMN_NAME IS NULL                                            -- no existe
              OR c.DATA_TYPE NOT IN ('char', 'nchar', 'varchar', 'nvarchar')       -- no es texto
              OR (d.largo IS NOT NULL AND (c.CHARACTER_MAXIMUM_LENGTH = -1
                                           OR c.CHARACTER_MAXIMUM_LENGTH > d.largo)))  -- se reduciría
BEGIN
    PRINT 'ATENCIÓN: la tabla Propios no es como se esperaba. NO SE HA CAMBIADO NADA.';
    SELECT d.columna, c.DATA_TYPE AS tipo_actual, c.CHARACTER_MAXIMUM_LENGTH AS tamano_actual,
           d.largo AS tamano_nuevo
    FROM @Destino d
    LEFT JOIN INFORMATION_SCHEMA.COLUMNS c
      ON c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = 'Propios' AND c.COLUMN_NAME = d.columna;
    SET NOEXEC ON;
END
ELSE
    PRINT 'Comprobación correcta: ningún campo se reduce.';
GO

/* ---------- 2. Ampliar columnas, quitar relleno y añadir miiban ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @filas int = (SELECT COUNT(*) FROM dbo.Propios);

    ALTER TABLE dbo.Propios ALTER COLUMN minombre                nvarchar(150) NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN micif                   nvarchar(20)  NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN midireccion             nvarchar(200) NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN mipoblacion             nvarchar(100) NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN miprovincia             nvarchar(100) NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN micp                    nvarchar(20)  NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN mitelefono1             nvarchar(20)  NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN mitelefono2             nvarchar(20)  NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN mifax                   nvarchar(20)  NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN micontacto              nvarchar(100) NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN mimail                  nvarchar(100) NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN milogo                  nvarchar(260) NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN miidentificadorbancario nvarchar(15)  NULL;
    ALTER TABLE dbo.Propios ALTER COLUMN mibic                   nvarchar(15)  NULL;

    /* Quitar SOLO el relleno de espacios por la derecha que ponía nchar. */
    UPDATE dbo.Propios SET
        minombre                = RTRIM(minombre),
        micif                   = RTRIM(micif),
        midireccion             = RTRIM(midireccion),
        mipoblacion             = RTRIM(mipoblacion),
        miprovincia             = RTRIM(miprovincia),
        micp                    = RTRIM(micp),
        mitelefono1             = RTRIM(mitelefono1),
        mitelefono2             = RTRIM(mitelefono2),
        mifax                   = RTRIM(mifax),
        micontacto              = RTRIM(micontacto),
        mimail                  = RTRIM(mimail),
        milogo                  = RTRIM(milogo),
        miidentificadorbancario = RTRIM(miidentificadorbancario),
        mibic                   = RTRIM(mibic);

    IF COL_LENGTH(N'dbo.Propios', N'miiban') IS NULL
    BEGIN
        ALTER TABLE dbo.Propios ADD miiban nvarchar(34) NULL;
        PRINT 'Columna Propios.miiban creada.';
    END;

    IF (SELECT COUNT(*) FROM dbo.Propios) <> @filas
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
    PRINT 'Columnas de Propios ampliadas (' + CAST(@filas AS varchar(10)) + ' fila/s, sin cambios en los datos).';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al ampliar Propios. SE HA DESHECHO TODO, la tabla está como antes.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 3. Rellenar miiban uniendo los 6 bloques (solo si está vacía) ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @rellenos int;
    EXEC sp_executesql N'
        UPDATE dbo.Propios
        SET miiban = UPPER(REPLACE(
                ISNULL(miiban1, N'''') + ISNULL(miiban2, N'''') + ISNULL(miiban3, N'''') +
                ISNULL(miiban4, N'''') + ISNULL(miiban5, N'''') + ISNULL(miiban6, N''''),
                N'' '', N''''))
        WHERE miiban IS NULL;
        SET @n = @@ROWCOUNT;',
        N'@n int OUTPUT', @n = @rellenos OUTPUT;

    COMMIT TRANSACTION;
    PRINT 'IBAN propio copiado a la columna nueva: ' + CAST(@rellenos AS varchar(10)) + ' fila/s.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al copiar el IBAN propio. Se ha deshecho el relleno (la columna nueva queda vacía).';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 4. Para revisar (solo informa) ---------- */
EXEC sp_executesql N'
SELECT numerador, minombre, micif, miidentificadorbancario, mibic, miiban, LEN(miiban) AS caracteres_iban
FROM dbo.Propios;';
PRINT 'Revisa en la pestaña Resultados que tus datos y el IBAN son correctos.';
PRINT 'Script terminado correctamente.';
GO

SET NOEXEC OFF;
GO
