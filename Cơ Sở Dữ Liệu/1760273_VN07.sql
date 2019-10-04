create database QL_DE_TAI
go
use QL_DE_TAI
go

--------------------------------------------------------------GIAOVIEN
create table GIAOVIEN (
	MAGV char(3), 
	HOTEN nvarchar(30), 
	LUONG money, 
	PHAI nvarchar(5), 
	NGSINH date, 
	DIACHI nvarchar(50), 
	GVQLCM char(3), 
	MABM nvarchar(5),

	primary key (MAGV),
)

alter table GIAOVIEN
add constraint C_PHAI_GIAOVIEN
check(PHAI in ('Nam', N'Nữ'))

alter table GIAOVIEN
add constraint C_KT_TUOI_LON_HON_18_GIAOVIEN
check (year(getdate()) - year(NGSINH) >= 18)

--------------------------------------------------------------KHOA
create table KHOA (
	MAKHOA varchar(4),
	TENKHOA nvarchar(30),
	NAMTL smallint,
	PHONG char(3),
	DIENTHOAI char(10),
	TRUONGKHOA char(3),
	NGAYNGANCHUC date,

	primary key (MAKHOA),
)

--------------------------------------------------------------NGUOITHAN
create table NGUOITHAN (
	MAGV char(3),
	TEN nvarchar(30),
	NGSINH date,
	PHAI nvarchar(5),

	primary key (MAGV, TEN),
)

alter table NGUOITHAN
add constraint C_PHAI_NGUOITHAN
check (PHAI in ('Nam', N'Nữ'))

--------------------------------------------------------------THAMGIADT
create table THAMGIADT (
	MAGV char(3),
	MADT char(3),
	STT smallint,
	PHUCAP money,
	KETQUA nvarchar(5),

	primary key (MAGV, MADT, STT),
)

--------------------------------------------------------------CONGVIEC
create table CONGVIEC (
	MADT char(3) not null,
	SOTT smallint,
	TENCV nvarchar(30),
	NGAYBD date,
	NGAYKT date,

	primary key (MADT, SOTT),
)

--------------------------------------------------------------DETAI
create table DETAI (
	MADT  char(3),
	TENDT nvarchar(50),
	CAPQL nvarchar(10),
	KINHPHI money,
	NGAYBD date,
	NGAYKT date,
	MACD char(4),
	GVCDDT char(3),

	primary key (MADT),
)

alter table DETAI
add constraint C_KT_NGAYBD_NGAYKT_DETAI
check (year(NGAYKT) - year(NGAYBD) > 0)

--------------------------------------------------------------CHUDE
create table CHUDE (
	MACD char(4),
	TENCD nvarchar(30),

	primary key (MACD),
)

--------------------------------------------------------------BOMON
create table BOMON (	
	MABM nvarchar(5),
	TENBM nvarchar(30),
	PHONG char(3),
	DIENTHOAI varchar(10),
	TRUONGBM char(3),
	MAKHOA varchar(4),
	NGAYNHANCHUC date,

	primary key (MABM),
)

alter table BOMON
add constraint U_TENBM_BOMON
unique (TENBM)

--------------------------------------------------------------GV_DT
create table GV_DT (
	MAGV char(3), 
	DIENTHOAI char(10),

	primary key (MAGV, DIENTHOAI),
)

------------------------------------------------------------------------------------------------
--------------------------------------------------------------GIAOVIEN
alter table GIAOVIEN
add constraint FK_GIAOVIEN_GIAOVIEN
foreign key (GVQLCM) references GIAOVIEN

alter table GIAOVIEN
add constraint FK_GIAOVIEN_BOMON
foreign key (MABM) references BOMON

--------------------------------------------------------------KHOA
alter table KHOA
add constraint FK_KHOA_GIAOVIEN
foreign key (TRUONGKHOA) references GIAOVIEN

--------------------------------------------------------------NGUOITHAN
alter table NGUOITHAN
add constraint FK_NGUOITHAN_GIAOVIEN
foreign key (MAGV) references GIAOVIEN

