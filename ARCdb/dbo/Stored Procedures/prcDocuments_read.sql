CREATE procedure dbo.prcDocuments_read
	@id int = 0,
	@folderID int = 0
AS
	select
		d.id,
		d.folderID,
		d.description,
		d.creator,
		d.creationDate
	from
		documents d
	where
		(@id = 0 or d.id = @id)
		and (@folderID = 0 or d.folderID = @folderID)
	order by
		d.id;