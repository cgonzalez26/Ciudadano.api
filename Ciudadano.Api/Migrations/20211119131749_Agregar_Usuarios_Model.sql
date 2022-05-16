CREATE TABLE [Usuarios] (
    [Id] nvarchar(64) NOT NULL,
    [InsertedAt] datetime2 NULL,
    [InsertedBy] nvarchar(128) NULL,
    [UpdatedAt] datetime2 NULL,
    [UpdatedBy] nvarchar(128) NULL,
    [DeletedAt] datetime2 NULL,
    [DeletedBy] nvarchar(128) NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioNombre] nvarchar(64) NOT NULL,
    [Password] nvarchar(1024) NOT NULL,
    [Nombres] nvarchar(64) NOT NULL,
    [Apellidos] nvarchar(64) NOT NULL,
    [FechaNacimiento] datetime2 NULL,
    [Email] nvarchar(64) NULL,
    [Foto] nvarchar(1024) NULL,
    [CodigoPostal] nvarchar(8) NULL,
    [Telefono] nvarchar(16) NULL,
    [RolId] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Usuarios_RolId] ON [Usuarios] ([RolId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211119131749_Agregar_Usuarios_Model', N'3.1.17');

GO