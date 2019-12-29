use master
go
if db_id('CN1') is not null
	drop database CN1
GO
create database CN1--Chi nhánh 1
go
use CN1
create table KhachHang
(
	MaKhachHang varchar(20) primary key,
	Ho nvarchar(100),
	Ten nvarchar(100),
	NgaySinh int,
	ThangSinh int,
	NamSinh int,
	ThoiGian datetime,
	TrangThai int
)

create table HoaDon
(
	MaHoaDon varchar(20) primary key,
	MaKhachHang varchar(20),
	SanPham varchar(200),
	SoLuong int,
	DonGia money,
	ThoiGian datetime,
	TrangThai int
)

alter table HoaDon
add foreign key (MaKhachHang) references KhachHang(MaKhachHang)


if db_id('CN2') is not null
	drop database CN2
GO
create database CN2--Chi nhánh 2
go
use CN2
go
create table HoaDon
(
	MaHoaDon varchar(20) primary key,
	MaKhachHang varchar(20),
	SanPham varchar(200), 
	HoTen varchar(200),
	NgaySinh datetime, -- ngay thang nam
	SoLuong int,
	DonGia money,
	ThoiGian datetime,--thời gian tương tác
	TrangThai int -- status = 0, enable = false(is deleted)
)
if db_id('DW') is not null
	drop database DW
GO
create database DW
go
Use DW
go
create table DW_KhachHang
(
	MaKhachHang varchar(20), 
	MaNguon int,-- mã nguồn dữ liệu
	HoTen varchar(200),
	NgaySinh datetime, -- ngay thang nam
	primary key (MaKhachHang, MaNguon)
)
go

go
create table DW_HoaDon
(
	MaHoaDon varchar(20),
	MaNguon int, -- mã nguồn dữ liệuMaKhachHang
	MaKhachHang varchar(20),
	SanPham varchar(200),
	SoLuong int,
	DonGia money
	primary key (MaHoaDon,MaNguon)
)

alter table DW_HoaDon
add foreign key (MaKhachHang, MaNguon) references DW_KhachHang(MaKhachHang, MaNguon)

create table ThoiGianRutTrichHoaDon -- CURRENT_TIMESTAMP
(
	NguonDuLieu int,--Ma nguon
	ThoiGian datetime
)

create table ThoiGianRutTrichKhachHang -- CURRENT_TIMESTAMP
(
	NguonDuLieu int,--Ma nguon
	ThoiGian datetime
)


create table KhachHang_ChiNhanh1
(
	MaKhachHang varchar(20) primary key,
	Ho nvarchar(100),
	Ten nvarchar(100),
	NgaySinh int,
	ThangSinh int,
	NamSinh int,
	ThoiGian datetime,
	TrangThai int
)

create table HoaDon_ChiNhanh1
(
	MaHoaDon varchar(20) primary key,
	MaKhachHang varchar(20),
	SanPham varchar(200),
	SoLuong int,
	DonGia money,
	ThoiGian datetime,
	TrangThai int
)

create table HoaDon_ChiNhanh2
(
	MaHoaDon varchar(20) primary key,
	MaKhachHang varchar(20),
	SanPham varchar(200),
	HoTen varchar(200),
	NgaySinh datetime, -- ngay thang nam
	SoLuong int,
	DonGia money,
	ThoiGian datetime,--thời gian tương tác
	TrangThai int -- status = 0, enable = false(is deleted)
)
 
--======================================================== Thêm khách hàng cn1

use CN1
go
insert into KhachHang
values ('0', 'Nguyen', 'Tam', 6, 9, 1999, CURRENT_TIMESTAMP, 1)
insert into KhachHang
values ('1', 'Nguyen', 'Tam', 6, 9, 1999, CURRENT_TIMESTAMP, 0)
insert into KhachHang
values ('2', 'Nguyen', 'Tam', 6, 9, 1999, CURRENT_TIMESTAMP, 1)


--========================================================= Thêm hóa đơn cn1
use CN1
go

