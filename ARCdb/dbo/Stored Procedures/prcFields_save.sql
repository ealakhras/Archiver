CREATE PROCEDURE [dbo].[prcFields_save]
	@id int = null,
	@folderID int = null,
	@name nvarchar(150) = null,
	@description nvarchar(MAX) = null,
	@type nchar(1) = null,
	@defVal nvarchar(150) = null,
	@width int = null,
	@alignment nchar(1) = null,
	@ord int = null
AS
	if (isnull(@id, 0) = 0)
	begin
		-- insert records:
		insert into fields(folderID, name, description, type, defval, width, alignment, ord)
			select
				@folderID,
				@name, 
				@description,
				@type,
				@defVal,
				@width,
				@alignment,
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
				width = isnull(@width, width),
				alignment = isnull(@alignment, alignment),
				ord = isnull(@ord, ord)
			where
				id = @id;
	end;

	exec prcFields_read @id = @id;