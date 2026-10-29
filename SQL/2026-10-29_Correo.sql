/* =====================================================================
   Proyecto Antonio Luis - Envío de facturas por correo (29-10-2026)
   ---------------------------------------------------------------------
   PENSADO PARA BASES DE DATOS CON DATOS REALES:
     - Primero hace una copia de seguridad completa. Si no puede, se para.
     - Solo AÑADE columnas nuevas (vacías). No modifica ni borra nada.
     - Se puede ejecutar más de una vez sin problema.

   Qué cambia:
     1. Propios (Mis Datos): configuración del correo de salida
        (servidor, puerto, cifrado, usuario, contraseña cifrada, remitente,
        copia oculta, asunto y texto del mensaje).
     2. Facturas: factenviada (sí/no) y factfechaenvio (cuándo se envió).
   ===================================================================== */

USE AdministracionAntonio;
GO

SET XACT_ABORT ON;
SET NOCOUNT ON;
GO

/* ---------- 0. Copia de seguridad ---------- */
DECLARE @fichero nvarchar(400) =
    N'C:\ByMartin\Historico\AntesDeCorreo_' +
    CONVERT(nvarchar(8), GETDATE(), 112) + N'_' +
    REPLACE(CONVERT(nvarchar(8), GETDATE(), 108), ':', '') + N'.bak';

BEGIN TRY
    BACKUP DATABASE AdministracionAntonio
        TO DISK = @fichero
        WITH COPY_ONLY, INIT, NAME = N'Antes del envío por correo';
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

    DECLARE @propios  int = (SELECT COUNT(*) FROM dbo.Propios);
    DECLARE @facturas int = (SELECT COUNT(*) FROM dbo.Facturas);

    IF COL_LENGTH(N'dbo.Propios', N'mismtpservidor') IS NULL
        ALTER TABLE dbo.Propios ADD mismtpservidor nvarchar(150) NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mismtppuerto') IS NULL
        ALTER TABLE dbo.Propios ADD mismtppuerto int NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mismtpcifrado') IS NULL
        ALTER TABLE dbo.Propios ADD mismtpcifrado bit NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mismtpusuario') IS NULL
        ALTER TABLE dbo.Propios ADD mismtpusuario nvarchar(150) NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mismtpclave') IS NULL
        ALTER TABLE dbo.Propios ADD mismtpclave nvarchar(1000) NULL;      -- cifrada
    IF COL_LENGTH(N'dbo.Propios', N'mimailremitente') IS NULL
        ALTER TABLE dbo.Propios ADD mimailremitente nvarchar(150) NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mimailnombre') IS NULL
        ALTER TABLE dbo.Propios ADD mimailnombre nvarchar(150) NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mimailcopia') IS NULL
        ALTER TABLE dbo.Propios ADD mimailcopia nvarchar(150) NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mimailasunto') IS NULL
        ALTER TABLE dbo.Propios ADD mimailasunto nvarchar(250) NULL;
    IF COL_LENGTH(N'dbo.Propios', N'mimailtexto') IS NULL
        ALTER TABLE dbo.Propios ADD mimailtexto nvarchar(max) NULL;

    IF COL_LENGTH(N'dbo.Facturas', N'factenviada') IS NULL
        ALTER TABLE dbo.Facturas ADD factenviada bit NULL;
    IF COL_LENGTH(N'dbo.Facturas', N'factfechaenvio') IS NULL
        ALTER TABLE dbo.Facturas ADD factfechaenvio datetime NULL;

    IF (SELECT COUNT(*) FROM dbo.Propios) <> @propios
       OR (SELECT COUNT(*) FROM dbo.Facturas) <> @facturas
    BEGIN
        ;THROW 50001, 'El número de filas ha cambiado. Se deshace todo.', 1;
    END;

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

SELECT
    (SELECT COUNT(*) FROM dbo.Propios)  AS filas_propios,
    (SELECT COUNT(*) FROM dbo.Facturas) AS facturas,
    (SELECT COUNT(*) FROM dbo.Facturas WHERE factpormail = 1) AS facturas_por_mail;
PRINT 'Script terminado correctamente.';
GO

SET NOEXEC OFF;
GO
