use ResidentManager
go

insert into CategoryApartment
values (N'Bình thường'), (N'Cao cấp')


if OBJECT_ID('sLoadApartment', 'P') is not null
	drop proc sLoadApartment
go
create proc sLoadApartment
as
	select * from Apartment
go

if OBJECT_ID('sLoadCategoryApartment') is not null
	drop proc sLoadCategoryApartment
go
create proc sLoadCategoryApartment
as
	select * from CategoryApartment
go

if OBJECT_ID('sLoadLocations') is not null
	drop proc sLoadLocations
go
create proc sLoadLocations
as
	select distinct(CONCAT(FloorID, '_',BlockID)) as 'flooridblockid' from Locations
go

if OBJECT_ID('sInsertApartment') is not null
	drop proc sInsertApartment
go
create proc sInsertApartment @iLoai int, @iDienTich float, @iTang int, @iKhoi int, @iChuNha int
as
	insert into Apartment
	values (@iLoai, @iDienTich, @iTang, @iKhoi, @iChuNha)
go

if OBJECT_ID('sMaxIDApartment') is not null
	drop proc sMaxIDApartment
go
create proc sMaxIDApartment
as
	select max(id) from Apartment 
go

exec sLoadCategoryApartment