--------------------------------------------------------------THAMGIADT
alter table THAMGIADT
add constraint FK_THAMGIADT_GIAOVIEN
foreign key (MAGV) references GIAOVIEN

alter table THAMGIADT
add constraint FK_THAMGIADT_CONGVIEC
foreign key (MADT, STT) references CONGVIEC(MADT, SOTT)

--------------------------------------------------------------CONGVIEC
alter table CONGVIEC
add constraint FK_CONGVIEC_DETAI
foreign key (MADT) references DETAI

--------------------------------------------------------------DETAI
alter table DETAI
add constraint FK_DETAI_GIAOVIEN
foreign key (GVCDDT) references GIAOVIEN

alter table DETAI
add constraint FK_DETAI_CHUDE
foreign key (MACD) references CHUDE

--------------------------------------------------------------CHUDE

--------------------------------------------------------------BOMON
alter table BOMON
add constraint FK_BOMON_GIAOVIEN
foreign key (TRUONGBM) references GIAOVIEN

alter table BOMON
add constraint FK_BOMON_KHOA
foreign key (MAKHOA) references KHOA

--------------------------------------------------------------GV_DT
alter table GV_DT
add constraint FK_GV_DT_GIAOVIEN
foreign key (MAGV) references GIAOVIEN

------------------------------------------------------------------------------------------------
--------------------------------------------------------------CHUDE
insert into CHUDE
values ('NCPT', N'Nghiên cứu và phát triển')

insert into CHUDE
values ('QLGD', N'Quản lí giáo dục')

insert into CHUDE
values ('UDCN', N'Ứng dụng công nghệ')

--------------------------------------------------------------GIAOVIEN
insert into GIAOVIEN
values ('001', N'Nguyễn Hoài An', 2000.0, 'Nam', '1973-02-15', N'25/3 Lạc Long Quân, Q.10, TP HCM', NULL, NULL)

insert into GIAOVIEN
values ('002', N'Trần Trà Hương', 2500.0, N'Nữ', '1960-06-20', N'125 Trần Hưng Đạo, Q.1, TP HCM', NULL, NULL)

insert into GIAOVIEN
values ('003', N'Nguyễn Ngọc Ánh', 2200.0, N'Nữ', '1975-05-11', N'12/21 Võ Văn Ngân Thủ Đức, TP HCM', NULL, NULL)

insert into GIAOVIEN
values ('004', N'Trương Nam Sơn', 2300.0, 'Nam', '1959-06-20', N'215 Lý Thường Kiệt, TP Biên Hòa', NULL, NULL)

insert into GIAOVIEN
values ('005', N'Lý Hoàng Hà', 2500.0, 'Nam', '1954-10-23', N'22/5 Nguyễn Xí, Q.Bình Thạnh, TP HCM', NULL, NULL)

insert into GIAOVIEN
values ('006', N'Trần Bạch Tuyết', 1500.0, N'Nữ', '1980-05-20', N'127 Hùng Vương, TP Mỹ Tho', NULL, NULL)

insert into GIAOVIEN
values ('007', N'Nguyễn An Trung', 2100.0, 'Nam', '1976-06-05', N'234 3/2, TP Biên Hòa', NULL, NULL)

insert into GIAOVIEN
values ('008', N'Trần Trung Hiếu', 1800.0, 'Nam', '1977-08-06', N'22/11 Lý Thường Kiệt, TP Mỹ Tho', NULL, NULL)

insert into GIAOVIEN
values ('009', N'Trần Hoàng Nam', 2000.0, 'Nam', '1975-11-22', N'234 Trần Não, An Phú, TP HCM', NULL, NULL)

insert into GIAOVIEN
values ('010', N'Phạm Nam Thanh', 1500.0, 'Nam', '1980-12-12', N'221 Hùng Vương, Q.5, TP HCM', NULL, NULL)

--------------------------------------------------------------KHOA
insert into KHOA
values ('CNTT', N'Công nghệ thông tin', 1995, 'B11', '0838123456', '002', '2005-02-20')

insert into KHOA
values ('HH', N'Hóa học', 1980, 'B41', '0838456456', '007', '2001-10-15')

