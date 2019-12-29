--================================================================= Load Khách hàng từ CN1 vào DW
use DW
go

if OBJECT_ID('LoadKhachHangFromCN1', 'P') is not null
	drop proc LoadKhachHangFromCN1
go
create proc LoadKhachHangFromCN1 @startTime datetime, @endTime datetime
as
begin
	insert into KhachHang_ChiNhanh1
	select * from [DESKTOP-714MBD8\SQLEXPRESS].[CN1].[dbo].[KhachHang] as KhachHangCN1
	where KhachHangCN1.ThoiGian >= @startTime and KhachHangCN1.ThoiGian <= @endTime

	insert into ThoiGianRutTrichKhachHang
	values (1, CURRENT_TIMESTAMP)

	delete 
	from [DESKTOP-714MBD8\SQLEXPRESS].[CN1].[dbo].[KhachHang]
	where ThoiGian >= @startTime and ThoiGian <= @endTime
end
go


--================================================================== Load Hóa đơn từ CN1 vào DW
use DW
go

if OBJECT_ID('LoadHoaDonFromCN1', 'P') is not null
	drop proc LoadHoaDonFromCN1
go
create proc LoadHoaDonFromCN1 @startTime datetime, @endTime datetime
as
begin
	insert into HoaDon_ChiNhanh1
	select * from [DESKTOP-714MBD8\SQLEXPRESS].[CN1].[dbo].[HoaDon] as HoaDonCN1
	where HoaDonCN1.ThoiGian >= @startTime and HoaDonCN1.ThoiGian <= @endTime

	insert into ThoiGianRutTrichHoaDon
	values (1, CURRENT_TIMESTAMP)

	delete 
	from [DESKTOP-714MBD8\SQLEXPRESS].[CN1].[dbo].[HoaDon]
	where ThoiGian >= @startTime and ThoiGian <= @endTime
end
go

--=================================================================== Load từ Chi Nhánh 2
use DW
go

if OBJECT_ID('LoadHoaDonFromCN2', 'P') is not null
	drop proc LoadHoaDonFromCN2
go
create proc LoadHoaDonFromCN2 @startTime datetime, @endTime datetime
as
begin
	insert into HoaDon_ChiNhanh2
	select * from [DESKTOP-714MBD8\SQLEXPRESS].[CN2].[dbo].[HoaDon] as HoaDonCN2
	where HoaDonCN2.ThoiGian >= @startTime and HoaDonCN2.ThoiGian <= @endTime

	insert into ThoiGianRutTrichKhachHang
	values (2, CURRENT_TIMESTAMP)

	insert into ThoiGianRutTrichHoaDon
	values (2, CURRENT_TIMESTAMP)

	delete 
	from [DESKTOP-714MBD8\SQLEXPRESS].[CN2].[dbo].[HoaDon]
	where ThoiGian >= @startTime and ThoiGian <= @endTime
end
go

--================================================================= Load KhachHang1 vào DW

if OBJECT_ID('LoadKhachHang1IntoDW', 'P') is not null
	drop proc LoadKhachHang1IntoDW
go
create proc LoadKhachHang1IntoDW
as
begin
	insert into DW_KhachHang
	select KhachHangCN1.MaKhachHang, 1, CONCAT(KhachHangCN1.Ho, ' ', KhachHangCN1.Ten), 
		   CAST(CONCAT(cast(KhachHangCN1.ThangSinh as varchar), '-',cast(KhachHangCN1.NgaySinh as varchar), '-', cast(KhachHangCN1.NamSinh as varchar)) as datetime)  
	from KhachHang_ChiNhanh1 as KhachHangCN1
	where not exists (select *
					  from DW_KhachHang dwkh
					  where dwkh.MaNguon = 1 and dwkh.MaKhachHang = KhachHangCN1.MaKhachHang)

	delete DW_KhachHang
	from KhachHang_ChiNhanh1 as KhachHangCN1
	where KhachHangCN1.TrangThai = 0 and KhachHangCN1.MaKhachHang = DW_KhachHang.MaKhachHang 
	      and DW_KhachHang.MaNguon = 1

	update DW_KhachHang
	set HoTen = CONCAT(khcn1.Ho, ' ', khcn1.Ten), NgaySinh = CAST(CONCAT(cast(khcn1.ThangSinh as varchar), '-',cast(khcn1.NgaySinh as varchar), '-', cast(khcn1.NamSinh as varchar)) as datetime)
	from KhachHang_ChiNhanh1 as khcn1
	where khcn1.TrangThai = 1 and khcn1.MaKhachHang = DW_KhachHang.MaKhachHang 
	      and DW_KhachHang.MaNguon = 1
