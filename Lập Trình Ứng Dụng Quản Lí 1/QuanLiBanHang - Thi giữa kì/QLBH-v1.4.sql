/*
Navicat SQL Server Data Transfer

Source Server         : SQLEXPRESS 2012 LOCAL
Source Server Version : 110000
Source Host           : .\SQLEXPRESS:1433
Source Database       : QLBH
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2014-03-27 18:45:52
*/


-- ----------------------------
-- Table structure for [dbo].[Categories]
-- ----------------------------
--DROP TABLE [dbo].[Categories]
GO
CREATE TABLE [dbo].[Categories] (
[CatID] int NOT NULL IDENTITY(1,1) ,
[CatName] nvarchar(50) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Categories]', RESEED, 33)
GO

-- ----------------------------
-- Records of Categories
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Categories] ON
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName]) VALUES (N'1', N'Sách');
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName]) VALUES (N'2', N'Điện thoại');
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName]) VALUES (N'3', N'Máy chụp hình');
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName]) VALUES (N'4', N'Quần áo - Giày dép');
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName]) VALUES (N'5', N'Máy tính');
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName]) VALUES (N'6', N'Đồ trang sức');
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName]) VALUES (N'7', N'Khác');
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO

-- ----------------------------
-- Table structure for [dbo].[OrderDetails]
-- ----------------------------
--DROP TABLE [dbo].[OrderDetails]
GO
CREATE TABLE [dbo].[OrderDetails] (
[ID] int NOT NULL IDENTITY(1,1) ,
[OrderID] int NOT NULL ,
[ProID] int NOT NULL ,
[Quantity] int NOT NULL ,
[Price] money NOT NULL ,
[Amount] money NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[OrderDetails]', RESEED, 4)
GO

-- ----------------------------
-- Records of OrderDetails
-- ----------------------------
SET IDENTITY_INSERT [dbo].[OrderDetails] ON
GO
INSERT INTO [dbo].[OrderDetails] ([ID], [OrderID], [ProID], [Quantity], [Price], [Amount]) VALUES (N'1', N'1', N'1', N'2', N'1500000.0000', N'3000000.0000');
GO
INSERT INTO [dbo].[OrderDetails] ([ID], [OrderID], [ProID], [Quantity], [Price], [Amount]) VALUES (N'2', N'1', N'2', N'2', N'300000.0000', N'600000.0000');
GO
INSERT INTO [dbo].[OrderDetails] ([ID], [OrderID], [ProID], [Quantity], [Price], [Amount]) VALUES (N'3', N'2', N'1', N'1', N'1500000.0000', N'1500000.0000');
GO
INSERT INTO [dbo].[OrderDetails] ([ID], [OrderID], [ProID], [Quantity], [Price], [Amount]) VALUES (N'4', N'2', N'2', N'1', N'300000.0000', N'300000.0000');
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO

-- ----------------------------
-- Table structure for [dbo].[Orders]
-- ----------------------------
--DROP TABLE [dbo].[Orders]
GO
CREATE TABLE [dbo].[Orders] (
[OrderID] int NOT NULL IDENTITY(1,1) ,
[OrderDate] datetime NOT NULL ,
[UserID] int NOT NULL ,
[Total] money NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Orders]', RESEED, 2)
GO

-- ----------------------------
-- Records of Orders
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Orders] ON
GO
INSERT INTO [dbo].[Orders] ([OrderID], [OrderDate], [UserID], [Total]) VALUES (N'1', N'2014-03-14 00:00:00.000', N'5', N'3600000.0000');
GO
INSERT INTO [dbo].[Orders] ([OrderID], [OrderDate], [UserID], [Total]) VALUES (N'2', N'2014-03-14 00:00:00.000', N'5', N'1800000.0000');
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO

-- ----------------------------
-- Table structure for [dbo].[Products]
-- ----------------------------
--DROP TABLE [dbo].[Products]
GO
CREATE TABLE [dbo].[Products] (
[ProID] int NOT NULL IDENTITY(1,1) ,
[ProName] nvarchar(40) NOT NULL ,
[TinyDes] nvarchar(80) NOT NULL ,
[FullDes] ntext NOT NULL ,
[Price] money NOT NULL ,
[CatID] int NOT NULL ,
[Quantity] int NOT NULL DEFAULT ((0)) 
)


GO
DBCC CHECKIDENT(N'[dbo].[Products]', RESEED, 30)
GO

