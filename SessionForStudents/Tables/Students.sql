CREATE TABLE [dbo].[Students] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [Name]                      NVARCHAR (MAX) NULL,
    [Surname]                   NVARCHAR (MAX) NULL,
    [Patronymic]                NVARCHAR (MAX) NULL,
    [GenderId]                  INT            NOT NULL,
    [DateOfBirth]               DATETIME2 (7)  NOT NULL,
    [PassingSessionByStudentId] INT            NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Students_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Genders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Students_PassingSessionByStudents_PassingSessionByStudentId] FOREIGN KEY ([PassingSessionByStudentId]) REFERENCES [dbo].[PassingSessionByStudents] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Students_GenderId]
    ON [dbo].[Students]([GenderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Students_PassingSessionByStudentId]
    ON [dbo].[Students]([PassingSessionByStudentId] ASC);
