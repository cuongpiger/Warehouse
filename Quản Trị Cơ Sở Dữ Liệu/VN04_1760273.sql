/*
1. Viết thủ tục in thông tin theo mẫu sau:
Stt ISBN TenSach TacGia NamXB
-------------------------------------------------------------------------
-------------------------------------------------------------------------
Tổng số đầu sách: 
*/
if OBJECT_ID('Query_1', 'P') is not null
	drop proc Query_1
go
create proc Query_1
as
	declare @stt int = 1, @isbn nchar(12), @tensach nvarchar(100), @tacgia nvarchar(50), @namxb int
	declare cur cursor for (select ds.isbn, ds.tensach, ds.tacgia, ds.namxb
							from DauSach ds) 
	open cur
	
	print 'Stt' + space(3) + 'ISBN' + space(5) + 'TenSach' + space(5) + 'TacGia' + space(5) + 'NamXB'
	print '----------------------------------------------------------------------------------------------------------------'
	
	fetch next from cur into @isbn, @tensach, @tacgia, @namxb

	while @@FETCH_STATUS = 0
	begin
		print cast(@stt as varchar(3)) + space(3 - len(@stt)) + @isbn + space(12 - len(@isbn)) + @tensach + 
		space(50 - len(@tensach)) +@tacgia + space(30 - len(@tacgia)) + cast(@namxb as varchar(4))
		set @stt += 1
		fetch next from cur into @isbn, @tensach, @tacgia, @namxb
	end

	close cur
	deallocate cur
	print '----------------------------------------------------------------------------------------------------------------'
	set @stt -= 1
	print N'Tổng số đầu sách: ' + cast(@stt as varchar)
go

exec Query_1

/*
2. Viết thủ tục truyền vào isbn, in thông tin theo mẫu sau:
Tên đầu sách:
Số sách đang mượn:
Stt TenDG MaPM SoNgayMuon
-------------------------------------------------------------------------
-------------------------------------------------------------------------
Số lượng phiếu mượn: 
*/
if OBJECT_ID('Query_2', 'P') is not null
	drop proc Query_2
go
create proc Query_2 @i_isbn nchar(12)
as
	if @i_isbn not in (select isbn from DauSach)
		return 0

	declare @cnt int = 0, @cnt2 int = 0, @stt int = 1, @tendausach nvarchar(100), @hoten nvarchar(70), @mapm char(10), @datem date, @datet date, @snm int
	declare cur cursor for (select dg.hoten, pm.mapm, pm.ngaymuon, pt.ngaytra
							from DocGia dg, PhieuMuon pm, PhieuTra pt, CT_PhieuMuon ctpm
							where dg.madg = pm.madg and pm.mapm = pt.mapm and ctpm.mapm = pm.mapm and ctpm.isbn = @i_isbn) 
	open cur

	set @cnt = (select count(distinct ctpm.mapm)
			    from CT_PhieuMuon ctpm
			    where ctpm.isbn = @i_isbn)
	set @cnt2 = (select count(distinct ctpm.masach)
				 from CT_PhieuMuon ctpm
				 where ctpm.isbn = @i_isbn)
	set @tendausach = (select tensach from DauSach where isbn = @i_isbn)
	print N'Tên đầu sách: ' + @tendausach
	print N'Số sách đang mượn: ' + cast(@cnt2 as varchar)
	print 'Stt          TenDG          MaPM           SoNgayMuon'
	print '----------------------------------------------------------------------------------------------------------------'

	fetch next from cur into @hoten, @mapm, @datem, @datet

	while @@FETCH_STATUS = 0
	begin
		if @datet is null
		begin
			set @datet = (select GETDATE())
		end

		set @snm = (SELECT DATEDIFF(dd, @datem, @datet) AS DateDiff)
		print cast(@stt as varchar(3)) + space(3 - len(@stt)) + @hoten + space(30 - len(@hoten)) + @mapm + space(15 - len(@mapm)) + cast(@snm as varchar)
		set @stt += 1
		fetch next from cur into @hoten, @mapm, @datem, @datet
	end

	close cur
	deallocate cur
	print '----------------------------------------------------------------------------------------------------------------'
	print N'Số lượng phiếu mượn: ' + cast(@cnt as varchar)

	return 1
go

exec Query_2 '245676441'

