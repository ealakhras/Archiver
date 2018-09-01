use financeSyria

-- misc:
select * from TblPrivileges;
select * from TblSettings;
select * from TblProductivity;
select * from TblProjects;
select * from TblGroupSecurity;

-- empty
select * from TblBookMarks;
select * from TblDesignItems;
select * from TblGroupAudit;
select * from TblReplaceItems;
select * from TblShortcuts;
select * from TblUserQuery;

-- to be imported:
select * from TblTree; -- folders
select * from TblDesign where arcAttr = 'DB NAME';
select * from TblDocuments 
select * from TblFiles;
select * from TblProjects;
select * from TblTreeDocuments;
