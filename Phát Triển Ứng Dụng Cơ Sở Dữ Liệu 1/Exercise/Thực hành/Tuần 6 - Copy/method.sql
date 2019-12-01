use QLSV
go

-- spd load the list of class ID
if OBJECT_ID('stpLoadClassID', 'P') is not null
	drop proc stpLoadClassID
go
create proc stpLoadClassID
as
	select MaLop from LOP
go

-- spd insert one student
if OBJECT_ID('stpInsertOneStudent', 'P') is not null
	drop proc stpInsertOneStudent
go
create proc stpInsertOneStudent @iMaSV nvarchar(10), @iHoTen nvarchar(40), @iNgaySinh date, @iPhai nvarchar(10), @iLop nvarchar(10), @iDTB float
as
	if @iDTB = -1
		set @iDTB = null
	
	insert into SINHVIEN
	values (@iMaSV, @iHoTen, @iNgaySinh, @iPhai, @iLop, @iDTB)
go

select * from SINHVIEN