create PROCEDURE [dbo].[prcFields_delete]
	@id int
AS
	delete fields where id = @id;