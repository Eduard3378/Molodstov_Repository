ALTER TABLE [dbo].[StudentGroups]
	ADD CONSTRAINT [ForeignKey_StudentGroup_Student]
	FOREIGN KEY (StudentId)
	REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
