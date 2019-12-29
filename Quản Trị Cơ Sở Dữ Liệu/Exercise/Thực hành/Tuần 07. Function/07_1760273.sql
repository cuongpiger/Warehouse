/*
1. Vieቷt hà m cho bieቷt danh sá ch đọ c giả ở ‘TP.HCM’
*/
if OBJECT_ID('Q1') is not null
	drop function Q1
go
create function Q1()
	returns table
as
	return (select *
			from DocGia dg
			where dg.diachi like '%TP.HCM%'	)
go

select *
from Q1()

/*
2. Vieቷt hàm cho bieቷt danh sá ch đọ c giả có sá ch đã đeቷn hạ n trả (gọi Func_L1 câu 4)
*/

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

if OBJECT_ID('Q2') is not null
	drop function Q2
go
create function Q2()
	returns table
as
	return (select dg.*
			from DocGia dg, PhieuMuon pm, CT_PhieuMuon ctpm
			where dg.madg = pm.mapm and pm.mapm = ctpm.mapm and
				  (select dbo.Query__5(ctpm.mapm, ctpm.isbn, ctpm.masach)) = 1)
go

select *
from Q2()

/*
3. Vieቷt hà m truyeቹn vào MaPM cho biết danh sá ch đọ c giả (MaDG, HoTen) và soቷ tieቹn
phạ t mà đọ c giả phả i trả (gọi Func_L1 câu 11)
*/
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

if OBJECT_ID('Q3') is not null
	drop function Q3
go
create function Q3()
	returns table
as
	return (select dg.*, dbo.Query__12(pt.mapt) as returnValue
			from DocGia dg, PhieuMuon pm, PhieuTra pt
			where dg.madg = pm.mapm and pm.mapm = pt.mapm)
go

select *
from Q3()

/*
4. Vieቷt hàm cho bieቷt danh sá ch cuoቷn sá ch (ISBN, MaSach) và NgayMuon củ a cuoቷn
sá ch đó .
*/

if OBJECT_ID('Q4') is not null
	drop function Q4
go
create function Q4()
	returns table
as
	return (select ctpm.isbn, ctpm.masach, pm.ngaymuon
			from PhieuMuon pm, CT_PhieuMuon ctpm
			where pm.mapm = ctpm.mapm)
go

select *
from Q4()