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

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedBy] nvarchar(max) NOT NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [DeletedAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230304221317_Create Users table', N'7.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cursos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Descp_corta] nvarchar(280) NOT NULL,
    [Descp_larga] nvarchar(max) NOT NULL,
    [Publ_objetivo] nvarchar(max) NOT NULL,
    [Objetivos] nvarchar(max) NOT NULL,
    [Requisitos] nvarchar(max) NOT NULL,
    [Nivel] int NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedBy] nvarchar(max) NOT NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [DeletedAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230304233526_Create Cursos table', N'7.0.3');
GO

COMMIT;
GO

