CREATE function [dbo].[fn_fields_inheritsFrom](@folderID int) returns int
as begin
	declare @result int;
	declare @parentID int
	declare @inheritsFields bit
	
	select
		@result = f.ID,
		@parentID = f.parentID,
		@inheritsFields = f.inheritsFields
	from
		folders f
	where
		f.id = @folderID;

	if (@inheritsFields != 0)
		set @result = dbo.fn_fields_inheritsFrom(@parentID);

	return @result;
end