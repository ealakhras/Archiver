CREATE TABLE [dbo].[images] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [documentID]   INT            NOT NULL,
    [name]         NVARCHAR (150) NULL,
    [description]  NVARCHAR (MAX) NULL,
    [data]         IMAGE          NULL,
    [thumbnail]    IMAGE          NULL,
    [creator]      NVARCHAR (150) CONSTRAINT [DF_images_creator] DEFAULT (suser_sname()) NOT NULL,
    [creationDate] DATETIME       CONSTRAINT [DF_images_creationDate] DEFAULT (getdate()) NOT NULL,
    [fileName1]    NVARCHAR (255) NULL,
    [fileName2]    NVARCHAR (255) NULL,
    [notesDetails] NTEXT          NULL,
    [ord]          INT            CONSTRAINT [DF_images_ord] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_images_documents] FOREIGN KEY ([documentID]) REFERENCES [dbo].[documents] ([id])
);







