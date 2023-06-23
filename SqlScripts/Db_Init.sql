/*Admin service db*/
USE AdminServiceDb;
CREATE TABLE [PairQrCodes] (
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[CreateDate] [DateTime] NOT NULL,
	[PresenterDataBase64] [varchar](max) NULL,
	[ReceiverDataBase64] [varchar](max) NULL,
	[UniqKey] [uniqueidentifier] NOT NULL UNIQUE
)
GO

--select * from [PairQrCodes]
--drop table [PairQrCodes]

/*Presenter service db*/
USE PresenterServiceDb;
CREATE TABLE Presenter (
	[Id] [uniqueidentifier] PRIMARY KEY,
	[Name] [varchar](max) NULL,
	[PhoneNumber] [varchar](13) NULL,
	[UniqKey] [uniqueidentifier] UNIQUE NOT NULL
)
GO

CREATE TABLE Meme (
	[Id] [uniqueidentifier] PRIMARY KEY NOT NULL FOREIGN KEY REFERENCES dbo.Presenter(Id),
	Text—ongratulations [varchar](200) NULL,
	[VideoId] [uniqueidentifier] NULL,
)
GO

--select * from Presenter
--select * from Meme

--drop table Presenter
--drop table Meme

/*Receiver service db*/
USE ReceiverServiceDb;
CREATE TABLE Receiver ( 
	[Id] [uniqueidentifier] PRIMARY KEY,
	[Name] [varchar](max) NULL,
	[SurpriseDate] [datetime2] NULL,
	[PhoneNumber] [varchar](13) NULL,
	[UniqKey] [uniqueidentifier] UNIQUE NOT NULL
)
GO

CREATE TABLE Meme (
	[Id] [uniqueidentifier] PRIMARY KEY NOT NULL FOREIGN KEY REFERENCES dbo.Receiver(Id),
	[Text—ongratulations] [varchar](200) NULL,
	[VideoId] [uniqueidentifier] NULL,
)
GO

--select * from Receiver
--select * from Meme

--drop table Receiver
--drop table Meme

update Receiver
set [Name] = '–ÓÏ‡Ì'
where Id = '8ABCB818-F54B-4EB7-9EC3-D9FC6CD605AD'