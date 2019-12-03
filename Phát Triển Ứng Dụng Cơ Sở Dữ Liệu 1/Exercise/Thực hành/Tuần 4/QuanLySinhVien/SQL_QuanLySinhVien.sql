-- store thêm một sinh viên vào CSDL
if OBJECT_ID('InsertSV', 'P') is not null
	drop proc InsertSV
go
create proc InsertSV(@i_masv varchar(15), @i_hoten nvarchar(30), @i_ngaysinh date, @i_phai nvarchar(5), @i_lop nvarchar(15), @i_dtb float)
as
	if @i_masv in (select MaSV from SINHVIEN)
		return 1

	if @i_masv is null
		return 2

	insert into SINHVIEN
	values (@i_masv, @i_hoten, @i_ngaysinh, @i_phai, @i_lop, @i_dtb)

	return 0
go

-- store trả về sinh viên cần tìm dựa vào mã sinh viên
if OBJECT_ID('SeekSV', 'P') is not null
	drop proc SeekSV
go
create proc SeekSV(@i_masv varchar(15))
as
	if @i_masv not in (select MaSV from SINHVIEN)
		return 1

	select *
	from SINHVIEN
	where MaSV = @i_masv

	return 0
go

-- tìm sinh viên có DTB cao nhất
if OBJECT_ID('SeekSVMaxScore', 'P') is not null
	drop proc SeekSVMaxScore
go
create proc SeekSVMaxScore
as
	select *
	from SINHVIEN sv
	where sv.DTB >= all (select sv1.DTB from SINHVIEN sv1)
go

-- tìm sinh viên có DTB thấp nhất
if OBJECT_ID('SeekSVMinScore', 'P') is not null
	drop proc SeekSVMinScore
go
create proc SeekSVMinScore
as
	select *
	from SINHVIEN sv
	where sv.DTB <= all (select sv1.DTB from SINHVIEN sv1)
go

-- xuất danh sách sinh viên theo phái
if OBJECT_ID('PrintSVGender', 'P') is not null
	drop proc PrintSVGender
go
create proc PrintSVGender(@i_phai nvarchar(5))
as
	select *
	from SINHVIEN sv
	where sv.Phai = @i_phai
go