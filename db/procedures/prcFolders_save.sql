CREATE PROCEDURE [dbo].[prcFolders_save]
	@id int = null,
	@parentID int = null,
	@name nvarchar(150) = null,
	@description nvarchar(MAX) = null
AS

	if (@id is null)
	begin
		-- insert records:
		insert into folders(parentID, name, description)
			select @parentID, @name, @description;

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
