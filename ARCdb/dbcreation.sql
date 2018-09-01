create database archiver on
	primary (name=N'archiver', filename=N'd:\work\archiver\db\archiver.mdf'),
	filegroup archiver_fs contains filestream(name=N'archiver_fs', filename=N'd:\work\archiver\db\fs')
	log on (name=N'archiver_log', filename=N'd:\work\archiver\db\archiver.ldf')

GO

ALTER DATABASE [archiver] SET FILESTREAM( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = N'fs' ) 

GO

-- insert into images(name, data) select 'adnan', * from openrowset(bulk 'd:\adnan photo.jpg', single_blob) x
