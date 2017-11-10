
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/09/2017 13:12:59
-- Generated from EDMX file: C:\Equipo Martin\Programacion\Repositorio Remoto\Proyecto Antonio Luis\Proyecto Antonio Luis\BaseDatos\ModelAdministracionAntonio.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdministracionAntonio];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Cuentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuentas];
GO
IF OBJECT_ID(N'[dbo].[Iva]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Iva];
GO
IF OBJECT_ID(N'[dbo].[Propios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Propios];
GO
IF OBJECT_ID(N'[dbo].[Ususarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ususarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Ususarios'
CREATE TABLE [dbo].[Ususarios] (
    [cod] decimal(18,0)  NOT NULL,
    [nombre] nchar(15)  NULL,
    [login] nchar(10)  NULL,
    [activo] nchar(10)  NULL,
    [grupo] nchar(20)  NULL,
    [pregunta] nchar(50)  NULL,
    [respuesta] nchar(50)  NULL,
    [sistema] nchar(10)  NULL,
    [clientes] nchar(10)  NULL,
    [facturas] nchar(10)  NULL,
    [csb19] nchar(10)  NULL,
    [contaplus] nchar(10)  NULL,
    [listados] nchar(10)  NULL,
    [mantenimiento] nchar(10)  NULL,
    [ayuda] nchar(10)  NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [numerador] nchar(10)  NOT NULL,
    [codcliente] nchar(6)  NULL,
    [nombrecliente] nchar(50)  NULL,
    [direcioncliente] nchar(50)  NULL,
    [localidacliente] nchar(50)  NULL,
    [cod_postalcliente] nchar(9)  NULL,
    [provinciacliente] nchar(30)  NULL,
    [cifcliente] nchar(10)  NULL,
    [grupocliente] nchar(10)  NULL,
    [telefonocliente] nchar(15)  NULL,
    [faxcliente] nchar(15)  NULL,
    [movilcliente] nchar(15)  NULL,
    [contactocliente] nchar(50)  NULL,
    [mailcliente] nchar(30)  NULL,
    [comentariocliente] nchar(100)  NULL,
    [activocliente] nchar(5)  NULL,
    [tarifacliente] decimal(18,2)  NOT NULL,
    [recargo] nchar(5)  NULL,
    [iban1cliente] decimal(4,0)  NULL,
    [iban2cliente] decimal(4,0)  NULL,
    [iban3cliente] decimal(4,0)  NULL,
    [iban4cliente] decimal(4,0)  NOT NULL,
    [iban5cliente] decimal(4,0)  NULL,
    [iban6cliente] decimal(4,0)  NULL,
    [domiciliadocliente] nchar(5)  NULL,
    [avioncliente] nchar(5)  NULL,
    [mod100] nchar(5)  NULL,
    [mod111] nchar(10)  NULL,
    [mod115] nchar(10)  NULL,
    [mod123] nchar(10)  NULL,
    [mod130] nchar(10)  NULL,
    [mod131] nchar(10)  NULL,
    [mod180] nchar(10)  NULL,
    [mod190] nchar(10)  NULL,
    [mod193] nchar(10)  NULL,
    [mod200] nchar(10)  NULL,
    [mod202] nchar(10)  NULL,
    [mod303] nchar(10)  NULL,
    [mod309] nchar(10)  NULL,
    [mod349] nchar(10)  NULL,
    [mod390] nchar(10)  NULL,
    [mod751] nchar(10)  NULL,
    [mod752] nchar(10)  NULL,
    [instrastatcliente] nchar(10)  NULL,
    [altacliente] nchar(10)  NULL,
    [bajacliente] nchar(10)  NULL,
    [fechaaltacliente] datetime  NULL,
    [empleadoscliente] decimal(3,0)  NULL
);
GO

-- Creating table 'Cuentas'
CREATE TABLE [dbo].[Cuentas] (
    [numerador] nchar(10)  NOT NULL,
    [digitos] nchar(3)  NULL,
    [ctacliente] nchar(20)  NULL,
    [ctabanco] nchar(20)  NULL,
    [ctasuplidos] nchar(20)  NULL,
    [ctaretenciones] nchar(20)  NULL,
    [ctaprestaciones] nchar(20)  NULL,
    [ctaiva0] nchar(20)  NULL,
    [ctaivasuperreducido] nchar(20)  NULL,
    [ctaivareducido] nchar(20)  NULL,
    [ctaivageneral] nchar(20)  NULL,
    [rutasubcuenta] nchar(100)  NULL,
    [rutadiario] nchar(100)  NULL,
    [rutaasi] nchar(100)  NULL,
    [rutacsb19] nchar(100)  NULL
);
GO

-- Creating table 'Propios'
CREATE TABLE [dbo].[Propios] (
    [numerador] nchar(10)  NOT NULL,
    [minombre] nchar(100)  NULL,
    [micif] nchar(15)  NULL,
    [midireccion] nchar(200)  NULL,
    [mipoblacion] nchar(100)  NULL,
    [miprovincia] nchar(100)  NULL,
    [micp] nchar(10)  NULL,
    [mitelefono1] nchar(20)  NULL,
    [mitelefono2] nchar(20)  NULL,
    [mifax] nchar(20)  NULL,
    [micontacto] nchar(50)  NULL,
    [mimail] nchar(50)  NULL,
    [miiban1] nchar(4)  NULL,
    [miiban2] nchar(4)  NULL,
    [miiban3] nchar(4)  NULL,
    [miiban4] nchar(4)  NULL,
    [miiban5] nchar(4)  NULL,
    [miiban6] nchar(4)  NULL,
    [milogo] nchar(200)  NULL
);
GO

-- Creating table 'Iva'
CREATE TABLE [dbo].[Iva] (
    [numerador] decimal(18,0)  NOT NULL,
    [ivaconcepto] nchar(20)  NULL,
    [ivaporciento] decimal(4,2)  NULL,
    [ivarecargo] decimal(4,2)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [cod] in table 'Ususarios'
ALTER TABLE [dbo].[Ususarios]
ADD CONSTRAINT [PK_Ususarios]
    PRIMARY KEY CLUSTERED ([cod] ASC);
GO

-- Creating primary key on [numerador] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([numerador] ASC);
GO

-- Creating primary key on [numerador] in table 'Cuentas'
ALTER TABLE [dbo].[Cuentas]
ADD CONSTRAINT [PK_Cuentas]
    PRIMARY KEY CLUSTERED ([numerador] ASC);
GO

-- Creating primary key on [numerador] in table 'Propios'
ALTER TABLE [dbo].[Propios]
ADD CONSTRAINT [PK_Propios]
    PRIMARY KEY CLUSTERED ([numerador] ASC);
GO

-- Creating primary key on [numerador] in table 'Iva'
ALTER TABLE [dbo].[Iva]
ADD CONSTRAINT [PK_Iva]
    PRIMARY KEY CLUSTERED ([numerador] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------