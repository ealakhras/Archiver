CREATE procedure [dbo].[prcFieldsValues_read]
	@documentID int = null,
	@folderID int = null
as
	select
		fv.documentID,
		fv.fieldID,
		fv.value
	from
		fieldsValues fv inner join fields f on fv.fieldID = f.id
	where
		(@folderID is null and (@documentID is null or fv.documentID = @documentID))
		or (@folderID is not null and fv.documentID in (
								select d.id 
								from documents d
								where d.folderID = @folderID)
								)
	order by
		fv.documentID,
		--fv.fieldID,
		f.ord;