CREATE DATABASE BANHANG 
GO
USE BANHANG
GO


CREATE TABLE [dbo].[HANGHOA](
	[mahh] [varchar](15) NOT NULL,
	[tenhh] [nvarchar](50) NULL,
	[dvt] [nvarchar](10) NULL,
	[xuatxu] [nvarchar](20) NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY (mahh)) 

GO

CREATE TABLE [dbo].[HOADON](
	[mahd] [varchar](15) NOT NULL,
	[tenkh] [nvarchar](50) NULL,
	[diachi] [nvarchar](100) NULL,
	[sdt] [varchar](15) NULL,
	[tongtien] [int] NULL,
	[ngay] [date] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY (mahd)
) 
GO

CREATE TABLE CTHOADON(
	[mahd] [varchar](15) NOT NULL,
	[mahh] [varchar](15) NOT NULL,
	[sl] [int] NULL,
	[dongia] [int] NULL,
 CONSTRAINT [PK_CTHOADON_1] PRIMARY KEY (mahd, mahh)
 )
GO

ALTER TABLE [dbo].[CTHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHOADON_HANGHOA1] FOREIGN KEY([mahh])
REFERENCES [dbo].[HANGHOA] ([mahh])
GO

ALTER TABLE [dbo].[CTHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHOADON_HOADON1] FOREIGN KEY([mahd])
REFERENCES [dbo].[HOADON] ([mahd])
GO

INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0001', N'Táo đỏ', N'kg', N'Mỹ')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0002', N'Nho ba mọi', N'kg', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0003', N'Dừa xiêm', N'trái', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0004', N'Lê', N'kg', N'Hàn Quốc')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0005', N'Hạt dẻ', N'kg', N'Trung Quốc')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0006', N'Cà phê hòa tan', N'gói', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0007', N'Sữa bột Similac', N'Hộp', N'Mỹ')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0008', N'CocaCola', N'Chai', N'Mỹ')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0009', N'Bánh quy', N'Hộp', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0010', N'bàn chải đánh răng', N'cái', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0011', N'Kem đánh răng', N'Hộp', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0012', N'Bột giặt', N'Bịch', N'Mỹ')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0013', N'Bia Heniken', N'Thùng', N'Hà Lan')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0014', N'Bia Sài Gòn', N'Thùng', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0015', N'Sữa tươi VinaMilk', N'Hộp', N'Việt Nam')
GO
INSERT [dbo].[HANGHOA] ([mahh], [tenhh], [dvt], [xuatxu]) VALUES (N'HH0016', N'Đường tinh luyện', N'kg', N'Việt Nam')
GO
INSERT [dbo].[HOADON] ([mahd], [tenkh], [diachi], [sdt], [tongtien], [ngay]) VALUES (N'HD0001', N'Lý Hoài An', N'123 Trần Hưng Đạo, P4 Q5 TpHCM', N'0908234158', NULL, CAST(0xA83F0B00 AS Date))
GO
INSERT [dbo].[HOADON] ([mahd], [tenkh], [diachi], [sdt], [tongtien], [ngay]) VALUES (N'HD0002', N'Trần Hoàng Ngân', N'17/9 Nguyễn Trãi, P. Nguyễn Cư Trinh Q1 Tp.HCM', N'0985125687', NULL, CAST(0x693F0B00 AS Date))
GO
INSERT [dbo].[HOADON] ([mahd], [tenkh], [diachi], [sdt], [tongtien], [ngay]) VALUES (N'HD0003', N'Lưu Tuyết Nhi', N'124 Nguyễn Văn Linh, P Tân Hưng Q7 Tp.HCM', N'0903221589', NULL, CAST(0x313F0B00 AS Date))
GO
INSERT [dbo].[HOADON] ([mahd], [tenkh], [diachi], [sdt], [tongtien], [ngay]) VALUES (N'HD0004', N'Hà Văn Tùng', N'221 Phạm Thế Hiển P5 Q8 TP.HCM', N'0913112998', NULL, CAST(0xD23F0B00 AS Date))
GO
INSERT [dbo].[HOADON] ([mahd], [tenkh], [diachi], [sdt], [tongtien], [ngay]) VALUES (N'HD0005', N'Trần Minh Tâm', N'35 Nguyễn Thiện Thuật Q5 TP.HCM', N'0936159613', NULL, CAST(0xF83F0B00 AS Date))
GO


INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0002', N'HH0001', 2, 95000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0002', N'HH0003', 1, 8000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0002', N'HH0007', 2, 325000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0002', N'HH0008', 1, 15000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0002', N'HH0012', 2, 23500)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0002', N'HH0016', 3, 35000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0004', N'HH0002', 2, 15000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0004', N'HH0005', 1, 25000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0004', N'HH0007', 1, 325000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0004', N'HH0013', 2, 495000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0004', N'HH0016', 5, 3500)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0005', N'HH0009', 2, 42000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0005', N'HH0010', 4, 5000)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0005', N'HH0011', 1, 7500)
GO
INSERT [dbo].[CTHOADON] ([mahd], [mahh], [sl], [dongia]) VALUES (N'HD0005', N'HH0015', 10, 3500)
GO