insert into KHOA
values ('SH', N'Sinh học', 1980, 'B31', '0838454545', '004', '2000-10-11')

insert into KHOA
values ('VL', N'Vật lý', 1976, 'B21', '0838223223', '005', '2003-09-18')

--------------------------------------------------------------BOMON
insert into BOMON
values ('CNTT', N'Công nghệ tri thức', 'B15', '0838126126', NULL, 'CNTT', NULL)

insert into BOMON
values ('HHC', N'Hóa hữu cơ', 'B44', '838222222', NULL, 'HH', NULL)

insert into BOMON
values ('HL', N'Hóa lý', 'B42', '0838878787', NULL, 'HH', NULL)

insert into BOMON
values ('HPT', N'Hóa phân tích', 'B43', '0838777777', '007', 'HH', '2007-10-15')

insert into BOMON
values ('HTTT', N'Hệ thống thông tin', 'B13', '0838125125', '002', 'CNTT', '2004-09-20')

insert into BOMON
values ('MMT', N'Mạng máy tính', 'B16', '0838676767', '001', 'CNTT', '2005-05-15')

insert into BOMON
values ('SH', N'Sinh hóa', 'B33', '0838898989', NULL, 'SH', NULL)

insert into BOMON
values ('VLĐT', N'Vật lí điện tử', 'B23', '0838234234', NULL, 'VL', NULL)

insert into BOMON
values ('VLƯD', N'Vật lí ứng dụng', 'B24', '0838454545', '005', 'VL', '2006-02-18')

insert into BOMON
values ('VS', N'Vi sinh', 'B32', '0838909090', '004', 'SH', '2007-01-01')

--------------------------------------------------------------GIAOVIEN
update GIAOVIEN
set GVQLCM='002', MABM='HTTT'
where MAGV='003'

update GIAOVIEN
set GVQLCM='004', MABM='VS'
where MAGV='006'

update GIAOVIEN
set GVQLCM='007', MABM='HPT'
where MAGV='008'

update GIAOVIEN
set GVQLCM='001', MABM='MMT'
where MAGV='009'

update GIAOVIEN
set GVQLCM='007', MABM='HPT'
where MAGV='010'

update GIAOVIEN
set MABM='MMT'
where MAGV='001'

update GIAOVIEN
set MABM='HTTT'
where MAGV='002'

update GIAOVIEN
set MABM='VS'
where MAGV='004'

update GIAOVIEN
set MABM='VLĐT'
where MAGV='005'

update GIAOVIEN
set MABM='HPT'
where MAGV='007'

--------------------------------------------------------------NGUOITHAN
insert into NGUOITHAN
values ('001',N'Hùng', '1990-01-14', 'Nam')

insert into NGUOITHAN
values ('001',N'Thủy', '1994-12-08', N'Nữ')

insert into NGUOITHAN
values ('003',N'Hà', '1998-09-03', N'Nữ')

insert into NGUOITHAN
values ('003',N'Thu', '1998-09-03', N'Nữ')

insert into NGUOITHAN
values ('007',N'Mai', '2003-03-26', N'Nữ')

insert into NGUOITHAN
values ('007',N'Vy', '2000-02-14', N'Nữ')

insert into NGUOITHAN
values ('008',N'Nam', '1991-05-06', 'Nam')

insert into NGUOITHAN
values ('009',N'An', '1996-08-19', 'Nam')

insert into NGUOITHAN
values ('010',N'Nguyệt', '2006-01-14', N'Nữ')

--------------------------------------------------------------GV_DT
insert into GV_DT
values ('001','0838912112')

insert into GV_DT
values ('001','0903123123')

insert into GV_DT
values ('002','0913454545')

insert into GV_DT
values ('003','0838121212')

insert into GV_DT
values ('003','0903656565')

insert into GV_DT
values ('003','0937125125')

insert into GV_DT
values ('006','0937888888')

insert into GV_DT
values ('008','0653717171')

insert into GV_DT
values ('008','0913232323')

--------------------------------------------------------------DETAI 
insert into DETAI
values ('001', N'HTTT quản lí các trường ĐH', 'ĐHQG', 20.0,'2007-10-20','2008-10-20','QLGD','002')

