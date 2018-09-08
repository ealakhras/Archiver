CREATE procedure [dbo].[prcDocuments_read]
	@id int = null,
	@folderID int = null,
	@withFieldsValues bit = 1
AS
	select
		d.id,
		d.folderID,
		d.name,
		d.description,
		d.creator,
		d.creationDate
	from
		documents d
	where
		(@id is null or d.id = @id)
		and (@folderID is null or d.folderID = @folderID)
	order by
		d.id;
		
	if (@withFieldsValues != 0) begin
		exec prcFieldsValues_read @documentID = @id, @folderID = @folderID;
	end;