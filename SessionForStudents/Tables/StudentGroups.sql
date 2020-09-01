CREATE TABLE [dbo].[StudentGroups] (
    [GroupId]   INT NOT NULL,
    [StudentId] INT NOT NULL,
    CONSTRAINT [PK_StudentGroups] PRIMARY KEY CLUSTERED ([GroupId] ASC, [StudentId] ASC),
    CONSTRAINT [FK_StudentGroups_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentGroups_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentGroups_StudentId]
    ON [dbo].[StudentGroups]([StudentId] ASC);