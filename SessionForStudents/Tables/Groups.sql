CREATE TABLE [dbo].[Groups] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [StudentId]            INT            NOT NULL,
    [GroupName]            NVARCHAR (MAX) NULL,
    [DateOfOffsetId]       INT            NOT NULL,
    [DateOfOffset1Id]      INT            NOT NULL,
    [DateOfOffset2Id]      INT            NOT NULL,
    [DateOfExaminationId]  INT            NOT NULL,
    [DateOfExamination1Id] INT            NOT NULL,
    [DateOfExamination2Id] INT            NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Groups_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Groups_StudentId]
    ON [dbo].[Groups]([StudentId] ASC);
