CREATE TABLE [Impuesto_Tsg] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [dFecha_Pago] datetime2 NOT NULL,
    [iAnio] int NOT NULL,
    [iPeriodo] int NOT NULL,
    [nMonto_Pagar] float NOT NULL,
    [sCatastro] nvarchar(50) NULL,
    [nPago] float NOT NULL,
    [nSaldo] float NOT NULL,
    [tObservaciones] nvarchar(max) NULL,
    [InmuebleId] nvarchar(64) NULL,
    CONSTRAINT [PK_Impuesto_Tsg] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Impuesto_Tsg_Inmuebles_InmuebleId] FOREIGN KEY ([InmuebleId]) REFERENCES [Inmuebles] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Impuesto_Tsg_InmuebleId] ON [Impuesto_Tsg] ([InmuebleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220108075956_Agregar_Impuestos_Tsg_Model', N'3.1.17');

GO