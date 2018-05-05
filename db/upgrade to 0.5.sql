/*
this script:
	upgrades db to 0.5
*/

-- correct inheritsFields for root:
update folders set inheritsFields = 0 where id = 0

-- set all fields to root:
update fields set folderID = 0;

-- fix fieldsValues date:
update fieldsValues set
		value = SUBSTRING(value, 1, 4) + '-' + SUBSTRING(value, 5, 2) + '-' + SUBSTRING(value, 7, 2)
	where fieldID = 3;

go

alter procedure [dbo].[prcDocuments_read]
	@id int = null,
	@folderID int = null,
	@withFieldsValues bit = 1
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
		(@id is null or d.id = @id)
		and (@folderID is null or d.folderID = @folderID)
	order by
		d.id;
		
	if (@withFieldsValues != 0) begin
		exec prcFieldsValues_read @documentID = @id, @folderID = @folderID;
	end;

go

alter procedure [dbo].[prcFolders_read]
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

go

alter procedure [dbo].[prcFieldsValues_read]
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

go

alter procedure [dbo].[prcFields_read]
	@id int = null,
	@folderID int = null,
	@showInherited bit = 1
as
	select
		f.id,
		f.folderID,
		f.name,
		f.description,
		f.type,
		f.width,
		f.alignment,
		f.defval,
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