/*
3. Viết thủ tục truyền vào MaPM in thông tin theo mẫu sau:
Ngày mượn:
Ma ĐG: Tên ĐG:
Stt ISBN MaSach SoNgayQuyDinh
-------------------------------------------------------------------------
-------------------------------------------------------------------------
Số sách đã trả:
Số sách chưa trả: 
*/

if OBJECT_ID('Query_3', 'P') is not null
	drop proc Query_3
go
create proc Query_3 @i_mapm char(10)
as
	if @i_mapm not in (select mapm from PhieuMuon)
		return 0

	declare @stt int = 1, @isbn nchar(12), @masach nchar(5), @snqd int, @ngaytra date, @cntMuon int = 0, @cntTra int = 0
	declare cur cursor for (select ctpm.isbn, ctpm.masach, ctpm.songayquydinh, pt.ngaytra
							from CT_PhieuMuon ctpm join PhieuTra pt on pt.mapm = ctpm.mapm and ctpm.mapm = @i_mapm) 
	open cur

	declare @nm date, @madg nchar(10), @ten nvarchar(70)
	set @nm = (select ngaymuon from PhieuMuon where mapm = @i_mapm)
	set @madg = (select dg.madg from PhieuMuon pm join DocGia dg on pm.madg = dg.madg and pm.mapm = @i_mapm)
	set @ten = (select dg.hoten from PhieuMuon pm join DocGia dg on pm.madg = dg.madg and pm.mapm = @i_mapm)

	print N'Ngày mượn: ' + cast(@nm as varchar)
	print N'Mã ĐG: ' + @madg + N'     Tên ĐG: ' + @ten
	
	print 'Stt         ISBN        MaSach        SoNgayQuyDinh'
	print '----------------------------------------------------------------------------------------------------------------'
	
	fetch next from cur into @isbn, @masach, @snqd, @ngaytra

	while @@FETCH_STATUS = 0
	begin
		print cast(@stt as varchar(3)) + space(3 - len(@stt)) + @isbn + space(12 - len(@isbn)) + @masach + 
		space(50 - len(@masach)) + cast(@snqd as varchar(4))
		set @stt += 1

		if @ngaytra is null
			set @cntTra += 1
		else
			set @cntMuon += 1

		fetch next from cur into @isbn, @masach, @snqd, @ngaytra
	end

	close cur
	deallocate cur
	print '----------------------------------------------------------------------------------------------------------------'
	print N'Số sách đã trả: ' + cast(@cntMuon as varchar)
	print N'Số sách chưa trả: ' + cast(@cntTra as varchar) 

	return 1
go

exec Query_3 'PM001'

/*
4. Viết thủ tục truyền vào MaPM in thông tin theo mẫu sau:
MaPM:
Ngày mượn:
MaDG: TenDG:
DANH SACH CT_PHIEUMUON
Stt ISBN MaSach SoNgayQuyDinh
-------------------------------------------------------------------------
-------------------------------------------------------------------------
Số CT_PhieuMuon:
DANH SÁCH PHIẾU TRẢ
Stt ISBN MaSach NgayTra
---------------------------------------------------------
--------------------------------------------------------- 
*/

if OBJECT_ID('Query_4', 'P') is not null
	drop proc Query_4
