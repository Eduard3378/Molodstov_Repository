CREATE PROCEDURE [dbo].[CreateStudent]
	@lastname nvarchar(max)
AS
Begin
	INSERT INTO Students(Lastname)
		VALUES(@lastname)
end
