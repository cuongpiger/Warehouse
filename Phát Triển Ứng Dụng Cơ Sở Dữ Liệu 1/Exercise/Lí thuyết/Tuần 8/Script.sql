create database ResidentManager
go

use ResidentManager
go

if object_id('dbo.Apartment') is not null
	drop table dbo.Apartment
go
create table Apartment(
	ID int NOT NULL identity(0,1) primary key,
	CategoryID int,
	Acreage float,
	FloorID int,
	BlockID int,
	HostID int,
)

if object_id('dbo.CategoryApartment') is not null
	drop table dbo.CategoryApartment
go
create table CategoryApartment(
	ID int NOT NULL identity(0,1) primary key,
	Name nvarchar(50)
)

if object_id('dbo.Locations') is not null
	drop table dbo.Locations
go
create table Locations(
	FloorID int,
	BlockID int,

	primary key(FloorID, BlockID)
)

if object_id('dbo.Paper') is not null
	drop table dbo.Paper
go
create table Paper(
	ID int NOT NULL identity(0,1) primary key,
	Note nvarchar(255),
	PaperURL varchar(255),
	OwnerID int,
)

if object_id('dbo.Resident') is not null
	drop table dbo.Resident
go
create table Resident(
	ID int NOT NULL identity(0,1) primary key,
	Name nvarchar(50),
	Phone varchar(15),
	IdentityCard varchar(15),
	CardType nvarchar(30),
)

if object_id('dbo.ResidentRelation') is not null
	drop table dbo.ResidentRelation
go
create table ResidentRelation(
	ResidentID_A int,
	ResidentID_B int,
	Relationship nvarchar(30),

	primary key(ResidentID_A, ResidentID_B)
)

if object_id('dbo.Tenancy') is not null
	drop table dbo.Tenancy
go
create table Tenancy(
	ID int NOT NULL identity(0,1) primary key,
	RenterID int,
    HostID int,
    PaperID int,
    StartDate date,
    EndDate date,
)

alter table Apartment
add foreign key (HostID) references Resident(ID)

alter table ResidentRelation
add foreign key (ResidentID_A) references Resident(ID)

alter table ResidentRelation
add foreign key (ResidentID_B) references Resident(ID)

alter table Tenancy
add foreign key (RenterID) references Resident(ID)

alter table Tenancy
add foreign key (HostID) references Resident(ID)

alter table Tenancy
add foreign key (PaperID) references Paper(ID)