go
create proc Query_4 @i_mapm char(10)
as
	declare @ngMuon date, @maDg nchar(10), @tenDg nvarchar(70)
	
	select @ngMuon = pm.ngaymuon, @maDg = dg.madg, @tenDg = dg.hoten
	from PhieuMuon pm join DocGia dg on pm.madg = dg.madg and pm.mapm = @i_mapm

	print 'Ma PM: ' + @i_mapm
	print N'Ngày mượn: ' + cast(@ngMuon as varchar)
	print 'MaDG: ' + @maDg + '   TenDG: ' + @tenDg

	declare @stt1 int = 1, @isbn1 nchar(12), @masach1 nchar(5), @snqd1 int
	declare cur1 cursor for (select ctpm.isbn, ctpm.masach, ctpm.songayquydinh
							 from CT_PhieuMuon ctpm
							 where ctpm.mapm = @i_mapm) 

	print 'DANH SACH CT_PHIEUMUON'
	print 'Stt' + space(5) + 'ISBN' + space(12) + 'MaSach' + space(5) + 'SoNgayQuyDinh'
	print '----------------------------------------------------------------------------------------------------------------'

	open cur1
	fetch next from cur1 into @isbn1, @masach1, @snqd1

	while @@FETCH_STATUS = 0
	begin
		print cast(@stt1 as varchar) + space(5) + @isbn1 + space(12 - len(@isbn1)) + @masach1 + space(5 - len(@masach1)) + cast(@snqd1 as varchar)
		set @stt1 += 1
		fetch next from cur1 into @isbn1, @masach1, @snqd1
	end
	print '----------------------------------------------------------------------------------------------------------------'

	close cur1
	deallocate cur1

	declare @so_ctpm int
	set @so_ctpm = (select count(*) from CT_PhieuMuon where mapm = @i_mapm)

	print N'Số CT_PhieuMuon: ' + cast(@so_ctpm as varchar)
	print N'DANH SÁCH PHIẾU TRẢ'

	declare @stt2 int = 1, @isbn2 nchar(12), @masach2 nchar(5), @ngaytra2 date
	declare cur2 cursor for (select ctpt.isbn, ctpt.masach, pt.ngaytra
							 from PhieuMuon pm, PhieuTra pt, CT_PhieuTra ctpt
							 where pm.mapm = @i_mapm and pm.mapm = pt.mapm and pt.mapt = ctpt.mapt) 

	print 'Stt' + space(5) + 'ISBN' + space(12) + 'MaSach' + space(5) + 'NgayTra'
	print '----------------------------------------------------------------------------------------------------------------'

	open cur2
	fetch next from cur2 into @isbn2, @masach2, @ngaytra2

	while @@FETCH_STATUS = 0
	begin
		print cast(@stt2 as varchar) + space(5) + @isbn2 + space(12 - len(@isbn2)) + @masach2 + space(5 - len(@masach2)) + cast(@ngaytra2 as varchar)
		set @stt2 += 1
		fetch next from cur2 into @isbn2, @masach2, @ngaytra2
	end
	print '----------------------------------------------------------------------------------------------------------------'

	close cur2
	deallocate cur2
go

exec Query_4 'PM001'

/*
5. Viết thủ tục in thông tin theo mẫu sau:
Tên sách:
DANH SÁCH SÁCH MƯỢN
Stt ISBN MaSach NgayMuon NgayTra TinhTrang
------------------------------------------------------------------------------------------------------- 
*/
if OBJECT_ID('Query_5', 'P') is not null
	drop proc Query_5
go
create proc Query_5
as
	declare @isbn1 nchar(12), @tensach1 nvarchar(100)
	declare cur1 cursor for (select ds.isbn, ds.tensach
							 from DauSach ds) 
	open cur1
	
	fetch next from cur1 into @isbn1, @tensach1

	while @@FETCH_STATUS = 0
	begin
		print N'Tên sách: ' + @tensach1
		print N'DANH SÁCH SÁCH MƯỢN'
		print 'Stt         ISBN            MaSach         NgayMuon        NgayTra       TinhTrang'
		print '----------------------------------------------------------------------------------------------------------------'
		
		declare @stt2 int = 1, @isbn2 nchar(12), @masach2 nchar(5), @ngmuon2 date, @ngtra2 date, @ttrang2 nchar(50)
		declare cur2 cursor for (select cs.isbn, cs.masach, pm.ngaymuon, pt.ngaytra, cs.tinhtrang
								 from CuonSach cs, PhieuMuon pm, PhieuTra pt, CT_PhieuMuon ctpm
								 where cs.isbn = @isbn1 and cs.isbn = ctpm.isbn and ctpm.mapm = pm.mapm and ctpm.mapm = pt.mapm) 

		open cur2
		fetch next from cur2 into @isbn2, @masach2, @ngmuon2, @ngtra2, @ttrang2
		
		while @@FETCH_STATUS = 0
		begin
			print cast(@stt2 as varchar(3)) + space(3 - len(@stt2)) + @isbn2 + space(12 - len(@isbn2)) + @masach2 + 
			space(50 - len(@masach2)) + cast(@ngmuon2 as varchar) + space(50 - len(@ngmuon2)) + cast(@ngtra2 as varchar) + space(30 - len(@ngtra2)) + @ttrang2
			fetch next from cur2 into @isbn2, @masach2, @ngmuon2, @ngtra2, @ttrang2
			set @stt2 += 1
		end
		close cur2
		deallocate cur2
		print '----------------------------------------------------------------------------------------------------------------'
		fetch next from cur1 into @isbn1, @tensach1
	end

	close cur1
	deallocate cur1
	
	print ' '
