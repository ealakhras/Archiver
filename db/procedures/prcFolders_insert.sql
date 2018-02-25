CREATE PROCEDURE [dbo].[prcFolders_insert]
	@parentID int = null,
	@name nvarchar(150),
	@description nvarchar(150) = null
AS
	declare @id int;

	insert into folders(parentID, name, description)
		select @parentID, @name, @description;

	set @id = @@IDENTITY;

	return @id;




select * from folders