CREATE TABLE [dbo].[documents] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [folderID]     INT            NOT NULL,
    [name]         NVARCHAR (150) NULL,
    [description]  NVARCHAR (MAX) NULL,
    [creator]      NVARCHAR (150) CONSTRAINT [DF_documents_creator] DEFAULT (suser_sname()) NOT NULL,
    [creationDate] DATETIME       CONSTRAINT [DF_documents_creationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_documents] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_documents_folders] FOREIGN KEY ([folderID]) REFERENCES [dbo].[folders] ([id])
);



