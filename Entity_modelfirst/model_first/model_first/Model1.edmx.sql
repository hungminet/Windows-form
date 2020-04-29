
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2020 14:16:05
-- Generated from EDMX file: D:\Git\Windows-form\Entity_modelfirst\model_first\model_first\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
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

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Employee_ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Product_ID] int IDENTITY(1,1) NOT NULL,
    [Employee_ID] int  NOT NULL
);
GO

-- Creating table 'Resources1'
CREATE TABLE [dbo].[Resources1] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Bills'
CREATE TABLE [dbo].[Bills] (
    [Bill_ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'BillProduct'
CREATE TABLE [dbo].[BillProduct] (
    [Bills_Bill_ID] int  NOT NULL,
    [Products_Product_ID] int  NOT NULL
);
GO

-- Creating table 'ProductResource'
CREATE TABLE [dbo].[ProductResource] (
    [Products_Product_ID] int  NOT NULL,
    [Resources_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Employee_ID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Employee_ID] ASC);
GO

-- Creating primary key on [Product_ID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Product_ID] ASC);
GO

-- Creating primary key on [Id] in table 'Resources1'
ALTER TABLE [dbo].[Resources1]
ADD CONSTRAINT [PK_Resources1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Bill_ID] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [PK_Bills]
    PRIMARY KEY CLUSTERED ([Bill_ID] ASC);
GO

-- Creating primary key on [Bills_Bill_ID], [Products_Product_ID] in table 'BillProduct'
ALTER TABLE [dbo].[BillProduct]
ADD CONSTRAINT [PK_BillProduct]
    PRIMARY KEY CLUSTERED ([Bills_Bill_ID], [Products_Product_ID] ASC);
GO

-- Creating primary key on [Products_Product_ID], [Resources_Id] in table 'ProductResource'
ALTER TABLE [dbo].[ProductResource]
ADD CONSTRAINT [PK_ProductResource]
    PRIMARY KEY CLUSTERED ([Products_Product_ID], [Resources_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Bills_Bill_ID] in table 'BillProduct'
ALTER TABLE [dbo].[BillProduct]
ADD CONSTRAINT [FK_BillProduct_Bill]
    FOREIGN KEY ([Bills_Bill_ID])
    REFERENCES [dbo].[Bills]
        ([Bill_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Products_Product_ID] in table 'BillProduct'
ALTER TABLE [dbo].[BillProduct]
ADD CONSTRAINT [FK_BillProduct_Product]
    FOREIGN KEY ([Products_Product_ID])
    REFERENCES [dbo].[Products]
        ([Product_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillProduct_Product'
CREATE INDEX [IX_FK_BillProduct_Product]
ON [dbo].[BillProduct]
    ([Products_Product_ID]);
GO

-- Creating foreign key on [Products_Product_ID] in table 'ProductResource'
ALTER TABLE [dbo].[ProductResource]
ADD CONSTRAINT [FK_ProductResource_Product]
    FOREIGN KEY ([Products_Product_ID])
    REFERENCES [dbo].[Products]
        ([Product_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Resources_Id] in table 'ProductResource'
ALTER TABLE [dbo].[ProductResource]
ADD CONSTRAINT [FK_ProductResource_Resource]
    FOREIGN KEY ([Resources_Id])
    REFERENCES [dbo].[Resources1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductResource_Resource'
CREATE INDEX [IX_FK_ProductResource_Resource]
ON [dbo].[ProductResource]
    ([Resources_Id]);
GO

-- Creating foreign key on [Employee_ID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_EmployeeProduct]
    FOREIGN KEY ([Employee_ID])
    REFERENCES [dbo].[Employees]
        ([Employee_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeProduct'
CREATE INDEX [IX_FK_EmployeeProduct]
ON [dbo].[Products]
    ([Employee_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------