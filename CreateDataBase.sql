create database CSSO;
go
use CSSO;
go
Create table TypeAssets
(
TypeAssetsID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
NameAssets [varchar](128) Not NULL
)
go
Create table Location
(
LocationID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
NameLocation [varchar](128) Not NULL
)
go
Create table AssetsStatus
(
AssetsStatusID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
NameAssetsStatus [varchar](128) Not NULL
)
go
create table Assets
(
	AssetsID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TypeAssets [smallint] REFERENCES TypeAssets(TypeAssetsID),
	Location [smallint] REFERENCES Location(LocationID),
	AssetsStatus [smallint] REFERENCES AssetsStatus(AssetsStatusID),	
	InventoryNumber	 [varchar](32) Not NULL,
	Info [varchar](128)  NULL
)
go
Create table Movies
(
MoviesID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
NameMovies [varchar](128) Not NULL
)
go
Create table RolesUsers
(
RolesUsersID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
NameRolesUsers [varchar](128) Not NULL
)
go
Create table Users
(
UsersID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserLogin [varchar](128) Not NULL,
UserPassword [varchar](128) Not NULL,
RolesUser [smallint] REFERENCES RolesUsers(RolesUsersID),
FIO [varchar](128) Not NULL,
)
go

Create table MoviesAssets
(
MoviesAssetsID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
Movies [smallint] REFERENCES Movies(MoviesID),
DateMovies [Date] Not null,
UserWhyMovie [smallint] REFERENCES Users(UsersID),
Assets [smallint] REFERENCES Assets(AssetsID),
)