
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/25/2021 23:56:55
-- Generated from EDMX file: C:\Users\Nemanja\Desktop\Marko\School\Baze 2\Projekat\Soundbase\Soundbase\ModelSoundbase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Soundbase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SongComposer_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongComposer] DROP CONSTRAINT [FK_SongComposer_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongComposer_Composer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongComposer] DROP CONSTRAINT [FK_SongComposer_Composer];
GO
IF OBJECT_ID(N'[dbo].[FK_SongGenre_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongGenre] DROP CONSTRAINT [FK_SongGenre_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongGenre_Genre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongGenre] DROP CONSTRAINT [FK_SongGenre_Genre];
GO
IF OBJECT_ID(N'[dbo].[FK_SongWriter_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongWriter] DROP CONSTRAINT [FK_SongWriter_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongWriter_Writer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongWriter] DROP CONSTRAINT [FK_SongWriter_Writer];
GO
IF OBJECT_ID(N'[dbo].[FK_SongEngineer_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongEngineer] DROP CONSTRAINT [FK_SongEngineer_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongEngineer_Engineer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongEngineer] DROP CONSTRAINT [FK_SongEngineer_Engineer];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistBand_Artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistBand] DROP CONSTRAINT [FK_ArtistBand_Artist];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistBand_Band]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistBand] DROP CONSTRAINT [FK_ArtistBand_Band];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistRecordLabel_Artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistRecordLabel] DROP CONSTRAINT [FK_ArtistRecordLabel_Artist];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistRecordLabel_RecordLabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtistRecordLabel] DROP CONSTRAINT [FK_ArtistRecordLabel_RecordLabel];
GO
IF OBJECT_ID(N'[dbo].[FK_BandRecordLabel_Band]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BandRecordLabel] DROP CONSTRAINT [FK_BandRecordLabel_Band];
GO
IF OBJECT_ID(N'[dbo].[FK_BandRecordLabel_RecordLabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BandRecordLabel] DROP CONSTRAINT [FK_BandRecordLabel_RecordLabel];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumArtwork]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtworkSet] DROP CONSTRAINT [FK_AlbumArtwork];
GO
IF OBJECT_ID(N'[dbo].[FK_SongOfficialVideo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OfficialVideoSet] DROP CONSTRAINT [FK_SongOfficialVideo];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistCreated]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreatedSet] DROP CONSTRAINT [FK_ArtistCreated];
GO
IF OBJECT_ID(N'[dbo].[FK_SongPerformed]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedSet] DROP CONSTRAINT [FK_SongPerformed];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistPerformed]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedSet] DROP CONSTRAINT [FK_ArtistPerformed];
GO
IF OBJECT_ID(N'[dbo].[FK_PerformedCreated_Performed]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedCreated] DROP CONSTRAINT [FK_PerformedCreated_Performed];
GO
IF OBJECT_ID(N'[dbo].[FK_PerformedCreated_Created]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerformedCreated] DROP CONSTRAINT [FK_PerformedCreated_Created];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumCreated]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreatedSet] DROP CONSTRAINT [FK_AlbumCreated];
GO
IF OBJECT_ID(N'[dbo].[FK_GenreGenre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GenreSet] DROP CONSTRAINT [FK_GenreGenre];
GO
IF OBJECT_ID(N'[dbo].[FK_RecordingEngineer_inherits_Engineer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EngineerSet_RecordingEngineer] DROP CONSTRAINT [FK_RecordingEngineer_inherits_Engineer];
GO
IF OBJECT_ID(N'[dbo].[FK_MixingEngineer_inherits_Engineer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EngineerSet_MixingEngineer] DROP CONSTRAINT [FK_MixingEngineer_inherits_Engineer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SongSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongSet];
GO
IF OBJECT_ID(N'[dbo].[ComposerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComposerSet];
GO
IF OBJECT_ID(N'[dbo].[GenreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GenreSet];
GO
IF OBJECT_ID(N'[dbo].[WriterSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WriterSet];
GO
IF OBJECT_ID(N'[dbo].[OfficialVideoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OfficialVideoSet];
GO
IF OBJECT_ID(N'[dbo].[EngineerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EngineerSet];
GO
IF OBJECT_ID(N'[dbo].[ArtistSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistSet];
GO
IF OBJECT_ID(N'[dbo].[BandSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BandSet];
GO
IF OBJECT_ID(N'[dbo].[RecordLabelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecordLabelSet];
GO
IF OBJECT_ID(N'[dbo].[ArtworkSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtworkSet];
GO
IF OBJECT_ID(N'[dbo].[AlbumSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlbumSet];
GO
IF OBJECT_ID(N'[dbo].[CreatedSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreatedSet];
GO
IF OBJECT_ID(N'[dbo].[PerformedSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerformedSet];
GO
IF OBJECT_ID(N'[dbo].[EngineerSet_RecordingEngineer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EngineerSet_RecordingEngineer];
GO
IF OBJECT_ID(N'[dbo].[EngineerSet_MixingEngineer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EngineerSet_MixingEngineer];
GO
IF OBJECT_ID(N'[dbo].[SongComposer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongComposer];
GO
IF OBJECT_ID(N'[dbo].[SongGenre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongGenre];
GO
IF OBJECT_ID(N'[dbo].[SongWriter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongWriter];
GO
IF OBJECT_ID(N'[dbo].[SongEngineer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongEngineer];
GO
IF OBJECT_ID(N'[dbo].[ArtistBand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistBand];
GO
IF OBJECT_ID(N'[dbo].[ArtistRecordLabel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistRecordLabel];
GO
IF OBJECT_ID(N'[dbo].[BandRecordLabel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BandRecordLabel];
GO
IF OBJECT_ID(N'[dbo].[PerformedCreated]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerformedCreated];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SongSet'
CREATE TABLE [dbo].[SongSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Duration] int  NOT NULL
);
GO

-- Creating table 'ComposerSet'
CREATE TABLE [dbo].[ComposerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GenreSet'
CREATE TABLE [dbo].[GenreSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GenreId] int  NULL
);
GO

-- Creating table 'WriterSet'
CREATE TABLE [dbo].[WriterSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OfficialVideoSet'
CREATE TABLE [dbo].[OfficialVideoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Format] nvarchar(max)  NOT NULL,
    [SongId] int  NOT NULL,
    [Song_Id] int  NOT NULL
);
GO

-- Creating table 'EngineerSet'
CREATE TABLE [dbo].[EngineerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ArtistSet'
CREATE TABLE [dbo].[ArtistSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BandSet'
CREATE TABLE [dbo].[BandSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RecordLabelSet'
CREATE TABLE [dbo].[RecordLabelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ArtworkSet'
CREATE TABLE [dbo].[ArtworkSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Artist] nvarchar(max)  NOT NULL,
    [Format] nvarchar(max)  NOT NULL,
    [Album_Id] int  NOT NULL
);
GO

-- Creating table 'AlbumSet'
CREATE TABLE [dbo].[AlbumSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CreatedSet'
CREATE TABLE [dbo].[CreatedSet] (
    [ArtistId] int  NOT NULL,
    [AlbumId] int  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PerformedSet'
CREATE TABLE [dbo].[PerformedSet] (
    [SongId] int  NOT NULL,
    [ArtistId] int  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'EngineerSet_RecordingEngineer'
CREATE TABLE [dbo].[EngineerSet_RecordingEngineer] (
    [StudioName] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'EngineerSet_MixingEngineer'
CREATE TABLE [dbo].[EngineerSet_MixingEngineer] (
    [Awards] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'SongComposer'
CREATE TABLE [dbo].[SongComposer] (
    [Songs_Id] int  NOT NULL,
    [Composers_Id] int  NOT NULL
);
GO

-- Creating table 'SongGenre'
CREATE TABLE [dbo].[SongGenre] (
    [Songs_Id] int  NOT NULL,
    [Genres_Id] int  NOT NULL
);
GO

-- Creating table 'SongWriter'
CREATE TABLE [dbo].[SongWriter] (
    [Songs_Id] int  NOT NULL,
    [Writers_Id] int  NOT NULL
);
GO

-- Creating table 'SongEngineer'
CREATE TABLE [dbo].[SongEngineer] (
    [Songs_Id] int  NOT NULL,
    [Engineers_Id] int  NOT NULL
);
GO

-- Creating table 'ArtistBand'
CREATE TABLE [dbo].[ArtistBand] (
    [Artists_Id] int  NOT NULL,
    [Bands_Id] int  NOT NULL
);
GO

-- Creating table 'ArtistRecordLabel'
CREATE TABLE [dbo].[ArtistRecordLabel] (
    [Artists_Id] int  NOT NULL,
    [RecordLabels_Id] int  NOT NULL
);
GO

-- Creating table 'BandRecordLabel'
CREATE TABLE [dbo].[BandRecordLabel] (
    [Bands_Id] int  NOT NULL,
    [RecordLabels_Id] int  NOT NULL
);
GO

-- Creating table 'PerformedCreated'
CREATE TABLE [dbo].[PerformedCreated] (
    [Performed_Id] int  NOT NULL,
    [Created_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'SongSet'
ALTER TABLE [dbo].[SongSet]
ADD CONSTRAINT [PK_SongSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComposerSet'
ALTER TABLE [dbo].[ComposerSet]
ADD CONSTRAINT [PK_ComposerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GenreSet'
ALTER TABLE [dbo].[GenreSet]
ADD CONSTRAINT [PK_GenreSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WriterSet'
ALTER TABLE [dbo].[WriterSet]
ADD CONSTRAINT [PK_WriterSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OfficialVideoSet'
ALTER TABLE [dbo].[OfficialVideoSet]
ADD CONSTRAINT [PK_OfficialVideoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EngineerSet'
ALTER TABLE [dbo].[EngineerSet]
ADD CONSTRAINT [PK_EngineerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArtistSet'
ALTER TABLE [dbo].[ArtistSet]
ADD CONSTRAINT [PK_ArtistSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BandSet'
ALTER TABLE [dbo].[BandSet]
ADD CONSTRAINT [PK_BandSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecordLabelSet'
ALTER TABLE [dbo].[RecordLabelSet]
ADD CONSTRAINT [PK_RecordLabelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArtworkSet'
ALTER TABLE [dbo].[ArtworkSet]
ADD CONSTRAINT [PK_ArtworkSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AlbumSet'
ALTER TABLE [dbo].[AlbumSet]
ADD CONSTRAINT [PK_AlbumSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CreatedSet'
ALTER TABLE [dbo].[CreatedSet]
ADD CONSTRAINT [PK_CreatedSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PerformedSet'
ALTER TABLE [dbo].[PerformedSet]
ADD CONSTRAINT [PK_PerformedSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EngineerSet_RecordingEngineer'
ALTER TABLE [dbo].[EngineerSet_RecordingEngineer]
ADD CONSTRAINT [PK_EngineerSet_RecordingEngineer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EngineerSet_MixingEngineer'
ALTER TABLE [dbo].[EngineerSet_MixingEngineer]
ADD CONSTRAINT [PK_EngineerSet_MixingEngineer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Songs_Id], [Composers_Id] in table 'SongComposer'
ALTER TABLE [dbo].[SongComposer]
ADD CONSTRAINT [PK_SongComposer]
    PRIMARY KEY CLUSTERED ([Songs_Id], [Composers_Id] ASC);
GO

-- Creating primary key on [Songs_Id], [Genres_Id] in table 'SongGenre'
ALTER TABLE [dbo].[SongGenre]
ADD CONSTRAINT [PK_SongGenre]
    PRIMARY KEY CLUSTERED ([Songs_Id], [Genres_Id] ASC);
GO

-- Creating primary key on [Songs_Id], [Writers_Id] in table 'SongWriter'
ALTER TABLE [dbo].[SongWriter]
ADD CONSTRAINT [PK_SongWriter]
    PRIMARY KEY CLUSTERED ([Songs_Id], [Writers_Id] ASC);
GO

-- Creating primary key on [Songs_Id], [Engineers_Id] in table 'SongEngineer'
ALTER TABLE [dbo].[SongEngineer]
ADD CONSTRAINT [PK_SongEngineer]
    PRIMARY KEY CLUSTERED ([Songs_Id], [Engineers_Id] ASC);
GO

-- Creating primary key on [Artists_Id], [Bands_Id] in table 'ArtistBand'
ALTER TABLE [dbo].[ArtistBand]
ADD CONSTRAINT [PK_ArtistBand]
    PRIMARY KEY CLUSTERED ([Artists_Id], [Bands_Id] ASC);
GO

-- Creating primary key on [Artists_Id], [RecordLabels_Id] in table 'ArtistRecordLabel'
ALTER TABLE [dbo].[ArtistRecordLabel]
ADD CONSTRAINT [PK_ArtistRecordLabel]
    PRIMARY KEY CLUSTERED ([Artists_Id], [RecordLabels_Id] ASC);
GO

-- Creating primary key on [Bands_Id], [RecordLabels_Id] in table 'BandRecordLabel'
ALTER TABLE [dbo].[BandRecordLabel]
ADD CONSTRAINT [PK_BandRecordLabel]
    PRIMARY KEY CLUSTERED ([Bands_Id], [RecordLabels_Id] ASC);
GO

-- Creating primary key on [Performed_Id], [Created_Id] in table 'PerformedCreated'
ALTER TABLE [dbo].[PerformedCreated]
ADD CONSTRAINT [PK_PerformedCreated]
    PRIMARY KEY CLUSTERED ([Performed_Id], [Created_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Songs_Id] in table 'SongComposer'
ALTER TABLE [dbo].[SongComposer]
ADD CONSTRAINT [FK_SongComposer_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Composers_Id] in table 'SongComposer'
ALTER TABLE [dbo].[SongComposer]
ADD CONSTRAINT [FK_SongComposer_Composer]
    FOREIGN KEY ([Composers_Id])
    REFERENCES [dbo].[ComposerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongComposer_Composer'
CREATE INDEX [IX_FK_SongComposer_Composer]
ON [dbo].[SongComposer]
    ([Composers_Id]);
GO

-- Creating foreign key on [Songs_Id] in table 'SongGenre'
ALTER TABLE [dbo].[SongGenre]
ADD CONSTRAINT [FK_SongGenre_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Genres_Id] in table 'SongGenre'
ALTER TABLE [dbo].[SongGenre]
ADD CONSTRAINT [FK_SongGenre_Genre]
    FOREIGN KEY ([Genres_Id])
    REFERENCES [dbo].[GenreSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongGenre_Genre'
CREATE INDEX [IX_FK_SongGenre_Genre]
ON [dbo].[SongGenre]
    ([Genres_Id]);
GO

-- Creating foreign key on [Songs_Id] in table 'SongWriter'
ALTER TABLE [dbo].[SongWriter]
ADD CONSTRAINT [FK_SongWriter_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Writers_Id] in table 'SongWriter'
ALTER TABLE [dbo].[SongWriter]
ADD CONSTRAINT [FK_SongWriter_Writer]
    FOREIGN KEY ([Writers_Id])
    REFERENCES [dbo].[WriterSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongWriter_Writer'
CREATE INDEX [IX_FK_SongWriter_Writer]
ON [dbo].[SongWriter]
    ([Writers_Id]);
GO

-- Creating foreign key on [Songs_Id] in table 'SongEngineer'
ALTER TABLE [dbo].[SongEngineer]
ADD CONSTRAINT [FK_SongEngineer_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Engineers_Id] in table 'SongEngineer'
ALTER TABLE [dbo].[SongEngineer]
ADD CONSTRAINT [FK_SongEngineer_Engineer]
    FOREIGN KEY ([Engineers_Id])
    REFERENCES [dbo].[EngineerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongEngineer_Engineer'
CREATE INDEX [IX_FK_SongEngineer_Engineer]
ON [dbo].[SongEngineer]
    ([Engineers_Id]);
GO

-- Creating foreign key on [Artists_Id] in table 'ArtistBand'
ALTER TABLE [dbo].[ArtistBand]
ADD CONSTRAINT [FK_ArtistBand_Artist]
    FOREIGN KEY ([Artists_Id])
    REFERENCES [dbo].[ArtistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Bands_Id] in table 'ArtistBand'
ALTER TABLE [dbo].[ArtistBand]
ADD CONSTRAINT [FK_ArtistBand_Band]
    FOREIGN KEY ([Bands_Id])
    REFERENCES [dbo].[BandSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistBand_Band'
CREATE INDEX [IX_FK_ArtistBand_Band]
ON [dbo].[ArtistBand]
    ([Bands_Id]);
GO

-- Creating foreign key on [Artists_Id] in table 'ArtistRecordLabel'
ALTER TABLE [dbo].[ArtistRecordLabel]
ADD CONSTRAINT [FK_ArtistRecordLabel_Artist]
    FOREIGN KEY ([Artists_Id])
    REFERENCES [dbo].[ArtistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RecordLabels_Id] in table 'ArtistRecordLabel'
ALTER TABLE [dbo].[ArtistRecordLabel]
ADD CONSTRAINT [FK_ArtistRecordLabel_RecordLabel]
    FOREIGN KEY ([RecordLabels_Id])
    REFERENCES [dbo].[RecordLabelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistRecordLabel_RecordLabel'
CREATE INDEX [IX_FK_ArtistRecordLabel_RecordLabel]
ON [dbo].[ArtistRecordLabel]
    ([RecordLabels_Id]);
GO

-- Creating foreign key on [Bands_Id] in table 'BandRecordLabel'
ALTER TABLE [dbo].[BandRecordLabel]
ADD CONSTRAINT [FK_BandRecordLabel_Band]
    FOREIGN KEY ([Bands_Id])
    REFERENCES [dbo].[BandSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RecordLabels_Id] in table 'BandRecordLabel'
ALTER TABLE [dbo].[BandRecordLabel]
ADD CONSTRAINT [FK_BandRecordLabel_RecordLabel]
    FOREIGN KEY ([RecordLabels_Id])
    REFERENCES [dbo].[RecordLabelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BandRecordLabel_RecordLabel'
CREATE INDEX [IX_FK_BandRecordLabel_RecordLabel]
ON [dbo].[BandRecordLabel]
    ([RecordLabels_Id]);
GO

-- Creating foreign key on [Album_Id] in table 'ArtworkSet'
ALTER TABLE [dbo].[ArtworkSet]
ADD CONSTRAINT [FK_AlbumArtwork]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumArtwork'
CREATE INDEX [IX_FK_AlbumArtwork]
ON [dbo].[ArtworkSet]
    ([Album_Id]);
GO

-- Creating foreign key on [Song_Id] in table 'OfficialVideoSet'
ALTER TABLE [dbo].[OfficialVideoSet]
ADD CONSTRAINT [FK_SongOfficialVideo]
    FOREIGN KEY ([Song_Id])
    REFERENCES [dbo].[SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongOfficialVideo'
CREATE INDEX [IX_FK_SongOfficialVideo]
ON [dbo].[OfficialVideoSet]
    ([Song_Id]);
GO

-- Creating foreign key on [ArtistId] in table 'CreatedSet'
ALTER TABLE [dbo].[CreatedSet]
ADD CONSTRAINT [FK_ArtistCreated]
    FOREIGN KEY ([ArtistId])
    REFERENCES [dbo].[ArtistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistCreated'
CREATE INDEX [IX_FK_ArtistCreated]
ON [dbo].[CreatedSet]
    ([ArtistId]);
GO

-- Creating foreign key on [SongId] in table 'PerformedSet'
ALTER TABLE [dbo].[PerformedSet]
ADD CONSTRAINT [FK_SongPerformed]
    FOREIGN KEY ([SongId])
    REFERENCES [dbo].[SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongPerformed'
CREATE INDEX [IX_FK_SongPerformed]
ON [dbo].[PerformedSet]
    ([SongId]);
GO

-- Creating foreign key on [ArtistId] in table 'PerformedSet'
ALTER TABLE [dbo].[PerformedSet]
ADD CONSTRAINT [FK_ArtistPerformed]
    FOREIGN KEY ([ArtistId])
    REFERENCES [dbo].[ArtistSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistPerformed'
CREATE INDEX [IX_FK_ArtistPerformed]
ON [dbo].[PerformedSet]
    ([ArtistId]);
GO

-- Creating foreign key on [Performed_Id] in table 'PerformedCreated'
ALTER TABLE [dbo].[PerformedCreated]
ADD CONSTRAINT [FK_PerformedCreated_Performed]
    FOREIGN KEY ([Performed_Id])
    REFERENCES [dbo].[PerformedSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Created_Id] in table 'PerformedCreated'
ALTER TABLE [dbo].[PerformedCreated]
ADD CONSTRAINT [FK_PerformedCreated_Created]
    FOREIGN KEY ([Created_Id])
    REFERENCES [dbo].[CreatedSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerformedCreated_Created'
CREATE INDEX [IX_FK_PerformedCreated_Created]
ON [dbo].[PerformedCreated]
    ([Created_Id]);
GO

-- Creating foreign key on [AlbumId] in table 'CreatedSet'
ALTER TABLE [dbo].[CreatedSet]
ADD CONSTRAINT [FK_AlbumCreated]
    FOREIGN KEY ([AlbumId])
    REFERENCES [dbo].[AlbumSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumCreated'
CREATE INDEX [IX_FK_AlbumCreated]
ON [dbo].[CreatedSet]
    ([AlbumId]);
GO

-- Creating foreign key on [GenreId] in table 'GenreSet'
ALTER TABLE [dbo].[GenreSet]
ADD CONSTRAINT [FK_GenreGenre]
    FOREIGN KEY ([GenreId])
    REFERENCES [dbo].[GenreSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GenreGenre'
CREATE INDEX [IX_FK_GenreGenre]
ON [dbo].[GenreSet]
    ([GenreId]);
GO

-- Creating foreign key on [Id] in table 'EngineerSet_RecordingEngineer'
ALTER TABLE [dbo].[EngineerSet_RecordingEngineer]
ADD CONSTRAINT [FK_RecordingEngineer_inherits_Engineer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[EngineerSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EngineerSet_MixingEngineer'
ALTER TABLE [dbo].[EngineerSet_MixingEngineer]
ADD CONSTRAINT [FK_MixingEngineer_inherits_Engineer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[EngineerSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------