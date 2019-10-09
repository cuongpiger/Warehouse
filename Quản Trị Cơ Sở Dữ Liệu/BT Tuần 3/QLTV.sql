USE [master]
GO
if db_id('QLTV') is not null
	drop database QLTV
GO
CREATE DATABASE [QLTV]
GO
USE [QLTV]
GO
CREATE TABLE [dbo].[CT_PhieuMuon](
	[mapm] [char](10) NOT NULL,
	[isbn] [nchar](12) NOT NULL,
	[masach] [nchar](5) NOT NULL,
	[songayquydinh] [int] NULL,
 CONSTRAINT [PK_CT_PhieuMuon] PRIMARY KEY CLUSTERED 
(
	[mapm] ASC,
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_PhieuTra]    Script Date: 2/17/2019 10:40:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PhieuTra](
	[mapt] [char](10) NOT NULL,
	[isbn] [nchar](12) NOT NULL,
	[masach] [nchar](5) NOT NULL,
	[mucgiaphat] [float] NULL,
	[tienphat] [float] NULL,
 CONSTRAINT [PK_CT_PhieuTra] PRIMARY KEY CLUSTERED 
(
	[mapt] ASC,
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuonSach]    Script Date: 2/17/2019 10:40:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuonSach](
	[isbn] [nchar](12) NOT NULL,
	[masach] [nchar](5) NOT NULL,
	[tinhtrang] [nchar](50) NULL,
 CONSTRAINT [PK_CuonSach] PRIMARY KEY CLUSTERED 
(
	[isbn] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DauSach]    Script Date: 2/17/2019 10:40:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DauSach](
	[isbn] [nchar](12) NOT NULL,
	[tensach] [nvarchar](100) NULL,
	[tacgia] [nvarchar](50) NULL,
	[namxb] [int] NULL,
	[nhaxb] [nchar](20) NULL,
	[soluong] [int] NULL,
	[mucgiaphat] [float] NULL,
	[theloai] [nvarchar](70) NULL,
 CONSTRAINT [PK_DauSach] PRIMARY KEY CLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 2/17/2019 10:40:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocGia](
	[madg] [nchar](10) NOT NULL,
	[hoten] [nvarchar](70) NULL,
	[socmnd] [nchar](10) NULL,
	[ngsinh] [date] NULL,
	[gioitinh] [nchar](3) NULL,
	[email] [nchar](40) NULL,
	[matkhau] [nchar](10) NULL,
	[diachi] [nvarchar](70) NULL,
 CONSTRAINT [PK_DocGia] PRIMARY KEY CLUSTERED 
(
	[madg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 2/17/2019 10:40:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[mapm] [char](10) NOT NULL,
	[madg] [nchar](10) NULL,
	[ngaymuon] [date] NULL,
 CONSTRAINT [PK_PhieuMuon] PRIMARY KEY CLUSTERED 
(
	[mapm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuTra]    Script Date: 2/17/2019 10:40:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTra](
	[mapt] [char](10) NOT NULL,
	[mapm] [char](10) NULL,
	[ngaytra] [date] NULL,
 CONSTRAINT [PK_PhieuTra] PRIMARY KEY CLUSTERED 
(
	[mapt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CT_PhieuMuon] ([mapm], [isbn], [masach], [songayquydinh]) VALUES (N'PM001     ', N'116525441   ', N'S001 ', 8)
INSERT [dbo].[CT_PhieuMuon] ([mapm], [isbn], [masach], [songayquydinh]) VALUES (N'PM001     ', N'245676441   ', N'S002 ', 8)
INSERT [dbo].[CT_PhieuMuon] ([mapm], [isbn], [masach], [songayquydinh]) VALUES (N'PM002     ', N'116525441   ', N'S002 ', 8)
INSERT [dbo].[CT_PhieuMuon] ([mapm], [isbn], [masach], [songayquydinh]) VALUES (N'PM002     ', N'245676441   ', N'S001 ', 8)
INSERT [dbo].[CT_PhieuMuon] ([mapm], [isbn], [masach], [songayquydinh]) VALUES (N'PM003     ', N'369874112   ', N'S001 ', 8)
INSERT [dbo].[CT_PhieuMuon] ([mapm], [isbn], [masach], [songayquydinh]) VALUES (N'PM003     ', N'587422656   ', N'S001 ', 8)
INSERT [dbo].[CT_PhieuMuon] ([mapm], [isbn], [masach], [songayquydinh]) VALUES (N'PM004     ', N'116525441   ', N'S001 ', 8)
INSERT [dbo].[CT_PhieuTra] ([mapt], [isbn], [masach], [mucgiaphat], [tienphat]) VALUES (N'PT001     ', N'116525441   ', N'S001 ', NULL, 0)
INSERT [dbo].[CT_PhieuTra] ([mapt], [isbn], [masach], [mucgiaphat], [tienphat]) VALUES (N'PT001     ', N'245676441   ', N'S002 ', NULL, 0)
INSERT [dbo].[CT_PhieuTra] ([mapt], [isbn], [masach], [mucgiaphat], [tienphat]) VALUES (N'PT002     ', N'116525441   ', N'S002 ', NULL, 0)
INSERT [dbo].[CT_PhieuTra] ([mapt], [isbn], [masach], [mucgiaphat], [tienphat]) VALUES (N'PT002     ', N'245676441   ', N'S001 ', NULL, 0)
INSERT [dbo].[CT_PhieuTra] ([mapt], [isbn], [masach], [mucgiaphat], [tienphat]) VALUES (N'PT003     ', N'369874112   ', N'S001 ', NULL, 0)
INSERT [dbo].[CT_PhieuTra] ([mapt], [isbn], [masach], [mucgiaphat], [tienphat]) VALUES (N'PT003     ', N'587422656   ', N'S001 ', NULL, 0)
INSERT [dbo].[CT_PhieuTra] ([mapt], [isbn], [masach], [mucgiaphat], [tienphat]) VALUES (N'PT004     ', N'116525441   ', N'S001 ', NULL, 0)
INSERT [dbo].[CuonSach] ([isbn], [masach], [tinhtrang]) VALUES (N'116525441   ', N'S001 ', N'có thể mượn                                       ')
INSERT [dbo].[CuonSach] ([isbn], [masach], [tinhtrang]) VALUES (N'116525441   ', N'S002 ', N'có thể mượn                                       ')
INSERT [dbo].[CuonSach] ([isbn], [masach], [tinhtrang]) VALUES (N'245676441   ', N'S001 ', N'có thể mượn                                       ')
INSERT [dbo].[CuonSach] ([isbn], [masach], [tinhtrang]) VALUES (N'245676441   ', N'S002 ', N'có thể mượn                                       ')
INSERT [dbo].[CuonSach] ([isbn], [masach], [tinhtrang]) VALUES (N'369874112   ', N'S001 ', N'có thể mượn                                       ')
INSERT [dbo].[CuonSach] ([isbn], [masach], [tinhtrang]) VALUES (N'587422656   ', N'S001 ', N'có thể mượn                                       ')
INSERT [dbo].[DauSach] ([isbn], [tensach], [tacgia], [namxb], [nhaxb], [soluong], [mucgiaphat], [theloai]) VALUES (N'116525441   ', N'Toán cao cấp A1', N'Tr?n Phuong', 2001, N'Giáo dục            ', 2, 3500, N'khoa học cơ bản')
INSERT [dbo].[DauSach] ([isbn], [tensach], [tacgia], [namxb], [nhaxb], [soluong], [mucgiaphat], [theloai]) VALUES (N'245676441   ', N'Toeic 600', N'Lê Ng?c Quý', 2010, N'Giáo dục            ', 2, 5500, N'ngoại ngữ')
INSERT [dbo].[DauSach] ([isbn], [tensach], [tacgia], [namxb], [nhaxb], [soluong], [mucgiaphat], [theloai]) VALUES (N'369874112   ', N'Lập trình C', N'Tr?n Bá Khang', 2014, N'Giáo dục            ', 1, 6500, N'khoa học ứng dụng')
INSERT [dbo].[DauSach] ([isbn], [tensach], [tacgia], [namxb], [nhaxb], [soluong], [mucgiaphat], [theloai]) VALUES (N'587422656   ', N'Lịch sử thế giới hiện đại', N'Phan Hoài Vu', 2001, N'Giáo dục            ', 1, 2500, N'xã hội')
INSERT [dbo].[DocGia] ([madg], [hoten], [socmnd], [ngsinh], [gioitinh], [email], [matkhau], [diachi]) VALUES (N'DG01      ', N'Lê Ngọc Bình', N'2157836254', CAST(N'1980-01-11' AS Date), N'Nữ ', N'binh@yahoo.com.vn                       ', N'30022     ', N'125 Lê Lợi, Q1, TP.HCM')
INSERT [dbo].[DocGia] ([madg], [hoten], [socmnd], [ngsinh], [gioitinh], [email], [matkhau], [diachi]) VALUES (N'DG02      ', N'Trần Thái An', N'8362541255', CAST(N'1987-05-22' AS Date), N'Nữ ', N'tako@gmail.com                          ', N'dfsdf     ', N'227 Nguyễn Huệ, Q3, TP.HCM')
INSERT [dbo].[DocGia] ([madg], [hoten], [socmnd], [ngsinh], [gioitinh], [email], [matkhau], [diachi]) VALUES (N'DG03      ', N'Nguyễn Ngọc', N'6252541542', CAST(N'1988-08-30' AS Date), N'Nam', N'ngocngoc@yahoo.com                      ', N'llllli    ', N'16 Lý Chính Thắng, Q3, TP.HCM')
INSERT [dbo].[DocGia] ([madg], [hoten], [socmnd], [ngsinh], [gioitinh], [email], [matkhau], [diachi]) VALUES (N'DG04      ', N'Trần Thanh', N'8795246254', CAST(N'1989-10-16' AS Date), N'Nam', N'tthanh@gmail.com                        ', N'00005     ', N'12 Cao Lỗ, Q8, TP.HCM')
INSERT [dbo].[DocGia] ([madg], [hoten], [socmnd], [ngsinh], [gioitinh], [email], [matkhau], [diachi]) VALUES (N'DG05      ', N'Hoàng Khanh', N'2524625541', CAST(N'1982-11-19' AS Date), N'Nam', N'khanh@hotmail.com                       ', N'toiieu    ', N'67 Kha Vạn Cân, Q9, TP.HCM')
INSERT [dbo].[PhieuMuon] ([mapm], [madg], [ngaymuon]) VALUES (N'PM001     ', N'DG01      ', CAST(N'2014-01-12' AS Date))
INSERT [dbo].[PhieuMuon] ([mapm], [madg], [ngaymuon]) VALUES (N'PM002     ', N'DG02      ', CAST(N'2014-02-26' AS Date))
INSERT [dbo].[PhieuMuon] ([mapm], [madg], [ngaymuon]) VALUES (N'PM003     ', N'DG04      ', CAST(N'2014-09-25' AS Date))
INSERT [dbo].[PhieuMuon] ([mapm], [madg], [ngaymuon]) VALUES (N'PM004     ', N'DG05      ', CAST(N'2014-11-14' AS Date))
INSERT [dbo].[PhieuTra] ([mapt], [mapm], [ngaytra]) VALUES (N'PT001     ', N'PM001     ', CAST(N'2014-01-18' AS Date))
INSERT [dbo].[PhieuTra] ([mapt], [mapm], [ngaytra]) VALUES (N'PT002     ', N'PM002     ', CAST(N'2014-03-04' AS Date))
INSERT [dbo].[PhieuTra] ([mapt], [mapm], [ngaytra]) VALUES (N'PT003     ', N'PM004     ', CAST(N'2014-10-05' AS Date))
INSERT [dbo].[PhieuTra] ([mapt], [mapm], [ngaytra]) VALUES (N'PT004     ', N'PM004     ', CAST(N'2014-11-20' AS Date))
ALTER TABLE [dbo].[CT_PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuMuon_CuonSach] FOREIGN KEY([isbn], [masach])
REFERENCES [dbo].[CuonSach] ([isbn], [masach])
GO
ALTER TABLE [dbo].[CT_PhieuMuon] CHECK CONSTRAINT [FK_CT_PhieuMuon_CuonSach]
GO
ALTER TABLE [dbo].[CT_PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuMuon_PhieuMuon] FOREIGN KEY([mapm])
REFERENCES [dbo].[PhieuMuon] ([mapm])
GO
ALTER TABLE [dbo].[CT_PhieuMuon] CHECK CONSTRAINT [FK_CT_PhieuMuon_PhieuMuon]
GO
ALTER TABLE [dbo].[CT_PhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuTra_CuonSach] FOREIGN KEY([isbn], [masach])
REFERENCES [dbo].[CuonSach] ([isbn], [masach])
GO
ALTER TABLE [dbo].[CT_PhieuTra] CHECK CONSTRAINT [FK_CT_PhieuTra_CuonSach]
GO
ALTER TABLE [dbo].[CT_PhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuTra_PhieuTra] FOREIGN KEY([mapt])
REFERENCES [dbo].[PhieuTra] ([mapt])
GO
ALTER TABLE [dbo].[CT_PhieuTra] CHECK CONSTRAINT [FK_CT_PhieuTra_PhieuTra]
GO
ALTER TABLE [dbo].[CuonSach]  WITH CHECK ADD  CONSTRAINT [FK_CuonSach_DauSach] FOREIGN KEY([isbn])
REFERENCES [dbo].[DauSach] ([isbn])
GO
ALTER TABLE [dbo].[CuonSach] CHECK CONSTRAINT [FK_CuonSach_DauSach]
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_DocGia] FOREIGN KEY([madg])
REFERENCES [dbo].[DocGia] ([madg])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_DocGia]
GO
ALTER TABLE [dbo].[PhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_PhieuTra_PhieuMuon] FOREIGN KEY([mapm])
REFERENCES [dbo].[PhieuMuon] ([mapm])
GO
ALTER TABLE [dbo].[PhieuTra] CHECK CONSTRAINT [FK_PhieuTra_PhieuMuon]
GO
USE [master]
GO
ALTER DATABASE [QLTV] SET  READ_WRITE 
GO
