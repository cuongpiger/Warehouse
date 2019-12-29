--1. Nhận vào hai số a, b và trả về tổng a, b. 
if OBJECT_ID('TinhTong2So', 'P') is not null
	drop proc TinhTong2So
go
create proc TinhTong2So
	@a int,
	@b int,
	@tong int output
as
	set @tong = @a + @b
go

declare @res int
exec TinhTong2So 5, 2, @res output
print @res

--2. Nhận vào hai số a, b và trả về hiệu a, b. if OBJECT_ID('TinhHieu2So', 'P') is not null
	drop proc TinhHieu2So
go
create proc TinhHieu2So
	@a int,
	@b int,
	@hieu int output
as
	set @hieu = @a - @b
go

declare @res int
exec TinhHieu2So 5, 2, @res output
print @res

--3. Nhận vào hai số a, b và trả về tích a, b. if OBJECT_ID('TinhTich2So', 'P') is not null
	drop proc TinhTich2So
go
create proc TinhTich2So
	@a int,
	@b int,
	@tich int output
as
	set @tich = @a * @b
go

declare @res int
exec TinhTich2So 5, 2, @res output
print @res

--4. Nhận vào hai số a, b và trả về thương a, b. if OBJECT_ID('TinhThuong2So', 'P') is not null
	drop proc TinhThuong2So
go
create proc TinhThuong2So
	@a int,
	@b int,
	@thuong int output
as
	if (@b != 0)
	begin
		set @thuong = @a / @b
	end
	else
	begin
		set @thuong = null
	end
go

declare @res int
exec TinhThuong2So 5, 0, @res output
print @res

--5. Nhận vào hai số a, b và trả về số dư của phép chia a cho b. if OBJECT_ID('ChiaLayDu', 'P') is not null
	drop proc ChiaLayDu
go
create proc ChiaLayDu
	@a int,
	@b int,
	@du int output
as
	set @du = @a % @b
go

declare @res int
exec ChiaLayDu 5, 2, @res output
print @res

--6. Nhận vào hai số a, b và i.
-- Nếu i là 1 trả về tổng a, b
-- Nếu i là 2 trả về hiệu a, b
-- Nếu i là 3 trả về tích a, b
-- Nếu i là 4 trả về thương a, b
-- Nếu i là 5 trả về số dư phép chia a cho b
--Yêu cầu: sử dụng lại stored procedure ở câu 1 đến câu 5 và dùng case để xét giá trị i. 
if OBJECT_ID('ChooseOption', 'P') is not null
	drop proc ChooseOption
go
create proc ChooseOption
	@a int,
	@b int,
	@i int
as
	declare @res int

	if (@i = 1)
	begin
		exec TinhTong2So @a, @b, @res output
	end
	else if (@i = 2)
	begin
		exec TinhHieu2So @a, @b, @res output
	end
	else if (@i = 3)
	begin
		exec TinhTich2So @a, @b, @res output
	end
	else if (@i = 4)
	begin
		exec TinhThuong2So @a, @b, @res output
	end
	else if (@i = 5)
	begin
		exec ChiaLayDu @a, @b, @res output
	end

	print @res
go

exec ChooseOption 5, 2, 1
exec ChooseOption 5, 2, 2
exec ChooseOption 5, 2, 3
exec ChooseOption 5, 2, 4
exec ChooseOption 5, 2, 5