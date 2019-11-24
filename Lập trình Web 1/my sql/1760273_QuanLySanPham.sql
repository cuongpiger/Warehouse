create database 1760273_QuanLySanPham
use 1760273_QuanLySanPham;

create table TaiKhoan (
	MaTaiKhoan int not null,
    TenDangNhap varchar(20),
    MatKhau varchar(20),
    TenHienThi varchar(64), 
    DiaChi varchar(256),
    DienThoai varchar(11),
    Email varchar(30),
    BiXoa bool,
    MaLoaiTaiKhoan int,
    
    primary key (MaTaiKhoan)
);

create table DonDatHang (
	MaDonDatHang varchar(9),
    NgayLap datetime,
    TongThanhTien int,
    MaTaiKhoan int,
    MaTinhTrang int,
    
    primary key (MaDonDatHang)
);

create table ChiTietDonDatHang (
	MaChiTietDonDatHang varchar(11),
    SoLuong int,
    GiaBan int,
    MaDonDatHang varchar(9),
    MaSanPham int,
    
    primary key (MaChiTietDonDatHang)
);

create table LoaiTaiKhoan (
	MaLoaiTaiKhoan int,
    TenLoaiTaiKhoan varchar(45),
    
    primary key (MaLoaiTaiKhoan)
);

create table LoaiSanPham (
	MaLoaiSanPham int,
    TenLoaiSanPham varchar(64),
    BiXoa bool,
    
    primary key (MaLoaiSanPham)
);

create table HangSanXuat (
	MaHangSanXuat int,
    TenHangSanXuat varchar(64),
    LogoURL varchar(45),
    BiXoa bool,
    
    primary key (MaHangSanXuat)
);

create table TinhTrang (
	MaTinhTrang int,
    TenTinhTrang varchar(45),
    
    primary key (MaTinhTrang)
);

create table SanPham (
	MaSanPham int,
    TenSanPham varchar(45),
    HinhURL varchar(45),
    GiaSanPham int,
    NgayNhap datetime,
    SoLuongTon int,
    SoLuongBan int,
    SoLuotXem int,
    MoTa text,
    BiXoa bool,
    MaLoaiSanPham int,
    MaHangSanXuat int,
    
    primary key (MaSanPham)
);

alter table DonDatHang
add constraint FK_TaiKhoan
foreign key (MaTaiKhoan) references TaiKhoan(MaTaiKhoan);

alter table DonDatHang
add constraint FK_TinhTrang
foreign key (MaTinhTrang) references TinhTrang(MaTinhTrang);

alter table ChiTietDonDatHang
add constraint FK_DonDatHang
foreign key (MaDonDatHang) references DonDatHang(MaDonDatHang);

alter table TaiKhoan
add constraint FK_LoaiTaiKhoan
foreign key (MaLoaiTaiKhoan) references LoaiTaiKhoan(MaLoaiTaiKhoan);

alter table SanPham
add constraint FK_LoaiSanPham
foreign key (MaLoaiSanPham) references LoaiSanPham(MaLoaiSanPham);

alter table SanPham
add constraint FK_HangSanXuat
foreign key (MaHangSanXuat) references HangSanXuat(MaHangSanXuat);