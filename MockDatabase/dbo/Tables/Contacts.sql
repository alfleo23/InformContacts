CREATE TABLE [dbo].[Contacts] (
    [ContactId]    INT        IDENTITY (1, 1) NOT NULL,
    [First Name]   NCHAR (30) NULL,
    [Last Name]    NCHAR (30) NULL,
    [Company]      NCHAR (50) NULL,
    [Phone Number] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([ContactId] ASC)
);
