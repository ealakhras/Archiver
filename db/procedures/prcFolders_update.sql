CREATE PROCEDURE [dbo].[prcFolders_update]
	@id int,
	@parentID int = null,
	@description nvarchar(MAX) = null
AS
	-- update record:
	update folders set
			parentID = isnull(@parentID, parentID),
			description = isnull(@description, description)
		where id = @id;

	-- return changed:
	select f.*
	from folders f
	where f.id = @id;