insert into HoaDon
values ('0', '0', 'Hoa don 1', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('1', '0', 'Hoa don 2', 69, 5000, CURRENT_TIMESTAMP, 0)
insert into HoaDon
values ('2', '0', 'Hoa don 3', 69, 5000, CURRENT_TIMESTAMP, 1)


--=========================================================== Thêm dữ liệu vào hóa đơn chi nhánh 2
use CN2
go

insert into HoaDon
values ('0', '0', 'HoaDon0001', 'KhachHang0001', '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('1', '1', 'HoaDon0002', 'KhachHang0001' , '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 0)
insert into HoaDon
values ('2', '2', 'HoaDon0003', 'KhachHang0001', '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)



--=========================================================== Thêm dữ liệu vào hóa đơn chi nhánh 2
--------------------------------------------------------------------Chức năng của DW-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------<<<<<<<<<<<<<LOAD>>>>>>>>>>>>>>----------------------------------------------------------------------
--================================================================= Load Khách hàng từ CN1 vào DW========================================================================
use DW
go

if OBJECT_ID('LoadKhachHangFromCN1', 'P') is not null
	drop proc LoadKhachHangFromCN1
go
create proc LoadKhachHangFromCN1 @startTime datetime, @endTime datetime
as
begin
	insert into KhachHang_ChiNhanh1
	select * from [1MND96SQAVBY2WX].[CN1].[dbo].[KhachHang] as KhachHangCN1
	where KhachHangCN1.ThoiGian >= @startTime and KhachHangCN1.ThoiGian <= @endTime
	order by thoigian
	insert into ThoiGianRutTrichKhachHang
	values (1, CURRENT_TIMESTAMP)

	delete 
	from [1MND96SQAVBY2WX].[CN1].[dbo].[KhachHang]
	where  trangthai = 0 and ThoiGian >= @startTime and ThoiGian <= @endTime
end
go


--================================================================== Load Hóa đơn từ CN1 vào DW==========================================================================
use DW
go

if OBJECT_ID('LoadHoaDonFromCN1', 'P') is not null
	drop proc LoadHoaDonFromCN1
go
create proc LoadHoaDonFromCN1 @startTime datetime, @endTime datetime
as
begin
	insert into HoaDon_ChiNhanh1
	select * from [1MND96SQAVBY2WX].[CN1].[dbo].[HoaDon] as HoaDonCN1
	where HoaDonCN1.ThoiGian >= @startTime and HoaDonCN1.ThoiGian <= @endTime
	order by thoigian
	insert into ThoiGianRutTrichHoaDon
	values (1, CURRENT_TIMESTAMP)

	delete 
	from [1MND96SQAVBY2WX].[CN1].[dbo].[HoaDon]
	where trangthai = 0 and ThoiGian >= @startTime and ThoiGian <= @endTime
end
go

--=================================================================== Load Hóa đơn từ Chi Nhánh 2 vào DW=========================================================================
use DW
go

if OBJECT_ID('LoadHoaDonFromCN2', 'P') is not null
	drop proc LoadHoaDonFromCN2
go
create proc LoadHoaDonFromCN2 @startTime datetime, @endTime datetime
as
begin
	insert into HoaDon_ChiNhanh2
	select * from [1MND96SQAVBY2WX].[CN2].[dbo].[HoaDon] as HoaDonCN2
	where HoaDonCN2.ThoiGian >= @startTime and HoaDonCN2.ThoiGian <= @endTime
	order by thoigian
	insert into ThoiGianRutTrichKhachHang
	values (2, CURRENT_TIMESTAMP)

	insert into ThoiGianRutTrichHoaDon
	values (2, CURRENT_TIMESTAMP)

	delete 
	from [1MND96SQAVBY2WX].[CN2].[dbo].[HoaDon]
	where TrangThai = 0 and ThoiGian >= @startTime and ThoiGian <= @endTime
end
go


--================================================================= Đổ dữ liệu từ chi nhánh 1 vào dữ liệu chính================================================================================
create proc DoDulieuCN1ToDW
as
begin
	----insert khách hàng mới
	insert into DW_KhachHang
	select KhachHangCN1.MaKhachHang, 1, CONCAT(KhachHangCN1.Ho, ' ', KhachHangCN1.Ten), 
		   CAST(CONCAT(cast(KhachHangCN1.ThangSinh as varchar), '-',cast(KhachHangCN1.NgaySinh as varchar), '-', cast(KhachHangCN1.NamSinh as varchar)) as datetime)  
	from KhachHang_ChiNhanh1 as KhachHangCN1
	where trangthai = 1 and not exists (select *
					  from DW_KhachHang dwkh
					  where dwkh.MaNguon = 1 and dwkh.MaKhachHang = KhachHangCN1.MaKhachHang )
	-----insert hóa đơn mới
	insert into DW_HoaDon
	select HoaDonCN1.MaHoaDon, 1, HoaDonCN1.MaKhachHang, HoaDonCN1.SanPham, HoaDonCN1.SoLuong, HoaDonCN1.DonGia
	from HoaDon_ChiNhanh1 as HoaDonCN1
	where trangthai = 1 and not exists (select * 
					  from DW_HoaDon dwhd
					  where dwhd.MaHoaDon = HoaDonCN1.MaHoaDon and dwhd.MaNguon = 1)
	-----update hóa đơn mới
	update DW_HoaDon
	set MaKhachHang = hdcn1.MaKhachHang, SanPham = hdcn1.SanPham, SoLuong = hdcn1.SoLuong, DonGia = hdcn1.DonGia
	from HoaDon_ChiNhanh1 as hdcn1
	where hdcn1.TrangThai = 1 and hdcn1.MaHoaDon = DW_HoaDon.MaHoaDon and
		  DW_HoaDon.MaNguon = 1
	-----update khách hàng mới
	update DW_KhachHang
	set HoTen = CONCAT(khcn1.Ho, ' ', khcn1.Ten), NgaySinh = CAST(CONCAT(cast(khcn1.ThangSinh as varchar), '-',cast(khcn1.NgaySinh as varchar), '-', cast(khcn1.NamSinh as varchar)) as datetime)
	from KhachHang_ChiNhanh1 as khcn1
	where khcn1.TrangThai = 1 and khcn1.MaKhachHang = DW_KhachHang.MaKhachHang 
	      and DW_KhachHang.MaNguon = 1
	-----delete hóa đơn
	delete DW_HoaDon
	from HoaDon_ChiNhanh1 as HoaDonCN1
	where HoaDonCN1.TrangThai = 0 and HoaDonCN1.MaHoaDon = DW_HoaDon.MaHoaDon and 
		  DW_HoaDon.MaNguon = 1
	-----delete khách hàng
		delete DW_KhachHang
	from KhachHang_ChiNhanh1 as KhachHangCN1
	where KhachHangCN1.TrangThai = 0 and KhachHangCN1.MaKhachHang = DW_KhachHang.MaKhachHang 
		and DW_KhachHang.MaNguon = 1

end
go
--================================================================= Đổ dữ liệu từ CN2 vào dữ liệu chính================================================================================


create proc DoDulieuCN2ToDW
as
begin
	----insert khách hàng
	insert into DW_KhachHang
	select distinct KhachHangCN2.MaKhachHang, 2, KhachHangCN2.HoTen, KhachHangCN2.NgaySinh
	from HoaDon_ChiNhanh2 as KhachHangCN2
	where trangthai = 1 and not exists (select *
					  from DW_KhachHang dwkh
					  where dwkh.MaNguon = 2 and dwkh.MaKhachHang = KhachHangCN2.MaKhachHang)
	----insert hóa đơn
	insert into DW_HoaDon
	select distinct HoaDonCN2.MaHoaDon, 2, HoaDonCN2.MaKhachHang, HoaDonCN2.SanPham, HoaDonCN2.SoLuong, HoaDonCN2.DonGia
	from HoaDon_ChiNhanh2 as HoaDonCN2
	where trangthai = 1 and not exists (select * 
					  from DW_HoaDon dwhd
					  where dwhd.MaHoaDon = HoaDonCN2.MaHoaDon and dwhd.MaNguon = 2)
	----update hóa đơn
	update DW_HoaDon
	set MaKhachHang = hdcn2.MaKhachHang, SanPham = hdcn2.SanPham, SoLuong = hdcn2.SoLuong, DonGia = hdcn2.DonGia
	from HoaDon_ChiNhanh2 as hdcn2
	where hdcn2.TrangThai = 1 and hdcn2.MaHoaDon = DW_HoaDon.MaHoaDon and
		  DW_HoaDon.MaNguon = 2
	----update khách hàng
	update DW_KhachHang
	set HoTen = khcn2.HoTen, NgaySinh = khcn2.NgaySinh
	from HoaDon_ChiNhanh2 as khcn2
	where khcn2.TrangThai = 1 and khcn2.MaKhachHang = DW_KhachHang.MaKhachHang 
	      and DW_KhachHang.MaNguon = 2
	----delete hóa đơn
	delete DW_HoaDon
	from HoaDon_ChiNhanh2 as HoaDonCN2
	where HoaDonCN2.TrangThai = 0 and HoaDonCN2.MaHoaDon = DW_HoaDon.MaHoaDon and 
		  DW_HoaDon.MaNguon = 2
	----delete khách hàng không có hóa đơn nào


	delete from DW_KhachHang
	where not exists(select * from DW_HoaDon hd where hd.MaKhachHang = DW_KhachHang.MaKhachHang and DW_KhachHang.MaNguon = 2 and  hd.MaNguon = 2)
	and DW_KhachHang.MaNguon = 2

end
go
--=============================================================Đổ dữ liệu================================================================================================
go
create proc DoDulieuTuChiNhanh1 @start datetime, @end datetime
as
begin
	--Lấy dữ liệu
	exec LoadHoaDonFromCN1 @start, @end
	exec LoadKhachHangFromCN1 @start, @end
	--Đổ dữ liệu
	exec DoDulieuCN1ToDW

	
	----Xóa bảng
	delete from HoaDon_ChiNhanh1
	delete from KhachHang_ChiNhanh1
end
go
create proc DoDulieuTuChiNhanh2 @start datetime, @end datetime
as
begin
	--Lấy dữ liệu
	exec LoadHoaDonFromCN2 @start, @end
	--Đổ dữ liệu
	
	exec DoDulieuCN2ToDW
	--Xóa bảng
	delete from HoaDon_ChiNhanh2
end
go


create proc DoDulieuLanTiepTheo
as
begin
	--Đổ nguồn 1
	
	declare @tmp1 datetime
	set @tmp1 = GETDATE()

	declare @temp datetime
	select top 1  @temp = thoigian
	from ThoiGianRutTrichHoaDon
	where NguonDuLieu = 1
	order by thoigian desc

	exec DoDulieuTuChiNhanh1 @temp, @tmp1
	
	--Đổ nguồn 2
	set @tmp1 = GETDATE()
	select top 1  @temp = thoigian
	from ThoiGianRutTrichHoaDon
	where NguonDuLieu = 2
	order by thoigian desc

	exec DoDulieuTuChiNhanh2 @temp, @tmp1
end
go







