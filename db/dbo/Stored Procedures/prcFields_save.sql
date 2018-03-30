CREATE PROCEDURE dbo.prcFields_save
	@id int = null,
	@folderID int = null,
	@name nvarchar(150) = null,
	@description nvarchar(MAX) = null,
	@type nchar(1) = null,
	@defVal nvarchar(150) = null,
	@ord int = null
AS
	if (isnull(@id, 0) = 0)
	begin
		-- insert records:
		insert into fields(folderID, name, description, type, defval, ord)
			select
				@folderID,
				@name, 
				@description,
				@type,
				@defVal,
				@ord;

		set @id = @@IDENTITY;

	end else begin
		-- update record:
		update fields set
				folderID = isnull(@folderID, folderID),
				name = isnull(@name, name),
				description = isnull(@description, description),
				type = isnull(@type, type),
				defVal = isnull(@defVal, defVal),
				ord = isnull(@ord, ord)
			where
				id = @id;
	end;

	-- return changes:
	select
		f.id,
		f.folderID,
		f.name,
		f.description,
		f.type,
		f.ord,
		f.defval,
		f.creator,
		f.creationDate
	from
		fields f
	where
		f.id = @id;