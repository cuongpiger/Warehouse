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

	if (@iDTB < 0 or @iDTB > 10)
		return
	
	insert into SINHVIEN
	values (@iMaSV, @iHoTen, @iNgaySinh, @iPhai, @iLop, @iDTB)
go

-- spd delete one student
if OBJECT_ID('spdDeleteOneStudent', 'P') is not null
	drop proc spdDeleteOneStudent
go
create proc spdDeleteOneStudent @iMaSV nvarchar(10)
as
	delete from SINHVIEN where MaSV = @iMaSV
go

-- spd update one student
if OBJECT_ID('spdUpdateOneStudent', 'P') is not null
	drop proc spdUpdateOneStudent
go
create proc spdUpdateOneStudent @iMaSV nvarchar(10), @iHoTen nvarchar(40), @iNgaySinh date, @iPhai nvarchar(10), @iLop nvarchar(10), @iDTB float
as
	if @iDTB = -1
		set @iDTB = null

	update SINHVIEN
	set HoTen = @iHoTen, NgaySinh = @iNgaySinh, Phai = @iPhai, Lop = @iLop, DTB = @iDTB
	where MaSV = @iMaSV
go

-- spd load list of students
if OBJECT_ID('spdLoadListStudents', 'P') is not null
	drop proc spdLoadListStudents
go
create proc spdLoadListStudents
as
	select * from SINHVIEN
go

-- spd insert one class
if OBJECT_ID('stpInsertOneClass', 'P') is not null
	drop proc stpInsertOneClass
go
create proc stpInsertOneClass @iMaLop nvarchar(10), @iKhoa int, @iLoai nvarchar(5), @iLopTruong nvarchar(10)
as
	if @iKhoa = -1
		set @iKhoa = null

	insert into LOP
	values (@iMaLop, @iKhoa, @iLoai, @iLopTruong)
go

-- spd delete one class
if OBJECT_ID('spdDeleteOneClass', 'P') is not null
	drop proc spdDeleteOneClass
go
create proc spdDeleteOneClass @iMaLop nvarchar(10)
as
	delete from LOP where MaLop = @iMaLop
go

-- spd update one class
if OBJECT_ID('spdUpdateOneClass', 'P') is not null
	drop proc spdUpdateOneClass
go
create proc spdUpdateOneClass @iMaLop nvarchar(10), @iKhoa int, @iLoai nvarchar(5), @iLopTruong nvarchar(10)
as
	update LOP
	set khoa = @iKhoa, loai = @iLoai, LopTruong = @iLopTruong
	where MaLop = @iMaLop
go

-- spd load list of classes
if OBJECT_ID('spdLoadListClasses', 'P') is not null
	drop proc spdLoadListClasses
go
create proc spdLoadListClasses
as
	select * from LOP
go

-- spd load list of student with class ID
if OBJECT_ID('spdLoadListStudentsWithClassID', 'P') is not null
	drop proc spdLoadListStudentsWithClassID
go
create proc spdLoadListStudentsWithClassID @iMaLop nvarchar(10)
as
	select *
	from SINHVIEN sv
	where sv.Lop = @iMaLop
go

-- spd load list of dkhp with MaSV
if OBJECT_ID('spdLoadListDkhpsWithMaSV', 'P') is not null
	drop proc spdLoadListDkhpsWithMaSV
go
create proc spdLoadListDkhpsWithMaSV @iMaSV nvarchar(10)
as
	select *
	from DKHP dk
	where dk.MaSV = @iMaSV
go

-- spd insert one dkhp
if OBJECT_ID('stpInsertOneDkhp', 'P') is not null
	drop proc stpInsertOneDkhp
go
create proc stpInsertOneDkhp @iNH nvarchar(10), @iHK nvarchar(10), @iMaSV nvarchar(20), @iMaMH nvarchar(20), @iSoTC int, @iDiaDiem nvarchar(50), @iDiem float
as
	if @iDiem = -1
		set @iDiem = null

	insert into DKHP
	values (@iNH, @iHK, @iMaSV, @iMaMH, @iSoTC, @iDiaDiem, @iDiem)
go

-- spd delete one dkhp
if OBJECT_ID('spdDeleteOneDkhp', 'P') is not null
	drop proc spdDeleteOneDkhp
go
create proc spdDeleteOneDkhp @iMaSV nvarchar(10), @iMaMH nvarchar(10), @iNH nvarchar(10), @iHK nvarchar(10)
as
	delete from DKHP where MaSV = @iMaSV and MaMH = @iMaMH and NH = @iNH and HK = @iHK
go

-- spd update one dkhp
if OBJECT_ID('spdUpdateOneDkhp', 'P') is not null
	drop proc spdUpdateOneDkhp
go
create proc spdUpdateOneDkhp @iNH nvarchar(10), @iHK nvarchar(10), @iMaSV nvarchar(20), @iMaMH nvarchar(20), @iSoTC int, @iDiaDiem nvarchar(50), @iDiem float
as
	update DKHP
	set SoTC = @iSoTC, Diadiem = @iDiaDiem, Diem = @iDiem
	where NH = @iNH and HK = @iHK and MaSV = @iMaSV and MaMH = @iMaMH
go

exec stpInsertOneStudent '1760274', 'Kim ngan', '1999-03-03', 'Nam', '17CK2', null
exec stpInsertOneStudent '1760275', 'Kim ngan', '1999-03-03', 'Nam', '17CK2', null
exec stpInsertOneStudent '1760276', 'Kim ngan', '1999-03-03', 'Nam', '17CK2', null

select * from DKHP