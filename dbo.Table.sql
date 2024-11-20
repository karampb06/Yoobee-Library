CREATE TABLE [dbo].[Users]
(

    [Id] INT NOT NULL PRIMARY KEY,             -- Unique identifier for the user
    [UserName] NVARCHAR(50) NOT NULL,          -- User's username
    [Email] NVARCHAR(100) NOT NULL UNIQUE,     -- User's email address (must be unique)
    [Password] NVARCHAR(255) NOT NULL          -- Hashed password
);