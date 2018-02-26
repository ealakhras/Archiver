CREATE PROCEDURE [dbo].[prcFolders_update]
	@id int,
	@parentID int = null,
	@name nvarchar(150) = null,
	@description nvarchar(MAX) = null
AS
	-- update record:
	update folders set
			parentID = isnull(@parentID, parentID),
			name = isnull(@name, name),
			description = isnull(@description, description)
		where
			id = @id;

	-- return changed:
	select
		f.id,
		f.parentID,
		f.name,
		f.description,
		f.creator,
		f.creationDate
	from
		folders f
	where
		f.id = @id;
