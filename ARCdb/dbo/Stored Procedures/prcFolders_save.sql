CREATE PROCEDURE [dbo].[prcFolders_save]
	@id int = null,
	@parentID int = null,
	@name nvarchar(150) = null,
	@description nvarchar(MAX) = null,
	@imageIndex int = null,
	@inheritsFields int = null
AS

	if (isnull(@id, 0) = 0)
	begin
		-- insert records:
		insert into folders(parentID, name, description, imageIndex, inheritsFields)
			select
				case isnull(@parentID, 0) when 0 then null else @parentID end,
				@name,
				@description,
				@imageIndex,
				@inheritsFields;

		set @id = @@IDENTITY;

	end else begin
		-- update record:
		update folders set
				parentID = isnull(@parentID, parentID),
				name = isnull(@name, name),
				description = isnull(@description, description),
				imageIndex = isnull(@imageIndex, imageIndex),
				inheritsFields = isnull(@inheritsFields, inheritsFields)
			where
				id = @id;
	end;

	-- return changes:
	select
		f.id,
		f.parentID,
		f.name,
		f.description,
		f.imageIndex,
		f.inheritsFields,
		f.creator,
		f.creationDate
	from
		folders f
	where
		f.id = @id;