go

exec Query_5

/*
6. Viết thủ tục cập nhật tiền phạt cho các sách mượn quá hạn 
*/

if OBJECT_ID('Query_6', 'P') is not null
	drop proc Query_6
go
create proc Query_6 @i_tienphat float
as
	update ctpt
	set ctpt.tienphat = @i_tienphat
	from CT_PhieuTra ctpt, CT_PhieuMuon ctpm, PhieuMuon pm, PhieuTra pt
	where pm.mapm = ctpm.mapm and pm.mapm = pt.mapm and ctpt.mapt = pt.mapt
	and (select DATEDIFF(dd, pm.ngaymuon, pt.ngaytra)) > ctpm.songayquydinh
go

exec Query_6 69000

/*
7. Thêm độc giả.
 Input: thông tin độc giả
 Output: 0 – thêm thành công hoặc mã lỗi (số nguyên > 0) nếu thêm thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mã độc giả tồn tại  nếu có trả về lỗi 1
	o B2: Kiểm tra email trùng  nếu trùng trả về lỗi 2
	o B3: Kiểm tra số cmnd trùng  nếu trùng trả về lỗi 3
	o B4: Kiểm tra độc giả phải từ 18 tuổi trở lên  nếu không đủ trả về lỗi 4
	o B5: Kiểm tra giới tính phải là nam, nữ hoặc null  nếu không trả về lỗi 6
	o B6: Thêm độc giả vào, trả về 0. 
*/

if OBJECT_ID('Query_7', 'P') is not null
	drop proc Query_7
go
create proc Query_7 @i_madg nchar(10), @i_hoten nvarchar(70), @i_socmnd nchar(10), @i_ngsinh date, 
@i_gioitinh nchar(3), @i_email nchar(40), @i_matkhau nchar(10), @i_diachi nvarchar(70)
as
	if @i_madg in (select madg from DocGia)
		return 1

	if @i_email in (select email from DocGia)
		return 2

	if @i_socmnd in (select socmnd from DocGia)
		return 3

	if YEAR(getdate()) - year(@i_ngsinh) < 18
		return 4

	if @i_gioitinh is null
		return 6

	insert into DocGia
	values (@i_madg, @i_hoten, @i_socmnd, @i_ngsinh, @i_gioitinh, @i_email, @i_matkhau, @i_diachi)

	return 0
go

exec Query_7 'DG06', N'Dương Mạnh Cường', '123454', '1999-04-08' ,'Nam', 'cuongpiger@gmail.com', '123', 'HCM'

/*
8. Thêm một cuốn sách.
 Input: thông tin cuốn sách
 Output: 0 – thêm thành công hoặc mã lỗi (số nguyên > 0) nếu thêm thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra isbn phải tồn tại ở đầu sách  nếu không trả về lỗi 1
	o B2: Kiểm tra mã sách có trùng với cuốn sách khác thuộc cùng đầu sách  nếu trùng trả về lỗi 2
	o B3: Kiểm tra tình trạng phải là “có thể mượn”  nếu không trả về lỗi 3
	o B4: Thêm cuốn sách vào, trả về 0. 
*/

if OBJECT_ID('Query_8', 'P') is not null
	drop proc Query_8
go
create proc Query_8 @i_isbn nchar(12), @i_masach nchar(5), @i_tinhtrang nchar(50)
as
	if @i_isbn not in (select isbn from DauSach)
		return 1

	if @i_masach in (select masach from CuonSach where isbn = @i_isbn)
		return 2

	if @i_tinhtrang <> N'có thể mượn'
		return 3

	insert into CuonSach
	values (@i_isbn, @i_masach, @i_tinhtrang)
	return 0
go

exec Query_8 '116525441', 'S003', N'có thể mượn'

