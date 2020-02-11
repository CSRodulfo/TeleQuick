CREATE TABLE [dbo].[AppProductCategories] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (256) NULL,
    [UpdatedBy]    NVARCHAR (256) NULL,
    [UpdatedDate]  DATETIME2 (7)  NOT NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Description]  NVARCHAR (500) NULL,
    [Icon]         NVARCHAR (MAX) NULL,
    [DateCreated]  DATETIME2 (7)  NOT NULL,
    [DateModified] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_AppProductCategories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

