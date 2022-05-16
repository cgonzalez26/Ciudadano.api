CREATE TABLE [TipoDenuncias] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [Nombre] nvarchar(128) NOT NULL,
    [Descripcion] nvarchar(512) NULL,
    CONSTRAINT [PK_TipoDenuncias] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Denuncias] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [sNroDocumento] nvarchar(20) NULL,
    [sNombre] nvarchar(50) NULL,
    [sApellido] nvarchar(50) NULL,
    [sMail] nvarchar(128) NULL,
    [sTelefono] nvarchar(50) NULL,
    [sDireccion] nvarchar(1024) NULL,
    [sEntre_Calle] nvarchar(1024) NULL,
    [sLongitud] nvarchar(20) NULL,
    [sLatitud] nvarchar(20) NULL,
    [tRelato] nvarchar(max) NULL,
    [TipoDenunciaId] nvarchar(64) NULL,
    CONSTRAINT [PK_Denuncias] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Denuncias_TipoDenuncias_TipoDenunciaId] FOREIGN KEY ([TipoDenunciaId]) REFERENCES [TipoDenuncias] ([Id]) ON DELETE NO ACTION
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'Descripcion', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'Nombre', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[TipoDenuncias]'))
    SET IDENTITY_INSERT [TipoDenuncias] ON;
INSERT INTO [TipoDenuncias] ([Id], [DeletedAt], [DeletedBy], [Descripcion], [InsertedAt], [InsertedBy], [IsDeleted], [Nombre], [UpdatedAt], [UpdatedBy])
VALUES (N'ID_BASURAL', NULL, NULL, N'BASURAL', NULL, NULL, CAST(0 AS bit), N'BASURAL', NULL, NULL),
(N'ID_BACHE', NULL, NULL, N'BACHE', NULL, NULL, CAST(0 AS bit), N'BACHE', NULL, NULL),
(N'ID_PERDIDA_AGUA', NULL, NULL, N'PERDIDA DE AGUA', NULL, NULL, CAST(0 AS bit), N'PERDIDA DE AGUA', NULL, NULL),
(N'ID_DESBORDE_CLOACAL', NULL, NULL, N'DESBORDE CLOACAL', NULL, NULL, CAST(0 AS bit), N'DESBORDE CLOACAL', NULL, NULL),
(N'ID_OCUPACION_VIA_PUBLICA', NULL, NULL, N'OCUPACION INDEBIDA DE LA VIA PUBLICA', NULL, NULL, CAST(0 AS bit), N'OCUPACION INDEBIDA DE LA VIA PUBLICA', NULL, NULL),
(N'ID_OBSTRUCCION_RAMPAS', NULL, NULL, N'OBSTRUCCION DE RAMPAS ACCESIBILIDAD', NULL, NULL, CAST(0 AS bit), N'OBSTRUCCION DE RAMPAS ACCESIBILIDAD', NULL, NULL),
(N'ID_OTRO', NULL, NULL, N'OTRO', NULL, NULL, CAST(0 AS bit), N'OTRO', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'Descripcion', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'Nombre', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[TipoDenuncias]'))
    SET IDENTITY_INSERT [TipoDenuncias] OFF;

GO

CREATE INDEX [IX_Denuncias_TipoDenunciaId] ON [Denuncias] ([TipoDenunciaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220112052912_Agregar_Denuncias_Models', N'3.1.17');

GO