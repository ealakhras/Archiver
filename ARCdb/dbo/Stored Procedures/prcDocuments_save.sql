CREATE PROCEDURE [dbo].[prcDocuments_save]
	@id int = null,
	@folderID int = null,
	@description nvarchar(MAX) = null,
	@fieldsValues typ_documentsFieldsValuesTable readonly
AS
	if (isnull(@id, 0) = 0)
	begin
		-- insert records:
		insert into documents(folderID, description)
			select
				@folderID,
				@description;

		set @id = @@IDENTITY;

	end else begin
		-- update record:
		update fields set
				folderID = isnull(@folderID, folderID),
				description = isnull(@description, description)
			where
				id = @id;
	end;

	-- insert fieldsValues, if any:
	if exists(select * from @fieldsValues) begin
		-- delete existing:
		delete fieldsValues where documentID = @id;

		-- insert fieldsValues:
		insert into fieldsValues(documentID, fieldID, value)
			select @id, fv.fieldID, fv.value
			from @fieldsValues fv;
	end

	exec prcDocuments_read @id = @id;