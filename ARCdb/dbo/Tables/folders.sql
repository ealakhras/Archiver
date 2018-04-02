CREATE TABLE [dbo].[folders] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [parentID]       INT            NULL,
    [name]           NVARCHAR (150) NOT NULL,
    [description]    NVARCHAR (MAX) NULL,
    [imageIndex]     INT            CONSTRAINT [DF__tmp_ms_xx__image__36B12243] DEFAULT ((2)) NOT NULL,
    [inheritsFields] BIT            CONSTRAINT [DF_folders_inheritsFields] DEFAULT ((0)) NOT NULL,
    [creator]        NVARCHAR (150) CONSTRAINT [DF__tmp_ms_xx__creat__37A5467C] DEFAULT (suser_sname()) NOT NULL,
    [creationDate]   DATETIME       CONSTRAINT [DF__tmp_ms_xx__creat__38996AB5] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__3213E83F5A37D9E2] PRIMARY KEY CLUSTERED ([id] ASC)
);




