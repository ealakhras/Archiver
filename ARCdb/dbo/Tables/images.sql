CREATE TABLE [dbo].[images] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [documentID]   INT            NOT NULL,
    [notes]        NVARCHAR (MAX) NULL,
    [data]         IMAGE          NULL,
    [creator]      NVARCHAR (150) CONSTRAINT [DF_images_creator] DEFAULT (suser_sname()) NOT NULL,
    [creationDate] DATETIME       CONSTRAINT [DF_images_creationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_images_documents] FOREIGN KEY ([documentID]) REFERENCES [dbo].[documents] ([id])
);

