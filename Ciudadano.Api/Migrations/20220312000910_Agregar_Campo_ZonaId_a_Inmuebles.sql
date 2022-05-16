DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Inmuebles]') AND [c].[name] = N'sZona');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Inmuebles] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Inmuebles] DROP COLUMN [sZona];

GO

ALTER TABLE [Inmuebles] ADD [ZonaId] nvarchar(64) NULL;

GO

CREATE UNIQUE INDEX [IX_Usuarios_UsuarioNombre] ON [Usuarios] ([UsuarioNombre]);

GO

CREATE INDEX [IX_Inmuebles_ZonaId] ON [Inmuebles] ([ZonaId]);

GO

ALTER TABLE [Inmuebles] ADD CONSTRAINT [FK_Inmuebles_Zonas_ZonaId] FOREIGN KEY ([ZonaId]) REFERENCES [Zonas] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220312000910_Agregar_Campo_ZonaId_a_Inmuebles', N'3.1.17');

GO