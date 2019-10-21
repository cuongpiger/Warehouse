--1. Vieቷt hà m cho biết so độc giả sinh là ‘Nữ ’
if OBJECT_ID('Query__1') is not null
	drop function Query__1
go
create function Query__1() returns int
as
begin
	return (select count(distinct madg)from DocGia where gioitinh = N'Nữ')
end
go

select dbo.Query__1()

--2. Vieቷt hà m truyeቹn và o MaDG cho biết tuoቻi củ a đọc gia
if OBJECT_ID('Query__2') is not null
	drop function Query__2
go
create function Query__2(@i_madg nchar(10)) returns int
as
begin
	declare @born date = (select ngsinh from DocGia where madg = @i_madg)
	return (select DATEDIFF(YY, @born, GETDATE()))
end
go

select dbo.Query__2('DG01')

--3. Vieቷt hà m truyeቹn và o ISBN, MaSach cho biết sá ch có theቻ mượn không
if OBJECT_ID('Query__3') is not null
	drop function Query__3
go
create function Query__3(@i_isbn nchar(12), @i_masach nchar(5)) returns int
as
begin
	declare @tinhTrang nchar(50) = (select tinhtrang from CuonSach where isbn = @i_isbn and masach = @i_masach)
	
	if @tinhTrang = N'có thể mượn'
		return 1
	return 0
end
go

select dbo.Query__3('116525441', 'S001')

--4. Vieቷt hà m truyeቹn và o MaDG cho bieቷt soቷ phieቷu mượ n củ a đọ c gia
if OBJECT_ID('Query__4') is not null
	drop function Query__4
go
create function Query__4(@i_madg nchar(10)) returns int
as
begin
	return (select COUNT(distinct mapm) from PhieuMuon where madg = @i_madg)
end
go

select dbo.Query__4('DG01')

/*5. Vieቷt hà m truyeቹn và o MaPM, ISBN, MaSach cho bieቷt sá ch đã đến hạ n trả chưa. Bieቷt
sá ch đeቷn hạn khi NGAYMUON + SONGAYQUYDINH < NGAYHIENTAI
Gợi ý: dùng hàm DateAdd(DAY, Số ngày cộng thêm, Ngay)*/

if OBJECT_ID('Query__5') is not null
	drop function Query__5
go
create function Query__5(@i_mapm char(10), @i_isbn nchar(12), @i_masach nchar(5)) returns int
as
begin
	declare @snqd int = (select songayquydinh from CT_PhieuMuon where isbn = @i_isbn and masach = @i_mapm and mapm = @i_mapm)
	declare @ngayMuon date = (select ngaymuon from PhieuMuon where mapm = @i_mapm)
	
	declare @ngayTra date = (select DATEADD(DAY, @snqd, @ngayMuon))

	if @ngayTra < GETDATE()
		return 1

	return 0
end
go

select dbo.Query__5('PM001', '116525441', 'S001')

/*6. Vieቷt hà m truyeቹn vào MaPM, đeቷm soቷ sá ch đeቷn hạ n trả
Gợi ý: gọi hàm câu 4 
*/

if OBJECT_ID('Query__6') is not null
	drop function Query__6
go
create function Query__6(@i_mapm char(10)) returns int
as 
begin
	declare @ngayMuon date = (select ngaymuon from PhieuMuon where mapm = @i_mapm)
	declare @c_isbn nchar(12), @c_masach nchar(5)
	declare cur cursor for (select isbn, masach from CT_PhieuMuon where mapm = @i_mapm)
	declare @res int = 0

	open cur
	fetch next from cur into @c_isbn, @c_masach

	while @@FETCH_STATUS = 0
	begin
		if (select dbo.Query__5(@i_mapm, @c_isbn, @c_masach)) = 1
			set @res += 1

		fetch next from cur into @c_isbn, @c_masach
	end
	close cur
	deallocate cur

	return @res
end 
go

/*7. Vieቷt hà m truyeቹn và o MaPM, đeቷm soቷ sá ch đã trả
Gợi ý: sách đã trả là sách nằm trong CT_PhieuTra của MaPM truyền vào*/

if OBJECT_ID('Query__7') is not null
	drop function Query__7
go
create function Query__7(@i_mapm char(10)) returns int
as 
begin
	return (select count(*)
			from PhieuTra pt join CT_PhieuTra ctpt on pt.mapm = @i_mapm and pt.mapt = @i_mapm)
end 
go

--8, 9. Vieቷt hà m truyeቹn và o ISBN, đếm soቷ sá ch đã mượ n củ a đaቹu sá ch nà y
if OBJECT_ID('Query__8') is not null
	drop function Query__8
go
create function Query__8(@i_isbn nchar(12)) returns int
as 
begin
	return (select count(distinct masach) from CT_PhieuMuon where isbn = @i_isbn)
end
go

--10. Vieቷt hà m truyeቹn và o MaDG, đeቷm số sá ch mà đọc giả nà y đã mượ n
if OBJECT_ID('Query__10') is not null
	drop function Query__10
go
create function Query__10(@i_madg nchar(10)) returns int
as
begin
	declare @sum int = 0, @c_isbn nchar(12), @c_mapm char(10)
	declare cur cursor for (select distinct ctpm.isbn, ctpm.mapm
							from PhieuMuon pm, CT_PhieuMuon ctpm
							where pm.mapm  = ctpm.mapm and pm.madg = @i_madg)

	open cur
	fetch next from cur into @c_isbn, @c_mapm

	while @@FETCH_STATUS = 0
	begin
		set @sum += (select count(distinct ctpm.masach)
					 from CT_PhieuMuon ctpm
					 where ctpm.isbn = @c_isbn and ctpm.mapm = @c_mapm)
	end
	return @sum
end
go

--11. Vieቷt hà m truyền vào NgayMuon, đeቷm soቷ sá ch đã đượ c mượ n trong ngà y đo
if OBJECT_ID('Query__11') is not null
	drop function Query__11
go
create function Query__11(@i_ngaymuon date) returns int
as
begin
	declare @sum int = 0, @c_isbn nchar(12), @c_mapm char(10)
	declare cur cursor for (select distinct ctpm.isbn, ctpm.mapm
							from PhieuMuon pm, CT_PhieuMuon ctpm
							where pm.mapm  = ctpm.mapm and pm.ngaymuon = @i_ngaymuon)

	open cur
	fetch next from cur into @c_isbn, @c_mapm

	while @@FETCH_STATUS = 0
	begin
		set @sum += (select count(distinct ctpm.masach)
					 from CT_PhieuMuon ctpm
					 where ctpm.isbn = @c_isbn and ctpm.mapm = @c_mapm)
	end
	return @sum
end
go

--12. Vieቷt hà m truyeቹn và o MaPT, tính toቻng soቷ tieቹn phạ t củ a phieቷu trả đo
if OBJECT_ID('Query__12') is not null
	drop function Query__12
go
create function Query__12(@i_mapt char(10)) returns float
as 
begin
	declare @sum float = 0, @c_isbn nchar(12), @c_masach nchar(5)
	declare cur cursor for (select distinct ctpt.isbn, ctpt.masach
							from CT_PhieuTra ctpt
							where ctpt.mapt = @i_mapt)

	open cur
	fetch next from cur into @c_isbn, @c_masach

	while @@FETCH_STATUS = 0
	begin
		set @sum += (select ctpt.tienphat
					 from CT_PhieuTra ctpt
					 where ctpt.isbn = @c_isbn and ctpt.masach = @c_masach)
	end
	return @sum
end
go