insert into DETAI
values ('002', N'HTTT quản lí giáo dục cho một Khoa', 'Trường', 20.0,'2000-10-12','2001-10-12','QLGD','002')

insert into DETAI
values ('003', N'Nghiên cứu và chế tạo sợi Nanô Platin', 'ĐHQG', 300.0,'2008-05-15','2010-05-15','NCPT','005')

insert into DETAI
values ('004', N'Tạo vật liệu sinh học bằng màng ổi người', 'Nhà nước', 100.0,'2007-01-04','2009-12-31','NCPT','004')

insert into DETAI
values ('005', N'Ứng dụng hóa học xanh', 'Trường', 200.0,'2003-10-10','2004-12-10','UDCN','007')

insert into DETAI
values ('006', N'Nghiên cứu tế bào gốc', 'Nhà nước', 4000.0,'2006-10-20','2009-10-20','NCPT','004')

insert into DETAI
values ('007', N'HTTT quản lí thư viện ở các trường ĐH', 'Trường', 20.0,'2009-05-10','2010-05-10','QLGD','001')

--------------------------------------------------------------CONGVIEC
insert into CONGVIEC
values ('001', 1, N'Khởi tạo và Lập kế hoạch', '2007-10-20', '2008-12-20')

insert into CONGVIEC
values ('001', 2, N'Xác định yêu cầu', '2008-12-21', '2008-03-21')

insert into CONGVIEC
values ('001', 3, N'Phân tích hệ thống', '2009-03-22', '2008-05-22')

insert into CONGVIEC
values ('001', 4, N'Thiết kệ hệ thống', '2008-05-23', '2005-06-23')

insert into CONGVIEC
values ('001', 5, N'Cài đặt kiểm thử', '2008-06-24', '2008-10-20')

insert into CONGVIEC
values ('002', 1, N'Khởi tạo và Lập kế hoạch', '2009-05-10', '2009-07-10')

insert into CONGVIEC
values ('002', 2, N'Xác định yêu cầu', '2009-07-11', '2009-10-11')

insert into CONGVIEC
values ('002', 3, N'Phân tích hệ thống', '2009-10-12', '2009-12-20')

insert into CONGVIEC
values ('002', 4, N'Thiết kệ hệ thống', '2009-12-21', '2010-02-22')

insert into CONGVIEC
values ('002', 5, N'Cài đặt kiểm thử', '2010-03-23', '2010-05-10')

insert into CONGVIEC
values ('006', 1, N'Lấy mẫu', '2006-10-20', '2007-02-20')

insert into CONGVIEC
values ('006', 2, N'Nuôi cấy', '2007-02-21', '2008-08-21')

--------------------------------------------------------------THAMGIADT
insert into THAMGIADT
values ('001', '002', 1, 0.0, NULL)

insert into THAMGIADT
values ('001', '002', 2, 2.0, NULL)

insert into THAMGIADT
values ('002', '001', 4, 2.0, N'Đạt')

insert into THAMGIADT
values ('003', '001', 1, 1.0, N'Đạt')

insert into THAMGIADT
values ('003', '001', 2, 0.0, N'Đạt')

insert into THAMGIADT
values ('003', '001', 4, 1.0, N'Đạt')

insert into THAMGIADT
values ('003', '002', 2, 0.0, NULL)

insert into THAMGIADT
values ('004', '006', 1, 0.0, N'Đạt')

insert into THAMGIADT
values ('004', '006', 2, 1.0, N'Đạt')

insert into THAMGIADT
values ('006', '006', 2, 1.5, N'Đạt')

insert into THAMGIADT
values ('009', '002', 3, 0.5, NULL)

insert into THAMGIADT
values ('009', '002', 4, 1.5, NULL)

---------------------------------------------------------------------QUESTIONS
--q1
select gv.HOTEN, gv.LUONG
from GIAOVIEN gv
where gv.PHAI = N'Nữ'

--q2
select gv.HOTEN, gv.LUONG*1.1
from GIAOVIEN gv

