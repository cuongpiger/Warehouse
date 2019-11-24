create database QUAN_LI_CHUNG_CU
go

create table CuDan (
	ten nvarchar(30) not null,
	sdt char(10),
	maCongDan varchar(12) primary key
);

create table TheCD (
	maThe varchar(12) foreign key references CuDan(maCongDan),
	loaiThe nvarchar(12)
);

create table CanHo (
	maCanHo varchar(10) primary key,
	maChuHo varchar(12) foreign key references CuDan(maCongDan),
	dienTich float,
	loaiCanHo nvarchar(15),
	maTang int,
	maKhoi int
);

create table NguoiThan (
	maChuHo varchar(12),
	maNguoiThan varchar(12),
	quanHe nvarchar(10),

	primary key (maChuHo, maNguoiThan)
);

create table GiayTo(
	maGiayTo varchar(10),
	maCuDan varchar(12) foreign key references CuDan(maCongDan),
	maCanHo varchar(10) foreign key references CanHo(maCanHo)
);

create table Thue (
	maCanHo varchar(10) foreign key references CanHo(maCanHo),
	giayTamTruTamVang nvarchar(50),
	maCuDan varchar(12) foreign key references CuDan(maCongDan)
);

create table PhiCanHo(
	maBienLai varchar(10) primary key,
	maCanHo varchar(10) foreign key references CanHo(maCanHo),
	chiPhi money,
	phiCoBan money,
);

create table DiaDiem(
	maTang varchar(10),
	maKhoi varchar(10),
	primary key (maTang, maKhoi),
);

create table TaiSan (
	maTaiSan varchar(10) primary key,
	loaiTaiSan nvarchar(20),
	tinhTrang nvarchar(30),
	tenSanPham nvarchar(15),
	ngayMua date,
	hanBaoHanh int,
	maCanHo varchar(10) foreign key references CanHo(maCanHo)
);

create table BienBanHuHongTaiSan(
	donViSuaChua nvarchar(20),
	ngayHong date,
	chiPhi money,
	ngaySua date,
	ngaySuaXong date,
	maBienBan varchar(10) primary key,
	maTaiSan varchar(10) foreign key references TaiSan(maTaiSan)
);

create table KhieuNai(
	maKhieuNai varchar(10) primary key,
	maCuDan varchar(12),
	ngay date,
	tieuDe nvarchar(30),
	noiDung nvarchar(30),
);

ALTER TABLE KhieuNai
ADD FOREIGN KEY (maCuDan) REFERENCES CuDan(maCongDan);