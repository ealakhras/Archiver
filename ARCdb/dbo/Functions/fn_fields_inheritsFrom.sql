create function [dbo].[fn_fields_inheritsFrom](@folderID int) returns int
as begin
	declare @result int;
	declare @parentID int
	declare @inheritsFields bit
	
	if (@folderID = 0)
	begin
		set @result = 0;
	end else begin
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
	end
	return @result;
end