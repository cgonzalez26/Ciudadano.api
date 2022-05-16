CREATE TABLE [Vehiculos] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [sModelo] nvarchar(50) NULL,
    [sMarca] nvarchar(50) NULL,
    [iAnio] int NOT NULL,
    [nVal_F_V] float NOT NULL,
    [sDomicilio] nvarchar(255) NULL,
    [iPIN] int NOT NULL,
    CONSTRAINT [PK_Vehiculos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [VehiculosTitulares] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [VehiculoId] nvarchar(64) NOT NULL,
    [TitularId] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_VehiculosTitulares] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_VehiculosTitulares_Titulares_TitularId] FOREIGN KEY ([TitularId]) REFERENCES [Titulares] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_VehiculosTitulares_Vehiculos_VehiculoId] FOREIGN KEY ([VehiculoId]) REFERENCES [Vehiculos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_VehiculosTitulares_TitularId] ON [VehiculosTitulares] ([TitularId]);

GO

CREATE INDEX [IX_VehiculosTitulares_VehiculoId] ON [VehiculosTitulares] ([VehiculoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220125210115_Agregar_Vehiculos_Models', N'3.1.17');

GO