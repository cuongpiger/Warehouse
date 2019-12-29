use qltv
go
--Tình trạng của cuốn sách = "có thể mượn" nếu sách đã được trả
--cs: i(+), d(-) u(+tinhtrang)
--ctpm:i(+) d(+) u(-)
--ctpt:i(+) d(+) u(-)
--pt:i(-)d(-)u(+mapm)
go
create function uf_7_1(@isbn varchar(12), @masach varchar(12))
returns table
as
	return (select * from CT_PhieuMuon ctm
								where ctm.isbn = @isbn and
								ctm.masach = @masach
								and not exists (select * from CT_PhieuTra ctt, PhieuTra pt
												where pt.mapm = ctm.mapm and pt.mapt = ctt.mapt
												and ctm.masach = ctt.masach and ctm.isbn = ctt.isbn
												))
go
create
--alter
trigger utr7 on cuonsach 
for update
as
	if update(tinhtrang)
		if exists (select * from (select * from inserted 
								union 
								select * from deleted ) t
					where t.tinhtrang = N'có thể mượn' 
					and exists (select * from uf_7_1(t.isbn,t.masach)))
		begin
			update CuonSach
			set tinhtrang = N'đang mượn'
			from (select * from inserted 
					union 
					select * from deleted ) t
			where cuonsach.isbn = t.isbn and CuonSach.masach = t.masach
			and t.tinhtrang = N'có thể mượn' 
			and exists (select * from uf_7_1(t.isbn,t.masach))
		end
go
--8. tienphat = mucgiaphat * (ngaytra – ngaymuon – songayquydinh),
--nếu vi phạm cập nhật tiền phạt cho đúng
create function [dbo].[uf_TinhTienPhat](@mapm varchar(10),@isbn varchar(12), @masach varchar(15))
returns float
as
begin
	declare @ngaymuon date = (select ngaymuon from phieumuon where mapm = @mapm)
	declare @songayqd int = (select songayquydinh from CT_PhieuMuon
							where isbn = @isbn and masach = @masach and
							mapm = @mapm)
	return (select mucgiaphat * (case when (datediff(day,@ngaymuon,ngaytra) > @songayqd) then (datediff(day,@ngaymuon,ngaytra) - @songayqd) 
								else 0 end)
								from PhieuTra pt, CT_PhieuTra ctt
	where pt.mapm = @mapm and ctt.mapt = pt.mapt and
	ctt.isbn = @isbn and ctt.masach = @masach)
end
go
create 
--alter
trigger utr_11 on ct_phieutra
for update
as
	if update(mucgiaphat) or update(tienphat)
		if not exists (select * from inserted i join PhieuTra pt on pt.mapt = i.mapt
		where dbo.uf_TinhTienPhat(pt.mapm,isbn, masach) = i.tienphat)
		begin
			update CT_PhieuTra
			set tienphat = dbo.uf_TinhTienPhat(pt.mapm,i.isbn, i.masach)
			from inserted i join PhieuTra pt on pt.mapt = i.mapt
			where i.masach = CT_PhieuTra.masach and i.isbn = CT_PhieuTra.isbn
		end
go