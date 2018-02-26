CREATE PROCEDURE [dbo].[prcFolders_select]
	@id int = 0,
	@parentID int = 0

AS
	select
		f.id,
		f.parentID,
		f.name,
		f.description,
		f.creator,
		f.creationDate
	from folders f
	where
		(f.id = @id or @id = 0)
		and (f.parentID = @parentID or @parentID = 0);

