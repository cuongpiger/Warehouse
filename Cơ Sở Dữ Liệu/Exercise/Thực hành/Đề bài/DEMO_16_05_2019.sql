﻿USE QUANLYDETAI
GO
--Tìm tên các giáo viên được phân công làm tất cả các đề tài có kinh phí trên 100 triệu
--GROUP BY HAVING
--DEM SO DTAI TREN 100TRIEU CUA MOI GV DA TGIA
--DEM SO DTAI TREN 100TR CUA DS DTAI
--GV1 (DT1:100,DT3:30, DT5:50, DT6:120)--> GV1 TGIA 1 DTAI TREN 100TR
--TRONG CSDL BANG DETAI CO TAT CA 10 DT NHUNG CO 3DTAI KPH I TREN 100TR
--GV1 KHONG THAMGIA TAT CA DTAI KPHI TREN 100TR
--DS CAC GV CO THAM GIA DETAI CO KPHI TREN 100TR
SELECT MAGV, DT.MADT, KINHPHI
FROM THAMGIADT TG JOIN DETAI DT ON TG.MADT = DT.MADT
WHERE DT.KINHPHI >100
--DEM GOM NHOM THEM MAGV
SELECT MAGV, COUNT(DISTINCT DT.MADT) AS SODT
FROM THAMGIADT TG JOIN DETAI DT ON TG.MADT = DT.MADT
WHERE DT.KINHPHI >100
GROUP BY MAGV
HAVING COUNT(DISTINCT DT.MADT) = (SELECT COUNT(*) FROM DETAI WHERE KINHPHI>100)

--CHI RA 1 TRUONG HOPWJ SAI
--VOI MOI GV CO TG DETAI >100TR, LAY DS DT >100TR MA GV1 CHUA THAM GIA
--LAY DS DETAI >100TR - DS DTAI >100TR MA GV 1 DA TG
SELECT MAGV
FROM THAMGIADT TG1
WHERE NOT EXISTS (
SELECT MADT FROM DETAI WHERE KINHPHI>100
EXCEPT
SELECT TG.MADT
FROM THAMGIADT TG JOIN DETAI DT ON TG.MADT = DT.MADT
WHERE KINHPHI>100 AND TG.MAGV = TG1.MAGV)

SELECT * FROM DETAI
SELECT * FROM THAMGIADT

--CAP NHAT VA DELETE
--DELETE: CHI RA MUON DELETE NHUNG DONG NAO
--DELETE KO WHERE -> DELETE HET BANG
DELETE FROM GIAOVIEN --> XOA TOANG BANG, NHUNG NEU DANG BI THAM CHIEU THI KHONG XOA DUOC
DELETE FROM GIAOVIEN WHERE MABM = 'HTTT' --> XOA HET GIAO VIEN BM HTTT. TUY NHIEN, TGDT DANG THAM CHIEU TOI. KO XOA DUOC

UPDATE GIAOVIEN
SET LUONG = 0
WHERE MAGV = '001'

UPDATE GIAOVIEN
SET LUONG = 0
WHERE PHAI = 'NAM'

--CAP NHAT LUONG CUA GV HO TRO MOI NGUOI THAN 500
UPDATE GIAOVIEN
SET
   LUONG = LUONG + 500*KETQUA.SONT
FROM
    (SELECT MAGV, COUNT(MAGV) AS SONT FROM NGUOITHAN GROUP BY MAGV) kETQUA
WHERE
   GIAOVIEN.MAGV = KETQUA.MAGV 


SELECT * FROM GIAOVIEN
