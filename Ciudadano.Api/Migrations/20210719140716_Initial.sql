IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Permisos] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [Nombre] nvarchar(128) NOT NULL,
    [Descripcion] nvarchar(512) NOT NULL,
    [Orden] int NOT NULL,
    CONSTRAINT [PK_Permisos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Roles] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [Nombre] nvarchar(128) NOT NULL,
    [Descripcion] nvarchar(512) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TipoZonas] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [Nombre] nvarchar(128) NOT NULL,
    [Descripcion] nvarchar(512) NOT NULL,
    CONSTRAINT [PK_TipoZonas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [RolPermisos] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [RolId] nvarchar(64) NOT NULL,
    [PermisoId] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_RolPermisos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RolPermisos_Permisos_PermisoId] FOREIGN KEY ([PermisoId]) REFERENCES [Permisos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RolPermisos_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Zonas] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [Nombre] nvarchar(128) NOT NULL,
    [PadreId] nvarchar(64) NULL,
    [Geometria] geography NULL,
    [FullId] nvarchar(1024) NOT NULL,
    [TipoZonaId] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_Zonas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Zonas_Zonas_PadreId] FOREIGN KEY ([PadreId]) REFERENCES [Zonas] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Zonas_TipoZonas_TipoZonaId] FOREIGN KEY ([TipoZonaId]) REFERENCES [TipoZonas] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'Descripcion', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'Nombre', N'Orden', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Permisos]'))
    SET IDENTITY_INSERT [Permisos] ON;
INSERT INTO [Permisos] ([Id], [DeletedAt], [DeletedBy], [Descripcion], [InsertedAt], [InsertedBy], [IsDeleted], [Nombre], [Orden], [UpdatedAt], [UpdatedBy])
VALUES (N'PAGES_HOME', NULL, NULL, N'Inicio', NULL, NULL, CAST(0 AS bit), N'Inicio', 100, NULL, NULL),
(N'PAGES_MANAGEMENT', NULL, NULL, N'Administración', NULL, NULL, CAST(0 AS bit), N'Administración', 200, NULL, NULL),
(N'PAGES_MANAGEMENT_ESTABLECIMIENTOS', NULL, NULL, N'Administración > Establecimientos', NULL, NULL, CAST(0 AS bit), N'Administración > Establecimientos', 300, NULL, NULL),
(N'PAGES_MANAGEMENT_ESTABLECIMIENTOS_ADD', NULL, NULL, N'Administración > Establecimientos > Agregar Establecimiento', NULL, NULL, CAST(0 AS bit), N'Administración > Establecimientos > Agregar Establecimiento', 301, NULL, NULL),
(N'PAGES_MANAGEMENT_ESTABLECIMIENTOS_EDIT', NULL, NULL, N'Administración > Establecimientos > Editar Establecimiento', NULL, NULL, CAST(0 AS bit), N'Administración > Establecimientos > Editar Establecimiento', 302, NULL, NULL),
(N'PAGES_MANAGEMENT_ESTABLECIMIENTOS_DELETE', NULL, NULL, N'Administración > Establecimientos > Eliminar Establecimiento', NULL, NULL, CAST(0 AS bit), N'Administración > Establecimientos > Eliminar Establecimiento', 303, NULL, NULL),
(N'PAGES_SECURITY', NULL, NULL, N'Seguridad', NULL, NULL, CAST(0 AS bit), N'Seguridad', 400, NULL, NULL),
(N'PAGES_SECURITY_ROLES_AND_PERMISSIONS', NULL, NULL, N'Seguridad > Roles y Permisos', NULL, NULL, CAST(0 AS bit), N'Seguridad > Roles y Permisos', 500, NULL, NULL),
(N'PAGES_SECURITY_ROLES_AND_PERMISSIONS_ADD', NULL, NULL, N'Seguridad > Roles y Permisos > Agregar Rol', NULL, NULL, CAST(0 AS bit), N'Seguridad > Roles y Permisos > Agregar Rol', 501, NULL, NULL),
(N'PAGES_SECURITY_ROLES_AND_PERMISSIONS_EDIT', NULL, NULL, N'Seguridad > Roles y Permisos > Editar Rol', NULL, NULL, CAST(0 AS bit), N'Seguridad > Roles y Permisos > Editar Rol', 502, NULL, NULL),
(N'PAGES_SECURITY_ROLES_AND_PERMISSIONS_DELETE', NULL, NULL, N'Seguridad > Roles y Permisos > Eliminar Rol', NULL, NULL, CAST(0 AS bit), N'Seguridad > Roles y Permisos > Eliminar Rol', 503, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'Descripcion', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'Nombre', N'Orden', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Permisos]'))
    SET IDENTITY_INSERT [Permisos] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'Descripcion', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'Nombre', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [DeletedAt], [DeletedBy], [Descripcion], [InsertedAt], [InsertedBy], [IsDeleted], [Nombre], [UpdatedAt], [UpdatedBy])
VALUES (N'COD_ADMIN', NULL, NULL, N'Super Admin', NULL, NULL, CAST(0 AS bit), N'Super Admin', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'Descripcion', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'Nombre', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'PermisoId', N'RolId', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[RolPermisos]'))
    SET IDENTITY_INSERT [RolPermisos] ON;
INSERT INTO [RolPermisos] ([Id], [DeletedAt], [DeletedBy], [InsertedAt], [InsertedBy], [IsDeleted], [PermisoId], [RolId], [UpdatedAt], [UpdatedBy])
VALUES (N'ID_SA_PH', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_HOME', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PM', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_MANAGEMENT', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PM_ES', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_MANAGEMENT_ESTABLECIMIENTOS', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PM_ES_ADD', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_MANAGEMENT_ESTABLECIMIENTOS_ADD', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PM_ES_EDIT', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_MANAGEMENT_ESTABLECIMIENTOS_EDIT', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PM_ES_DELETE', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_MANAGEMENT_ESTABLECIMIENTOS_DELETE', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PS', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_SECURITY', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PS_RP', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_SECURITY_ROLES_AND_PERMISSIONS', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PS_RP_ADD', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_SECURITY_ROLES_AND_PERMISSIONS_ADD', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PS_RP_EDIT', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_SECURITY_ROLES_AND_PERMISSIONS_EDIT', N'COD_ADMIN', NULL, NULL),
(N'ID_SA_PS_RP_DELETE', NULL, NULL, NULL, NULL, CAST(0 AS bit), N'PAGES_SECURITY_ROLES_AND_PERMISSIONS_DELETE', N'COD_ADMIN', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'DeletedBy', N'InsertedAt', N'InsertedBy', N'IsDeleted', N'PermisoId', N'RolId', N'UpdatedAt', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[RolPermisos]'))
    SET IDENTITY_INSERT [RolPermisos] OFF;

GO

CREATE UNIQUE INDEX [IX_Roles_Nombre] ON [Roles] ([Nombre]);

GO

CREATE INDEX [IX_RolPermisos_PermisoId] ON [RolPermisos] ([PermisoId]);

GO

CREATE INDEX [IX_RolPermisos_RolId] ON [RolPermisos] ([RolId]);

GO

CREATE INDEX [IX_Zonas_PadreId] ON [Zonas] ([PadreId]);

GO

CREATE INDEX [IX_Zonas_TipoZonaId] ON [Zonas] ([TipoZonaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210719140716_Initial', N'3.1.17');

GO