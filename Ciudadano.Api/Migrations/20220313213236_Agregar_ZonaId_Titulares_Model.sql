ALTER TABLE [Titulares] ADD [ZonaId] nvarchar(64) NULL;

GO

CREATE INDEX [IX_Titulares_ZonaId] ON [Titulares] ([ZonaId]);

GO

ALTER TABLE [Titulares] ADD CONSTRAINT [FK_Titulares_Zonas_ZonaId] FOREIGN KEY ([ZonaId]) REFERENCES [Zonas] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220313213236_Agregar_ZonaId_Titulares_Model', N'3.1.17');

GO