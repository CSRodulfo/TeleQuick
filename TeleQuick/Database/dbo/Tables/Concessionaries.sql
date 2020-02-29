CREATE TABLE [dbo].[Concessionaries] (
    [Id]       INT            NOT NULL,
    [Name]     NVARCHAR (30)  NOT NULL,
    [Detail]   NVARCHAR (200) NOT NULL,
    [MainForm] NVARCHAR (50)  CONSTRAINT [DF__Concessio__MainF__01142BA1] DEFAULT (N'') NOT NULL,
    [Uri]      NVARCHAR (500) CONSTRAINT [DF__Concessiona__Uri__02084FDA] DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Concessionaries] PRIMARY KEY CLUSTERED ([Id] ASC)
);



