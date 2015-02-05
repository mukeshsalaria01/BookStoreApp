
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/03/2015 08:41:00
-- Generated from EDMX file: C:\Users\mukesh\Downloads\MyBookStore\MyBookStore\MyBookStore\DataModel\BooksDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyBookStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ISBN] nvarchar(50)  NULL,
    [BookId] varchar(50)  NULL,
    [Titlte] varchar(50)  NULL,
    [Descripton] varchar(850)  NULL,
    [Author] varchar(50)  NULL,
    [Price] decimal(18,0)  NULL,
    [ImageUrl] varchar(500)  NULL,
    [ReleaseDate] datetime  NULL,
    [Publisher] varchar(50)  NULL,
    [ExpectedDeliveryDate] datetime  NULL,
    [Checked] bit  NULL,
    [DateCreated] datetime  NULL,
    [ModifyBy] nvarchar(50)  NULL,
    [DateModified] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------