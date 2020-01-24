USE [Minesweeper]
GO

/****** Object: Table [dbo].[Users] Script Date: 1/24/2020 3:17:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [Gender]    NVARCHAR (50) NOT NULL,
    [Age]       NVARCHAR (50) NOT NULL,
    [State]     NVARCHAR (50) NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    [Username]  NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL
);


