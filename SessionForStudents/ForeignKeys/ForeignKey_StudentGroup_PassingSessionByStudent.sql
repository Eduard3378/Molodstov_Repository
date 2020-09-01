ALTER TABLE [dbo].[StudentGroups]
	ADD CONSTRAINT  [ForeignKey_StudentGroup_PassingSessionByStudent] 
	FOREIGN KEY ([PassingSessionByStudentId]) 
	REFERENCES [dbo].[PassingSessionByStudents] ([Id]) ON DELETE CASCADE
