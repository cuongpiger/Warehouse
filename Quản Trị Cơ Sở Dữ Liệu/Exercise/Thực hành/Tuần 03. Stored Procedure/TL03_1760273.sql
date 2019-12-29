------------------------------------------------------------------------------------------------1
if OBJECT_ID('Query1', 'P') is not null
	drop proc Query1
go
create proc Query1
	@maPM char(10)
as
	select dg.socmnd, dg.hoten, dg.diachi, dg.ngsinh
	from DocGia dg, PhieuMuon pm
	where dg.madg = pm.madg and pm.mapm = @maPM
go

exec Query1 'PM001'
------------------------------------------------------------------------------------------------2
if OBJECT_ID('Query2', 'P') is not null
	drop proc Query2
go
create proc Query2
	@ip_nam int
as
	select *
	from DocGia dg
	where year(dg.ngsinh) = @ip_nam
go

exec Query2 1980
------------------------------------------------------------------------------------------------3
if OBJECT_ID('Query3', 'P') is not null
	drop proc Query3
go
create proc Query3
as
	select *
	from DocGia dg
	where dg.ngsinh <= all (select dg1.ngsinh
							from DocGia dg1)
go

exec Query3 
------------------------------------------------------------------------------------------------4
if OBJECT_ID('Query4', 'P') is not null
	drop proc Query4
go
create proc Query4
	@maPM char(10)
as
	select dg.socmnd, dg.hoten, count(*)
	from DocGia dg, PhieuMuon pm, CT_PhieuMuon ctpm
	where dg.madg = pm.madg and pm.mapm = @maPM and pm.mapm = ctpm.mapm
	group by dg.socmnd, dg.hoten
go

exec Query4 'PM004'
------------------------------------------------------------------------------------------------5
if OBJECT_ID('Query5', 'P') is not null
	drop proc Query5
go
create proc Query5
	@i_ispn nchar(12)
as
	select dg.socmnd, dg.hoten, dg.ngsinh, dg.diachi
	from DocGia dg, PhieuMuon pm, CT_PhieuMuon ctpm
	where dg.madg = pm.madg and pm.mapm = ctpm.mapm and ctpm.isbn = @i_ispn
go

exec Query5 '116525441'