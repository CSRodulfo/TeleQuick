CREATE TABLE [dbo].[AppOrderDetails] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [CreatedBy]   NVARCHAR (256)  NULL,
    [UpdatedBy]   NVARCHAR (256)  NULL,
    [UpdatedDate] DATETIME2 (7)   NOT NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [UnitPrice]   DECIMAL (18, 2) NOT NULL,
    [Quantity]    INT             NOT NULL,
    [Discount]    DECIMAL (18, 2) NOT NULL,
    [ProductId]   INT             NOT NULL,
    [OrderId]     INT             NOT NULL,
    CONSTRAINT [PK_AppOrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AppOrderDetails_AppOrders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[AppOrders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AppOrderDetails_AppProducts_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[AppProducts] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AppOrderDetails_OrderId]
    ON [dbo].[AppOrderDetails]([OrderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppOrderDetails_ProductId]
    ON [dbo].[AppOrderDetails]([ProductId] ASC);

