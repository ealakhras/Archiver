CREATE TABLE [dbo].[lovs] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (50)  NOT NULL,
    [vals]         TEXT           NULL,
    [description]  NVARCHAR (250) NULL,
    [creationDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

