--ds gv tham gia tat ca de tai
select * from DETAI
--c1: dem so detai moi gv da tham gia = sodtai cua bang dt
select magv
from THAMGIADT tg
group by magv
having count(distinct madt) = (select count(*) from detai)
--c2: xet cac gv, voi moi gv, lay ds dtai chua tg cua gv do
--neu ds nay ton tai -> ko tham gia tat ca
--except
select magv
from THAMGIADT tg
where not exists(
select madt 
from detai
except
--ds detai gv 001 co tham gia
select distinct madt
from THAMGIADT tg2
where magv = tg.MAGV)
--c2.2 not in
--ds dt ma gv 001 chua tham gia
select magv
from THAMGIADT tg
where not exists(
select madt
from detai
where madt not in (select madt from THAMGIADT tg2 where magv= tg.MAGV))

--Cho danh sách trưởng bộ môn chưa đảm nhiệm đề tài nào--
--b1: laasy tap matruongbm
--b2: lay tap ma gvcn dt
select truongbm
from bomon
where truongbm is not null
and truongbm not in (select distinct GVCNDT
from detai)

--Q61. Cho biết giáo viên nào đã tham gia tất cả các đề tài có mã chủ đề là QLGD.
--BI CHIA: THAMGIADT
--DS DT TAI CHU DE QLDG --> CHIA (1)
SELECT MADT
FROM DETAI DT
WHERE MACD = 'QLDG'
--LAY DS DTAI THUOC CD QLDG MA GV 001 DA THAM GIA(2)
SELECT TG.MADT
FROM THAMGIADT TG JOIN DETAI DT1 ON TG.MADT = DT1.MADT
WHERE MAGV = '001' AND DT1.MACD = 'QLDG'
--(1-2) : ds DTAI THUOC CD QLDG MA GV1 CHUA THAM GIA
SELECT MADT
FROM DETAI DT
WHERE MACD = 'QLDG'
EXCEPT
SELECT TG.MADT
FROM THAMGIADT TG JOIN DETAI DT1 ON TG.MADT = DT1.MADT
WHERE MAGV = '001' AND DT1.MACD = 'QLDG'
--TONG QUAT LEN CHO CAC GV CO TG DETAI DE XET
SELECT * FROM THAMGIADT TG0
WHERE 
NOT EXISTS(SELECT MADT
FROM DETAI DT
WHERE MACD = 'QLDG'
EXCEPT
SELECT TG.MADT
FROM THAMGIADT TG JOIN DETAI DT1 ON TG.MADT = DT1.MADT
WHERE MAGV = TG0.MAGV AND DT1.MACD = 'QLDG')