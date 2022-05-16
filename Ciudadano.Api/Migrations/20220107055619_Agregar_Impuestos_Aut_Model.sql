CREATE TABLE [Impuesto_Aut] (
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
    [sDominio] nvarchar(50) NULL,
    [nPago] float NOT NULL,
    [nSaldo] float NOT NULL,
    [tObservaciones] nvarchar(max) NULL,
    CONSTRAINT [PK_Impuesto_Aut] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220107055619_Agregar_Impuestos_Aut_Model', N'3.1.17');

GO