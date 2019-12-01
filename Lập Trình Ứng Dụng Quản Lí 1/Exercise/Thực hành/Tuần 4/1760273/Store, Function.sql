-- Lấy tên các category
if OBJECT_ID('GetCategoriesName', 'P') is not null
	drop proc GetCategoriesName
go
create proc GetCategoriesName
as
	select CategoryName, CategoryID
	from Categories
go


-- Lấy danh sách các mặt hàng dựa vào Category
if OBJECT_ID('GetDataDependCategory', 'P') is not null
	drop proc GetDataDependCategory
go
create proc GetDataDependCategory (@i_category )