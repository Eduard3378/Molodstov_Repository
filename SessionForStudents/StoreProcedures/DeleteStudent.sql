CREATE PROCEDURE [dbo].[DeleteStudent]
	@id int
AS
Begin
	Delete from [dbo].Students
	Where Id = @id
End
