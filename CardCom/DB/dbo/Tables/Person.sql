CREATE TABLE [dbo].[Person] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [PersonID]     NVARCHAR (50) NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [EmailAddress] NVARCHAR (50) NOT NULL,
    [DateOfBirth]  DATE          NOT NULL,
    [PhoneNumber]  NVARCHAR(50)           NOT NULL,
    [Gender] BIT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

