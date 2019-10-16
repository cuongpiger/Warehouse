create database QLHV2222
go
use QLHV2222
go
CREATE TABLE [dbo].[Subject](
	[ID] [nchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Credits] [int] NULL,
	[evaluation] [nvarchar](50) NULL,
	[evaluation1] [varchar](20) NULL,
 CONSTRAINT [PK_MONHOC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET QUOTED_IDENTIFIER ON
GO
GO
CREATE TABLE [dbo].[Course](
	[TeacherID] [nchar](10) NOT NULL,
	[SubjectID] [nchar](10) NOT NULL,
	[ClassID] [nchar](10) NOT NULL,
 CONSTRAINT [PK_PHANCONG] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC,
	[SubjectID] ASC,
	[ClassID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Result](
	[StudentID] [nchar](10) NOT NULL,
	[SubjectID] [nchar](10) NOT NULL,
	[Times] [int] NOT NULL,
	[Mark] [float] NULL,
 CONSTRAINT [PK_KETQUA] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[SubjectID] ASC,
	[Times] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ability](
	[TeacherID] [nchar](10) NOT NULL,
	[SubjectID] [nchar](10) NOT NULL,
	[Seniority] [int] NULL,
	[NumofCours] [int] NULL,
 CONSTRAINT [PK_GIAOVIEN_DAY_MONHOC] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC,
	[SubjectID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [nchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[ClassID] [nchar](10) NULL,
	[evaluation] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ID] [nchar](10) NOT NULL,
	[NumofStude] [int] NULL,
	[Perfect] [nchar](10) NULL,
	[ManagerID] [nchar](10) NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL,
 CONSTRAINT [PK_LOPHOC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [nchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Address] [nvarchar](10) NULL,
	[Phone] [nchar](10) NULL,
	[ManagerID] [nchar](10) NULL,
	[evaluation] [nvarchar](50) NULL,
 CONSTRAINT [PK_GIAOVIEN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]




-- `dbo.Teacher`
INSERT dbo.Teacher VALUES ('GV00001   ',N'Nguyễn Văn An', '1981-01-02 00:00:00.000', N'Nam', NULL, 'GV00002   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00002   ',N'Nguyễn Thị Như Lan', '1984-12-02 00:00:00.000', N'Nữ', NULL, 'GV00005   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00003   ', N'Trần Minh Anh', '1986-03-23 00:00:00.000', N'Nam', '0909123999', 'GV00002   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00004   ', N'Trương Tường Vi', '1988-02-01 00:00:00.000', N'Nữ', '0998990909', 'GV00005   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00005   ', N'Hà Anh Tuấn', '1986-12-03 00:00:00.000', N'Nam', '0909909000', 'GV00008   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00006   ', N'Trần Anh Dũng', '1979-04-04 00:00:00.000', N'Nam', NULL, 'GV00010   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00007   ', N'Trần Duy Tân', '1978-01-04 00:00:00.000', N'Nam', NULL, 'GV00002   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00008   ', N'Nguyễn Thị Linh', '1979-07-08 00:00:00.000', N'Nữ', '0938079700', 'GV00005   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00009   ', N'Trần Thị Kiều', '1977-01-03 00:00:00.000', N'Nữ', NULL, 'GV00005   ', N'Không Đạt')
INSERT dbo.Teacher VALUES ('GV00010   ', N'Trần Phương Loan', '1978-04-30 00:00:00.000', N'Nữ', NULL, 'GV00005   ', N'Không Đạt')
GO

-- `dbo.Subject`
INSERT dbo.Subject VALUES ('MH00001   ', N'Cơ sở dữ liệu', 20, N'Không Đạt', NULL)
INSERT dbo.Subject VALUES ('MH00002   ', N'Cấu trúc dữ liệu', 6, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00003   ', N'Mạng máy tính', 4, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00004   ', N'Toán cao cấp', 6, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00005   ', N'Tin học cơ sở', 3, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00006   ', N'Công nghệ phân mềm', 4, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00007   ', N'Trí tuệ nhân tạo', 4, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00008   ', N'Khai thác dữ liệu', 3, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00009   ', N'Phân tích thiết kế hệ thống thông tin', 4, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00010   ', N'Hệ thống thông minh', 4, NULL, NULL)
INSERT dbo.Subject VALUES ('MH00013   ', N'He', 4, NULL, NULL)
GO

-- `dbo.Student`
INSERT dbo.Student VALUES ('HV000001  ', N'Nguyễn Thùy Linh', '1990-02-01 00:00:00.000', N'buộc thôi học', 'LH000001  ', N'Không Đạt')
INSERT dbo.Student VALUES ('HV000002  ', N'Nguyễn Thị Kiề Trang', '1993-12-20 00:00:00.000', N'buộc thôi học', 'LH000001  ', N'Không Đạt')
INSERT dbo.Student VALUES ('HV000003  ', N'Nguyễn Xuân Thu', '1994-12-30 00:00:00.000', N'đang học', 'LH000002  ', N'Khá')
INSERT dbo.Student VALUES ('HV000004  ', N'Trần Trung Chính', '1992-03-12 00:00:00.000', N'đang học', 'LH000003  ', N'Khá')
INSERT dbo.Student VALUES ('HV000005  ', N'Trần Minh An', '1991-12-03 00:00:00.000', N'đang học', 'LH000003  ', N'Khá')
INSERT dbo.Student VALUES ('HV000006  ', N'Trương Mỹ Linh', '1989-12-12 00:00:00.000', N'đã tốt nghiệp', 'LH000004  ', N'Khá')
INSERT dbo.Student VALUES ('HV000007  ', N'Trần Hào', '1989-02-02 00:00:00.000', N'đã tốt nghiệp', 'LH000004  ', N'Khá')
INSERT dbo.Student VALUES ('HV000008  ', N'Nguyễn Huỳnh', '1992-03-03 00:00:00.000', N'đang học', 'LH000004  ', N'Khá')
INSERT dbo.Student VALUES ('HV000009  ', N'Nguyễn Xuân Trường', '1993-03-13 00:00:00.000', N'đang học', 'LH000005  ', N'Khá')
INSERT dbo.Student VALUES ('HV000010  ', N'Nguyễn Bình Minh', '1992-03-12 00:00:00.000', N'đang học', 'LH000004  ', N'Khá')
INSERT dbo.Student VALUES ('HV000011  ', N'Nguyễn', '1945-03-12 00:00:00.000', NULL, NULL, NULL)
INSERT dbo.Student VALUES ('HV000012  ', N'Nguyễn', '1945-03-12 00:00:00.000', NULL, NULL, NULL)
GO

-- `dbo.Result`
INSERT dbo.Result VALUES ('HV000001  ', 'MH00001   ', 1, 8)
INSERT dbo.Result VALUES ('HV000001  ', 'MH00001   ', 2, 10)
INSERT dbo.Result VALUES ('HV000001  ', 'MH00004   ', 1, 6)
INSERT dbo.Result VALUES ('HV000001  ', 'MH00005   ', 1, NULL)
INSERT dbo.Result VALUES ('HV000001  ', 'MH00009   ', 1, 9)
INSERT dbo.Result VALUES ('HV000001  ', 'MH00009   ', 2, 9)
INSERT dbo.Result VALUES ('HV000002  ', 'MH00001   ', 1, 7)
INSERT dbo.Result VALUES ('HV000002  ', 'MH00004   ', 1, 8)
INSERT dbo.Result VALUES ('HV000003  ', 'MH00008   ', 1, 8.7)
INSERT dbo.Result VALUES ('HV000003  ', 'MH00009   ', 1, 9)
INSERT dbo.Result VALUES ('HV000003  ', 'MH00010   ', 1, 10)
INSERT dbo.Result VALUES ('HV000004  ', 'MH00008   ', 1, 4)
INSERT dbo.Result VALUES ('HV000004  ', 'MH00008   ', 2, 3)
INSERT dbo.Result VALUES ('HV000004  ', 'MH00009   ', 1, 2)
INSERT dbo.Result VALUES ('HV000004  ', 'MH00009   ', 2, 5)
INSERT dbo.Result VALUES ('HV000004  ', 'MH00010   ', 1, 6)
INSERT dbo.Result VALUES ('HV000005  ', 'MH00008   ', 1, 7.5)
INSERT dbo.Result VALUES ('HV000005  ', 'MH00009   ', 1, 1)
INSERT dbo.Result VALUES ('HV000005  ', 'MH00009   ', 2, 7)
INSERT dbo.Result VALUES ('HV000005  ', 'MH00010   ', 1, 1)
INSERT dbo.Result VALUES ('HV000005  ', 'MH00010   ', 2, 3.5)
GO

-- `dbo.Course`
INSERT dbo.Course VALUES ('GV00001   ', 'MH00004   ', 'LH000001  ')
INSERT dbo.Course VALUES ('GV00002   ', 'MH00001   ', 'LH000001  ')
INSERT dbo.Course VALUES ('GV00003   ', 'MH00010   ', 'LH000001  ')
INSERT dbo.Course VALUES ('GV00004   ', 'MH00009   ', 'LH000002  ')
INSERT dbo.Course VALUES ('GV00005   ', 'MH00008   ', 'LH000002  ')
INSERT dbo.Course VALUES ('GV00005   ', 'MH00008   ', 'LH000004  ')
INSERT dbo.Course VALUES ('GV00006   ', 'MH00008   ', 'LH000003  ')
INSERT dbo.Course VALUES ('GV00006   ', 'MH00009   ', 'LH000002  ')
INSERT dbo.Course VALUES ('GV00006   ', 'MH00009   ', 'LH000003  ')
INSERT dbo.Course VALUES ('GV00006   ', 'MH00010   ', 'LH000004  ')
INSERT dbo.Course VALUES ('GV00007   ', 'MH00010   ', 'LH000002  ')
INSERT dbo.Course VALUES ('GV00007   ', 'MH00010   ', 'LH000003  ')
INSERT dbo.Course VALUES ('GV00008   ', 'MH00002   ', 'LH000002  ')
GO

-- `dbo.Class`
INSERT dbo.Class VALUES ('LH000001  ', 1, 'HV000002  ', 'GV00005   ', 2010, 2014)
INSERT dbo.Class VALUES ('LH000002  ', 1, 'HV000003  ', 'GV00003   ', 2009, 2013)
INSERT dbo.Class VALUES ('LH000003  ', 2, 'HV000004  ', 'GV00005   ', 2010, 2014)
INSERT dbo.Class VALUES ('LH000004  ', 4, 'HV000008  ', 'GV00010   ', 2011, 2015)
INSERT dbo.Class VALUES ('LH000005  ', 1, 'HV000009  ', 'GV00005   ', 2010, 2014)
GO

-- `dbo.Ability`
INSERT dbo.Ability VALUES ('GV00001   ', 'MH00001   ', 3, NULL)
INSERT dbo.Ability VALUES ('GV00001   ', 'MH00004   ', 2, NULL)
INSERT dbo.Ability VALUES ('GV00002   ', 'MH00001   ', 1, NULL)
INSERT dbo.Ability VALUES ('GV00002   ', 'MH00002   ', 1, NULL)
INSERT dbo.Ability VALUES ('GV00003   ', 'MH00006   ', 2, NULL)
INSERT dbo.Ability VALUES ('GV00003   ', 'MH00007   ', 3, NULL)
INSERT dbo.Ability VALUES ('GV00003   ', 'MH00010   ', 4, NULL)
INSERT dbo.Ability VALUES ('GV00004   ', 'MH00009   ', 6, NULL)
INSERT dbo.Ability VALUES ('GV00004   ', 'MH00010   ', 1, NULL)
INSERT dbo.Ability VALUES ('GV00005   ', 'MH00008   ', 4, NULL)
INSERT dbo.Ability VALUES ('GV00005   ', 'MH00010   ', 2, NULL)
INSERT dbo.Ability VALUES ('GV00006   ', 'MH00008   ', 4, NULL)
INSERT dbo.Ability VALUES ('GV00006   ', 'MH00009   ', 2, NULL)
INSERT dbo.Ability VALUES ('GV00006   ', 'MH00010   ', 4, NULL)
INSERT dbo.Ability VALUES ('GV00008   ', 'MH00001   ', 2, NULL)
INSERT dbo.Ability VALUES ('GV00008   ', 'MH00002   ', 1, NULL)
INSERT dbo.Ability VALUES ('GV00009   ', 'MH00010   ', 2, NULL)
INSERT dbo.Ability VALUES ('GV00010   ', 'MH00001   ', 3, NULL)
INSERT dbo.Ability VALUES ('GV00010   ', 'MH00002   ', 1, NULL)
GO
