USE [master]
GO
if db_id('QLCD') is not null
drop database QLCD
GO
CREATE DATABASE QLCD
GO
USE [QLCD]
GO

create table GiayTo
(
	loaiGiayTo nvarchar(50),
	hinhAnh nvarchar(100),
	cmnd nvarchar(10),
	primary key (loaiGiayTo, cmnd)
)

create table QuanHeGiaDinh
(
	maA nvarchar(10),
	loaiGiayToA nvarchar(10),
	maB nvarchar(10),
	loaiGiayToB nvarchar(10),
	primary key (maA, loaiGiayToA, maB, loaiGiayToB)
)

create table CuDan
(
	hoTen nvarchar(50),
	sdt nvarchar(12),
	loaiGiayTo nvarchar(10),
	cmnd nvarchar(10),
	primary key (loaiGiayTo, cmnd)
)

create table CanHo
(
	maCanHo nvarchar(10),
	maTang nvarchar(10),
	maKhoi nvarchar(10),
	block int,
	dienTich float,
	loaiCanHo nvarchar(20),
	loaiGiayTo nvarchar(10),
	cmnd nvarchar(10),
	primary key (maCanHo)
)

create table LichSuCanHo
(
	ma nvarchar(10),
	ngay datetime, 
	maCanHo nvarchar(10), 
	ghiChu nvarchar(255),
	primary key (ma)
)		

alter table LichSuCanHo add foreign key (maCanHo) references CanHo