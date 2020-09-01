CREATE TABLE [dbo].[Sessions] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (12) NULL,
    CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED ([Id] ASC)
);