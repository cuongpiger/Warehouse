-- 1. Đọc giả phải có ít nhất một phiếu mượn sách
/*
							Insert							Delete							Update
DocGia						+								-								-
PhieuMuon					-								+								+ MaDG
*/
IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'trg_Cau_1_del_PhieuMuon')
begin
	drop trigger trg_Cau_1_del_PhieuMuon
end
go
create trigger trg_Cau_1_del_PhieuMuon on PhieuMuon
for delete, update
as
begin
	if exists (select *
			   from deleted de, DocGia dg
		       where de.madg = dg.madg and (select COUNT(pm.mapm)
											from DocGia dg1, PhieuMuon pm
											where dg1.madg = dg.madg and pm.madg = dg1.madg) <= 1)
	begin
		raiserror('Error', 0, 1)
		rollback transaction
	end
end
go

update PhieuMuon set madg = 'DG02' where mapm = 'PM001'

-- 2. Phiếu mượn sách phải có ít nhất một chi tiết
/*
							Insert							Delete							Update
PhieuMuon					+								-								-
CT_PhieuMuon				-								+								+ MaPM
*/
IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'trg_Cau_2_CT_PhieuMuon')
begin
	drop trigger trg_Cau_2_CT_PhieuMuon
end
go
create trigger trg_Cau_2_CT_PhieuMuon on CT_PhieuMuon
for delete, update
as
begin
	if exists (select *
			   from deleted de, PhieuMuon pm
		       where de.mapm = pm.mapm and (select COUNT(ctpm.isbn)
											from PhieuMuon pm1, CT_PhieuMuon ctpm
											where pm1.mapm = ctpm.mapm and pm.madg = pm1.mapm) <= 1)
	begin
		raiserror('Error', 0, 1)
		rollback transaction
	end
end
go

update CT_PhieuMuon set mapm = 'PM003' where mapm = 'PM004' and isbn = '116525441'

-- 3. Ngày trả phải lớn hơn ngày mượn
/*
							Insert							Delete							Update
PhieuMuon					-								-								+ NgayMuon
PhieuTra					+								-								+ NgayTra, MaPM
*/

IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'trg_Cau_3_PhieuMuon')
begin
	drop trigger trg_Cau_3_PhieuMuon
end
go
create trigger trg_Cau_3_PhieuMuon on PhieuMuon
for update
as
begin
	if exists (select *
			   from inserted it, PhieuTra pt
		       where it.mapm = pt.mapm and it.ngaymuon >= pt.ngaytra)
	begin
		raiserror('Error', 0, 1)
		rollback transaction
	end
end
go

update PhieuMuon set ngaymuon = '2014-01-20' where mapm  = 'PM001'



IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'trg_Cau_3_PhieuTra_insert_update')
begin
	drop trigger trg_Cau_3_PhieuTra_insert_update
end
go
create trigger trg_Cau_3_PhieuTra_insert_update on PhieuTra
for update
as
begin
	if exists (select *
			   from inserted it, PhieuMuon pm
		       where it.mapm = pm.mapm and it.ngaytra <= pm.ngaymuon)
	begin
		raiserror('Error', 0, 1)
		rollback transaction
	end
end
go

update PhieuMuon set ngaymuon = '2014-01-20' where mapm  = 'PM001'

-- 4. CMND của đọc giả không được trùng
/*
							Insert							Delete							Update
DocGia						+						 		-								- SoCMND
*/
IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'trg_Cau_4_DocGia_SoCMND')
begin
	drop trigger trg_Cau_4_DocGia_SoCMND
end
go
create trigger trg_Cau_4_DocGia_SoCMND on DocGia
for insert, update
as
begin
	if exists (select *
			   from inserted it, DocGia dg
		       where it.madg <> dg.madg and it.socmnd = dg.socmnd)
	begin
		raiserror('Error', 0, 1)
		rollback transaction
	end
end
go

select * from DocGia

update DocGia set socmnd = '8362541255' where madg = 'DG01'

-- 5. Email của đọc giả không được trùng và phải chứa @
/*
							Insert							Delete							Update
DocGia						+						 		-								- Email
*/
if exists (select 1 from sys.triggers
		   where name = 'Cau_5')
begin
	drop trigger Cau_5
end
go

create trigger Cau_5 on DocGia
for insert, update
as
begin
	if exists (select * 
			   from inserted ist, DocGia dg
			   where ist.email = dg.email or (charindex('@', ist.email) <= 0))
	begin
		raiserror ('Error', 0, 1)
		rollback transaction
	end