--q3
select distinct gv.MAGV
from GIAOVIEN gv, BOMON bm
where gv.HOTEN like N'Nguyễn%' or 
	 (gv.MAGV = bm.TRUONGBM and year(bm.NGAYNHANCHUC) > 1995)

--q4
select gv.HOTEN
from GIAOVIEN gv, BOMON bm
where gv.MABM = bm.MABM and bm.MAKHOA = 'CNTT'

--q5
select bm.*, gv.*
from GIAOVIEN gv, BOMON bm
where bm.TRUONGBM = gv.MAGV

--q6
select gv.*, bm.*
from GIAOVIEN gv join BOMON bm on gv.MABM = bm.MABM

--q7
select dt.TENDT, gv.HOTEN
from GIAOVIEN gv join DETAI dt on dt.GVCDDT = gv.MAGV

--q8
select k.*, gv.*
from KHOA k join GIAOVIEN gv on k.TRUONGKHOA = gv.MAGV

--q9
select distinct gv.HOTEN
from GIAOVIEN gv, THAMGIADT tgdt
where gv.MABM = 'VS' and gv.MAGV = tgdt.MAGV and tgdt.MADT = '006'

--q10
select dt.MADT, cd.TENCD, gv.HOTEN, gv.NGSINH, gv.DIACHI
from GIAOVIEN gv join (DETAI dt join CHUDE cd on dt.MACD = cd.MACD) on gv.MAGV = dt.GVCDDT
where dt.CAPQL = N'Tru?ng'

--q11
select gv1.HOTEN, gv2.HOTEN
from GIAOVIEN gv1 join GIAOVIEN gv2 on gv1.GVQLCM = gv2.MAGV

--q12
select gv2.HOTEN
from GIAOVIEN gv1, GIAOVIEN gv2
where gv1.HOTEN = N'Trần Trà Hương' and gv2.GVQLCM = gv1.MAGV

--q13
select gv.HOTEN
from GIAOVIEN gv join BOMON bm on (gv.MAGV = bm.TRUONGBM and bm.MABM = 'HTTT')

--q14
select distinct gv.HOTEN
from GIAOVIEN gv join (DETAI dt join CHUDE cd on (dt.MACD = cd.MACD and cd.TENCD = N'Quản lí giáo dục')) on gv.MAGV = dt.GVCDDT

--q15
select cv.TENCV, cv.NGAYBD
from CONGVIEC cv join DETAI dt on (cv.MADT = dt.MADT and dt.TENDT = N'HTTT quản lí các trường ĐH')
where cv.NGAYBD >= '2008-05-01' and cv.NGAYBD <= '2008-05-30'

--q16
select distinct gv2.HOTEN, gv1.HOTEN
from GIAOVIEN gv1, BOMON bm1, GIAOVIEN gv2
where gv1.MAGV = bm1.TRUONGBM and gv2.MABM = bm1.MABM and gv1.MAGV <> gv2.MAGV

--q17
select cv.*
from CONGVIEC cv
where cv.NGAYBD between '2007-01-01' and '2007-08-01'

--q18
select gv2.HOTEN
from GIAOVIEN gv1, GIAOVIEN gv2
where gv1.HOTEN = N'Trần Trà Hương' and gv1.MABM = gv2.MABM and gv1.MAGV <> gv2.MAGV

--q19
select distinct gv.*
from GIAOVIEN gv, BOMON bm, DETAI dt
where bm.TRUONGBM = gv.MAGV and dt.GVCDDT = gv.MAGV

--q20
select gv.*
from KHOA k, GIAOVIEN gv, BOMON bm
where k.TRUONGKHOA = gv.MAGV and bm.TRUONGBM = gv.MAGV

--q21
select distinct gv.HOTEN
from BOMON bm, GIAOVIEN gv, DETAI dt
where bm.TRUONGBM = gv.MAGV and dt.GVCDDT = gv.MAGV

--q22
select distinct gv.MAGV
from KHOA k, DETAI dt, GIAOVIEN gv
where gv.MAGV = k.TRUONGKHOA and gv.MAGV = dt.GVCDDT

