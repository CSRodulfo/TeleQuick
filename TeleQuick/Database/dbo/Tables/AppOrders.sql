CREATE TABLE [dbo].[AppOrders] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (256)  NULL,
    [UpdatedBy]    NVARCHAR (256)  NULL,
    [UpdatedDate]  DATETIME2 (7)   NOT NULL,
    [CreatedDate]  DATETIME2 (7)   NOT NULL,
    [Discount]     DECIMAL (18, 2) NOT NULL,
    [Comments]     NVARCHAR (500)  NULL,
    [DateCreated]  DATETIME2 (7)   NOT NULL,
    [DateModified] DATETIME2 (7)   NOT NULL,
    [CashierId]    NVARCHAR (450)  NULL,
    [CustomerId]   INT             NOT NULL,
    CONSTRAINT [PK_AppOrders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AppOrders_AspNetUsers_CashierId] FOREIGN KEY ([CashierId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AppOrders_CashierId]
    ON [dbo].[AppOrders]([CashierId] ASC);

