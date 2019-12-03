use BANHANG
go

-- load list of origins
if OBJECT_ID('sLoadListOrigins', 'P') is not null
	drop proc sLoadListOrigins
go
create proc sLoadListOrigins
as
	select distinct xuatxu from HANGHOA
go

-- load list of goods base on origin
if OBJECT_ID('sLoadListGoodsOrigin', 'P') is not null
	drop proc sLoadListGoodsOrigin
go
create proc sLoadListGoodsOrigin @iOrigin nvarchar(15)
as
	select hh.mahh, hh.tenhh
	from HANGHOA hh
	where hh.xuatxu = @iOrigin
go

-- load list of invoices base on goodsID
if OBJECT_ID('sLoadListInvoicesGoodsID', 'P') is not null
	drop proc sLoadListInvoicesGoodsID
go
create proc sLoadListInvoicesGoodsID @iGoodsID nvarchar(15)
as
	select hd.*
	from HOADON hd join CTHOADON ct on ct.mahd = hd.mahd
	where ct.mahh = @iGoodsID
go

-- calculate total money of a invoice base on ID
if OBJECT_ID('fCalcTotalInvoice') is not null
	drop function fCalcTotalInvoice
go
create function fCalcTotalInvoice(@iGoodsID nvarchar(15)) returns int
as
begin
	return (select sum(ct.sl * ct.dongia)
			from HOADON hd join CTHOADON ct on ct.mahd = hd.mahd
			where ct.mahh = @iGoodsID)
end
go

-- load list of invoice detail base on invoiceID
if OBJECT_ID('sLoadListInvoicesDetailsByInvoiceID', 'P') is not null
	drop proc sLoadListInvoicesDetailsByInvoiceID
go
create proc sLoadListInvoicesDetailsByInvoiceID @iInvoiceID nvarchar(15)
as
	select ct.mahd, ct.mahh, hh.tenhh, hh.dvt, hh.xuatxu, ct.sl, ct.dongia
	from HANGHOA hh join CTHOADON ct on ct.mahh = hh.mahh
	where ct.mahd = @iInvoiceID
go

