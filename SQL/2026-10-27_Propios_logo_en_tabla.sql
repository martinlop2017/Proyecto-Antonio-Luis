/* =====================================================================
   Proyecto Antonio Luis - Logo guardado en la tabla Propios (27-10-2026)
   ---------------------------------------------------------------------
   Hasta ahora solo se guardaba la RUTA del logo (columna milogo). Si el
   fichero se movía o se instalaba el programa en otro equipo, el logo se
   perdía. Ahora la imagen se guarda dentro de la base de datos.

   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Solo AÑADE una columna nueva vacía (milogoimagen). No modifica ni
       borra ningún dato. La columna milogo (la ruta) se conserva.
     - Se puede ejecutar más de una vez sin problema.

   La imagen se carga desde el programa: Sistema > Mis Datos, botón del
   logo, y Grabar. Si la ruta antigua sigue existiendo, el programa la
   carga solo al abrir Mis Datos y la guarda en la tabla al pulsar Grabar.

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
    N'C:\ByMartin\Historico\AntesDeLogoEnTabla_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de guardar el logo en la tabla';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    PRINT 'Comprueba que existe la carpeta C:\ByMartin\Historico.';
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 1. Añadir la columna para la imagen (vacía) ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @filas int = (SELECT COUNT(*) FROM dbo.Propios);

    IF COL_LENGTH(N'dbo.Propios', N'milogoimagen') IS NULL
    BEGIN
        ALTER TABLE dbo.Propios ADD milogoimagen varbinary(max) NULL;
        PRINT 'Columna Propios.milogoimagen creada.';
    END
    ELSE
        PRINT 'La columna Propios.milogoimagen ya existía (no se toca).';

    IF (SELECT COUNT(*) FROM dbo.Propios) <> @filas
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al añadir la columna. SE HA DESHECHO TODO.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

PRINT 'Script terminado correctamente. Ahora abre Mis Datos, comprueba el logo y pulsa Grabar.';
GO

SET NOEXEC OFF;
GO
