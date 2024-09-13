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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240911120450_initaldb'
)
BEGIN
    CREATE TABLE [Blogs] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [AuthorName] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240911120450_initaldb'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240911120450_initaldb', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240911120902_initalDataBlog'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AuthorName', N'Content', N'CreatedDate', N'Title') AND [object_id] = OBJECT_ID(N'[Blogs]'))
        SET IDENTITY_INSERT [Blogs] ON;
    EXEC(N'INSERT INTO [Blogs] ([Id], [AuthorName], [Content], [CreatedDate], [Title])
    VALUES (1, N''Abdullah Ali'', N''I Love Asp.Net'', ''2024-09-11T15:09:01.1460218+03:00'', N''ASP.Net''),
    (2, N''Malak Mohamed'', N''I Love API Core'', ''2024-09-11T15:09:01.1460278+03:00'', N''API Core''),
    (3, N''Omar Ali'', N''I Love MVC Core'', ''2024-09-11T15:09:01.1460286+03:00'', N''MVC Core'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AuthorName', N'Content', N'CreatedDate', N'Title') AND [object_id] = OBJECT_ID(N'[Blogs]'))
        SET IDENTITY_INSERT [Blogs] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240911120902_initalDataBlog'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240911120902_initalDataBlog', N'8.0.8');
END;
GO

COMMIT;
GO

