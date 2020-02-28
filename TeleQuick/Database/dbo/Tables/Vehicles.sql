CREATE TABLE [dbo].[Vehicles] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Make]               NVARCHAR (50)  NOT NULL,
    [Model]              NVARCHAR (50)  NOT NULL,
    [Year]               INT            NOT NULL,
    [RegistrationNumber] NVARCHAR (10)  NOT NULL,
    [CreatedBy]          NVARCHAR (256) NULL,
    [UpdatedBy]          NVARCHAR (256) NULL,
    [UpdatedDate]        DATETIME       NOT NULL,
    [CreatedDate]        DATETIME       NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

