CREATE TABLE [dbo].[Specialties] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [GroupId]       INT            NOT NULL,
    [SpecialtyName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Specialties_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Specialties_GroupId]
    ON [dbo].[Specialties]([GroupId] ASC);

