CREATE TABLE [dbo].[SNPForSubjects] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [GroupId]                   INT            NOT NULL,
    [SessionId]                 INT            NOT NULL,
    [GroupDateOfOffsetId]       INT            NOT NULL,
    [DateOfOffset]              DATETIME2 (7)  NOT NULL,
    [SNPOfOffset]               NVARCHAR (MAX) NULL,
    [GroupDateOfOffset1Id]      INT            NOT NULL,
    [DateOfOffset1]             DATETIME2 (7)  NOT NULL,
    [SNPOfOffset1]              NVARCHAR (MAX) NULL,
    [GroupDateOfOffset2Id]      INT            NOT NULL,
    [DateOfOffset2]             DATETIME2 (7)  NOT NULL,
    [SNPOfOffset2]              NVARCHAR (MAX) NULL,
    [GroupDateOfExaminationId]  INT            NOT NULL,
    [DateOfExamination]         DATETIME2 (7)  NOT NULL,
    [SNPOfExamination]          NVARCHAR (MAX) NULL,
    [GroupDateOfExamination1Id] INT            NOT NULL,
    [DateOfExamination1]        DATETIME2 (7)  NOT NULL,
    [SNPOfExamination1]         NVARCHAR (MAX) NULL,
    [GroupDateOfExamination2Id] INT            NOT NULL,
    [DateOfExamination2]        DATETIME2 (7)  NOT NULL,
    [SNPOfExamination2]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SNPForSubjects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SNPForSubjects_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SNPForSubjects_Sessions_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Sessions] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_SNPForSubjects_GroupId]
    ON [dbo].[SNPForSubjects]([GroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SNPForSubjects_SessionId]
    ON [dbo].[SNPForSubjects]([SessionId] ASC);

