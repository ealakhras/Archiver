CREATE PROCEDURE dbo.prcDocuments_delete
	@id int
AS
	delete documents where id = @id;