--q23
select distinct gv.MAGV
from GIAOVIEN gv, THAMGIADT tgdt
where gv.MABM = 'HTTT' and gv.MAGV = tgdt.MAGV and tgdt.MADT = '001'

--q24
select gv2.HOTEN
from GIAOVIEN gv1, GIAOVIEN gv2
where gv1.MAGV = '002' and gv2.MABM = gv1.MABM and gv2.MAGV <> '002'

--q25
select gv.*
from BOMON bm join GIAOVIEN gv on gv.MAGV = bm.TRUONGBM

--q26
select HOTEN, LUONG
from GIAOVIEN

--q27
select count(MAGV), sum(LUONG)
from GIAOVIEN

--q28
select gv.MABM, count(gv.MAGV), AVG(gv.LUONG)
from GIAOVIEN gv join BOMON bm on gv.MABM = bm.MABM
group by gv.MABM

--q29
select cd.TENCD, count(dt.MADT)
from CHUDE cd join DETAI dt on cd.MACD = dt.MACD
group by cd.TENCD

--q30
select gv.HOTEN, count(distinct tgdt.MADT)
from GIAOVIEN gv join THAMGIADT tgdt on gv.MAGV = tgdt.MAGV
group by gv.HOTEN 

--q31
select gv.MAGV, gv.HOTEN, count(distinct dt.MADT)
from DETAI dt join GIAOVIEN gv on dt.GVCDDT = gv.MAGV
group by gv.MAGV, gv.HOTEN

--q32
select gv.MAGV, gv.HOTEN, count(nt.TEN)
from GIAOVIEN gv join NGUOITHAN nt on gv.MAGV = nt.MAGV
group by gv.HOTEN, gv.MAGV

--q33
select gv.MAGV, gv.HOTEN
from GIAOVIEN gv join THAMGIADT dt on gv.MAGV = dt.MAGV
group by gv.MAGV, gv.HOTEN
having count(distinct dt.MADT) >= 2

--q34
select count(distinct gv.MAGV)
from (DETAI dt join THAMGIADT tgdt on dt.MADT = tgdt.MADT) join GIAOVIEN gv on tgdt.MAGV = gv.MAGV
where dt.TENDT = N'Ứng dụng hóa học xanh'

--q35
select max(LUONG)
from GIAOVIEN

--q36
select gv1.*
from GIAOVIEN gv1
where gv1.LUONG in (select max(gv2.LUONG)
				    from GIAOVIEN gv2)

--q37
select max(gv.LUONG)
from GIAOVIEN gv join BOMON bm on gv.MABM = bm.MABM
where gv.MABM = 'HTTT'

--q38
select gv.HOTEN
from GIAOVIEN gv
where gv.NGSINH in (select min(gv1.NGSINH)
					from GIAOVIEN gv1 join BOMON bm on gv1.MABM = bm.MABM
					where gv1.MABM = 'HTTT')

--q39
select gv.HOTEN
from GIAOVIEN gv
where gv.NGSINH in (select max(gv1.NGSINH)
					from GIAOVIEN gv1 join BOMON bm on (bm.MAKHOA = 'CNTT' and bm.MABM = gv1.MABM))

--q40
select gv.HOTEN, k.TENKHOA
from (GIAOVIEN gv join BOMON bm on gv.MABM = bm.MABM) join KHOA k on k.MAKHOA = bm.MAKHOA
where gv.LUONG in (select max(gv1.LUONG)
				   from GIAOVIEN gv1)

--q41
select distinct gv1.MABM, gv1.HOTEN
from GIAOVIEN gv, GIAOVIEN gv1
group by gv.MABM, gv1.LUONG, gv1.HOTEN, gv1.MABM
having gv1.LUONG = max(gv.LUONG)

--q42
select TENDT
from DETAI
except
select distinct dt.TENDT
from (GIAOVIEN gv join THAMGIADT tgdt on gv.MAGV = tgdt.MAGV) join DETAI dt on dt.MADT = tgdt.MADT, GIAOVIEN gv1
where gv1.HOTEN = N'Nguyễn Hoài An' and tgdt.MAGV = gv1.MAGV

