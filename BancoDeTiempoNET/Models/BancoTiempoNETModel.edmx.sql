
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2021 18:59:13
-- Generated from EDMX file: C:\Users\Javier\source\repos\BancoDeTiempoNET\Models\BancoTiempoNETModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BancoDeTiempo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmailDemandanteNotificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notificacion] DROP CONSTRAINT [FK_EmailDemandanteNotificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailOfertanteNotificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notificacion] DROP CONSTRAINT [FK_EmailOfertanteNotificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailDemandanteServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servicio] DROP CONSTRAINT [FK_EmailDemandanteServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailOfertanteServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servicio] DROP CONSTRAINT [FK_EmailOfertanteServicio];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Notificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notificacion];
GO
IF OBJECT_ID(N'[dbo].[Servicio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicio];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Notificacion'
CREATE TABLE [dbo].[Notificacion] (
    [id] int IDENTITY(1,1) NOT NULL,
    [emailDemandante] varchar(255)  NOT NULL,
    [emailOfertante] varchar(255)  NOT NULL,
    [asunto] varchar(255)  NULL,
    [cuerpo] varchar(255)  NULL,
    [fecha] datetime  NULL
);
GO

-- Creating table 'Servicio'
CREATE TABLE [dbo].[Servicio] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(255)  NOT NULL,
    [horas] float  NULL,
    [fechaRealizacion] datetime  NULL,
    [fechaPublicacion] datetime  NULL,
    [servicioRealizado] tinyint  NULL,
    [emailDemandante] varchar(255) NULL,
    [emailOfertante] varchar(255)  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [email] varchar(255)  NOT NULL,
    [nombre] varchar(255)  NULL,
    [primerApellido] varchar(255)  NULL,
    [segundoApellido] varchar(255)  NULL,
    [telefono] varchar(32)  NULL,
    [balanceHoras] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Notificacion'
ALTER TABLE [dbo].[Notificacion]
ADD CONSTRAINT [PK_Notificacion]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Servicio'
ALTER TABLE [dbo].[Servicio]
ADD CONSTRAINT [PK_Servicio]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [email] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([email] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [emailDemandante] in table 'Notificacion'
ALTER TABLE [dbo].[Notificacion]
ADD CONSTRAINT [FK_EmailDemandanteNotificacion]
    FOREIGN KEY ([emailDemandante])
    REFERENCES [dbo].[Usuario]
        ([email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailDemandanteNotificacion'
CREATE INDEX [IX_FK_EmailDemandanteNotificacion]
ON [dbo].[Notificacion]
    ([emailDemandante]);
GO

-- Creating foreign key on [emailOfertante] in table 'Notificacion'
ALTER TABLE [dbo].[Notificacion]
ADD CONSTRAINT [FK_EmailOfertanteNotificacion]
    FOREIGN KEY ([emailOfertante])
    REFERENCES [dbo].[Usuario]
        ([email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailOfertanteNotificacion'
CREATE INDEX [IX_FK_EmailOfertanteNotificacion]
ON [dbo].[Notificacion]
    ([emailOfertante]);
GO

-- Creating foreign key on [emailDemandante] in table 'Servicio'
ALTER TABLE [dbo].[Servicio]
ADD CONSTRAINT [FK_EmailDemandanteServicio]
    FOREIGN KEY ([emailDemandante])
    REFERENCES [dbo].[Usuario]
        ([email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailDemandanteServicio'
CREATE INDEX [IX_FK_EmailDemandanteServicio]
ON [dbo].[Servicio]
    ([emailDemandante]);
GO

-- Creating foreign key on [emailOfertante] in table 'Servicio'
ALTER TABLE [dbo].[Servicio]
ADD CONSTRAINT [FK_EmailOfertanteServicio]
    FOREIGN KEY ([emailOfertante])
    REFERENCES [dbo].[Usuario]
        ([email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailOfertanteServicio'
CREATE INDEX [IX_FK_EmailOfertanteServicio]
ON [dbo].[Servicio]
    ([emailOfertante]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------