-- ----------------------------
-- Records of Products
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Products] ON
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'1', N'Freshwater Cultured Pearl', N'Freshwater Cultured Pearl, Citrine, Peridot & Amethyst Bracelet, 7.5"', N'<UL>
    <LI>Metal stamp: 14k </LI>
    <LI>Metal: yellow-gold</LI>
    <LI>Material Type: amethyst, citrine, gold, pearl, peridot</LI>
    <LI>Gem Type: citrine, peridot, amethyst</LI>
    <LI>Length: 7.5 inches</LI>
    <LI>Clasp Type: filigree-box</LI>
    <LI>Total metal weight: 0.6 Grams</LI>
</UL>
<STRONG>Pearl Information</STRONG><BR>
<UL>
    <LI>Pearl type: freshwater-cultured</LI>
</UL>
<STRONG>Packaging Information</STRONG><BR>
<UL>
    <LI>Package: Regal Blue Sueded-Cloth Pouch</LI>
</UL>', N'1500000.0000', N'6', N'83');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'2', N'Pink Sapphire Sterling Silver', N'14 1/2 Carat Created Pink Sapphire Sterling Silver Bracelet w/ Diamond Accents', N'<P><STRONG>Jewelry Information</STRONG></P>
<UL>
    <LI>Loại hàng: Hàng trong nước</LI>
</UL>
', N'300000.0000', N'6', N'64');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'3', N'Torrini KC241', N'Nhẫn kim cương - vẻ đẹp kiêu sa', N'<P>Không chỉ có kiểu dáng truyền thống chỉ có một hạt kim cương ở giữa, các nhà thiết kế đã tạo những những chiếc nhẫn vô cùng độc đáo và tinh tế. Tuy nhiên, giá của đồ trang sức này thì chỉ có dân chơi mới có thể kham được.</P>
<UL>
    <LI>Kiểu sản phẩm: Nhẫn nữ</LI>
    <LI>Loại đá: To paz</LI>
    <LI>Chất liệu: kim cương, nguyên liệu và công nghệ Italy...</LI>
    <LI>Đơn giá: 2,110,250 VND / Chiếc</LI>
</UL>
', N'1600000000.0000', N'6', N'86');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'4', N'Torrini KC242', N'tinh xảo và sang trọng', N'<P>Để sở hữu một chiếc nhẫn kim cương lấp lánh trên tay, bạn phải là người chịu chi và sành điệu.<BR>
Với sự kết hợp khéo léo và độc đáo giữa kim cương và Saphia, Ruby... những chiếc nhẫn càng trở nên giá trị.</P>
<UL>
    <LI>Kiểu sản phẩm: Nhẫn nam</LI>
    <LI>Loại đá: To paz</LI>
    <LI>Chất liệu: Vàng tây 24K, nguyên liệu và công nghệ Italy...</LI>
</UL>
', N'42000000.0000', N'6', N'63');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'5', N'Nokia 7610', N'Độ phân giải cao, màn hình màu, chụp ảnh xuất sắc.', N'<UL>
    <LI>Máy ảnh có độ phân giải 1 megapixel</LI>
    <LI>Màn hình 65.536 màu, rộng 2,1 inch, 176 X 208 pixel với đồ họa sắc nét, độ phân giải cao</LI>
    <LI>Quay phim video lên đến 10 phút với hình ảnh sắc nét hơn</LI>
    <LI>Kinh nghiệm đa phương tiện được tăng cường</LI>
    <LI>Streaming video &amp; âm thanh với RealOne Player (hỗ trợ các dạng thức MP3/AAC).</LI>
    <LI>Nâng cấp cho những đoạn phim cá nhân của bạn bằng các tính năng chỉnh sửa tự động thông minh</LI>
    <LI>In ảnh chất lượng cao từ nhà, văn phòng, kios và qua mạng</LI>
    <LI>Dễ dàng kết nối vớI máy PC để lưu trữ và chia sẻ (bằng cáp USB, PopPort, công nghệ Bluetooth)</LI>
    <LI>48 nhạc chuông đa âm sắc, True tones. Mạng GSM 900 / GSM 1800 / GSM 1900</LI>
    <LI>Kích thước 109 x 53 x 19 mm, 93 cc</LI>
    <LI>Trọng lượng 118 g</LI>
    <LI>Hiển thị: Loại TFT, 65.536 màu</LI>
    <LI>Kích cở: 176 x 208 pixels </LI>
