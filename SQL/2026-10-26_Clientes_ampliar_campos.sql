/* =====================================================================
   Proyecto Antonio Luis - Adaptación de la tabla Clientes (26-10-2026)
   ---------------------------------------------------------------------
   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Comprueba que ningún campo se va a quedar más pequeño de lo que es
       ahora. Si alguno se quedara más pequeño, se para sin tocar nada.
     - Solo AMPLÍA columnas: no borra filas, no borra columnas y no
       recorta ningún dato.
     - Lo único que "limpia" es el relleno de espacios por la derecha que
       añadía el tipo nchar (no es dato, es relleno).
     - Todo va en transacción: si algo falla, se deshace y se para.
     - Se puede ejecutar más de una vez sin problema.

   Qué cambia:
     1. Clientes: amplía nombre, dirección, contacto, email... y los pasa
        de nchar a nvarchar. Teléfonos y fax pasan de número a texto
        (el valor se conserva tal cual: 955123456 -> '955123456').
     2. Facturas: amplía nombre, dirección y nº de empleados, porque al
        facturar se copian ahí los datos del cliente.
     3. Crea la tabla Contadores (nueva) para que el código de un cliente
        borrado no se reutilice (la subcuenta contable usa ese código).
     4. Si hay códigos de cliente repetidos, los lista (no los toca).

   Cómo ejecutarlo: SQL Server Management Studio, conectado a la
   instancia SQLEXPRESS, abrir este fichero y pulsar Ejecutar.
   Leer los mensajes de la pestaña "Mensajes" al terminar.
   ===================================================================== */

USE AdministracionAntonio;
GO

SET ANSI_WARNINGS ON;   -- garantiza que SQL Server da error antes que recortar un dato
SET XACT_ABORT ON;
SET NOCOUNT ON;
GO

/* ---------- 0. Copia de seguridad completa antes de tocar nada ---------- */
DECLARE @fichero nvarchar(400) =
    N'C:\ByMartin\Historico\AntesDeAmpliarClientes_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de ampliar Clientes';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    PRINT 'Comprueba que existe la carpeta C:\ByMartin\Historico.';
    SET NOEXEC ON;   -- no ejecuta nada más del script
END CATCH;
GO

/* ---------- 1. Comprobación: ningún campo puede quedar más pequeño ---------- */
DECLARE @Destino TABLE (tabla sysname, columna sysname, largo int, precision_ int);
INSERT INTO @Destino VALUES
    (N'Clientes', N'nombrecliente',     150,  NULL),
    (N'Clientes', N'cifcliente',         20,  NULL),
    (N'Clientes', N'direcioncliente',   150,  NULL),
    (N'Clientes', N'localidacliente',    80,  NULL),
    (N'Clientes', N'provinciacliente',   50,  NULL),
    (N'Clientes', N'cod_postalcliente',  20,  NULL),
    (N'Clientes', N'telefono1cliente',   20,  NULL),
    (N'Clientes', N'telefono2cliente',   20,  NULL),
    (N'Clientes', N'faxcliente',         20,  NULL),
    (N'Clientes', N'contactocliente',   100,  NULL),
    (N'Clientes', N'mailcliente',       100,  NULL),
    (N'Clientes', N'comentariocliente', 1000, NULL),
    (N'Clientes', N'empleadoscliente',  NULL, 6),
    (N'Facturas', N'factnombre',        150,  NULL),
    (N'Facturas', N'factdireccion',     150,  NULL),
    (N'Facturas', N'factemleados',      NULL, 6);

DECLARE @problemas int = 0;

-- Columnas que no existen en la base de datos
SELECT @problemas = @problemas + COUNT(*)
FROM @Destino d
WHERE NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS c
                  WHERE c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = d.tabla AND c.COLUMN_NAME = d.columna);

-- Columnas de texto que ahora son MÁS grandes que el tamaño nuevo
SELECT @problemas = @problemas + COUNT(*)
FROM @Destino d
JOIN INFORMATION_SCHEMA.COLUMNS c
  ON c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = d.tabla AND c.COLUMN_NAME = d.columna
WHERE d.largo IS NOT NULL
  AND (c.CHARACTER_MAXIMUM_LENGTH = -1 OR c.CHARACTER_MAXIMUM_LENGTH > d.largo
       OR (c.CHARACTER_MAXIMUM_LENGTH IS NULL AND c.NUMERIC_PRECISION > d.largo));

-- Columnas numéricas con más dígitos que los nuevos
SELECT @problemas = @problemas + COUNT(*)
FROM @Destino d
JOIN INFORMATION_SCHEMA.COLUMNS c
  ON c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = d.tabla AND c.COLUMN_NAME = d.columna
WHERE d.precision_ IS NOT NULL
  AND (c.NUMERIC_PRECISION IS NULL OR c.NUMERIC_PRECISION > d.precision_ OR c.NUMERIC_SCALE > 0);

