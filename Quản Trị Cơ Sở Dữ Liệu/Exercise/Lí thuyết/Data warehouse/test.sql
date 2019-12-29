--lấy lần đầu
use master
go
declare @tmp1 datetime
set @tmp1 = GETDATE()
use dw
exec DoDulieuTuChiNhanh1 '1999-12-9 17:18:11.563', @tmp1
exec DoDulieuTuChiNhanh2 '1999-12-9 17:18:11.563', @tmp1


use CN1
select * from KhachHang
select * from hoadon
update HoaDon set SoLuong = 29923, DonGia = 123213, ThoiGian = getdate()  where MaHoaDon = 0
update KhachHang set NamSinh = 3124,NgaySinh = 31, ThangSinh = 12, ThoiGian = getdate() where MaKhachHang = 0


update KhachHang set ten = 'nguyen', ho = 'tam', ThoiGian = getdate() where MaKhachHang = 0
select * from HoaDon
update HoaDon set MaKhachHang = 2, ThoiGian = getdate()  where MaHoaDon = 0
update HoaDon set MaKhachHang = 2, ThoiGian = getdate()  where MaHoaDon = 2

update HoaDon set TrangThai = 0, ThoiGian = getdate()  where MaHoaDon = 0
update HoaDon set TrangThai = 0, ThoiGian = getdate()  where MaHoaDon = 0
update KhachHang set TrangThai = 0, ThoiGian = getdate()  where MaKhachHang = 4
use CN1
insert into KhachHang
values ('4', 'Nguyen', 'Tam', 6, 9, 1999, CURRENT_TIMESTAMP, 1)
insert into KhachHang
values ('5', 'Nguyen', 'Tam', 6, 9, 1999, CURRENT_TIMESTAMP, 1)
insert into KhachHang
values ('6', 'Nguyen', 'Tam', 6, 9, 1999, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('4', '4', 'Hoa don 3', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('5', '5', 'Hoa don 4', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('6', '6', 'Hoa don 5', 69, 5000, CURRENT_TIMESTAMP, 1)
use CN1
update HoaDon set TrangThai = 0, ThoiGian = getdate()  where MaHoaDon = 4
update HoaDon set TrangThai = 0, ThoiGian = getdate()  where MaHoaDon = 5
update HoaDon set TrangThai = 0, ThoiGian = getdate()  where MaHoaDon = 6
update KhachHang set TrangThai = 0, ThoiGian = getdate()  where MaKhachHang = 4
update KhachHang set TrangThai = 0, ThoiGian = getdate()  where MaKhachHang = 5
update KhachHang set TrangThai = 0, ThoiGian = getdate()  where MaKhachHang = 6


use CN2
select * from HoaDon
insert into HoaDon
values ('3', '0', 'HoaDon0001', 'KhachHang0001', '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('4', '0', 'HoaDon0002', 'KhachHang0001' , '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('5', '0', 'HoaDon0003', 'KhachHang0001', '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)
	--CN 2: testcase 1
use CN2
update HoaDon set MaKhachHang = 3, thoigian = getdate() where MaHoaDon = 2
update HoaDon set MaKhachHang = 0, thoigian = getdate() where MaHoaDon = 2
update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 2
	--CN 2: test case 2
	use CN2
insert into HoaDon
values ('3', '0', 'HoaDon0001', 'KhachHang0001', '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('4', '0', 'HoaDon0002', 'KhachHang0001' , '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)
insert into HoaDon
values ('5', '0', 'HoaDon0003', 'KhachHang0001', '04-08-1999', 69, 5000, CURRENT_TIMESTAMP, 1)
use CN2
update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 0
update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 3
update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 4
update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 5

update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 3
update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 4
update HoaDon set TrangThai = 0 , thoigian = getdate() where MaHoaDon = 5


update hoadon set SoLuong = 5, SanPham = 'baby', DonGia = 5000, HoTen = 'ho cam dao', ThoiGian = GETDATE() where MaHoaDon = 2
--Các lần lấy tiếp theo
use dw
exec DoDulieuLanTiepTheo

use DW
select * from KhachHang_ChiNhanh1
select * from HoaDon_ChiNhanh1
select * from HoaDon_ChiNhanh2
select * from DW_KhachHang
select * from DW_HoaDon
select * from ThoiGianRutTrichHoaDon
select * from ThoiGianRutTrichKhachHang