</UL>
', N'2900000.0000', N'2', N'0');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'6', N'Áo thun nữ', N'Màu sắc tươi tắn, kiểu dáng trẻ trung', N'<UL>
    <LI>Loại hàng: Hàng trong nước</LI>
    <LI>Xuất xứ: Tp Hồ Chí Minh</LI>
</UL>
', N'180000.0000', N'4', N'62');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'7', N'Simen AP75', N'Thiết kế tinh xảo, hiện đại', N'<UL>
    <LI>Hình ảnh hoàn hảo, rõ nét ở mọi góc màn hình</LI>
    <LI>Giảm thiểu sự phản chiếu ánh sáng</LI>
    <LI>Menu hiển thị tiếng Việt</LI>
    <LI>Hệ thống hình ảnh thông minh</LI>
    <LI>Âm thanh Hifi Stereo mạnh mẽ</LI>
    <LI>Hệ thống âm lượng thông minh</LI>
    <LI>Bộ nhớ 100 chương trình</LI>
    <LI>Chọn kênh ưa thích</LI>
    <LI>Các kiểu sắp đặt sẵn hình ảnh / âm thanh</LI>
    <LI>Kích thước (rộng x cao x dày): 497 x 458 x 487mm</LI>
    <LI>Trọng lượng: 25kg</LI>
    <LI>Màu: vàng, xanh, bạc </LI>
</UL>
', N'2800000.0000', N'2', N'15');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'8', N'Áo bé trai', N'Hóm hỉnh dễ thương', N'<UL>
    <LI>Quần áo bé trai</LI>
    <LI>Loại hàng: Hàng trong nước</LI>
    <LI>Xuất xứ: Tp Hồ Chí Minh</LI>
</UL>
', N'270000.0000', N'4', N'74');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'9', N'Bông tai nạm hạt rubby', N'Trẻ trung và quý phái', N'<UL>
    <LI>Tên sản phẩm: Bông tai nạm hạt rubby</LI>
    <LI>Đóng nhãn hiệu: Torrini</LI>
    <LI>Nguồn gốc, xuất xứ: Italy</LI>
    <LI>Hình thức thanh toán: L/C T/T M/T CASH</LI>
    <LI>Thời gian giao hàng: trong vòng 3 ngày kể từ ngày mua</LI>
    <LI>Chất lượng/chứng chỉ: good</LI>
</UL>
', N'2400000.0000', N'6', N'43');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'10', N'Đầm dạ hội ánh kim', N'Đủ màu sắc - kiểu dáng', N'<UL>
    <LI>Màu sắc: Khuynh hướng ánh kim có thể thể hiện trên vàng, bạc, đỏ tía, xanh biển, vàng tím, trắng và đen.</LI>
    <LI>Một số biến tấu mang tính vui nhộn là vàng chanh, màu hoa vân anh và ngọc lam; trong đó hoàng kim và nhũ bạc khá phổ biến.</LI>
    <LI>Phong cách: Diềm đăng ten, rủ xuống theo chiều thẳng đứng, nhiều lớp, cổ chẻ sâu, eo chít cao tới ngực... được biến tấu tùy theo mỗi nhà thiết kế.</LI>
</UL>
', N'2800000.0000', N'4', N'80');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'11', N'Dây chuyền ánh bạc', N'Kiểu dáng mới lạ', N'<UL>
    <LI>Chất liệu chính: Bạc</LI>
    <LI>Màu sắc: Bạc</LI>
    <LI>Chất lượng: Mới</LI>
    <LI>Phí vận chuyển: Liên hệ</LI>
    <LI>Giá bán có thể thay đổi tùy theo trọng lượng và giá vàng của từng thời điểm.</LI>
</UL>
', N'250000.0000', N'6', N'88');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'12', N'Đồ bộ bé gái', N'Đủ màu sắc - kiểu dáng', N'<UL>
    <LI>Màu sắc: đỏ tía, xanh biển, vàng tím, trắng và đen.</LI>
    <LI>Xuất xứ: Tp. Hồ Chí Minh</LI>
    <LI>Chất liệu: cotton</LI>
    <LI>Loại hàng: hàng trong nước</LI>
