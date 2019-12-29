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

--2. Nhận vào hai số a, b và trả về hiệu a, b. 
if OBJECT_ID('TinhHieu2So', 'P') is not null
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

--3. Nhận vào hai số a, b và trả về tích a, b. 
if OBJECT_ID('TinhTich2So', 'P') is not null
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

--4. Nhận vào hai số a, b và trả về thương a, b. 
if OBJECT_ID('TinhThuong2So', 'P') is not null
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

--5. Nhận vào hai số a, b và trả về số dư của phép chia a cho b. 
if OBJECT_ID('ChiaLayDu', 'P') is not null
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

--7. Nhận vào n, m và trả về tổng các giá trị nằm trong đoạn n, m (dùng tham số output). 
if OBJECT_ID('SumFromMtoN', 'P') is not null
	drop proc SumFromMtoN
go
create proc SumFromMtoN
	@m int,
	@n int,
	@res int output
as
	set @res = 0

	while (@m <= @n)
	begin
		set @res = @res + @m
		set @m = @m + 1
	end
go

declare @res int
exec SumFromMtoN 1, 5, @res output
print @res

--8. Nhận vào năm n, kiểm tra xem n có phải năm nhuận không. Nếu n là năm nhuận trả về 1 còn
--không phải trả về 0 (dùng tham số output). 
if OBJECT_ID('IsLeapYear', 'P') is not null
	drop proc IsLeapYear
go
create proc IsLeapYear
	@yy int,
	@res int output
as
	declare @foo nvarchar (10)
	set @foo = convert (nvarchar, @yy) + '-12-31'
	set @res = cast((select DATEPART(y, @foo) AS DatePartInt) as int);
go

declare @res int
exec IsLeapYear 2012, @res output

if (@res = 366)
begin
	print N'Is Leap Year'
end
else
begin
	print N'Is Normal Year'
end

--9. Nhận vào năm n, m, đếm xem có bao nhiêu năm nhuận trong đoạn n đến m (dùng tham số
--output). 
if OBJECT_ID('CountLeapYear', 'P') is not null
	drop proc CountLeapYear
go
create proc CountLeapYear
	@m int,
	@n int,
	@res int output
as
	declare @foo nvarchar (10)
	set @res = 0

	while (@m <= @n)
	begin
		set @foo = convert (nvarchar, @m) + '-12-31'

		if (cast((select DATEPART(y, @foo) AS DatePartInt) as int) = 366)
		begin
			set @res += 1
		end

		set @m += 1
	end
go

declare @res int
exec CountLeapYear 2004, 2019, @res output
print N'Has ' + cast(@res as varchar) + N' years is leap years'

--10. Nhận vào n và trả ra giá trị n!, biết rằng n! = 1*2*3*…*n if OBJECT_ID('CalcFact', 'P') is not null
	drop proc CalcFact
go
create proc CalcFact
	@n int,
	@res int output
as
	set @res = 1
	declare @flag int set @flag = 2

	while (@flag <= @n)
	begin
		set @res *= @flag
		set @flag += 1
	end
go

declare @res int
exec CalcFact 4, @res output
print @res

--11. Nhận vào ngày a (kiểu date hoặc datetime) cho biết tháng của ngày a có bao nhiêu ngày. Ví dụ:
--ếu ngày a là ngày 15/02/2000 thì trả về 28 là số ngày của tháng 2 trong năm 2000.if OBJECT_ID('CalcMonth', 'P') is not null
	drop proc CalcMonth
go
create proc CalcMonth
	@a date
as
	return datediff(day, dateadd(day, 1-day(@a), @a),
              dateadd(month, 1, dateadd(day, 1-day(@a), @a)))
go

declare @a date ='2013-2-01'
declare @res int 
exec @res = CalcMonth @a
print @res

--12. Nhận vào n, kiểm tra xem n có phải số nguyên tố không. Nếu là số nguyên tố trả về 1 còn
--không trả về 0. if OBJECT_ID('CheckPrime', 'P') is not null
	drop proc CheckPrime
go
create proc CheckPrime
	@n int
as
	if (@n <= 1)
	begin
		return 0
	end
	declare @i int = 2
	while (@i <= sqrt(@n))
	begin
		if (@n % @i = 0)
		begin
			return 0
		end

		set @i += 1
	end

	return 1
go

declare @res int
exec @res = CheckPrime 4
print @res

--13. Nhận vào n, m và trả về tích các số nguyên tố nằm trong đoạn n, m (dùng tham số output). Lưu
--ý: số nguyên tố là số có hai ước chung là 1 và chính nó, ví dụ: 13, 17, ... if OBJECT_ID('MultiPrime', 'P') is not null
	drop proc MultiPrime
go
create proc MultiPrime
	@m int,
	@n int,
	@res int output
as
	set @res = 1

	while (@m <= @n)
	begin
		declare @tmp int
		exec @tmp = CheckPrime @m

		if (@tmp = 1)
		begin
			set @res = @res * @m
		end

		set @m += 1
	end
go

declare @res int
exec MultiPrime 1, 7, @res output
print @res

--14. Nhận vào n, kiểm tra xem n có phải số chính phương không. Nếu là số chính phương trả về 1
--còn không trả về 0. Lưu ý: số chính phương là bình phương của một số khác, ví dụ: 4, 9, ... if OBJECT_ID('SoChinhPhuong', 'P') is not null
	drop proc SoChinhPhuong
go
create proc SoChinhPhuong
	@n int
as
	declare @i int = 1
	while (@i <= @n)
	begin
		declare @tmp int = @i*@i
		if (@tmp = @n)
		begin
			return 1
		end

		set @i += 1
	end

	return 0
go

declare @res int
exec @res = SoChinhPhuong 4
print @res

--15. Nhận vào n, m và trả về tổng các số chính phương nằm trong đoạn n, m (dùng tham số output). 
if OBJECT_ID('TongSoChinhPhuong', 'P') is not null
	drop proc TongSoChinhPhuong
go
create proc TongSoChinhPhuong
	@m int,
	@n int,
	@res int output
as
	set @res = 0
	while (@m <= @n)
	begin
		declare @tmp int
		exec @tmp = SoChinhPhuong @m
		if (@tmp = 1)
		begin
			set @res += @m
		end

		set @m += 1
	end
go

declare @res int
exec TongSoChinhPhuong 1, 7, @res output
print @res