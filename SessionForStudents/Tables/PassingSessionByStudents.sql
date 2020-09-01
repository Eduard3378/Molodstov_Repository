CREATE TABLE [dbo].[PassingSessionByStudents] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [StudentId]    INT            NOT NULL,
    [SessionId]    INT            NOT NULL,
    [CreditScore1] NVARCHAR (MAX) NULL,
    [CreditScore2] NVARCHAR (MAX) NULL,
    [CreditScore3] NVARCHAR (MAX) NULL,
    [ExamMark1]    NVARCHAR (MAX) NULL,
    [ExamMark2]    NVARCHAR (MAX) NULL,
    [ExamMark3]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_PassingSessionByStudents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PassingSessionByStudents_Sessions_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Sessions] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PassingSessionByStudents_SessionId]
    ON [dbo].[PassingSessionByStudents]([SessionId] ASC);
