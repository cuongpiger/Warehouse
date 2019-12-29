--1. Số lượng độc giả có địa chỉ tại Thủ Đức. 
select count(distinct dg.socmnd) 
from DocGia dg
where dg.diachi like N'%Thủ Đức%'

--2. Đếm số phiếu mượn trong ngày 25 tháng 12. select count(distinct pm.mapm)
from PhieuMuon pm
where day(pm.ngaymuon) = 25 and month(pm.ngaymuon) = 12

--3. Đếm số lượng đầu sách xuất bản sau năm 2000 hiện có trong thư viện. 
select count(distinct ds.isbn) 
from DauSach ds
where ds.namxb = 2001

--4. Số isbn, mã sách và số lượng độc giả đã từng mượn cuốn sách này. select cs.isbn, cs.masach, count(ctpm.mapm)
from CuonSach cs join CT_PhieuMuon ctpm on ctpm.isbn = cs.isbn
group by cs.isbn, cs.masach

--5. Số cmnd, họ tên và số lượng đầu sách mà độc giả này đã từng mượn. select dg.socmnd, dg.hoten, count(distinct ctpm.isbn)
from DocGia dg join PhieuMuon pm on pm.madg = dg.madg join CT_PhieuMuon ctpm on ctpm.mapm = pm.mapm
group by dg.socmnd, dg.hoten

--6. Mã phiếu trả, ngày trả và tổng tiền phạt của phiếu trả đó. select pt.mapt, pt.ngaytra, sum(ctpt.tienphat)
from PhieuTra pt join CT_PhieuTra ctpt on ctpt.mapt = pt.mapt
group by pt.mapt, pt.ngaytra

--7. Số isbn, mã sách của cuốn sách có nhiều độc giả mượn nhất. select cs.isbn, cs.masach, count(ctpm.mapm)
from CuonSach cs join CT_PhieuMuon ctpm on ctpm.isbn = cs.isbn
group by cs.isbn, cs.masach
having count(ctpm.mapm) >= all (select count(ctpm1.mapm)
							    from CuonSach cs1 join CT_PhieuMuon ctpm1 on ctpm1.isbn = cs1.isbn
								group by cs1.isbn, cs1.masach)

--8. Số cmnd, họ tên độc giả mượn ít đầu sách nhất. select dg.socmnd, dg.hoten
from DocGia dg join PhieuMuon pm on pm.madg = dg.madg join CT_PhieuMuon ctpm on ctpm.mapm = pm.mapm
group by dg.socmnd, dg.hoten
having count(ctpm.isbn) <= all (select count(ctpm1.isbn)
from DocGia dg1 join PhieuMuon pm1 on pm1.madg = dg1.madg join CT_PhieuMuon ctpm1 on ctpm1.mapm = pm1.mapm
group by dg1.socmnd, dg1.hoten)

--9. Ngày có ít phiếu trả nhất. select pt.ngaytra
from PhieuTra pt
group by pt.ngaytra
having count(pt.mapt) <= all (select count(pt1.mapt)
from PhieuTra pt1
group by pt1.ngaytra)

--10. Phiếu trả có tổng tiền phạt lớn nhất. select ctpt.mapt
from CT_PhieuTra ctpt
group by ctpt.mapt
having sum(ctpt.tienphat) >= all (select sum(ctpt1.tienphat)
								  from CT_PhieuTra ctpt1
								  group by ctpt1.mapt)

--11. Ngày có nhiều phiếu mượn nhất. select pm.ngaymuon
from PhieuMuon pm
group by pm.ngaymuon
having count(pm.mapm) >= all(select count(pm1.mapm)
							 from PhieuMuon pm1
							 group by pm1.ngaymuon)

--12. Số cmnd, họ tên độc giả của phiếu mượn có nhiều sách được mượn nhất. select dg.socmnd, dg.hotenfrom DocGia dg join PhieuMuon pm on pm.madg = dg.madg join CT_PhieuMuon ctpm on ctpm.mapm = pm.mapmjoin CuonSach cs on (cs.isbn = ctpm.isbn and cs.masach = ctpm.masach)group by dg.socmnd, dg.hotenhaving count(*) >= all(select count(*)from DocGia dg1 join PhieuMuon pm1 on pm1.madg = dg1.madg join CT_PhieuMuon ctpm1 on ctpm1.mapm = pm1.mapmjoin CuonSach cs1 on (cs1.isbn = ctpm1.isbn and cs1.masach = ctpm1.masach)group by dg1.socmnd, dg1.hoten)--13. Số cmnd, họ tên độc giả của phiếu mượn có nhiều phiếu trả nhất. select dg.socmnd, dg.hoten, pm.mapmfrom DocGia dg join PhieuMuon pm on pm.madg = dg.madg join PhieuTra pt on pt.mapm = pm.mapmjoin CT_PhieuTra ctpt on ctpt.mapt = pt.maptgroup by dg.socmnd, dg.hoten, pm.mapmhaving count(*) >= all (select count(*)from DocGia dg1 join PhieuMuon pm1 on pm1.madg = dg1.madg join PhieuTra pt1 on pt1.mapm = pm1.mapmjoin CT_PhieuTra ctpt1 on ctpt1.mapt = pt1.maptgroup by dg1.socmnd, dg1.hoten, pm1.mapm)