</UL>
', N'120000.0000', N'4', N'61');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'13', N'Đầm dạ hội Xinh Xinh', N'Đơn giản nhưng quý phái', N'<P>Những đường cong tuyệt đẹp sẽ càng được phô bày khi diện các thiết kế này.</P>
<UL>
    <LI>Nét cắt táo bạo ở ngực giúp bạn gái thêm phần quyến rũ, ngay cả khi không có trang&nbsp; sức nào trên người.</LI>
    <LI>Đầm hai dây thật điệu đà với nơ xinh trước ngực nhưng trông bạn vẫn toát lên vẻ tinh nghịch và bụi bặm nhờ thiết kế đầm bí độc đáo cùng sắc màu sẫm.</LI>
    <LI>Hãng sản xuất: NEM</LI>
    <LI>Kích cỡ : Tất cả các kích cỡ</LI>
    <LI>Kiểu dáng : Quây/Ống</LI>
    <LI>Chất liệu : Satin</LI>
    <LI>Màu : đen, đỏ</LI>
    <LI>Xuất xứ : Việt Nam</LI>
</UL>
', N'2600000.0000', N'4', N'92');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'14', N'Đầm dạ hội NEM', N'Táo bạo và quyến rũ', N'<P>Những đường cong tuyệt đẹp sẽ càng được phô bày khi diện các thiết kế này.</P>
<UL>
    <LI>Nét cắt táo bạo ở ngực giúp bạn gái thêm phần quyến rũ, ngay cả khi không có trang&nbsp; sức nào trên người.</LI>
    <LI>Đầm hai dây thật điệu đà với nơ xinh trước ngực nhưng trông bạn vẫn toát lên vẻ tinh nghịch và bụi bặm nhờ thiết kế đầm bí độc đáo cùng sắc màu sẫm.</LI>
    <LI>Hãng sản xuất: NEM</LI>
    <LI>Kích cỡ : Tất cả các kích cỡ</LI>
    <LI>Kiểu dáng : Quây/Ống</LI>
    <LI>Chất liệu : Satin</LI>
    <LI>Màu : đen, đỏ</LI>
    <LI>Xuất xứ : Việt Nam</LI>
</UL>
', N'1200000.0000', N'4', N'0');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'15', N'Dây chuyền đá quý', N'Kết hợp vàng trắng và đá quý', N'<UL>
    <LI>Kiểu sản phẩm: Dây chuyền</LI>
    <LI>Chất liệu: Vàng trắng 14K và đá quý, nguyên liệu và công nghệ Italy...</LI>
    <LI>Trọng lượng chất liệu: 1.1 Chỉ </LI>
</UL>
', N'1925000.0000', N'6', N'22');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'16', N'Nokia N72', N'Sành điệu cùng N72', N'<UL>
    <LI>Camera mega pixel : 2 mega pixel</LI>
    <LI>Bộ nhớ trong : 16 - 31 mb</LI>
    <LI>Chức năng : quay phim, ghi âm, nghe đài FM</LI>
    <LI>Hỗ trợ: Bluetooth, thẻ nhớ ngoài, nhạc MP3 &lt;br/&gt;</LI>
    <LI>Trọng lượng (g) : 124g</LI>
    <LI>Kích thước (mm) : 109 x 53 x 21.8 mm</LI>
    <LI>Ngôn ngữ : Có tiếng việt</LI>
    <LI>Hệ điều hành: Symbian OS 8.1</LI>
</UL>
', N'3200000.0000', N'2', N'81');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'17', N'Mặt dây chuyền Ruby', N'Toả sáng cùng Ruby', N'<UL>
    <LI>Kiểu sản phẩm:&nbsp; Mặt dây</LI>
    <LI>Chất liệu: Vàng trắng 14K, nguyên liệu và công nghệ Italy...</LI>
    <LI>Trọng lượng chất liệu: 0.32 Chỉ</LI>
</UL>
', N'1820000.0000', N'6', N'33');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'18', N'1/2 Carat Pink Sapphire Silver', N'Created Pink Sapphire', N'<UL>
    <LI>Brand Name: Ice.com</LI>
    <LI>Material Type: sterling-silver, created-sapphire, diamond</LI>
    <LI>Gem Type: created-sapphire, Diamond</LI>
    <LI>Minimum total gem weight: 14.47 carats</LI>
    <LI>Total metal weight: 15 Grams</LI>
    <LI>Number of stones: 28</LI>
    <LI>Created-sapphire Information</LI>
    <LI>Minimum color: Not Available</LI>
