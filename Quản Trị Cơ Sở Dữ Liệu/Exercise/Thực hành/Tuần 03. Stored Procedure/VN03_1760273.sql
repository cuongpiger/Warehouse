------------------------------------------------------------------------------------------------1
if OBJECT_ID('Query1', 'P') is not null
	drop proc Query1
go
create proc Query1
	@maPM char(10)
as
	select dg.socmnd, dg.hoten, dg.diachi, dg.ngsinh
	from DocGia dg, PhieuMuon pm
	where dg.madg = pm.madg and pm.mapm = @maPM
go

exec Query1 'PM001'
------------------------------------------------------------------------------------------------2
if OBJECT_ID('Query2', 'P') is not null
	drop proc Query2
go
create proc Query2
	@ip_nam int
as
	select *
	from DocGia dg
	where year(dg.ngsinh) = @ip_nam
go

exec Query2 1980
------------------------------------------------------------------------------------------------3
if OBJECT_ID('Query3', 'P') is not null
	drop proc Query3
go
create proc Query3
as
	select *
	from DocGia dg
	where dg.ngsinh <= all (select dg1.ngsinh
							from DocGia dg1)
go

exec Query3 
------------------------------------------------------------------------------------------------4
if OBJECT_ID('Query4', 'P') is not null
	drop proc Query4
go
create proc Query4
	@maPM char(10)
as
	select dg.socmnd, dg.hoten, count(*)
	from DocGia dg, PhieuMuon pm, CT_PhieuMuon ctpm
	where dg.madg = pm.madg and pm.mapm = @maPM and pm.mapm = ctpm.mapm
	group by dg.socmnd, dg.hoten
go

exec Query4 'PM004'
------------------------------------------------------------------------------------------------5
if OBJECT_ID('Query5', 'P') is not null
	drop proc Query5
go
create proc Query5
	@i_ispn nchar(12)
as
	select dg.socmnd, dg.hoten, dg.ngsinh, dg.diachi
	from DocGia dg, PhieuMuon pm, CT_PhieuMuon ctpm
	where dg.madg = pm.madg and pm.mapm = ctpm.mapm and ctpm.isbn = @i_ispn
go

exec Query5 '116525441'
--6. Nhận vào số cmnd một độc giả, xuất ra thông tin các cuốn sách (mã isbn, mã sách) mà độc giả đã từng mượn. 
if OBJECT_ID('Query6', 'P') is not null
	drop proc Query6
go
create proc Query6
	@cmnd nchar(10)
as
	select dg.socmnd, dg.hoten, dg.ngsinh, dg.diachi
	from DocGia dg, PhieuMuon pm, CT_PhieuMuon ctpm
	where dg.madg = pm.madg and pm.mapm = ctpm.mapm and dg.socmnd = @cmnd
go

--7. Nhận vào một mã phiếu mượn trả ra số lượng phiếu trả cho phiếu mượn đó.
if OBJECT_ID('Query7', 'P') is not null
	drop proc Query7
go
create proc Query7
	@ma char(10)
as
	select count(pt.mapt)
	from PhieuMuon pm, PhieuTra pt
	where pm.mapm = pt.mapm
	group by pm.mapm
	having pm.mapm = @ma
go

exec Query7 'PM004'
--8. Nhận vào một mã isbn, xóa đầu sách mang mã isbn đó theo các bước sau:
-- Kiểm tra đầu sách có tồn tại không  nếu không trả về mã lỗi là 1
-- Kiểm tra đầu sách đó đã có cuốn sách nào chưa
--o Nếu chưa có cuốn sách nào thuộc đầu sách, tiến hành xóa đầu sách và trả về 0
--báo hiệu xóa thành công.
--o Nếu có, kiểm tra các cuốn sách thuộc đầu sách đã từng có độc giả mượn hay trả
--chưa:
-- Nếu chưa, xóa các cuốn sách thuộc đầu sách sau đó xóa đầu sách và trả
--về 0 báo hiệu xóa thành công.
-- Nếu có, không được xóa và trả về mã lỗi là 2. 
if OBJECT_ID('Query8', 'P') is not null
	drop proc Query8
go
create proc Query8
	@isbn nchar(12)
as
	if (@isbn not in (select ds.isbn
					  from DauSach ds))
	begin
		return 1
	end

	if (@isbn not in (select cs.isbn
					  from CuonSach cs))
	begin
		delete from DauSach where isbn = @isbn
	end
	else
	begin
		delete from DauSach
		where isbn = (select cs.isbn
					  from CuonSach cs
					  where cs.tinhtrang = N'có thể mượn')

		if (@@ROWCOUNT = 0)
			return 2
		else
			return 0
	end
go

--Nhận vào mã phiếu trả, cập nhật ngày trả theo các bước sau:
-- Kiểm tra mã phiếu trả có tồn tại không  nếu không trả về mã lỗi là 1
-- Cập nhật ngày trả của phiếu trả 
--Cập nhật tiền phạt của các chi tiết phiếu trả tương ứng theo công thức:
--tiền phạt = mucgiaphat * (ngày trả mới – ngày mượn – số ngày quy định) 
if OBJECT_ID('Query9', 'P') is not null
	drop proc Query9
go
create proc Query9
	@mapt char(10),
	@ngayTra date
as
	if (@mapt not in (select pt.mapt from PhieuTra pt))
		return 1
	else
	begin
		update PhieuTra
		set ngaytra = @ngayTra
		where mapt = @mapt

		declare @tmp date = (select pm.ngaymuon
							 from PhieuMuon pm, PhieuTra pt
							 where pm.mapm = pt.mapm and pt.mapt = @mapt)

		declare @tmp2 int = (select ctpm.songayquydinh
							 from CT_PhieuMuon ctpm, PhieuTra pt
							 where ctpm.mapm = pt.mapm and pt.mapt = @mapt)

		declare @tmp3 int = DATEDIFF(dd, @tmp, @ngayTra)
		
		update CT_PhieuTra
		set tienphat = mucgiaphat * (@tmp3 - @tmp2)
		where mapt = @mapt
	end
	
	return 0
go
--10. Nhận vào thông tin một phiếu mượn (mã phiếu mượn, mã độc giả), thêm phiếu mượn vào
--CSDL theo các bước sau:
-- Kiểm tra mã phiếu mượn đã tồn tại chưa  nếu đã tồn tại trả về mã lỗi là 1
-- Kiểm tra mã độc giả phải khác null và phải tồn tại trong bảng độc giả  nếu không trả
--về mã lỗi 2
-- Thêm phiếu mượn vào CSDL, biết rằng ngày mượn luôn là ngày hiện tại của hệ thống.
--Trả về 0 báo hiệu thêm thành công. 
if OBJECT_ID('Query10', 'P') is not null
	drop proc Query10
go
create proc Query10
	@madg nchar(10),
	@mapm char(10)
as
	if (@mapm in (select pm.mapm from PhieuMuon pm))
		return 1

	if (@madg is null or @madg not in (select dg.madg from DocGia dg))
		return 22

	insert into PhieuMuon
	values (@mapm, @madg, cast(GETDATE() as date))

	return 0
go