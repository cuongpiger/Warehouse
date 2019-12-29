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