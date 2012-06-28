
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/14/2012 11:41:36
-- Generated from EDMX file: C:\Users\pmartins\Documents\Visual Studio 2010\Projects\Tampinhas\Tampinhas\Tampinhas.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tampinhas];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_UserProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_ProjectOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationSet] DROP CONSTRAINT [FK_OrganizationPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationCounty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationSet] DROP CONSTRAINT [FK_OrganizationCounty];
GO
IF OBJECT_ID(N'[dbo].[FK_CountyDistrict]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaceSet] DROP CONSTRAINT [FK_CountyDistrict];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectStatusType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_ProjectStatusType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectCommentUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectCommentSet] DROP CONSTRAINT [FK_ProjectCommentUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectCommentProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectCommentSet] DROP CONSTRAINT [FK_ProjectCommentProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectStatusChangeProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectStatusChangeSet] DROP CONSTRAINT [FK_ProjectStatusChangeProject];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectSet];
GO
IF OBJECT_ID(N'[dbo].[OrganizationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationSet];
GO
IF OBJECT_ID(N'[dbo].[PlaceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaceSet];
GO
IF OBJECT_ID(N'[dbo].[StatusTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusTypeSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectCommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectCommentSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectStatusChangeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectStatusChangeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Active] bit  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BenefiterName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CreatorId] int  NOT NULL,
    [OrganizationId] int  NOT NULL,
    [StatusTypeId] int  NOT NULL,
    [ResponsibleName] nvarchar(max)  NOT NULL,
    [RaisedAmmount] int  NOT NULL,
    [TotalAmmountRaise] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'OrganizationSet'
CREATE TABLE [dbo].[OrganizationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [DistrictId] int  NOT NULL,
    [CountyId] int  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlaceSet'
CREATE TABLE [dbo].[PlaceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ParentId] int  NULL
);
GO

-- Creating table 'StatusTypeSet'
CREATE TABLE [dbo].[StatusTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectCommentSet'
CREATE TABLE [dbo].[ProjectCommentSet] (
    [UserId] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [ProjectId] int  NOT NULL,
    [ComentDate] datetime  NOT NULL
);
GO

-- Creating table 'ProjectStatusChangeSet'
CREATE TABLE [dbo].[ProjectStatusChangeSet] (
    [ProjectId] int  NOT NULL,
    [StatusChangeComment] nvarchar(max)  NOT NULL,
    [StatusChangeDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [PK_ProjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrganizationSet'
ALTER TABLE [dbo].[OrganizationSet]
ADD CONSTRAINT [PK_OrganizationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaceSet'
ALTER TABLE [dbo].[PlaceSet]
ADD CONSTRAINT [PK_PlaceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatusTypeSet'
ALTER TABLE [dbo].[StatusTypeSet]
ADD CONSTRAINT [PK_StatusTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [ProjectId], [ComentDate] in table 'ProjectCommentSet'
ALTER TABLE [dbo].[ProjectCommentSet]
ADD CONSTRAINT [PK_ProjectCommentSet]
    PRIMARY KEY CLUSTERED ([UserId], [ProjectId], [ComentDate] ASC);
GO

-- Creating primary key on [ProjectId], [StatusChangeDate] in table 'ProjectStatusChangeSet'
ALTER TABLE [dbo].[ProjectStatusChangeSet]
ADD CONSTRAINT [PK_ProjectStatusChangeSet]
    PRIMARY KEY CLUSTERED ([ProjectId], [StatusChangeDate] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CreatorId] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_UserProject]
    FOREIGN KEY ([CreatorId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject'
CREATE INDEX [IX_FK_UserProject]
ON [dbo].[ProjectSet]
    ([CreatorId]);
GO

-- Creating foreign key on [OrganizationId] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ProjectOrganization]
    FOREIGN KEY ([OrganizationId])
    REFERENCES [dbo].[OrganizationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectOrganization'
CREATE INDEX [IX_FK_ProjectOrganization]
ON [dbo].[ProjectSet]
    ([OrganizationId]);
GO

-- Creating foreign key on [DistrictId] in table 'OrganizationSet'
ALTER TABLE [dbo].[OrganizationSet]
ADD CONSTRAINT [FK_OrganizationPlace]
    FOREIGN KEY ([DistrictId])
    REFERENCES [dbo].[PlaceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationPlace'
CREATE INDEX [IX_FK_OrganizationPlace]
ON [dbo].[OrganizationSet]
    ([DistrictId]);
GO

-- Creating foreign key on [CountyId] in table 'OrganizationSet'
ALTER TABLE [dbo].[OrganizationSet]
ADD CONSTRAINT [FK_OrganizationCounty]
    FOREIGN KEY ([CountyId])
    REFERENCES [dbo].[PlaceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationCounty'
CREATE INDEX [IX_FK_OrganizationCounty]
ON [dbo].[OrganizationSet]
    ([CountyId]);
GO

-- Creating foreign key on [ParentId] in table 'PlaceSet'
ALTER TABLE [dbo].[PlaceSet]
ADD CONSTRAINT [FK_CountyDistrict]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[PlaceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CountyDistrict'
CREATE INDEX [IX_FK_CountyDistrict]
ON [dbo].[PlaceSet]
    ([ParentId]);
GO

-- Creating foreign key on [StatusTypeId] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ProjectStatusType]
    FOREIGN KEY ([StatusTypeId])
    REFERENCES [dbo].[StatusTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectStatusType'
CREATE INDEX [IX_FK_ProjectStatusType]
ON [dbo].[ProjectSet]
    ([StatusTypeId]);
GO

-- Creating foreign key on [UserId] in table 'ProjectCommentSet'
ALTER TABLE [dbo].[ProjectCommentSet]
ADD CONSTRAINT [FK_ProjectCommentUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProjectId] in table 'ProjectCommentSet'
ALTER TABLE [dbo].[ProjectCommentSet]
ADD CONSTRAINT [FK_ProjectCommentProject]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[ProjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectCommentProject'
CREATE INDEX [IX_FK_ProjectCommentProject]
ON [dbo].[ProjectCommentSet]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'ProjectStatusChangeSet'
ALTER TABLE [dbo].[ProjectStatusChangeSet]
ADD CONSTRAINT [FK_ProjectStatusChangeProject]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[ProjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------