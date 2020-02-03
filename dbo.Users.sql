CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [Gender]    NVARCHAR (50) NOT NULL,
    [Age]       INT NOT NULL,
    [State]     NVARCHAR (50) NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    [Username]  NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

