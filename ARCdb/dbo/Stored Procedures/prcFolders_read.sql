CREATE PROCEDURE [dbo].[prcFolders_read]
	@id int = null,
	@parentID int = null
AS
	select
		f.id,
		f.parentID,
		f.name,
		f.description,
		f.imageIndex,
		f.inheritsFields,
		f.creator,
		f.creationDate,
		(select count(*) from folders c where c.parentID = f.id) children
	from
		folders f
	where
		(@id is null or f.id = @id)
		and (@parentID is null or f.parentID = @parentID);

