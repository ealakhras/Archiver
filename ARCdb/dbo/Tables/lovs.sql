CREATE TABLE [dbo].[lovs] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (50)  NOT NULL,
    [vals]         TEXT           NULL,
    [description]  NVARCHAR (250) NULL,
    [creator]      NVARCHAR (150) CONSTRAINT [DF_lovs_creator] DEFAULT (suser_sname()) NOT NULL,
    [creationDate] DATETIME       CONSTRAINT [DF__lovs__creationDa__6B24EA82] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__lovs__3213E83FD2984549] PRIMARY KEY CLUSTERED ([id] ASC)
);



