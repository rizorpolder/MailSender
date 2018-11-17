
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/17/2018 00:27:57
-- Generated from EDMX file: C:\Users\rizorpolder\source\repos\MailSender\MailSenderLibrary\Data\SpamDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpamDatabase];
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

-- Creating table 'ServersSet'
CREATE TABLE [dbo].[ServersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Port] nvarchar(max)  NOT NULL,
    [UseSSL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RecepientSet'
CREATE TABLE [dbo].[RecepientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SheluderTaskSet'
CREATE TABLE [dbo].[SheluderTaskSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Servers_Id] int  NOT NULL,
    [MailingList_Id] int  NULL,
    [Sender_Id] int  NOT NULL
);
GO

-- Creating table 'SenderSet'
CREATE TABLE [dbo].[SenderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Decription] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmailSet'
CREATE TABLE [dbo].[EmailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MailingListSet'
CREATE TABLE [dbo].[MailingListSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmailSheluderTask'
CREATE TABLE [dbo].[EmailSheluderTask] (
    [Emails_Id] int  NOT NULL,
    [SheluderTask_Id] int  NOT NULL
);
GO

-- Creating table 'RecepientMailingList'
CREATE TABLE [dbo].[RecepientMailingList] (
    [Recepients_Id] int  NOT NULL,
    [MailingLists_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ServersSet'
ALTER TABLE [dbo].[ServersSet]
ADD CONSTRAINT [PK_ServersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecepientSet'
ALTER TABLE [dbo].[RecepientSet]
ADD CONSTRAINT [PK_RecepientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SheluderTaskSet'
ALTER TABLE [dbo].[SheluderTaskSet]
ADD CONSTRAINT [PK_SheluderTaskSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SenderSet'
ALTER TABLE [dbo].[SenderSet]
ADD CONSTRAINT [PK_SenderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailSet'
ALTER TABLE [dbo].[EmailSet]
ADD CONSTRAINT [PK_EmailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailingListSet'
ALTER TABLE [dbo].[MailingListSet]
ADD CONSTRAINT [PK_MailingListSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Emails_Id], [SheluderTask_Id] in table 'EmailSheluderTask'
ALTER TABLE [dbo].[EmailSheluderTask]
ADD CONSTRAINT [PK_EmailSheluderTask]
    PRIMARY KEY CLUSTERED ([Emails_Id], [SheluderTask_Id] ASC);
GO

-- Creating primary key on [Recepients_Id], [MailingLists_Id] in table 'RecepientMailingList'
ALTER TABLE [dbo].[RecepientMailingList]
ADD CONSTRAINT [PK_RecepientMailingList]
    PRIMARY KEY CLUSTERED ([Recepients_Id], [MailingLists_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Servers_Id] in table 'SheluderTaskSet'
ALTER TABLE [dbo].[SheluderTaskSet]
ADD CONSTRAINT [FK_ServersSheluderTask]
    FOREIGN KEY ([Servers_Id])
    REFERENCES [dbo].[ServersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServersSheluderTask'
CREATE INDEX [IX_FK_ServersSheluderTask]
ON [dbo].[SheluderTaskSet]
    ([Servers_Id]);
GO

-- Creating foreign key on [MailingList_Id] in table 'SheluderTaskSet'
ALTER TABLE [dbo].[SheluderTaskSet]
ADD CONSTRAINT [FK_MailingListSheluderTask]
    FOREIGN KEY ([MailingList_Id])
    REFERENCES [dbo].[MailingListSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailingListSheluderTask'
CREATE INDEX [IX_FK_MailingListSheluderTask]
ON [dbo].[SheluderTaskSet]
    ([MailingList_Id]);
GO

-- Creating foreign key on [Sender_Id] in table 'SheluderTaskSet'
ALTER TABLE [dbo].[SheluderTaskSet]
ADD CONSTRAINT [FK_SenderSheluderTask]
    FOREIGN KEY ([Sender_Id])
    REFERENCES [dbo].[SenderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SenderSheluderTask'
CREATE INDEX [IX_FK_SenderSheluderTask]
ON [dbo].[SheluderTaskSet]
    ([Sender_Id]);
GO

-- Creating foreign key on [Emails_Id] in table 'EmailSheluderTask'
ALTER TABLE [dbo].[EmailSheluderTask]
ADD CONSTRAINT [FK_EmailSheluderTask_Email]
    FOREIGN KEY ([Emails_Id])
    REFERENCES [dbo].[EmailSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SheluderTask_Id] in table 'EmailSheluderTask'
ALTER TABLE [dbo].[EmailSheluderTask]
ADD CONSTRAINT [FK_EmailSheluderTask_SheluderTask]
    FOREIGN KEY ([SheluderTask_Id])
    REFERENCES [dbo].[SheluderTaskSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailSheluderTask_SheluderTask'
CREATE INDEX [IX_FK_EmailSheluderTask_SheluderTask]
ON [dbo].[EmailSheluderTask]
    ([SheluderTask_Id]);
GO

-- Creating foreign key on [Recepients_Id] in table 'RecepientMailingList'
ALTER TABLE [dbo].[RecepientMailingList]
ADD CONSTRAINT [FK_RecepientMailingList_Recepient]
    FOREIGN KEY ([Recepients_Id])
    REFERENCES [dbo].[RecepientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MailingLists_Id] in table 'RecepientMailingList'
ALTER TABLE [dbo].[RecepientMailingList]
ADD CONSTRAINT [FK_RecepientMailingList_MailingList]
    FOREIGN KEY ([MailingLists_Id])
    REFERENCES [dbo].[MailingListSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecepientMailingList_MailingList'
CREATE INDEX [IX_FK_RecepientMailingList_MailingList]
ON [dbo].[RecepientMailingList]
    ([MailingLists_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------