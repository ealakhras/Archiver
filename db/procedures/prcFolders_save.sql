CREATE PROCEDURE [dbo].[prcFolders_save]
	@id int = null,
	@parentID int = null,
	@name nvarchar(150) = null,
	@description nvarchar(MAX) = null
AS

	if (isnull(@id, 0) = 0)
	begin
		-- insert records:
		insert into folders(parentID, name, description)
			select
				case isnull(@parentID, 0) when 0 then null else @parentID end,
				@name,
				@description;

		set @id = @@IDENTITY;

	end else begin
		-- update record:
		update folders set
				parentID = isnull(@parentID, parentID),
				name = isnull(@name, name),
				description = isnull(@description, description)
			where
				id = @id;
	end;

	-- return changes:
	select
		f.id,
		f.parentID,
		f.name,
		f.description,
		f.creator,
		f.creationDate
	from
		folders f
	where
		f.id = @id;
