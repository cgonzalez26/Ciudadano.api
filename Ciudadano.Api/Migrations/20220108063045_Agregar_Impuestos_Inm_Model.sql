CREATE TABLE [Inmuebles] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [sZona] nvarchar(50) NULL,
    [sTerreno] nvarchar(50) NULL,
    [nVal_Ed] float NOT NULL,
    [nVal_Fis] float NOT NULL,
    [sDomicilio] nvarchar(255) NULL,
    [iPIN] int NOT NULL,
    CONSTRAINT [PK_Inmuebles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Titulares] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [sNombre] nvarchar(50) NOT NULL,
    [sApellido] nvarchar(50) NULL,
    [sDomicilio] nvarchar(1024) NULL,
    [sTelefono] nvarchar(50) NULL,
    [sCelular] nvarchar(50) NULL,
    [sMail] nvarchar(128) NULL,
    CONSTRAINT [PK_Titulares] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Impuesto_Inm] (
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
    CONSTRAINT [PK_Impuesto_Inm] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Impuesto_Inm_Inmuebles_InmuebleId] FOREIGN KEY ([InmuebleId]) REFERENCES [Inmuebles] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [InmueblesTitulares] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [InmuebleId] nvarchar(64) NOT NULL,
    [TitularId] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_InmueblesTitulares] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InmueblesTitulares_Inmuebles_InmuebleId] FOREIGN KEY ([InmuebleId]) REFERENCES [Inmuebles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InmueblesTitulares_Titulares_TitularId] FOREIGN KEY ([TitularId]) REFERENCES [Titulares] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Impuesto_Inm_InmuebleId] ON [Impuesto_Inm] ([InmuebleId]);

GO

CREATE INDEX [IX_InmueblesTitulares_InmuebleId] ON [InmueblesTitulares] ([InmuebleId]);

GO

CREATE INDEX [IX_InmueblesTitulares_TitularId] ON [InmueblesTitulares] ([TitularId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220108063045_Agregar_Impuestos_Inm_Model', N'3.1.17');

GO