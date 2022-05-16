ALTER TABLE [Inmuebles] ADD [sCatastro] nvarchar(50) NULL;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Tsg]') AND [c].[name] = N'nSaldo');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Tsg] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Impuesto_Tsg] ALTER COLUMN [nSaldo] float NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Tsg]') AND [c].[name] = N'nPago');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Tsg] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Impuesto_Tsg] ALTER COLUMN [nPago] float NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Tsg]') AND [c].[name] = N'nMonto_Pagar');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Tsg] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Impuesto_Tsg] ALTER COLUMN [nMonto_Pagar] float NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Tsg]') AND [c].[name] = N'iPeriodo');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Tsg] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Impuesto_Tsg] ALTER COLUMN [iPeriodo] int NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Tsg]') AND [c].[name] = N'iAnio');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Tsg] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Impuesto_Tsg] ALTER COLUMN [iAnio] int NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Tsg]') AND [c].[name] = N'dFecha_Pago');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Tsg] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Impuesto_Tsg] ALTER COLUMN [dFecha_Pago] datetime2 NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Inm]') AND [c].[name] = N'nSaldo');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Inm] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Impuesto_Inm] ALTER COLUMN [nSaldo] float NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Inm]') AND [c].[name] = N'nPago');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Inm] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Impuesto_Inm] ALTER COLUMN [nPago] float NULL;

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Inm]') AND [c].[name] = N'nMonto_Pagar');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Inm] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Impuesto_Inm] ALTER COLUMN [nMonto_Pagar] float NULL;

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Inm]') AND [c].[name] = N'iPeriodo');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Inm] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Impuesto_Inm] ALTER COLUMN [iPeriodo] int NULL;

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Inm]') AND [c].[name] = N'iAnio');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Inm] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Impuesto_Inm] ALTER COLUMN [iAnio] int NULL;

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Inm]') AND [c].[name] = N'dFecha_Pago');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Inm] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Impuesto_Inm] ALTER COLUMN [dFecha_Pago] datetime2 NULL;

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Aut]') AND [c].[name] = N'nSaldo');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Aut] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Impuesto_Aut] ALTER COLUMN [nSaldo] float NULL;

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Aut]') AND [c].[name] = N'nPago');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Aut] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Impuesto_Aut] ALTER COLUMN [nPago] float NULL;

GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Aut]') AND [c].[name] = N'nMonto_Pagar');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Aut] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Impuesto_Aut] ALTER COLUMN [nMonto_Pagar] float NULL;

GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Aut]') AND [c].[name] = N'iPeriodo');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Aut] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Impuesto_Aut] ALTER COLUMN [iPeriodo] int NULL;

GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Aut]') AND [c].[name] = N'iAnio');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Aut] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [Impuesto_Aut] ALTER COLUMN [iAnio] int NULL;

GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Impuesto_Aut]') AND [c].[name] = N'dFecha_Pago');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Impuesto_Aut] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [Impuesto_Aut] ALTER COLUMN [dFecha_Pago] datetime2 NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220129202620_Quitar_Restriccion_Campos_No_Nulos', N'3.1.17');

GO