/*
9. Thêm một phiếu mượn.
 Input: thông tin phiếu mượn (không truyền vào ngày mượn)
 Output: 0 – thêm thành công hoặc mã lỗi (số nguyên > 0) nếu thêm thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra madg phải tồn tại ở độc giả  nếu không trả về lỗi 1
	o B2: Kiểm tra mã phiếu có trùng với phiếu khác  nếu trùng trả về lỗi 2
	o B3: Thêm phiếu mượn vào với ngày mượn là ngày hiện tại của hệ thống, trả về 0. 
*/
if OBJECT_ID('Query_9', 'P') is not null
	drop proc Query_9
go
create proc Query_9 @i_mapm char(10), @i_madg nchar(10)
as
	if @i_madg not in (select madg from DocGia)
		return 1

	if @i_mapm in (select mapm from PhieuMuon)
		return 2

	insert into PhieuMuon
	values (@i_mapm, @i_madg, GETDATE())
	return 0
go

exec Query_9 'PM005', 'DG05'

/*
10. Thêm một chi tiết cho phiếu mượn.
 Input: thông tin chi tiết phiếu mượn
 Output: 0 – thêm thành công hoặc mã lỗi (số nguyên > 0) nếu thêm thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mapm phải tồn tại ở phiếu mượn  nếu không trả về lỗi 1
	o B2: Kiểm tra cuốn sách được mượn (isbn, mã sách) phải tồn tại và tình trạng phải là có thể mượn  nếu không thỏa trả về lỗi 2 
	o B3: Kiểm tra số ngày quy định phải có và là số nguyên dương  nếu không trả về lỗi 3
	o B4: Thêm chi tiết phiếu mượn vào, trả về 0. 
*/

if OBJECT_ID('Query_10', 'P') is not null
	drop proc Query_10
go
create proc Query_10 @i_mapm char(10), @i_isbn nchar(12), @i_masach nchar(5), @i_snqd int
as
	if @i_mapm not in (select mapm from PhieuMuon)
		return 1

	if not exists (select *
				   from CuonSach cs
			       where cs.isbn = @i_isbn and cs.masach = @i_masach and cs.tinhtrang = N'có thể mượn')
		return 3

	insert into CT_PhieuMuon
	values (@i_mapm, @i_isbn, @i_masach, @i_snqd)
	return 0
go

exec Query_10 'PM005', '116525441', 'S001', 69

/*
11. Thêm một phiếu trả.
 Input: thông tin phiếu trả (không truyền vào ngày trả)
 Output: 0 – thêm thành công hoặc mã lỗi (số nguyên > 0) nếu thêm thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mapm phải tồn tại ở phiếu mượn  nếu không trả về lỗi 1
	o B2: Kiểm tra mã phiếu có trùng với phiếu khác  nếu trùng trả về lỗi 2
	o B3: Thêm phiếu trả vào với ngày trả là ngày hiện tại của hệ thống, trả về 0. 
*/

if OBJECT_ID('Query_11', 'P') is not null
	drop proc Query_11
go
create proc Query_11 @i_mapt char(10), @i_mapm char(10)
as
	if @i_mapm not in (select mapm from PhieuMuon)
		return 1

	if @i_mapt in (select mapt from PhieuTra)
		return 2

	insert into PhieuTra
	values (@i_mapt, @i_mapm, GETDATE())
	return 0
go

exec Query_11 'PT005', 'PM005'

/*
12. Thêm một chi tiết cho phiếu trả.
 Input: thông tin phiếu trả (không truyền vào mức giá phạt và tiền phạt)
 Output: 0 – thêm thành công hoặc mã lỗi (số nguyên > 0) nếu thêm thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mapt phải tồn tại ở phiếu trả  nếu không trả về lỗi 1
	o B2: Kiểm tra cuốn sách được trả (isbn, mã sách) phải là cuốn sách được mượn và chưa được trả  nếu không thỏa trả về lỗi 2
	o B3: Thêm chi tiết phiếu trả vào, trả về 0. Lưu ý: mức giá phạt được lấy từ mức giá phạt hiện tại của đầu sách tương ứng và tiền phạt được tính theo công thức như bên dưới:
			tienphat = mucgiaphat * (ngaytra – ngaymuon – songayquydinh) 
*/

if OBJECT_ID('Query_12', 'P') is not null
	drop proc Query_12
