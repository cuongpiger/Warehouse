-----------------------------------------------------------------------------question 1
select rd.hoten as N'Họ tên', rd.socmnd as N'Số CMND'
from DocGia rd
where YEAR(GETDATE()) - YEAR(rd.ngsinh) > 30 and rd.diachi like '%TP.HCM%'	

-----------------------------------------------------------------------------question 2
select rd.hoten as N'Họ tên', rd.socmnd as N'Số CMND'
from DocGia rd
where rd.gioitinh = N'Nữ' and (rd.email like 'c%' or rd.email like 't%')
order by rd.socmnd asc

-----------------------------------------------------------------------------question 3
select bk.tensach
from DauSach bk
where bk.soluong >= 3 and bk.soluong <= 10
order by bk.soluong desc

-----------------------------------------------------------------------------question 4
select rd.hoten as N'Họ tên', rd.socmnd as N'Số CMND'
from DocGia rd join PhieuMuon tik on rd.madg = tik.madg
where DAY(tik.ngaymuon) = 20 and MONTH(tik.ngaymuon) = 12

-----------------------------------------------------------------------------question 5
select rd.hoten as N'Họ tên', rd.socmnd as N'Số CMND'
from DocGia rd join PhieuMuon pm on rd.madg = pm.madg join CT_PhieuMuon ctpm on pm.mapm = ctpm.mapm
where ctpm.masach in (select cs.masach
					 from DauSach ds join CuonSach cs on ds.isbn = cs.isbn
					 where ds.tensach = N'Toán cao cấp A1') and
					 YEAR(pm.ngaymuon) = 2010

-----------------------------------------------------------------------------question 6
select ds.isbn as N'Số ISBN', ds.tensach as N'Tên sách'
from DauSach ds
where ds.namxb <= all(select ds1.namxb
					  from DauSach ds1)

-----------------------------------------------------------------------------question 7
select rd.hoten as N'Họ tên', rd.socmnd as N'Số CMND'
from DocGia rd
where rd.gioitinh like N'Nam' and YEAR(rd.ngsinh) <= all(select YEAR(dg.ngsinh)
														 from DocGia dg
														 where dg.gioitinh like N'Nam')

-----------------------------------------------------------------------------question 8
select ds.tensach as N'Tên sách'
from DauSach ds
where ds.mucgiaphat <= all (select ds1.mucgiaphat
							from DauSach ds1)

-----------------------------------------------------------------------------question 9
select ds.tensach as N'Tên sách'
from DauSach ds join CT_PhieuMuon ctpm on ds.isbn = ctpm.isbn join PhieuMuon pm on pm.mapm = ctpm.mapm join DocGia dg on dg.madg = pm.madg
where YEAR(dg.ngsinh) = 1974 or YEAR(dg.ngsinh) = 1986 or YEAR(dg.ngsinh) = 1990 or YEAR(dg.ngsinh) = 1992

-----------------------------------------------------------------------------question 10
select dg.hoten as N'Họ tên', dg.socmnd as N'Số CMND'
from DocGia dg
where dg.email is not null and dg.madg not in (select pm.madg
											   from DauSach ds, PhieuMuon pm, CT_PhieuMuon ctpm
											   where pm.mapm = ctpm.mapm and
													 ctpm.isbn = ds.isbn and
													 ds.namxb in (2000, 2005, 2009)) 

-----------------------------------------------------------------------------question 11
select pm.mapm as N'Mã phiếu mượn', pm.ngaymuon as N'Ngày mượn'
from PhieuMuon pm join DocGia dg on dg.madg = pm.madg
where dg.hoten like N'Lê%'or dg.hoten like N'Trần%'

-----------------------------------------------------------------------------question 12
select distinct rd.hoten as N'Họ tên', rd.socmnd as N'Số CMND'
from DocGia rd, PhieuMuon pm, PhieuTra pt, CT_PhieuTra ctpt
where rd.madg = pm.madg and pm.mapm = pt.mapm and pt.mapt = ctpt.mapt and
ctpt.tienphat >= all(select ctpm1.tienphat
					 from CT_PhieuTra ctpm1)