</UL>
', N'3400000.0000', N'6', N'10');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'19', N'Netaya', N'Dây chuyền vàng trắng', N'<UL>
    <LI>Kiểu sản phẩm:&nbsp; Dây chuyền</LI>
    <LI>Chất liệu: Vàng tây 18K, nguyên liệu và công nghệ Italy...</LI>
    <LI>Trọng lượng chất liệu: 1 Chỉ</LI>
</UL>
', N'1820000.0000', N'6', N'17');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'20', N'Giày nam GN16', N'Êm - đẹp - bền', N'<UL>
    <LI>Loại hàng: Hàng trong nước</LI>
    <LI>Xuất xứ: Tp Hồ Chí Minh</LI>
    <LI>Giá: 300 000 VNĐ</LI>
</UL>
', N'540000.0000', N'4', N'0');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'21', N'G3.370A', N'Đen bóng, sang trọng', N'<UL>
    <LI>Loại hàng: Hàng trong nước</LI>
    <LI>Xuất xứ: Tp Hồ Chí Minh</LI>
</UL>
', N'300000.0000', N'4', N'74');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'22', N'Giày nữ GN1', N'Kiểu dáng thanh thoát', N'<UL>
    <LI>Loại hàng: Hàng trong nước</LI>
    <LI>Xuất xứ: Tp Hồ Chí Minh</LI>
</UL>
', N'290000.0000', N'4', N'30');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'23', N'NV002', N'Kiểu dáng độc đáo', N'<P><STRONG>Thông tin sản phẩm</STRONG></P>
<UL>
    <LI>Mã sản phẩm: NV002</LI>
    <LI>Trọng lượng: 2 chỉ</LI>
    <LI>Vật liệu chính: Vàng 24K</LI>
</UL>
', N'3600000.0000', N'6', N'5');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'24', N'NV009', N'Sáng chói - mới lạ', N'<P><STRONG>Thông tin sản phẩm</STRONG></P>
<UL>
    <LI>Mã sản phẩm: NV005</LI>
    <LI>Trọng lượng: 1 cây</LI>
    <LI>Vật liệu chính: Vàng 24K</LI>
</UL>
', N'14900000.0000', N'6', N'22');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'25', N'CK010', N'Độc đáo, sang trọng', N'<UL>
    <LI>Kiểu dáng nam tính và độc đáo, những thiết kế dưới đây đáp ứng được mọi yêu cần khó tính nhất của người sở hữu.</LI>
    <LI>Những hạt kim cương sẽ giúp người đeo nó tăng thêm phần sành điệu</LI>
    <LI>Không chỉ có kiểu dáng truyền thống chỉ có một hạt kim cương ở giữa, các nhà thiết kế đã tạo những những chiếc nhẫn vô cùng độc đáo và tinh tế.</LI>
    <LI>Tuy nhiên, giá của đồ trang sức này thì chỉ có dân chơi mới có thể kham được</LI>
</UL>
', N'2400000000.0000', N'6', N'52');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'26', N'CK009', N'Nữ tính - đầy quí phái', N'<UL>
    <LI>Để sở hữu một chiếc nhẫn kim cương lấp lánh trên tay, bạn phải là người chịu chi và sành điệu.</LI>
    <LI>Với sự kết hợp khéo léo và độc đáo giữa kim cương và Saphia, Ruby... những chiếc nhẫn càng trở nên giá trị</LI>
    <LI>Nhà sản xuất: Torrini</LI>
</UL>
<P>Cái này rất phù hợp cho bạn khi tặng nàng</P>
', N'1850000000.0000', N'6', N'11');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'27', N'CK007', N'Sự kết hợp khéo léo, độc đáo', N'<UL>
    <LI>Để sở hữu một chiếc nhẫn kim cương lấp lánh trên tay, bạn phải là người chịu chi và sành điệu.</LI>
    <LI>Với sự kết hợp khéo léo và độc đáo giữa kim cương và Saphia, Ruby... những chiếc nhẫn càng trở nên giá trị</LI>
    <LI>Nhà sản xuất: Torrini</LI>
</UL>
<P>Cái này rất phù hợp cho bạn khi tặng nàng</P>
', N'3100000000.0000', N'6', N'28');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'28', N'CK005', N'Tinh xảo - sang trọng', N'<UL>
    <LI>Kim cương luôn là đồ trang sức thể hiện đẳng cấp của người sử dụng.</LI>
    <LI>Không phải nói nhiều về những kiểu nhẫn dưới đây, chỉ có thể gói gọn trong cụm từ: tinh xảo và sang trọng</LI>
    <LI>Thông tin nhà sản xuất: Torrini</LI>
    <LI>Thông tin chi tiết: Cái này rất phù hợp cho bạn khi tặng nàng</LI>
