CREATE TABLE [dbo].[InvoiceHeaders] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Date]            DATETIME       NOT NULL,
    [Hours]           DATETIME       NOT NULL,
    [Voucher]         NVARCHAR (50)  NOT NULL,
    [PointOfSale]     INT            NOT NULL,
    [CurrentAccount]  INT            NOT NULL,
    [CAE]             NUMERIC (18)   NOT NULL,
    [Subtotal]        DECIMAL (6, 2) NOT NULL,
    [IVAIns]          DECIMAL (6, 2) NOT NULL,
    [IVARni]          DECIMAL (6, 2) NOT NULL,
    [IVARG3337]       DECIMAL (6, 2) NOT NULL,
    [IIBB]            DECIMAL (6, 2) NOT NULL,
    [Total]           DECIMAL (6, 2) NOT NULL,
    [ConcessionaryId] INT            NOT NULL,
    CONSTRAINT [PK_InvoiceHeaders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InvoiceHeaders_Concessionaries] FOREIGN KEY ([ConcessionaryId]) REFERENCES [dbo].[Concessionaries] ([Id])
);




GO


