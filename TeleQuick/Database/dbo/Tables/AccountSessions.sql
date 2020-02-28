CREATE TABLE [dbo].[AccountSessions] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [LoginUser]         NVARCHAR (50)  NOT NULL,
    [LoginUserPassword] NVARCHAR (50)  NOT NULL,
    [IsValid]           BIT            NOT NULL,
    [ConcessionaryId]   INT            NOT NULL,
    [CreatedBy]         NVARCHAR (256) NULL,
    [UpdatedBy]         NVARCHAR (256) NULL,
    [UpdatedDate]       DATETIME       NOT NULL,
    [CreatedDate]       DATETIME       NOT NULL,
    CONSTRAINT [PK_AccountSessions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountSessions_Concessionaries_ConcessionaryId] FOREIGN KEY ([ConcessionaryId]) REFERENCES [dbo].[Concessionaries] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountSessions_ConcessionaryId]
    ON [dbo].[AccountSessions]([ConcessionaryId] ASC);

