CREATE TABLE [dbo].[Groups] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [StudentId]          INT            NOT NULL,
    [GroupName]          NVARCHAR (MAX) NULL,
    [DateOfOffset]       DATETIME2 (7)  NOT NULL,
    [DateOfOffset1]      DATETIME2 (7)  NOT NULL,
    [DateOfOffset2]      DATETIME2 (7)  NOT NULL,
    [DateOfExamination]  DATETIME2 (7)  NOT NULL,
    [DateOfExamination1] DATETIME2 (7)  NOT NULL,
    [DateOfExamination2] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Groups_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Groups_StudentId]
    ON [dbo].[Groups]([StudentId] ASC);
