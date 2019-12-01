-- Kiểm tra username là duy nhất
if OBJECT_ID('CheckIdentityUsername') is not null
	drop function CheckIdentityUsername
go
create function CheckIdentityUsername (@i_username nvarchar(50))
	returns int
as
begin
	declare @res int = 1
	if exists (select * from Users where f_Username = @i_username)
		set @res = 0

	return @res
end
go

-- Thêm new user
if OBJECT_ID('InsertNewUser', 'P') is not null
	drop proc InsertNewUser
go
create proc InsertNewUser (@iUsername nvarchar(50), @iPassword nvarchar(255), @iName nvarchar(50), @iEmail nvarchar(50), @iDOB date, @iPermission int, @result int output)
as
begin
	set @result = 1
	if exists (select * from Users where f_Password = @iPassword)
		set @result = 0

	insert into Users (f_Username, f_Password, f_Name, f_Email, f_DOB, f_Permission)
	values (@iUsername, @iPassword, @iName, @iEmail, @iDOB, @iPermission)
end
go