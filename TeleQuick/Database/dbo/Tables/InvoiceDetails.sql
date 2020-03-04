CREATE TABLE [dbo].[InvoiceDetails] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Date]            DATETIME       NOT NULL,
    [Quantity]        INT            NOT NULL,
    [TollStation]     NVARCHAR (50)  NOT NULL,
    [Way]             NVARCHAR (5)   NOT NULL,
    [Category]        INT            NOT NULL,
    [Total]           DECIMAL (6, 2) NOT NULL,
    [InvoiceHeaderId] INT            NOT NULL,
    [VehicleId]       INT            NOT NULL,
    CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderId] FOREIGN KEY ([InvoiceHeaderId]) REFERENCES [dbo].[InvoiceHeaders] ([Id]),
    CONSTRAINT [FK_InvoiceDetails_Vehicles] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id])
);








GO
CREATE NONCLUSTERED INDEX [IX_InvoiceDetails_InvoiceHeaderId]
    ON [dbo].[InvoiceDetails]([InvoiceHeaderId] ASC);

