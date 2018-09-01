CREATE TABLE [dbo].[images] (
    [id] INT IDENTITY (1, 1) NOT NULL,
	[guid] UNIQUEIDENTIFIER UNIQUE NOT NULL ROWGUIDCOL default newid(),
	[documentID]   INT,
    [name]         NVARCHAR (150),
    [description]  NVARCHAR (MAX),
    [data]         VARBINARY(MAX) filestream,
    [thumbnail]    IMAGE,
    [fileName]    NVARCHAR (255),
    [notesDetails] NTEXT         ,
    [ord]          INT            CONSTRAINT [DF_images_ord] DEFAULT ((0)) NOT NULL,
    [creator]      NVARCHAR (150) CONSTRAINT [DF_images_creator] DEFAULT (suser_sname()) NOT NULL,
    [creationDate] DATETIME       CONSTRAINT [DF_images_creationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_images_documents] FOREIGN KEY ([documentID]) REFERENCES [dbo].[documents] ([id])
);