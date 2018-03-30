create PROCEDURE [dbo].[prcFields_read]
	@id int = 0,
	@folderID int = 0
AS
	select
		f.id,
		f.folderID,
		f.name,
		f.description,
		f.type,
		f.ord,
		f.defval,
		f.creator,
		f.creationDate
	from
		fields f
	where
		(f.id = @id or @id = 0)
		and (f.folderID = @folderID or @folderID = 0)

	order by
		f.ord;