end
go

--======================================================================= Load HoaDon1 vào DW
if OBJECT_ID('LoadHoaDon1IntoDW', 'P') is not null
	drop proc LoadHoaDon1IntoDW
go
create proc LoadHoaDon1IntoDW
as
begin
	insert into DW_HoaDon
	select HoaDonCN1.MaHoaDon, HoaDonCN1.MaKhachHang, HoaDonCN1.SanPham, HoaDonCN1.SoLuong, HoaDonCN1.DonGia, 1
	from HoaDon_ChiNhanh1 as HoaDonCN1
	where not exists (select * 
					  from DW_HoaDon dwhd
					  where dwhd.MaHoaDon = HoaDonCN1.MaHoaDon and dwhd.MaNguon = 1)

	delete DW_HoaDon
	from HoaDon_ChiNhanh1 as HoaDonCN1
	where HoaDonCN1.TrangThai = 0 and HoaDonCN1.MaHoaDon = DW_HoaDon.MaHoaDon and 
		  DW_HoaDon.MaNguon = 1

	update DW_HoaDon
	set MaKhachHang = hdcn1.MaKhachHang, SanPham = hdcn1.SanPham, SoLuong = hdcn1.SoLuong, DonGia = hdcn1.DonGia
	from HoaDon_ChiNhanh1 as hdcn1
	where hdcn1.TrangThai = 1 and hdcn1.MaHoaDon = DW_HoaDon.MaHoaDon and
		  DW_HoaDon.MaNguon = 1
end
go

--====================================================================== Load Khach hàng 2
if OBJECT_ID('LoadKhachHang2IntoDW', 'P') is not null
	drop proc LoadKhachHang2IntoDW
go
create proc LoadKhachHang2IntoDW
as
begin
	insert into DW_KhachHang
	select KhachHangCN2.MaKhachHang, 2, KhachHangCN2.HoTen, KhachHangCN2.NgaySinh
	from HoaDon_ChiNhanh2 as KhachHangCN2
	where not exists (select *
					  from DW_KhachHang dwkh
					  where dwkh.MaNguon = 2 and dwkh.MaKhachHang = KhachHangCN2.MaKhachHang)

	delete DW_KhachHang
	from HoaDon_ChiNhanh2 as KhachHangCN2
	where KhachHangCN2.TrangThai = 0 and KhachHangCN2.MaKhachHang = DW_KhachHang.MaKhachHang 
	      and DW_KhachHang.MaNguon = 2

	update DW_KhachHang
	set HoTen = khcn2.HoTen, NgaySinh = khcn2.NgaySinh
	from HoaDon_ChiNhanh2 as khcn2
	where khcn2.TrangThai = 2 and khcn2.MaKhachHang = DW_KhachHang.MaKhachHang 
	      and DW_KhachHang.MaNguon = 2
end
go

--======================================================================= Load HoaDon2 vào DW
if OBJECT_ID('LoadHoaDon2IntoDW', 'P') is not null
	drop proc LoadHoaDon2IntoDW
go
create proc LoadHoaDon2IntoDW
as
begin
	insert into DW_HoaDon
	select HoaDonCN2.MaHoaDon, HoaDonCN2.MaKhachHang, HoaDonCN2.SanPham, HoaDonCN2.SoLuong, HoaDonCN2.DonGia, 2
	from HoaDon_ChiNhanh2 as HoaDonCN2
	where not exists (select * 
					  from DW_HoaDon dwhd
					  where dwhd.MaHoaDon = HoaDonCN2.MaHoaDon and dwhd.MaNguon = 2)

	delete DW_HoaDon
	from HoaDon_ChiNhanh2 as HoaDonCN2
	where HoaDonCN2.TrangThai = 0 and HoaDonCN2.MaHoaDon = DW_HoaDon.MaHoaDon and 
		  DW_HoaDon.MaNguon = 2

	update DW_HoaDon
	set MaKhachHang = hdcn2.MaKhachHang, SanPham = hdcn2.SanPham, SoLuong = hdcn2.SoLuong, DonGia = hdcn2.DonGia
	from HoaDon_ChiNhanh2 as hdcn2
	where hdcn2.TrangThai = 1 and hdcn2.MaHoaDon = DW_HoaDon.MaHoaDon and
		  DW_HoaDon.MaNguon = 2
end
go