end
go

-- 6. Tình trạng của cuốn sách = "đang được mượn" nếu sách chưa được trả
/*
							Insert							Delete							Update
CuonSach						-						 		-								+ (tinhtrang)
PhieuTra						+								+								+ 
*/

if exists (select 1 from sys.triggers
		   where name = 'Cau_6_a')
	drop trigger Cau_6_a
go

create trigger Cau_6_a on CuonSach
for update 
as
begin
	if exists (select *
			   from inserted ist, CT_PhieuTra ctpt, PhieuTra pt
			   where ist.isbn = ctpt.isbn and ist.masach = ctpt.masach and ctpt.mapt = pt.mapt
					 and (ist.tinhtrang = N'có thể mượn' and (pt.ngaytra <= GETDATE())))
	begin
		raiserror ('Error', 0, 1)
		rollback transaction
	end
end
go



if exists (select 1 from sys.triggers
		   where name = 'Cau_6_b')
	drop trigger Cau_6_b
go

create trigger Cau_6_b on PhieuTra
for insert
as
begin
	if exists (select *
			   from inserted ist, CuonSach cs, CT_PhieuTra ctpt
			   where ist.mapt = ctpt.mapt and ctpt.isbn = cs.isbn and ctpt.masach = cs.masach
					 and cs.tinhtrang = N'đang được mượn')
	begin
		raiserror ('Error', 0, 1)
		rollback transaction
	end
end
go


if exists (select 1 from sys.triggers
		   where name = 'Cau_6_c')
	drop trigger Cau_6_c
go

create trigger Cau_6_c on PhieuTra
for delete, update
as
begin
	if exists (select *
			   from deleted dlt, CuonSach cs, CT_PhieuTra ctpt
			   where dlt.mapt = ctpt.mapt and ctpt.isbn = cs.isbn and ctpt.masach = cs.masach
					 and cs.tinhtrang = N'đang được mượn')
	begin
		raiserror ('Error', 0, 1)
		rollback transaction
	end
end
go

-- 7. Tình trạng của cuốn sách = "có thể mượn" nếu sách đã được trả
/*
							Insert							Delete							Update
CuonSach						-						 		-								+ (tinhtrang)
*/

if exists (select 1 from sys.triggers
		   where name = 'Cau_7_a')
	drop trigger Cau_7_a
go

create trigger Cau_7_a on CuonSach
for update 
as
begin
	if exists (select *
			   from inserted ist, CT_PhieuTra ctpt, PhieuTra pt
			   where ist.isbn = ctpt.isbn and ist.masach = ctpt.masach and ctpt.mapt = pt.mapt
					 and (ist.tinhtrang = N'đang được mượn' and (pt.ngaytra > GETDATE())))
	begin
		raiserror ('Error', 0, 1)
		rollback transaction
	end
end
go

-- 8. tienphat = mucgiaphat * (ngaytra – ngaymuon – songayquydinh)

-- 9. Sách trả phải là sách được mượn trong phiếu mượn tương ứng
/*
							Insert							Delete							Update
CT_PhieuTra					+						 		-								+ (isbn, mapt)
*/
if exists (select 1 from sys.triggers
		   where name = 'Cau_9')
	drop trigger Cau_9
go

create trigger Cau_9 on CT_PhieuTra
for insert, update 
as
begin
	if exists (select *
			   from inserted ist, PhieuTra pt, CT_PhieuMuon ctpm
			   where ist.mapt = pt.mapt and pt.mapm = ctpm.mapm and (ctpm.isbn <> ist.isbn and ctpm.mapm <> ist.masach))
	begin
		raiserror ('error', 0, 1)
		rollback transaction
	end
end
go

-- 10. Mỗi phiếu trả có ít nhất một chi tiết
/*
							Insert							Delete							Update
CT_PhieuTra					-						 		+								+ (isbn, mapt)
PhieuTra					+								-								-
*/

if exists (select 1 from sys.triggers
		   where name = 'Cau_10')
	drop trigger Cau_10
go

create trigger Cau_10 on CT_PhieuTra
for delete, update 
as
begin
	if exists (select *
			   from deleted dlt, PhieuTra pt
			   where dlt.mapt <> pt.mapt)
	begin
		raiserror ('error', 0, 1)
		rollback transaction
	end
end
go