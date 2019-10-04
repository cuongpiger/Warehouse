use master
go

if (DB_ID ('QLCHUYENBAY')) is not null
	drop database QLCHUYENBAY
go

create database QLCHUYENBAY
go
use QLCHUYENBAY
go

create table KHACHHANG (
	MAKH varchar(4) not null,
	TEN nvarchar(30),
	DCHI nvarchar(30),
	DTHOAI varchar(10),
	constraint PK_KHACHHANG primary key (MAKH),
)

create table DATCHO (
	MAKH varchar(4) not null,
	NGAYDI date not null,
	MACB varchar(4) not null,
	constraint PK_DATCHO primary key (MAKH, NGAYDI, MACB),
)

create table LICHBAY (
	NGAYDI date not null,
	MACB varchar(4) not null,
	SOHIEU varchar(4),
	MALOAI varchar(4),
	constraint PK_LICHBAY primary key (NGAYDI, MACB),
)

create table CHUYENBAY (
	MACB varchar(4) not null,
	SBDI nvarchar(10),
	SBDEN nvarchar(10),
	GIODI time,
	GIODEN time,
	constraint PK_CHUYENBAY primary key (MACB),
)

create table MAYBAY (
	SOHIEU varchar(4) not null,
	MALOAI varchar(4) not null,
	constraint PK_MAYBAY primary key (SOHIEU, MALOAI),
)

create table LOAIMB (
	HANGSX nvarchar(10),
	MALOAI varchar(4) not null,
	constraint PK_LOAIMB primary key (MALOAI),
)

create table KHANANG (
	MANV varchar(4) not null,
	MALOAI varchar(4) not null,
	constraint PK_KHANANG primary key (MANV, MALOAI),
)

create table NHANVIEN (
	MANV varchar(4) not null,
	TEN nvarchar(30),
	DCHI nvarchar(30),
	DTHOAI varchar(10),
	LUONG decimal,
	LOAINV nvarchar(10),
	constraint PK_NHANVIEN primary key (MANV),
)

create table PHANCONG (
	MANV varchar(4) not null,
	NGAYDI date not null,
	MACB varchar(4) not null,
	constraint PK_PHANCONG primary key (MANV, NGAYDI, MACB),
)

alter table DATCHO
add constraint FK_DATCHO_KHACHHANG foreign key (MAKH) references KHACHHANG

alter table DATCHO
add constraint FK_DATCHO_LICHBAY foreign key(NGAYDI, MACB) references LICHBAY(NGAYDI, MACB)

alter table LICHBAY
add constraint FK_LICHBAY_CHUYENBAY foreign key (MACB) references CHUYENBAY

alter table LICHBAY
add constraint FK_LICHBAY_MAYBAY foreign key (SOHIEU, MALOAI) references MAYBAY(SOHIEU, MALOAI)

alter table MAYBAY
add constraint FK_MAYBAY_LOAIMB foreign key (MALOAI) references LOAIMB

alter table KHANANG
add constraint FK_KHANANG_LOAIMB foreign key (MALOAI) references LOAIMB

alter table KHANANG
add constraint FK_KHANANG_NHANVIEN foreign key (MANV) references NHANVIEN

alter table PHANCONG
add constraint FK_KHANG_PHANCONG foreign key (MANV) references NHANVIEN

alter table PHANCONG
add constraint FK_PHANCONG_LICHBAY foreign key (NGAYDI, MACB) references LICHBAY