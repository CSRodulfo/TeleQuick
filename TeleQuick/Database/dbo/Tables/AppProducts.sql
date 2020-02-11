CREATE TABLE [dbo].[AppProducts] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [CreatedBy]         NVARCHAR (256)  NULL,
    [UpdatedBy]         NVARCHAR (256)  NULL,
    [UpdatedDate]       DATETIME2 (7)   NOT NULL,
    [CreatedDate]       DATETIME2 (7)   NOT NULL,
    [Name]              NVARCHAR (100)  NOT NULL,
    [Description]       NVARCHAR (500)  NULL,
    [Icon]              VARCHAR (256)   NULL,
    [BuyingPrice]       DECIMAL (18, 2) NOT NULL,
    [SellingPrice]      DECIMAL (18, 2) NOT NULL,
    [UnitsInStock]      INT             NOT NULL,
    [IsActive]          BIT             NOT NULL,
    [IsDiscontinued]    BIT             NOT NULL,
    [DateCreated]       DATETIME2 (7)   NOT NULL,
    [DateModified]      DATETIME2 (7)   NOT NULL,
    [ParentId]          INT             NULL,
    [ProductCategoryId] INT             NOT NULL,
    CONSTRAINT [PK_AppProducts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AppProducts_AppProductCategories_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[AppProductCategories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AppProducts_AppProducts_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[AppProducts] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AppProducts_Name]
    ON [dbo].[AppProducts]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppProducts_ParentId]
    ON [dbo].[AppProducts]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppProducts_ProductCategoryId]
    ON [dbo].[AppProducts]([ProductCategoryId] ASC);

