--//a.
-- Tao Database
create database QLSV
go
use QLSV

-- Tao cac Table
create table SINHVIEN
(	
	MaSV varchar(15) not null,
	HoTen nvarchar(30),
	NgaySinh date,
	Phai nvarchar(5),
	Lop varchar(15),
	DTB numeric(5,1)
)
go
create table LOP
(	
	MaLop varchar(15) not null,
	khoa int,
	loai nvarchar(5),
	LopTruong varchar(15) 
)
go
create table DKHP
(
	NH varchar(5) not null,
	HK varchar(1) not null,
	MaSV varchar(15) not null,
	MaMH varchar(15) not null,
	SoTC numeric(5,1),
	Diadiem varchar(5),
	Diem numeric(5,1)  
)
go
-- Tao khoa chinh
alter table SINHVIEN
add constraint PK_SINHVIEN primary key (MaSV)

alter table LOP
add constraint PK_LOP primary key (MaLop)

alter table DKHP
add constraint PK_DKHP primary key (NH, HK, MaSV, MaMH) 

go
--//b.
-- Tao khoa ngoai
alter table LOP
add constraint FK_LOP_SINHVIEN foreign key (LopTruong) references SINHVIEN(MaSV)

alter table SINHVIEN
add constraint FK_SINHVIEN_LOP foreign key (Lop) references LOP(MaLop)

alter table DKHP
add constraint FK_DKHP_SINHVIEN foreign key (MaSV) references SINHVIEN(MaSV)

go
--//c.
-- Nhap lieu

insert into SINHVIEN (MaSV, HoTen, NgaySinh, Phai)
values('19110033', N'Nguyễn Văn Thành', '12/22/2001', 'Nam'),
('19110066', N'Đào Thị Hân', '04/15/2001', N'Nữ'),
('19110088', N'Vũ Đức Hải', '05/03/2001', 'Nam'),
('18120120', N'Phạm Hữu Hào', '08/06/2000', 'Nam'),
('18120460', N'Nguyễn Ngọc Lan', '02/14/2000', N'Nữ')
go

insert into LOP (MaLop, Khoa, Loai, LopTruong)
values ('19TTH1', '2019', 'CQ', '19110033'),
('19TTH2', '2019', 'TN', '19110088'),
('18CNTT1', '2018', 'CQ', '18120460')
go

 insert into DKHP (nh, hk, masv, mamh, sotc, diadiem)
values ('19-20', '1', '19110033', 'BAA00004', 3, 'LT'),
('19-20','1','19110033','BAA00011',4,'LT'),
('19-20','1','19110033','CSC00003',4,'NVC'),
('19-20','1','19110033','MTH00010',3,'NVC'),
('19-20','1','19110066','BAA00004',3,'LT'),
('19-20','1','19110066','BAA00021',3,'NVC'),
('19-20','1','19110066','MTH00030',4,'NVC'),
('19-20','1','19110088','BAA00004',3,'LT'),
('19-20','1','19110088','BAA00101',4,'NVC'),
('19-20','1','19110088','CSC00003',4,'NVC'),
('19-20','1','19110088','MTH00083',2,'NVC'),
('19-20','1','18120120','BAA00012',3,'LT'),
('19-20','1','18120120','CSC10001',4,'NVC'),
('19-20','1','18120120','MTH00086',3,'NVC'),
('19-20','1','18120460','BAA00012',3,'LT'),
('19-20','1','18120460','CSC00004',4,'NVC'),
('19-20','1','18120460','MTH00041',3,'NVC')
go
-- Cap nhat du lieu
update SINHVIEN set lop='18CNTT1' where MaSV='18120120'
update SINHVIEN set lop='18CNTT1' where MaSV='18120460'
update SINHVIEN set lop='19TTH1' where MaSV='19110033'
update SINHVIEN set lop='19TTH1' where MaSV='19110066'
update SINHVIEN set lop='19TTH2' where MaSV='19110088'
go
--//d. Hay cho biet thong tin cac lop truong (malop, masv, hoten, phai)

select l.MaLop, s.MaSV, s.HoTen, s.Phai 
from SINHVIEN as s inner join LOP as l on s.MaSV = l.LopTruong
order by s.MaSV
go
--//e. Hay cho biet danh sach sinh vien thuoc lop (malop, masv, hoten, phai, dtb)

select l.MaLop, s.MaSV, s.HoTen, s.Phai, s.DTB 
from SINHVIEN as s inner join LOP as l on s.Lop = l.MaLop
where l.MaLop='19TTH1'
order by s.MaSV
go
--//f. Viet Function tinh tong so sinh vien

create Function fc_Tong ()
returns int
as
begin
	declare @tong int

	select @tong = count(masv) from SINHVIEN

	return @tong
end

-- thuc thi: select dbo.fc_Tong() as tong
go

--//g. Viet Function tinh diem trung binh cua sinh vien

create Function fc_DiemTrungBinh(@masv varchar(15))
returns numeric(5,1)
as
begin
  declare @dtb numeric(5,1)

  select @dtb = (sum(diem * sotc) / sum(sotc)) from DKHP where MaSV = @masv

  return @dtb
end

-- thuc thi: select dbo.fc_DiemTrungBinh('19110033') as dtb 
go

--//h. Viet store tim sinh vien co diem trung binh lon nhat

create procedure sp_MaxDTB
as
begin
	declare @max numeric(5,2)

	select @max = isnull(max(dtb),0) from SINHVIEN

	select * from SINHVIEN where dtb = @max order by masv

end

-- thuc thi: exec sp_MaxDTB
go

--//i. Viet store xuat ket qua dang ky học phan cua mot sinh vien

create procedure sp_KQ_DKHP @nh varchar(5), @hk varchar(1),  @masv varchar(15)
as
begin
	select s.*, d.* from SINHVIEN as s inner join DKHP as d on s.MaSV = d.MaSV
	where d.NH = @nh and d.HK = @hk and d.MaSV = @masv 
end
-- thuc thi: exec sp_KQ_DKHP '19-20', '1', '19110033'
go 
