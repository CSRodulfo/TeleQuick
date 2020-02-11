CREATE TABLE [dbo].[AppCustomers] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (256) NULL,
    [UpdatedBy]    NVARCHAR (256) NULL,
    [UpdatedDate]  DATETIME2 (7)  NOT NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Email]        NVARCHAR (100) NULL,
    [PhoneNumber]  VARCHAR (30)   NULL,
    [Address]      NVARCHAR (MAX) NULL,
    [City]         NVARCHAR (50)  NULL,
    [DateCreated]  DATETIME2 (7)  NOT NULL,
    [DateModified] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_AppCustomers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AppCustomers_Name]
    ON [dbo].[AppCustomers]([Name] ASC);

