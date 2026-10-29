/* =====================================================================
   Proyecto Antonio Luis - Acuses de recibo del correo (29-10-2026)
   ---------------------------------------------------------------------
   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Solo AÑADE dos columnas nuevas (vacías). No modifica ni borra nada.
     - Se puede ejecutar más de una vez sin problema.

   Qué cambia (tabla Propios, Mis Datos):
     - mimailacuselectura: pedir confirmación de lectura al enviar facturas.
     - mimailacuseentrega: pedir aviso de entrega al enviar facturas.

   Ejecutar DESPUÉS de 2026-10-29_Correo.sql.
   ===================================================================== */

USE AdministracionAntonio;
GO

SET XACT_ABORT ON;
SET NOCOUNT ON;
GO

/* ---------- 0. Copia de seguridad ---------- */
DECLARE @fichero nvarchar(400) =
    N'C:\ByMartin\Historico\AntesDeAcusesCorreo_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes de los acuses de correo';
    PRINT 'Copia de seguridad hecha en: ' + @fichero;
END TRY
BEGIN CATCH
    PRINT 'ERROR: no se ha podido hacer la copia de seguridad. NO SE HA CAMBIADO NADA.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

/* ---------- 1. Columnas nuevas ---------- */
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @propios int = (SELECT COUNT(*) FROM dbo.Propios);

    IF COL_LENGTH(N'dbo.Propios', N'mimailacuselectura') IS NULL
        ALTER TABLE dbo.Propios ADD mimailacuselectura bit NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mimailacuseentrega') IS NULL
        ALTER TABLE dbo.Propios ADD mimailacuseentrega bit NULL;

    IF (SELECT COUNT(*) FROM dbo.Propios) <> @propios
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

    COMMIT TRANSACTION;
    PRINT 'Columnas nuevas preparadas.';
    PRINT 'Script terminado correctamente.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERROR al añadir las columnas. SE HA DESHECHO TODO.';
    PRINT ERROR_MESSAGE();
    SET NOEXEC ON;
END CATCH;
GO

SET NOEXEC OFF;
GO
