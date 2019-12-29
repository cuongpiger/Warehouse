﻿--1. Đọc giả phải có ít nhất một phiếu mượn sách
/*
					Thêm					Xóa						Sửa
DocGia				+						-						-
PhieuMuon			+						+						+ (MaDG)
*/

if OBJECT_ID('insertPhieuMuon', 'P') is not null
	drop proc insertPhieuMuon
go

create proc insertPhieuMuon
	@iMaPM char(10), @iMaDG nchar(10), @iNgayMuon date
as
	insert into PhieuMuon
	values(@iMaPM, @iMaDG, @iNgayMuon)
go

if exists (select 1 from sys.triggers where name = 'trgXoaPhieuMuon_1')
	drop trigger trgXoaPhieuMuon_1
go

create trigger trgXoaPhieuMuon_1 on PhieuMuon
for delete, update
as
begin
	declare @tmpMaPM char(10), @tmpMaDG nchar(10), @tmpNgayMuon date
	
	if exists (select *
			   from deleted dlt join DocGia dg on dlt.madg = dg.madg
			   where (select count(pm.mapm)
					  from PhieuMuon pm
					  where pm.madg = dlt.madg) = 0)
	begin
		declare cur cursor for (select dlt.mapm, dlt.madg, dlt.ngaymuon
								from deleted dlt join DocGia dg on dlt.madg = dg.madg
								where (select count(pm.mapm)
									   from PhieuMuon pm
									   where pm.madg = dlt.madg) = 0)
		open cur
		fetch next from cur into @tmpMaPM, @tmpMaDG, @tmpNgayMuon

		while @@FETCH_STATUS = 0
		begin
			raiserror (N'Không thể xóa hay sửa Phiếu Mượn', 0, 1);
			exec insertPhieuMuon @tmpMaPM, @tmpMaDG, @tmpNgayMuon
			fetch next from cur into @tmpMaPM, @tmpMaDG, @tmpNgayMuon
		end

		close cur
		deallocate cur
	end
end
go

insert into PhieuMuon
values ('PM009', 'DG03', '2012-12-21')

delete from PhieuMuon
where mapm = 'PM009'

update PhieuMuon
set madg = 'DG05'
where mapm = 'PM001'


--  2. Phiếu mượn sách phải có ít nhất một chi tiết
/*
					Thêm					Xóa						Sửa
PhieuMuon			+						-						-
CT_PhieuMuon		+						+						+ (MaPM)					
*/

if OBJECT_ID('insertCT_PhieuMuon', 'P') is not null
	drop proc insertCT_PhieuMuon
go

create proc insertCT_PhieuMuon
	@tmpMaPM char(10), @tmpIsbn nchar(12), @tmpMaSach nchar(5), @tmpSoNgayQuyDinh int
as
	insert into CT_PhieuMuon
	values(@tmpMaPM, @tmpIsbn, @tmpMaSach, @tmpSoNgayQuyDinh)
go

if exists (select 1 from sys.triggers where name = 'trgXoaPhieuMuon_1')
	drop trigger trgXoaPhieuMuon_1
go

if exists (select 1 from sys.triggers where name = 'trgXoaSuaCT_PhieuMuon_2')
	drop trigger trgXoaSuaCT_PhieuMuon_2
go

create trigger trgXoaSuaCT_PhieuMuon_2 on CT_PhieuMuon
for delete, update
as
begin
	declare @tmpMaPM char(10), @tmpIsbn nchar(12), @tmpMaSach nchar(5), @tmpSoNgayQuyDinh int
	if exists (select *
			   from deleted dlt join PhieuMuon pm on pm.mapm = dlt.mapm
			   where dlt.mapm not in (select ctpm.mapm
									  from CT_PhieuMuon ctpm))
	begin
		declare cur cursor for (select dlt.mapm, dlt.isbn, dlt.masach, dlt.songayquydinh
								from deleted dlt join PhieuMuon pm on pm.mapm = dlt.mapm
								where dlt.mapm not in (select ctpm.mapm
													   from CT_PhieuMuon ctpm))
		open cur
		fetch next from cur into @tmpMaPM, @tmpIsbn, @tmpMaSach, @tmpSoNgayQuyDinh

		while @@FETCH_STATUS = 0
		begin
			raiserror ('Không thể xóa hay sửa Chi tiết phiếu mượn', 0, 1)
			exec insertCT_PhieuMuon @tmpMaPM, @tmpIsbn, @tmpMaSach, @tmpSoNgayQuyDinh
			fetch next from cur into @tmpMaPM, @tmpIsbn, @tmpMaSach, @tmpSoNgayQuyDinh
		end

		close cur
		deallocate cur
	end
