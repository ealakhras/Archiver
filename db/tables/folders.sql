CREATE TABLE [dbo].[folders] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [parentID]     INT            NULL,
    [name]         NVARCHAR (150) NOT NULL,
    [description]  NVARCHAR (MAX) NULL,
	[imageIndex] INT NOT NULL DEFAULT 2, 
    [creator]      NVARCHAR (150) DEFAULT (suser_sname()) NOT NULL,
    [creationDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