IF @problemas > 0
BEGIN
    PRINT 'ATENCIÓN: la base de datos no es como se esperaba. NO SE HA CAMBIADO NADA.';
    PRINT 'Columnas afectadas (tamaño actual frente al nuevo):';
    SELECT d.tabla, d.columna,
           c.DATA_TYPE AS tipo_actual,
           COALESCE(c.CHARACTER_MAXIMUM_LENGTH, c.NUMERIC_PRECISION) AS tamano_actual,
           COALESCE(d.largo, d.precision_) AS tamano_nuevo
    FROM @Destino d
    LEFT JOIN INFORMATION_SCHEMA.COLUMNS c
      ON c.TABLE_SCHEMA = 'dbo' AND c.TABLE_NAME = d.tabla AND c.COLUMN_NAME = d.columna;
    SET NOEXEC ON;
END
ELSE
    PRINT 'Comprobación correcta: ningún campo se reduce.';
GO

/* ---------- 2. Ampliar columnas (en transacción) ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @filasClientes int = (SELECT COUNT(*) FROM dbo.Clientes);
    DECLARE @filasFacturas int = (SELECT COUNT(*) FROM dbo.Facturas);

    ALTER TABLE dbo.Clientes ALTER COLUMN nombrecliente     nvarchar(150)  NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN cifcliente        nvarchar(20)   NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN direcioncliente   nvarchar(150)  NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN localidacliente   nvarchar(80)   NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN provinciacliente  nvarchar(50)   NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN cod_postalcliente nvarchar(20)   NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN telefono1cliente  nvarchar(20)   NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN telefono2cliente  nvarchar(20)   NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN faxcliente        nvarchar(20)   NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN contactocliente   nvarchar(100)  NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN mailcliente       nvarchar(100)  NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN comentariocliente nvarchar(1000) NULL;
    ALTER TABLE dbo.Clientes ALTER COLUMN empleadoscliente  numeric(6,0)   NULL;

    ALTER TABLE dbo.Facturas ALTER COLUMN factnombre    nvarchar(150) NULL;
    ALTER TABLE dbo.Facturas ALTER COLUMN factdireccion nvarchar(150) NULL;
    ALTER TABLE dbo.Facturas ALTER COLUMN factemleados  decimal(6,0)  NULL;

    /* Quitar SOLO el relleno de espacios por la derecha que ponía nchar.
       No se cambia ningún valor: 'ACME S.L.      ' -> 'ACME S.L.' */
    UPDATE dbo.Clientes SET
        nombrecliente     = RTRIM(nombrecliente),
        cifcliente        = RTRIM(cifcliente),
        direcioncliente   = RTRIM(direcioncliente),
        localidacliente   = RTRIM(localidacliente),
        provinciacliente  = RTRIM(provinciacliente),
        cod_postalcliente = RTRIM(cod_postalcliente),
        contactocliente   = RTRIM(contactocliente),
        mailcliente       = RTRIM(mailcliente),
        comentariocliente = RTRIM(comentariocliente);

    UPDATE dbo.Facturas SET
        factnombre    = RTRIM(factnombre),
        factdireccion = RTRIM(factdireccion);

    -- Control final: el número de filas no puede haber cambiado
    IF (SELECT COUNT(*) FROM dbo.Clientes) <> @filasClientes
       OR (SELECT COUNT(*) FROM dbo.Facturas) <> @filasFacturas
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
    PRINT 'Columnas ampliadas correctamente. Clientes: ' + CAST(@filasClientes AS varchar(10)) +
          ' filas, Facturas: ' + CAST(@filasFacturas AS varchar(10)) + ' filas (sin cambios).';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al ampliar las columnas. SE HA DESHECHO TODO, la base de datos está como antes.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 3. Contador de códigos de cliente (tabla nueva) ---------- */
IF OBJECT_ID(N'dbo.Contadores', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Contadores (
        nombre nvarchar(50)  NOT NULL CONSTRAINT PK_Contadores PRIMARY KEY,
        valor  numeric(18,0) NOT NULL
    );
    PRINT 'Tabla Contadores creada.';
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Contadores WHERE nombre = N'Clientes')
BEGIN
    -- Arranca en el mayor código usado, mirando clientes y facturas
    -- (por si ya se borró algún cliente que tenía facturas).
    INSERT INTO dbo.Contadores (nombre, valor)
    SELECT N'Clientes', ISNULL(MAX(v), 0)
    FROM (SELECT MAX(codcliente)     AS v FROM dbo.Clientes
          UNION ALL
          SELECT MAX(factcodcliente)      FROM dbo.Facturas) AS t;
END;
GO

/* ---------- 4. Aviso de códigos de cliente repetidos (solo informa) ---------- */
IF EXISTS (SELECT codcliente FROM dbo.Clientes
           WHERE codcliente IS NOT NULL
           GROUP BY codcliente HAVING COUNT(*) > 1)
BEGIN
    PRINT 'AVISO: hay códigos de cliente repetidos (no se ha tocado nada). Revísalos cuando puedas:';
    SELECT codcliente, nombrecliente
    FROM dbo.Clientes
    WHERE codcliente IN (SELECT codcliente FROM dbo.Clientes
                         WHERE codcliente IS NOT NULL
                         GROUP BY codcliente HAVING COUNT(*) > 1)
    ORDER BY codcliente;
END;
GO

SELECT 'Último código de cliente usado' AS dato, valor FROM dbo.Contadores WHERE nombre = N'Clientes';
PRINT 'Script terminado correctamente.';
GO

SET NOEXEC OFF;
GO
