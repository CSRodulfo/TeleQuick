CREATE TABLE [dbo].[TagRfids] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [TAGNumber]   INT            NOT NULL,
    [TAGEneable]  BIT            NOT NULL,
    [VehicleId]   INT            NOT NULL,
    [CreatedBy]   NVARCHAR (256) NULL,
    [UpdatedBy]   NVARCHAR (256) NULL,
    [UpdatedDate] DATETIME       NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_TagRfids] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TagRfids_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_TagRfids_VehicleId]
    ON [dbo].[TagRfids]([VehicleId] ASC);

