CREATE PROCEDURE [dbo].[UpdateStudent]
	@id int,
	 @lastname nvarchar(max) 
AS
Begin
	Update Students
			set Lastname = @lastname
			where id=@id;
End
