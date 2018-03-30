CREATE PROCEDURE [dbo].[prcFolders_delete]
	@id int
AS
	delete folders where id = @id;

