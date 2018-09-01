CREATE PROCEDURE [dbo].[prcFields_read]
	@id int = null,
	@folderID int = null,
	@showInherited bit = 1
AS
	select
		f.id,
		f.folderID,
		f.name,
		f.description,
		f.type,
		f.width,
		f.alignment,
		f.defval,
		f.lovID,
		f.ord,
		f.creator,
		f.creationDate
	from
		fields f
	where
		(@id is null or f.id = @id)
		and (@folderID is null or @showInherited != 0 or f.folderID = @folderID)
		and (@showInherited = 0 or (f.folderID = dbo.fn_fields_inheritsFrom(@folderID)))
	order by
		f.ord;