go
create proc Query_12 @i_mapt char(10), @i_isbn nchar(12), @i_masach nchar(5)
as
	if @i_mapt not in (select mapt from PhieuTra)
		return 1

	if exists (select * from CuonSach cs where cs.isbn = @i_isbn and cs.masach = @i_masach and cs.tinhtrang != N'có thể mượn')
		return 2
	
	declare @ngayMuon date, @ngayTra date
	select @ngayMuon = pm.ngaymuon, @ngayTra = pt.ngaytra
	from PhieuMuon pm, PhieuTra pt
	where pt.mapt = @i_mapt and pt.mapm = pm.mapm

	declare @snqd int = (select ctpm.songayquydinh
						 from PhieuTra pt join CT_PhieuMuon ctpm on pt.mapt = @i_mapt and pt.mapm = ctpm.mapm and ctpm.masach = @i_masach)

	declare @mucGiaPhat float = (select mucgiaphat from DauSach where @i_isbn = isbn)
	declare @tienPhat float = @mucGiaPhat * ((select DATEDIFF(dd, @ngayMuon, @ngayTra)) - @snqd)

	insert into CT_PhieuTra
	values (@i_mapt, @i_isbn, @i_masach, @mucGiaPhat, @snqd)
	return 0
go

/*
13. Cập nhật ngày mượn của một phiếu mượn.
 Input: mã phiếu mượn và ngày mượn mới
 Output: 0 – cập nhật thành công hoặc mã lỗi (số nguyên > 0) nếu thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mapm phải tồn tại  nếu không trả về lỗi 1
	o B2: Cập nhật ngày mượn
	o B3: Cập nhật lại tiền phạt cho các chi tiết phiếu trả ứng với phiếu mượn vừa được cập nhật ngày
	o B4: Trả về 0 báo hiệu thành công
*/

if OBJECT_ID('Query_13', 'P') is not null
	drop proc Query_13
go
create proc Query_13 @i_mapm char(10), @i_ngaymuon date
as
	if @i_mapm not in (select mapm from PhieuMuon)
		return 1

	update PhieuMuon
	set ngaymuon = @i_ngaymuon
	where mapm = @i_mapm
	--tienphat = mucgiaphat * (ngaytra – ngaymuon – songayquydinh) 

	declare @g_mapt char(10), @g_isbn nchar(12), @g_mucgiaphat float, @g_ngaytra date, @g_snqd int
	declare cur cursor for (select ctpt.mapt, ctpt.isbn, ctpt.mucgiaphat, pt.ngaytra, ctpm.songayquydinh
							from CT_PhieuMuon ctpm, CT_PhieuTra ctpt, PhieuTra pt
							where pt.mapm = @i_mapm and ctpm.mapm = pt.mapm and ctpt.mapt = pt.mapt and ctpm.isbn = ctpt.isbn) 
	open cur
	
	fetch next from cur into @g_mapt, @g_isbn, @g_mucgiaphat, @g_ngaytra, @g_snqd

	while @@FETCH_STATUS = 0
	begin
		declare @rangeDay int = (select DATEDIFF(dd, @i_ngaymuon, @g_ngaytra))
		declare @u_tienphat float = @g_mucgiaphat * (@rangeDay - @g_snqd)
		
		update CT_PhieuTra
		set tienphat = @u_tienphat
		where mapt = @g_mapt and isbn = @g_isbn

		fetch next from cur into @g_mapt, @g_isbn, @g_mucgiaphat, @g_ngaytra, @g_snqd
	end

	close cur
	deallocate cur

	return 0
go

exec Query_13 'PM001', '2014-01-11'

/*
14. Cập nhật mức giá phạt cho một chi tiết trong phiếu trả.
 Input: mã phiếu trả, số isbn, mã sách và mức giá phạt mới
 Output: 0 – cập nhật thành công hoặc mã lỗi (số nguyên > 0) nếu thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mapt phải tồn tại  nếu không trả về lỗi 1
	o B2: Kiểm tra cuốn sách (số isbn, mã sách) phải tồn tại trong chi tiết phiếu trả  nếu không trả về lỗi 2
	o B3: Kiểm tra mức giá phạt phải là số dương  nếu không trả về lỗi 3
	o B4: Cập nhật mức giá phạt
	o B5: Cập nhật lại tiền phạt với mức giá phạt mới
	o B6: Trả về 0 báo hiệu thành công
*/

