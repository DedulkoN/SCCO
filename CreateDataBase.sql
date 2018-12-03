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
Create table Moves
(
MovesID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
NameMoves [varchar](128) Not NULL
)
go
Create table RoleUsers
(
RoleUserID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
NameRoleUser [varchar](128) Not NULL
)
go
Create table Users
(
UsersID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserLogin [varchar](128) Not NULL,
UserPassword [varchar](128) Not NULL,
RolesUser [smallint] REFERENCES RoleUsers(RoleUserID),
FIO [varchar](128) Not NULL,
)
go

Create table MovesAssets
(
MoviesAssetsID [smallint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
Moves [smallint] REFERENCES Moves(MovesID),
DateMoves [Date] Not null,
UserWhyMove [smallint] REFERENCES Users(UsersID),
Assets [smallint] REFERENCES Assets(AssetsID),
)