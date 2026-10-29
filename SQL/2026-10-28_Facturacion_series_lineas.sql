/* =====================================================================
   Proyecto Antonio Luis - Facturación: series, ejercicio y líneas (28-10-2026)
   ---------------------------------------------------------------------
   Prepara las tablas para:
     - Series distintas: M = facturación mensual, D = factura directa
       (manual), R = rectificativas. Numeración independiente por serie y año.
     - No borrar facturas al cambiar de año (cada factura lleva su ejercicio).
     - Facturas con todas las líneas que hagan falta (tabla FacturaLineas).
     - Remesas identificadas por año (ya no solo por el nombre del mes).

   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Solo CREA tablas nuevas y AÑADE columnas nuevas. No borra ni modifica
       ninguna columna existente: el programa actual sigue funcionando.
     - Las columnas nuevas se RELLENAN a partir de los datos que ya hay,
       solo donde estén vacías (no sobrescribe nada).
     - Las líneas de las facturas existentes se copian desde sus importes
       (honorarios, nóminas y suplidos), solo si esa factura aún no tiene líneas.
     - Todo va en transacción: si algo falla, se deshace y se para.
     - Se puede ejecutar más de una vez sin problema.

   Al final lista, solo para revisarlas, las facturas con datos que no se
   han podido interpretar (fecha no válida, sin total...).

   Cómo ejecutarlo: SQL Server Management Studio, conectado a la
   instancia SQLEXPRESS, abrir este fichero y pulsar Ejecutar.
   ===================================================================== */

USE AdministracionAntonio;
GO

SET XACT_ABORT ON;
SET NOCOUNT ON;
SET DATEFORMAT dmy;
GO

