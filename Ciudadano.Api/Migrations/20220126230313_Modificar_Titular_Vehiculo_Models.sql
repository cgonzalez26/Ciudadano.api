ALTER TABLE [Vehiculos] ADD [sDominio] nvarchar(50) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Titulares] ADD [sNroDocumento] nvarchar(50) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Impuesto_Aut] ADD [VehiculoId] nvarchar(64) NULL;

GO

CREATE INDEX [IX_Impuesto_Aut_VehiculoId] ON [Impuesto_Aut] ([VehiculoId]);

GO

ALTER TABLE [Impuesto_Aut] ADD CONSTRAINT [FK_Impuesto_Aut_Vehiculos_VehiculoId] FOREIGN KEY ([VehiculoId]) REFERENCES [Vehiculos] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220126230313_Modificar_Titular_Vehiculo_Models', N'3.1.17');

GO