create PROCEDURE [dbo].[prcFieldsValues_delete]
	@documentID int,
	@fieldID int
AS
	delete fieldsValues
		where
			documentID = @documentID
			and fieldID = @fieldID;