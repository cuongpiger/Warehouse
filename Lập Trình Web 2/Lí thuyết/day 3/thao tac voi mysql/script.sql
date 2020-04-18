ALTER DATABASE QuanLiBanHang CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

create table Categories (
	CatID int not null auto_increment,
    CatName varchar(50),
    
    primary key (CatID)
);

insert into categories (CatName)
values (N'Sách');

insert into categories (CatName)
values (N'Điện thoại');

insert into categories (CatName)
values (N'Máy chụp hình');

insert into categories (CatName)
values (N'Quần áo - Giày dép');

insert into categories (CatName)
values (N'Máy tính');

insert into categories (CatName)
values (N'Đồ trang sức');

insert into categories (CatName)
values (N'Khác');

select * from categories;