--q43
select dt2.TENDT, gv1.HOTEN
from DETAI dt2 join GIAOVIEN gv1 on dt2.GVCDDT = gv1.MAGV
where dt2.TENDT in (select TENDT
					from DETAI
					except
					select distinct dt.TENDT
					from (GIAOVIEN gv join THAMGIADT tgdt on gv.MAGV = tgdt.MAGV) join DETAI dt on dt.MADT = tgdt.MADT, GIAOVIEN gv1
					where gv1.HOTEN = N'Nguyễn Hoài An' and tgdt.MAGV = gv1.MAGV)

--q44
-- data test
insert into GIAOVIEN
values ('011', N'Dương Mạnh Cường', 2000.0, 'Nam', '1999-04-08', N'Củ Chi', NULL, 'HTTT')

select gv.HOTEN, gv.MAGV
from BOMON bm join GIAOVIEN gv on bm.MABM = gv.MABM
where not exists (select *
				  from THAMGIADT tgdt
				  where tgdt.MAGV = gv.MAGV and bm.MAKHOA = 'CNTT')
				  and bm.MAKHOA = 'CNTT'

--q45
select gv.HOTEN, gv.MAGV
from GIAOVIEN gv
where not exists (select *
				  from THAMGIADT tgdt
				  where tgdt.MAGV = gv.MAGV)

--q46
select gv2.MAGV, gv2.HOTEN
from GIAOVIEN gv1, GIAOVIEN gv2
where gv1.HOTEN = N'Nguyễn Hoài An' and gv2.LUONG > gv1.LUONG

--q47
select gv.MAGV, gv.HOTEN
from (GIAOVIEN gv join BOMON bm on gv.MAGV = bm.TRUONGBM) join THAMGIADT tgdt on tgdt.MAGV = gv.MAGV
group by gv.MAGV, gv.HOTEN
having count(distinct tgdt.MADT) > 0

--q48
-- data test
insert into GIAOVIEN
values ('012', N'Dương Mạnh Cường', 2000.0, 'Nam', '1999-04-08', N'Củ Chi', NULL, 'HTTT')
select distinct gv1.HOTEN, gv2.HOTEN
from GIAOVIEN gv1, GIAOVIEN gv2
where gv1.HOTEN = gv2.HOTEN and gv1.PHAI = gv2.PHAI and gv1.MAGV <> gv2.MAGV

--q49
select gv3.MAGV, gv3.HOTEN
from GIAOVIEN gv3
where gv3.MABM = 'HTTT' and gv3.LUONG in (select gv2.LUONG
										  from GIAOVIEN gv2
										  where gv2.MABM = 'HTTT'
										  except
										  select min(gv1.LUONG)
										  from GIAOVIEN gv1
										  where gv1.MABM = 'HTTT')

--q50
-- data test
insert into GIAOVIEN
values ('013', N'Nguyễn Kim Ngân', 3000.0, 'Nam', '1999-03-03', N'Củ Chi', NULL, 'VS')
select gv2.HOTEN
from GIAOVIEN gv2
where gv2.LUONG > (select max(gv1.LUONG)
				   from GIAOVIEN gv1
				   where gv1.MABM = 'HTTT')
				   and gv2.MABM <> 'HTTT'

--q51
select y1.nameFaculty1, y1.countGV1
from (select k1.TENKHOA as nameFaculty1, count(gv1.MAGV) as countGV1
	  from (KHOA k1 join BOMON bm1 on bm1.MAKHOA = k1.MAKHOA) join GIAOVIEN gv1 on bm1.MABM = gv1.MABM
	  group by k1.TENKHOA) y1
where y1.countGV1 = (select max(y.countGV)
					 from (select k.TENKHOA as nameFaculty, count(distinct gv.MAGV) as countGV
						   from (KHOA k join BOMON bm on bm.MAKHOA = k.MAKHOA) join GIAOVIEN gv on bm.MABM = gv.MABM
						   group by k.TENKHOA) y)