/* ---------- 0. Copia de seguridad completa antes de tocar nada ---------- */
DECLARE @fichero nvarchar(400) =
    N'C:\ByMartin\Historico\AntesDeSeriesLineas_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de series y líneas de factura';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    PRINT 'Comprueba que existe la carpeta C:\ByMartin\Historico.';
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 1. Tablas y columnas nuevas (vacías) ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @filasFacturas int = (SELECT COUNT(*) FROM dbo.Facturas);
    DECLARE @filasRemesas  int = (SELECT COUNT(*) FROM dbo.Resilla);

    -- Series de facturación
    IF OBJECT_ID(N'dbo.Series', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.Series (
            serie       nvarchar(10) NOT NULL CONSTRAINT PK_Series PRIMARY KEY,
            descripcion nvarchar(50) NOT NULL,
            uso         nvarchar(20) NOT NULL      -- Mensual / Directa / Rectificativa
        );
        PRINT 'Tabla Series creada.';
    END;

    -- Líneas de factura
    IF OBJECT_ID(N'dbo.FacturaLineas', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.FacturaLineas (
            lineaid       int IDENTITY(1,1) NOT NULL CONSTRAINT PK_FacturaLineas PRIMARY KEY,
            factcontador  decimal(18,0) NOT NULL
                          CONSTRAINT FK_FacturaLineas_Facturas REFERENCES dbo.Facturas(factcontador),
            orden         int           NOT NULL,
            concepto      nvarchar(250) NOT NULL,
            cantidad      decimal(18,3) NOT NULL CONSTRAINT DF_FacturaLineas_cantidad DEFAULT (1),
            precio        decimal(18,2) NOT NULL,
            importe       decimal(18,2) NOT NULL,
            sujetoiva     bit           NOT NULL CONSTRAINT DF_FacturaLineas_sujetoiva DEFAULT (1)  -- 0 = suplido
        );
        CREATE INDEX IX_FacturaLineas_factura ON dbo.FacturaLineas (factcontador, orden);
        PRINT 'Tabla FacturaLineas creada.';
    END;

    -- Facturas: columnas nuevas
    IF COL_LENGTH(N'dbo.Facturas', N'factserie') IS NULL
        ALTER TABLE dbo.Facturas ADD factserie nvarchar(10) NULL;
    IF COL_LENGTH(N'dbo.Facturas', N'factejercicio') IS NULL
        ALTER TABLE dbo.Facturas ADD factejercicio int NULL;
    IF COL_LENGTH(N'dbo.Facturas', N'factfechadoc') IS NULL
        ALTER TABLE dbo.Facturas ADD factfechadoc date NULL;              -- fecha de la factura (fecha real)
    IF COL_LENGTH(N'dbo.Facturas', N'factorigen') IS NULL
        ALTER TABLE dbo.Facturas ADD factorigen nvarchar(1) NULL;         -- M = mensual, D = directa
    IF COL_LENGTH(N'dbo.Facturas', N'factbaseimponible') IS NULL
        ALTER TABLE dbo.Facturas ADD factbaseimponible decimal(18,2) NULL;
    IF COL_LENGTH(N'dbo.Facturas', N'factremesaid') IS NULL
        ALTER TABLE dbo.Facturas ADD factremesaid numeric(18,0) NULL;     -- remesa (Resilla.remesanumerador)
    IF COL_LENGTH(N'dbo.Facturas', N'factestado') IS NULL
        ALTER TABLE dbo.Facturas ADD factestado nvarchar(15) NULL;        -- Emitida / Anulada / Rectificada
    IF COL_LENGTH(N'dbo.Facturas', N'factrectificaid') IS NULL
        ALTER TABLE dbo.Facturas ADD factrectificaid decimal(18,0) NULL;  -- factura que rectifica
    IF COL_LENGTH(N'dbo.Facturas', N'factfechacontab') IS NULL
        ALTER TABLE dbo.Facturas ADD factfechacontab datetime NULL;       -- cuándo se pasó a contabilidad
    IF COL_LENGTH(N'dbo.Facturas', N'factfechadomic') IS NULL
        ALTER TABLE dbo.Facturas ADD factfechadomic datetime NULL;        -- cuándo se envió al banco

    -- Remesas: columnas nuevas
    IF COL_LENGTH(N'dbo.Resilla', N'remesaejercicio') IS NULL
        ALTER TABLE dbo.Resilla ADD remesaejercicio int NULL;
    IF COL_LENGTH(N'dbo.Resilla', N'remesafechacargo') IS NULL
        ALTER TABLE dbo.Resilla ADD remesafechacargo date NULL;
    IF COL_LENGTH(N'dbo.Resilla', N'remesafechaenvio') IS NULL
        ALTER TABLE dbo.Resilla ADD remesafechaenvio datetime NULL;
    IF COL_LENGTH(N'dbo.Resilla', N'remesafichero') IS NULL
        ALTER TABLE dbo.Resilla ADD remesafichero nvarchar(260) NULL;

    IF (SELECT COUNT(*) FROM dbo.Facturas) <> @filasFacturas
       OR (SELECT COUNT(*) FROM dbo.Resilla) <> @filasRemesas
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
    PRINT 'Tablas y columnas nuevas preparadas.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al crear tablas o columnas. SE HA DESHECHO TODO.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 2. Rellenar lo nuevo a partir de los datos existentes ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @filasFacturas int = (SELECT COUNT(*) FROM dbo.Facturas);

    -- Series
    IF NOT EXISTS (SELECT 1 FROM dbo.Series)
        INSERT INTO dbo.Series (serie, descripcion, uso) VALUES
            (N'M', N'Facturación mensual', N'Mensual'),
            (N'D', N'Facturas directas',   N'Directa'),
            (N'R', N'Rectificativas',      N'Rectificativa');

    -- Todo con SQL dinámico porque las columnas acaban de crearse
    EXEC sp_executesql N'
        SET DATEFORMAT dmy;

        -- Fecha real desde el texto dd/mm/aaaa
        UPDATE dbo.Facturas
        SET factfechadoc = CONVERT(date, LEFT(LTRIM(factfecha), 10), 103)
        WHERE factfechadoc IS NULL
          AND LTRIM(factfecha) LIKE ''[0-3][0-9]/[0-1][0-9]/[12][0-9][0-9][0-9]%''
          AND ISDATE(LEFT(LTRIM(factfecha), 10)) = 1;

        -- Ejercicio: año de la fecha
        UPDATE dbo.Facturas
        SET factejercicio = YEAR(factfechadoc)
        WHERE factejercicio IS NULL AND factfechadoc IS NOT NULL;

        -- Serie y origen
        UPDATE dbo.Facturas
        SET factorigen = CASE WHEN LTRIM(factremesa) LIKE N''Factura Directa%'' THEN N''D'' ELSE N''M'' END
        WHERE factorigen IS NULL;

        UPDATE dbo.Facturas
        SET factserie = factorigen
        WHERE factserie IS NULL;

        -- Base imponible = honorarios + nóminas (los suplidos van aparte, sin IVA)
        UPDATE dbo.Facturas
        SET factbaseimponible = ISNULL(factbase1, 0) + ISNULL(factbaseempleado, 0)
        WHERE factbaseimponible IS NULL;

        -- Estado
        UPDATE dbo.Facturas SET factestado = N''Emitida'' WHERE factestado IS NULL;

        -- Remesas: ejercicio y fecha de cargo desde el texto
        UPDATE dbo.Resilla
        SET remesafechacargo = CONVERT(date, LEFT(LTRIM(remesafecha), 10), 103)
        WHERE remesafechacargo IS NULL
          AND LTRIM(remesafecha) LIKE ''[0-3][0-9]/[0-1][0-9]/[12][0-9][0-9][0-9]%''
          AND ISDATE(LEFT(LTRIM(remesafecha), 10)) = 1;

        UPDATE dbo.Resilla
        SET remesaejercicio = YEAR(remesafechacargo)
        WHERE remesaejercicio IS NULL AND remesafechacargo IS NOT NULL;

        -- Enlace factura -> remesa (solo si el nombre de la remesa es único)
        UPDATE f
        SET f.factremesaid = r.remesanumerador
        FROM dbo.Facturas f
        JOIN dbo.Resilla r ON RTRIM(r.remesanumero) = RTRIM(f.factremesa)
        WHERE f.factremesaid IS NULL
          AND (SELECT COUNT(*) FROM dbo.Resilla r2 WHERE RTRIM(r2.remesanumero) = RTRIM(f.factremesa)) = 1;

        -- Líneas de las facturas existentes (solo las que aún no tienen ninguna)
        SELECT f.factcontador INTO #sinlineas
        FROM dbo.Facturas f
        WHERE NOT EXISTS (SELECT 1 FROM dbo.FacturaLineas l WHERE l.factcontador = f.factcontador);

        INSERT INTO dbo.FacturaLineas (factcontador, orden, concepto, cantidad, precio, importe, sujetoiva)
        SELECT f.factcontador, 1,
               ISNULL(NULLIF(RTRIM(f.factconcepto1), N''''), N''Honorarios''),
               1, f.factbase1, f.factbase1, 1
        FROM dbo.Facturas f
        WHERE ISNULL(f.factbase1, 0) <> 0
          AND f.factcontador IN (SELECT factcontador FROM #sinlineas);

        INSERT INTO dbo.FacturaLineas (factcontador, orden, concepto, cantidad, precio, importe, sujetoiva)
        SELECT f.factcontador, 2, N''Nóminas'',
               ISNULL(f.factemleados, 0), ISNULL(f.factprecioempleado, 0), f.factbaseempleado, 1
        FROM dbo.Facturas f
        WHERE ISNULL(f.factbaseempleado, 0) <> 0
          AND f.factcontador IN (SELECT factcontador FROM #sinlineas);

        INSERT INTO dbo.FacturaLineas (factcontador, orden, concepto, cantidad, precio, importe, sujetoiva)
        SELECT f.factcontador, 3,
               ISNULL(NULLIF(RTRIM(f.factconcepto2), N''''), N''Suplidos''),
               1, f.factbase2, f.factbase2, 0
        FROM dbo.Facturas f
        WHERE ISNULL(f.factbase2, 0) <> 0
          AND f.factcontador IN (SELECT factcontador FROM #sinlineas);

        DROP TABLE #sinlineas;
    ';

    IF (SELECT COUNT(*) FROM dbo.Facturas) <> @filasFacturas
    BEGIN
        ;THROW 50001, 'El número de facturas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
    PRINT 'Datos existentes completados (series, ejercicio, fechas, base imponible, remesas y líneas).';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al completar los datos. Se ha deshecho el relleno (las columnas nuevas quedan vacías).';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 3. Numeración única por serie y año (solo si no hay repetidos) ---------- */
EXEC sp_executesql N'
IF EXISTS (SELECT factserie, factejercicio, factnumerofact
           FROM dbo.Facturas
           WHERE factserie IS NOT NULL AND factejercicio IS NOT NULL AND factnumerofact IS NOT NULL
           GROUP BY factserie, factejercicio, factnumerofact HAVING COUNT(*) > 1)
BEGIN
    PRINT ''AVISO: hay números de factura repetidos en la misma serie y año (no se ha tocado nada).'';
    PRINT ''No se crea el control de números únicos hasta que se revisen:'';
    SELECT factserie, factejercicio, factnumerofact, factcontador, factnombre, factfecha
    FROM dbo.Facturas f
    WHERE EXISTS (SELECT 1 FROM dbo.Facturas g
                  WHERE g.factserie = f.factserie AND g.factejercicio = f.factejercicio
                    AND g.factnumerofact = f.factnumerofact AND g.factcontador <> f.factcontador)
    ORDER BY factserie, factejercicio, factnumerofact;
END
ELSE IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N''UX_Facturas_serie_numero''
                    AND object_id = OBJECT_ID(N''dbo.Facturas''))
BEGIN
    CREATE UNIQUE INDEX UX_Facturas_serie_numero
        ON dbo.Facturas (factserie, factejercicio, factnumerofact)
        WHERE factserie IS NOT NULL AND factejercicio IS NOT NULL AND factnumerofact IS NOT NULL;
    PRINT ''Control de números de factura únicos por serie y año creado.'';
END;';
GO

/* ---------- 4. Para revisar (solo informa, no cambia nada) ---------- */
EXEC sp_executesql N'
IF EXISTS (SELECT 1 FROM dbo.Facturas WHERE factfechadoc IS NULL)
BEGIN
    PRINT ''AVISO: facturas con una fecha que no se ha podido interpretar (quedan sin ejercicio):'';
    SELECT factcontador, factserie, factnumerofact, factnombre, factfecha
    FROM dbo.Facturas WHERE factfechadoc IS NULL ORDER BY factcontador;
END;

IF EXISTS (SELECT 1 FROM dbo.Facturas WHERE facttotalfactura IS NULL OR factimporteiva IS NULL)
BEGIN
    PRINT ''AVISO: facturas sin total o sin IVA (normalmente facturas directas antiguas):'';
    SELECT factcontador, factserie, factnumerofact, factnombre, factfecha, factbaseimponible,
           factimporteiva, facttotalfactura
    FROM dbo.Facturas WHERE facttotalfactura IS NULL OR factimporteiva IS NULL ORDER BY factcontador;
END;

SELECT factserie AS serie, factejercicio AS ejercicio, COUNT(*) AS facturas,
       MIN(factnumerofact) AS desde, MAX(factnumerofact) AS hasta
FROM dbo.Facturas GROUP BY factserie, factejercicio ORDER BY factejercicio, factserie;

SELECT COUNT(*) AS lineas_de_factura FROM dbo.FacturaLineas;';
PRINT 'Script terminado correctamente.';
GO

SET NOEXEC OFF;
GO
