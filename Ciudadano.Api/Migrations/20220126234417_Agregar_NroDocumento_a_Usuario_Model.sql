ALTER TABLE [Usuarios] ADD [sNroDocumento] nvarchar(50) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220126234417_Agregar_NroDocumento_a_Usuario_Model', N'3.1.17');

GO