</UL>
', N'1800000000.0000', N'6', N'29');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'29', N'NV01TT', N'Tinh tế đến không ngờ', N'<UL>
    <LI>Tinh xảo và sang trọng</LI>
    <LI>Thông tin nhà sản xuất: Torrini</LI>
    <LI>Không chỉ có kiểu dáng truyền thống chỉ có một hạt kim cương ở giữa, các nhà thiết kế đã tạo những những chiếc nhẫn vô cùng độc đáo và tinh tế.</LI>
    <LI>Tuy nhiên, giá của đồ trang sức này thì chỉ có dân chơi mới có thể kham được</LI>
</UL>
', N'500000000.0000', N'6', N'49');
GO
INSERT INTO [dbo].[Products] ([ProID], [ProName], [TinyDes], [FullDes], [Price], [CatID], [Quantity]) VALUES (N'30', N'Motorola W377', N'Nữ tính - trẻ trung', N'<UL>
    <LI>General: 2G Network, GSM 900 / 1800 / 1900</LI>
    <LI>Size:&nbsp; 99 x 45 x 18.6 mm, 73 cc</LI>
    <LI>Weight: 95 g</LI>
    <LI>Display: type TFT, 65K colors</LI>
    <LI>Size: 128 x 160 pixels, 28 x 35 mm</LI>
</UL>
', N'2400000.0000', N'2', N'0');
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO

-- ----------------------------
-- Table structure for [dbo].[Users]
-- ----------------------------
--DROP TABLE [dbo].[Users]
GO
CREATE TABLE [dbo].[Users] (
[f_ID] int NOT NULL IDENTITY(1,1) ,
[f_Username] nvarchar(50) NOT NULL ,
[f_Password] nvarchar(255) NOT NULL ,
[f_Name] nvarchar(50) NOT NULL ,
[f_Email] nvarchar(50) NOT NULL ,
[f_DOB] datetime NOT NULL ,
[f_Permission] int NOT NULL DEFAULT ((0)) 
)


GO
DBCC CHECKIDENT(N'[dbo].[Users]', RESEED, 9)
GO

-- ----------------------------
-- Records of Users
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_Username], [f_Password], [f_Name], [f_Email], [f_DOB], [f_Permission]) VALUES (N'5', N'nndkhoa', N'E0308DA5BBE8279ADC296567334D429B', N'Khoa N. D. Ngô', N'nndkhoa@a.c', N'2014-02-26 00:00:00.000', N'0');
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_Username], [f_Password], [f_Name], [f_Email], [f_DOB], [f_Permission]) VALUES (N'6', N'tdquang', N'BABA9830D1E5DEAE4954C1364B536D66', N'Trần Duy Quang', N'tdquang@a.c', N'2014-02-18 00:00:00.000', N'0');
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_Username], [f_Password], [f_Name], [f_Email], [f_DOB], [f_Permission]) VALUES (N'8', N'abc', N'E10ADC3949BA59ABBE56E057F20F883E', N'abc', N'abc@a.c', N'2014-03-07 00:00:00.000', N'0');
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_Username], [f_Password], [f_Name], [f_Email], [f_DOB], [f_Permission]) VALUES (N'9', N'admin', N'0192023A7BBD73250516F069DF18B500', N'Admin', N'admin@g.c', N'2014-03-19 00:00:00.000', N'1');
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

-- ----------------------------
-- Indexes structure for table Categories
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [dbo].[Categories]
-- ----------------------------
ALTER TABLE [dbo].[Categories] ADD PRIMARY KEY ([CatID])
GO

-- ----------------------------
-- Indexes structure for table OrderDetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [dbo].[OrderDetails]
-- ----------------------------
ALTER TABLE [dbo].[OrderDetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Orders
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [dbo].[Orders]
-- ----------------------------
ALTER TABLE [dbo].[Orders] ADD PRIMARY KEY ([OrderID])
GO

-- ----------------------------
-- Indexes structure for table Products
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [dbo].[Products]
-- ----------------------------
ALTER TABLE [dbo].[Products] ADD PRIMARY KEY ([ProID])
GO

-- ----------------------------
-- Indexes structure for table Users
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [dbo].[Users]
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD PRIMARY KEY ([f_ID])
GO