if OBJECT_ID('Query_14', 'P') is not null
	drop proc Query_14
go
create proc Query_14 @i_mapt char(10), @i_isbn nchar(12), @i_masach nchar(5), @i_mucgiaphat float
as
	if @i_mapt not in (select mapt from PhieuTra)
		return 1

	if not exists (select * from CT_PhieuTra ctpt where ctpt.mapt = @i_mapt and @i_isbn = ctpt.isbn and ctpt.masach = @i_masach)
		return 2
	
	if exists (select * from CT_PhieuTra ctpt where ctpt.mapt = @i_mapt and @i_isbn = ctpt.isbn and ctpt.masach = @i_masach and mucgiaphat < 0)
		return 3
		--tienphat = mucgiaphat * (ngaytra – ngaymuon – songayquydinh) 
	
	declare @g_ngaymuon date, @g_ngaytra date, @g_snqd int

	select @g_ngaymuon = pm.ngaymuon, @g_ngaytra = pt.ngaytra, @g_snqd = ctpm.songayquydinh
	from PhieuTra pt, CT_PhieuMuon ctpm, PhieuMuon pm
	where pt.mapm = ctpm.mapm and pm.mapm = pt.mapm

	update CT_PhieuTra
	set	mucgiaphat = @i_mucgiaphat, tienphat = (@i_mucgiaphat * ((select DATEDIFF(dd, @g_ngaymuon, @g_ngaytra))) - @g_snqd)
	where mapt = @i_mapt and @i_isbn = isbn and masach = @i_masach

	return 0
go

/*
15. Xóa độc giả.
 Input: mã độc giả
 Output: 0 – xóa thành công hoặc mã lỗi (số nguyên > 0) nếu thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra madg phải tồn tại  nếu không trả về lỗi 1
	o B2: Kiểm tra độc giả đã từng mượn hay trả sách chưa  nếu rồi trả về lỗi 2 báo hiệu không được xóa
	o B3: Xóa độc giả và trả về 0 báo hiệu xóa thành công
*/

if OBJECT_ID('Query_15', 'P') is not null
	drop proc Query_15
go
create proc Query_15 @i_madg nchar(10)
as
	if @i_madg not in (select madg from DocGia)
		return 1

	if exists (select * 
			   from PhieuMuon pm join PhieuTra pt on pm.mapm = pt.mapm and pm.madg = @i_madg and pt.ngaytra is null)
		return 2

	delete from DocGia
	where madg = @i_madg

	return 0
go

/*
16. Xóa phiếu mượn.
 Input: mã phiếu mượn
 Output: 0 – xóa thành công hoặc mã lỗi (số nguyên > 0) nếu thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mapm phải tồn tại  nếu không trả về lỗi 1
	o B2: Kiểm tra phiếu mượn đã có phiếu trả tương ứng chưa  nếu có trả về lỗi 2 báo hiệu không được xóa
	o B3: Xóa chi tiết phiếu mượn tương ứng
	o B4: Xóa phiếu mượn
	o B5: Trả về 0 báo hiệu thành công
*/

if OBJECT_ID('Query_16', 'P') is not null
	drop proc Query_16
go
create proc Query_16 @i_mapm char(10)
as
	if @i_mapm not in (select mapm from PhieuMuon)
		return 1

	if @i_mapm in (select mapm from PhieuTra)
		return 2

	delete from CT_PhieuMuon
	where mapm = @i_mapm

	delete from PhieuMuon
	where mapm = @i_mapm
go

/*
17. Xóa phiếu trả.
 Input: mã phiếu trả
 Output: 0 – xóa thành công hoặc mã lỗi (số nguyên > 0) nếu thất bại.
 Các bước thực hiện:
	o B1: Kiểm tra mapt phải tồn tại  nếu không trả về lỗi 1
	o B2: Xóa chi tiết phiếu trả tương ứng
	o B3: Xóa phiếu trả
	o B4: Trả về 0 báo hiệu thành công
*/

if OBJECT_ID('Query_17', 'P') is not null
	drop proc Query_17
go
create proc Query_17 @i_mapt char(10)
as
	if @i_mapt not in (select mapt from PhieuTra)
		return 1

	delete from CT_PhieuTra
	where mapt = @i_mapt

	delete from PhieuTra
	where mapt = @i_mapt

	return 0
go