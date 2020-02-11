CREATE TABLE [dbo].[AppUserAccounts] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]   NVARCHAR (256) NULL,
    [UpdatedBy]   NVARCHAR (256) NULL,
    [UpdatedDate] DATETIME2 (7)  NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [Name]        NVARCHAR (111) NOT NULL,
    [Email]       NVARCHAR (111) NOT NULL,
    [PhoneNumber] NVARCHAR (111) NOT NULL,
    CONSTRAINT [PK_AppUserAccounts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

