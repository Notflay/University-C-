IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Users].[UpdateAt]', N'UpdatedAt', N'COLUMN';
GO

EXEC sp_rename N'[Users].[DeleteBy]', N'DeletedBy', N'COLUMN';
GO

EXEC sp_rename N'[Cursos].[UpdateAt]', N'UpdatedAt', N'COLUMN';
GO

EXEC sp_rename N'[Cursos].[DeleteBy]', N'DeletedBy', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230305061226_Create Users table', N'7.0.3');
GO

COMMIT;
GO

