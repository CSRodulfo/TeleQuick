CREATE TABLE [dbo].[Concessionaries] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (30)  NOT NULL,
    [Detail]   NVARCHAR (200) NOT NULL,
    [MainForm] NVARCHAR (50)  DEFAULT (N'') NOT NULL,
    [Uri]      NVARCHAR (500) DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Concessionaries] PRIMARY KEY CLUSTERED ([Id] ASC)
);

