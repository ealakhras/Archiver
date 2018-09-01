use archiver

-- insert lovs:
set identity_insert lovs on;
insert into lovs(id, name, vals)
	select d.ArcId, 'المحافظات', d.ArcValue from financeSyria..TblDesign d where d.arcAttr = 'ITM' order by d.ArcId;
set identity_insert lovs off;

--
-- add lovID to fields
--

-- clear way:
delete fieldsValues;
delete fields;
delete documents;
delete folders;

-- add folders from tblTree
set identity_insert folders on;
insert into folders(id, parentID, name)
	select
		case t.ArcId when -1 then 0 else t.ArcId end, -- id
		case t.ArcParentId when -2 then null when -1 then 0 else t.ArcParentId end, -- parentID
		t.ArcName
	from
		financeSyria..TblTree t
	order by
		t.ArcId;

-- update root name from tblProjects:
update folders set
		name = (select p.ArcTitle from financeSyria..TblProjects p)
	where id = 0;

set identity_insert folders off;


-- now for fields:
set identity_insert fields on;
insert into fields(id, folderID, name, type, width, lovID, ord)
	select
		d.arcObjectID, -- id
		0, -- folderID: root
		d.ArcValue, -- name
		case (select left(dt.ArcValue, 1) from financeSyria..TblDesign dt where dt.arcAttr = 'DB NAME' and dt.arcObjectID = d.arcObjectID)
				when 'S' then 'N'
				when 'D' then 'D'
				when 'C' then 'L'
				when 'M' then 'T'
			end, -- type
		(select convert(integer, dw.ArcValue) / 15 from financeSyria..TblDesign dw where dw.arcAttr = 'WDTH' and dw.arcObjectID = d.arcObjectID), -- width
		null, --(select convert(integer, dw.ArcValue) / 15 from financeSyria..TblDesign dw where dw.arcAttr = 'WDTH' and dw.arcObjectID = d.arcObjectID), -- lovID
		d.arcObjectID -- ord
	from
		financeSyria..TblDesign d
	where
		d.arcAttr = 'FLD NM'
	order by
		d.arcType;

set identity_insert fields off

-- now documents:
set identity_insert documents on
insert into documents(id, folderID)
	select d.arcID, case td.arcNodeID when -1 then 0 else td.arcNodeID end
	from financeSyria..tblDocuments d inner join financeSyria..tblTreeDocuments td on d.arcID = td.arcDocID;
set identity_insert documents off


-- now for fieldsValues:
insert into fieldsValues(documentID, fieldID, value)
	select
		d.arcID,
		(select arcObjectID from financeSyria..tblDesign ds where ds.arcValue = 'S1' and ds.arcAttr = 'DB NAME'),
		d.s1
	from
		financeSyria..tblDocuments d

	union all select
		d.arcID,
		(select arcObjectID from financeSyria..tblDesign ds where ds.arcValue = 'D1' and ds.arcAttr = 'DB NAME'),
		d.d1
	from
		financeSyria..tblDocuments d

	union all select
		d.arcID,
		(select arcObjectID from financeSyria..tblDesign ds where ds.arcValue = 'C1' and ds.arcAttr = 'DB NAME'),
		d.C1
	from
		financeSyria..tblDocuments d

	union all select
		d.arcID,
		(select arcObjectID from financeSyria..tblDesign ds where ds.arcValue = 'M1' and ds.arcAttr = 'DB NAME'),
		d.m1
	from
		financeSyria..tblDocuments d;

set identity_insert images on;

insert into images(id, documentID, description, fileName, notesDetails, data)
	select
		f.arcID,
		f.arcDocID,
		f.arcNote,
		f.arcFileName,
		f.arcNoteDet,
		cast('' as varbinary(max))
--		(select * from openrowset(bulk 'd:\work\archiver\db' + f.arcFileName, single_blob) x
	from
		financeSyria..tblFiles f;

set identity_insert images off;

truncate table images


select * from folders
select * from fields
select * from documents
select * from images