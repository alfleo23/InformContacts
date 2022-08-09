CREATE TABLE [dbo].[Contacts] (
    [ContactId]    INT          IDENTITY (1, 1) NOT NULL,
    [First Name]   VARCHAR(30)   NULL,
    [Last Name]    VARCHAR(30)   NULL,
    [Company]      VARCHAR(50)   NULL,
    [Phone Number] VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([ContactId] ASC)
);

