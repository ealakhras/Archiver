CREATE TABLE [dbo].[fields] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [folderID]     INT            NOT NULL,
    [name]         NVARCHAR (150) NOT NULL,
    [description]  NVARCHAR (MAX) NULL,
    [type]         NCHAR (1)      CONSTRAINT [DF_fields_type] DEFAULT (N'T') NOT NULL,
    [defval]       NVARCHAR (150) NULL,
    [width]        INT            CONSTRAINT [DF_fields_width] DEFAULT ((60)) NOT NULL,
    [alignment]    NCHAR (1)      CONSTRAINT [DF_fields_alignment] DEFAULT (N'L') NOT NULL,
    [lovID]        INT            NULL,
    [ord]          INT            CONSTRAINT [DF_fields_ord] DEFAULT ((0)) NOT NULL,
    [creator]      NVARCHAR (150) CONSTRAINT [DF_fields_creator] DEFAULT (suser_sname()) NOT NULL,
    [creationDate] DATETIME       CONSTRAINT [DF_fields_creationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_fields] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CK_fields_alignment] CHECK ([alignment]=N'C' OR [alignment]=N'R' OR [alignment]=N'L'),
    CONSTRAINT [CK_fields_type] CHECK ([type]='L' OR [type]='Y' OR [type]='D' OR [type]='N' OR [type]='T'),
    CONSTRAINT [FK_fields_folders] FOREIGN KEY ([folderID]) REFERENCES [dbo].[folders] ([id]),
    CONSTRAINT [FK_fields_lovs] FOREIGN KEY ([lovID]) REFERENCES [dbo].[lovs] ([id])
);





