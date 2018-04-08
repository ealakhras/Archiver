CREATE TABLE [dbo].[fieldsValues] (
    [documentID] INT            NOT NULL,
    [fieldID]    INT            NOT NULL,
    [value]      NVARCHAR (MAX) NULL,
    CONSTRAINT [FK_fieldsValues_documents] FOREIGN KEY ([documentID]) REFERENCES [dbo].[documents] ([id]),
    CONSTRAINT [FK_fieldsValues_fields] FOREIGN KEY ([fieldID]) REFERENCES [dbo].[fields] ([id])
);



