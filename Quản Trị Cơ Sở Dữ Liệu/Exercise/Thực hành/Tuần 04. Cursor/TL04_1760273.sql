/*
1. Viết thủ tục in thông tin theo mẫu sau:
Stt ISBN TenSach TacGia NamXB
-------------------------------------------------------------------------
-------------------------------------------------------------------------
Tổng số đầu sách: */
if OBJECT_ID('Query_1', 'P') is not null
	drop proc Query_1
go
create proc Query_1
as
	declare @stt int = 1, @isbn nchar(12), @tensach nvarchar(100), @tacgia nvarchar(50), @namxb int
	declare cur cursor for (select ds.isbn, ds.tensach, ds.tacgia, ds.namxb
							from DauSach ds) 
	open cur
	
	print 'Stt' + space(3) + 'ISBN' + space(5) + 'TenSach' + space(5) + 'TacGia' + space(5) + 'NamXB'	print '----------------------------------------------------------------------------------------------------------------'		fetch next from cur into @isbn, @tensach, @tacgia, @namxb	while @@FETCH_STATUS = 0	begin		print cast(@stt as varchar(3)) + space(3 - len(@stt)) + @isbn + space(12 - len(@isbn)) + @tensach + 		space(50 - len(@tensach)) +@tacgia + space(30 - len(@tacgia)) + cast(@namxb as varchar(4))		set @stt += 1		fetch next from cur into @isbn, @tensach, @tacgia, @namxb	end

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
	print N'Tên đầu sách: ' + @tendausach	print N'Số sách đang mượn: ' + cast(@cnt2 as varchar)	print 'Stt          TenDG          MaPM           SoNgayMuon'	print '----------------------------------------------------------------------------------------------------------------'	fetch next from cur into @hoten, @mapm, @datem, @datet	while @@FETCH_STATUS = 0	begin		if @datet is null		begin			set @datet = (select GETDATE())		end		set @snm = (SELECT DATEDIFF(dd, @datem, @datet) AS DateDiff)		print cast(@stt as varchar(3)) + space(3 - len(@stt)) + @hoten + space(30 - len(@hoten)) + @mapm + space(15 - len(@mapm)) + cast(@snm as varchar)		set @stt += 1		fetch next from cur into @hoten, @mapm, @datem, @datet	end

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
	
	print 'Stt         ISBN        MaSach        SoNgayQuyDinh'	print '----------------------------------------------------------------------------------------------------------------'		fetch next from cur into @isbn, @masach, @snqd, @ngaytra	while @@FETCH_STATUS = 0	begin		print cast(@stt as varchar(3)) + space(3 - len(@stt)) + @isbn + space(12 - len(@isbn)) + @masach + 		space(50 - len(@masach)) + cast(@snqd as varchar(4))		set @stt += 1		if @ngaytra is null			set @cntTra += 1		else			set @cntMuon += 1		fetch next from cur into @isbn, @masach, @snqd, @ngaytra	end

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
	open cur1		fetch next from cur1 into @isbn1, @tensach1	while @@FETCH_STATUS = 0	begin		print N'Tên sách: ' + @tensach1		print N'DANH SÁCH SÁCH MƯỢN'		print 'Stt         ISBN            MaSach         NgayMuon        NgayTra       TinhTrang'		print '----------------------------------------------------------------------------------------------------------------'				declare @stt2 int = 1, @isbn2 nchar(12), @masach2 nchar(5), @ngmuon2 date, @ngtra2 date, @ttrang2 nchar(50)		declare cur2 cursor for (select cs.isbn, cs.masach, pm.ngaymuon, pt.ngaytra, cs.tinhtrang
								 from CuonSach cs, PhieuMuon pm, PhieuTra pt, CT_PhieuMuon ctpm								 where cs.isbn = @isbn1 and cs.isbn = ctpm.isbn and ctpm.mapm = pm.mapm and ctpm.mapm = pt.mapm) 		open cur2		fetch next from cur2 into @isbn2, @masach2, @ngmuon2, @ngtra2, @ttrang2				while @@FETCH_STATUS = 0		begin			print cast(@stt2 as varchar(3)) + space(3 - len(@stt2)) + @isbn2 + space(12 - len(@isbn2)) + @masach2 + 			space(50 - len(@masach2)) + cast(@ngmuon2 as varchar) + space(50 - len(@ngmuon2)) + cast(@ngtra2 as varchar) + space(30 - len(@ngtra2)) + @ttrang2			fetch next from cur2 into @isbn2, @masach2, @ngmuon2, @ngtra2, @ttrang2			set @stt2 += 1		end		close cur2
		deallocate cur2		print '----------------------------------------------------------------------------------------------------------------'		fetch next from cur1 into @isbn1, @tensach1
	end

	close cur1
	deallocate cur1
	
	print ' '
go

exec Query_5