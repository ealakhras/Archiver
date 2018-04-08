create procedure [dbo].[prcFieldsValues_read]
	@documentID int = 0,
	@folderID int = 0
as
	select
		fv.documentID,
		fv.fieldID,
		fv.value
	from
		fieldsValues fv --inner join fields f on fv.fieldID = f.id
	where
		(@folderID = 0 and (@documentID = 0 or fv.documentID = @documentID))
		or (@folderID != 0 and fv.documentID in (
								select d.id 
								from documents d
								where d.folderID = @folderID)
								)
	order by
		fv.documentID,
		fv.fieldID;
		--f.ord;