--q52
select y.nameTeacher, y.numSub
from (select gv.HOTEN as nameTeacher, count(dt.MADT) as numSub
	  from GIAOVIEN gv join DETAI dt on gv.MAGV = dt.GVCDDT
	  group by gv.HOTEN) y
where y.numSub = (select max(y1.numTeacher1)
				  from (select gv1.MAGV, count(distinct dt1.MADT) as numTeacher1
						from DETAI dt1 join GIAOVIEN gv1 on dt1.GVCDDT = gv1.MAGV
						group by gv1.MAGV) y1)

--q53
select y.nameFaculty
from (select gv.MABM as nameFaculty, count(distinct gv.MAGV) as numTeacher
	  from GIAOVIEN gv
	  group by gv.MABM) y
where y.numTeacher = (select max(y1.numTeacher1)
					  from (select count(gv1.MAGV) as numTeacher1
							from GIAOVIEN gv1
							group by gv1.MABM) y1)

--q54
select y.idTeacher, y.nameTeacher, y.numSub, y.nameFaculty
from (select gv.MAGV as idTeacher, gv.HOTEN as nameTeacher, count(tgdt.MADT) as numSub, bm.TENBM as nameFaculty
	  from (GIAOVIEN gv join BOMON bm on gv.MABM = bm.MABM) join THAMGIADT tgdt on gv.MAGV = tgdt.MAGV
	  group by gv.MAGV, gv.HOTEN, bm.TENBM) y
where y.numSub = (select max(y1.numSub1)
				  from (select count(distinct tgdt1.MADT) as numSub1
						from (GIAOVIEN gv1 join BOMON bm1 on gv1.MABM = bm1.MABM) join THAMGIADT tgdt1 on gv1.MAGV = tgdt1.MAGV
						group by gv1.MAGV, gv1.HOTEN) y1)

--q55
select y.nameTeacher, y.numSub
from (select gv.HOTEN as nameTeacher, count(distinct tgdt.MADT) as numSub
	  from GIAOVIEN gv join THAMGIADT tgdt on (gv.MAGV = tgdt.MAGV)
	  group by gv.HOTEN, gv.MABM
	  having gv.MABM = 'HTTT') y
where y.numSub = (select max(y1.numSub1)
				  from (select count(distinct tgdt1.MADT) as numSub1
						from GIAOVIEN gv1 join THAMGIADT tgdt1 on (gv1.MAGV = tgdt1.MAGV)
						group by gv1.HOTEN, gv1.MABM
						having gv1.MABM = 'HTTT') y1)

--q56
select y.idTeacher, y.nameTeacher, y.numFam, y.nameFaculty
from (select gv.MAGV as idTeacher, gv.HOTEN as nameTeacher, count(nt.TEN) as numFam, bm.TENBM as nameFaculty
	  from (GIAOVIEN gv join BOMON bm on gv.MABM = bm.MABM) join NGUOITHAN nt on gv.MAGV = nt.MAGV
	  group by gv.MAGV, gv.HOTEN, bm.TENBM) y
where y.numFam = (select max(y1.numFam1)
				  from (select count(distinct nt1.TEN) as numFam1
						from (GIAOVIEN gv1 join BOMON bm1 on gv1.MABM = bm1.MABM) join NGUOITHAN nt1 on gv1.MAGV = nt1.MAGV
						group by gv1.MAGV, gv1.HOTEN) y1)

--q57
select y.idTeacher, y.nameTeacher, y.numSub
from (select gv.MAGV as idTeacher, gv.HOTEN as nameTeacher, count(distinct dt.MADT) as numSub
	  from (GIAOVIEN gv join BOMON bm on gv.MAGV = bm.TRUONGBM) join DETAI dt on gv.MAGV = dt.GVCDDT
	  group by gv.MAGV, gv.HOTEN) y
where y.numSub = (select max(y1.numSub1)
				  from (select count(distinct dt1.MADT) as numSub1
						from (GIAOVIEN gv1 join BOMON bm1 on gv1.MAGV = bm1.TRUONGBM) join DETAI dt1 on gv1.MAGV = dt1.GVCDDT
						group by gv1.MAGV) y1)
