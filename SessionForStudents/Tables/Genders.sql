CREATE TABLE [dbo].[Genders] (
    [Id]     INT           NOT NULL,
    [Name]   NVARCHAR (12) NULL,
    [Design] NVARCHAR (3)  NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED ([Id] ASC)
);
