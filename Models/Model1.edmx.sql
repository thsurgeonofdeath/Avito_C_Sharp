
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/05/2022 13:14:28
-- Generated from EDMX file: C:\Users\PC\Desktop\info 1\Semester 3\C# and ASPNET\onl\ASP_Projet\ASP_Projet\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PROJECTDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Annonces'
CREATE TABLE [dbo].[Annonces] (
    [Id_annonce] int IDENTITY(1,1) NOT NULL,
    [id_proprietaire] int  NULL,
    [id_categorie] int  NULL,
    [titre] nvarchar(100)  NULL,
    [image] nvarchar(100)  NULL,
    [prix] float  NULL,
    [courteDescription] nvarchar(200)  NULL,
    [description] nvarchar(500)  NULL,
    [date] datetime  NULL,
    [isSpecial] bit  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id_categorie] int IDENTITY(1,1) NOT NULL,
    [nom] nvarchar(100)  NULL
);
GO

-- Creating table 'Proprietaires'
CREATE TABLE [dbo].[Proprietaires] (
    [Id_proprietaire] int IDENTITY(1,1) NOT NULL,
    [nom] nvarchar(100)  NULL,
    [telephone] nvarchar(100)  NULL,
    [ville] nvarchar(100)  NULL,
    [email] nvarchar(100)  NULL,
    [password] nvarchar(100)  NULL,
    [isSpecial] bit  NULL
);
GO

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [email] nvarchar(100)  NULL,
    [password] nvarchar(100)  NULL
);
GO

-- Creating table 'Liste_Favorie'
CREATE TABLE [dbo].[Liste_Favorie] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [id_proprietaire] int  NULL
);
GO

-- Creating table 'Liste_noire'
CREATE TABLE [dbo].[Liste_noire] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [id_proprietaire] int  NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [id_proprietaire] int  NULL,
    [msg] nvarchar(200)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_annonce] in table 'Annonces'
ALTER TABLE [dbo].[Annonces]
ADD CONSTRAINT [PK_Annonces]
    PRIMARY KEY CLUSTERED ([Id_annonce] ASC);
GO

-- Creating primary key on [Id_categorie] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id_categorie] ASC);
GO

-- Creating primary key on [Id_proprietaire] in table 'Proprietaires'
ALTER TABLE [dbo].[Proprietaires]
ADD CONSTRAINT [PK_Proprietaires]
    PRIMARY KEY CLUSTERED ([Id_proprietaire] ASC);
GO

-- Creating primary key on [Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Liste_Favorie'
ALTER TABLE [dbo].[Liste_Favorie]
ADD CONSTRAINT [PK_Liste_Favorie]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Liste_noire'
ALTER TABLE [dbo].[Liste_noire]
ADD CONSTRAINT [PK_Liste_noire]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_categorie] in table 'Annonces'
ALTER TABLE [dbo].[Annonces]
ADD CONSTRAINT [FK__Annonce__id_cate__4E88ABD4]
    FOREIGN KEY ([id_categorie])
    REFERENCES [dbo].[Categories]
        ([Id_categorie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Annonce__id_cate__4E88ABD4'
CREATE INDEX [IX_FK__Annonce__id_cate__4E88ABD4]
ON [dbo].[Annonces]
    ([id_categorie]);
GO

-- Creating foreign key on [id_proprietaire] in table 'Annonces'
ALTER TABLE [dbo].[Annonces]
ADD CONSTRAINT [FK__Annonce__id_prop__4D94879B]
    FOREIGN KEY ([id_proprietaire])
    REFERENCES [dbo].[Proprietaires]
        ([Id_proprietaire])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Annonce__id_prop__4D94879B'
CREATE INDEX [IX_FK__Annonce__id_prop__4D94879B]
ON [dbo].[Annonces]
    ([id_proprietaire]);
GO

-- Creating foreign key on [id_proprietaire] in table 'Liste_Favorie'
ALTER TABLE [dbo].[Liste_Favorie]
ADD CONSTRAINT [FK__Liste_Fav__id_pr__71D1E811]
    FOREIGN KEY ([id_proprietaire])
    REFERENCES [dbo].[Proprietaires]
        ([Id_proprietaire])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Liste_Fav__id_pr__71D1E811'
CREATE INDEX [IX_FK__Liste_Fav__id_pr__71D1E811]
ON [dbo].[Liste_Favorie]
    ([id_proprietaire]);
GO

-- Creating foreign key on [id_proprietaire] in table 'Liste_noire'
ALTER TABLE [dbo].[Liste_noire]
ADD CONSTRAINT [FK__Liste_noi__id_pr__74AE54BC]
    FOREIGN KEY ([id_proprietaire])
    REFERENCES [dbo].[Proprietaires]
        ([Id_proprietaire])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Liste_noi__id_pr__74AE54BC'
CREATE INDEX [IX_FK__Liste_noi__id_pr__74AE54BC]
ON [dbo].[Liste_noire]
    ([id_proprietaire]);
GO

-- Creating foreign key on [id_proprietaire] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK__Message__id_prop__02FC7413]
    FOREIGN KEY ([id_proprietaire])
    REFERENCES [dbo].[Proprietaires]
        ([Id_proprietaire])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Message__id_prop__02FC7413'
CREATE INDEX [IX_FK__Message__id_prop__02FC7413]
ON [dbo].[Messages]
    ([id_proprietaire]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------