end
go

-- 3. Ngày trả phải lớn hơn ngày mượn
/*
					Thêm					Xóa						Sửa
PhieuMuon			-						-						+ (NgayMuon)
PhieuTra			+						-						+ (NgayTra)
*/

create trigger trgSuaPhieuMuon_3 on PhieuMuon
for update
as
begin
	declare @tmpMaPM char(10), @tmpMaDG nchar(10), @tmpNgayMuon date

	declare cur cursor for (select dlt.mapm, dlt.madg, dlt.ngaymuon
							from inserted ist join PhieuTra pt on pt.mapm = ist.mapm join deleted dlt on ist.mapm = dlt.mapm
							where ist.ngaymuon >= pt.ngaytra)
	open cur
	fetch next from cur into @tmpMaPM, @tmpMaDG, @tmpNgayMuon

	while @@FETCH_STATUS = 0
	begin
		raiserror ('Không thể sửa phiếu mượn', 0, 1)
		update PhieuMuon
		set ngaymuon = @tmpNgayMuon
		where mapm = @tmpMaPM

		fetch next from cur into @tmpMaPM, @tmpMaDG, @tmpNgayMuon
	end

	close cur
	deallocate cur
end
go

create trigger trgThemPhieuTra_3 on PhieuTra
for insert
as 
begin
	declare @tmpMaPT char(10)
	declare cur cursor for (select ist.mapt
							from inserted ist join PhieuMuon pm on pm.mapm = ist.mapm
							where pm.ngaymuon >= ist.ngaytra)
	open cur
	fetch next from cur into @tmpMaPT

	while @@FETCH_STATUS = 0
	begin
		raiserror ('Không thể thêm phiếu trả', 0, 1)
		delete from PhieuTra where mapt = @tmpMaPT

		fetch next from cur into @tmpMaPT
	end
	
	close cur
	deallocate cur	
end
go

create trigger trgSuaPhieuTra_3 on PhieuTra
for update
as 
begin
	declare @tmpMaPT char(10), @tmpMaPM char(10), @tmpNgayTra date
	declare cur cursor for (select dlt.mapt, dlt.mapm, dlt.ngaytra
							from inserted ist join PhieuMuon pm on pm.mapm = ist.mapm join deleted dlt on dlt.mapt = ist.mapt
							where pm.ngaymuon >= ist.ngaytra)
	open cur
	fetch next from cur into @tmpMaPT, @tmpMaPM, @tmpNgayTra

	while @@FETCH_STATUS = 0
	begin
		raiserror ('Không thể sửa phiếu trả', 0, 1)
		update PhieuTra
		set ngaytra = @tmpNgayTra
		where mapt = @tmpMaPT

		fetch next from cur into @tmpMaPT, @tmpMaPM, @tmpNgayTra
	end
	
	close cur
	deallocate cur	
end
go

-- 4. CMND của đọc giả không được trùng
/*
					Thêm					Xóa						Sửa
DocGia				+						-						+ SoCMND
*/

create trigger trgThemDocGia_4 on DocGia
for insert
as 
begin
	declare @tmpMaDG nchar(10)
	declare cur cursor for (select ist.madg
							from inserted ist join DocGia dg on dg.socmnd = ist.socmnd and dg.madg <> ist.madg)
	open cur
	fetch next from cur into @tmpMaDG

	while @@FETCH_STATUS = 0
	begin
		raiserror ('Không thể thêm độc giả', 0, 1)
		
		delete from DocGia
		where madg = @tmpMaDG

		fetch next from cur into @tmpMaDG
	end
	
	close cur
	deallocate cur	
end
go

create trigger trgSuaDocGia_4 on DocGia
for update
as 
begin
	declare @tmpMaDG nchar(10), @tmpSoCMND nchar(10)
	declare cur cursor for (select dlt.madg, dlt.socmnd
							from inserted ist join DocGia dg on dg.socmnd = ist.socmnd and dg.madg <> ist.madg join deleted dlt on
							dlt.madg = ist.madg)
	open cur
	fetch next from cur into @tmpMaDG, @tmpSoCMND

	while @@FETCH_STATUS = 0
	begin
		raiserror ('Không thể sửa độc giả', 0, 1)
		
		update DocGia
		set socmnd = @tmpSoCMND
		where madg = @tmpMaDG

		fetch next from cur into @tmpMaDG, @tmpSoCMND
	end
	
	close cur
	deallocate cur	
end
go