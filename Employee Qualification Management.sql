
USE [EmployeeQualification]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/30/2017 1:44:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[BirthDate] [date] NOT NULL,
	[Email] [varchar](50) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeQualification]    Script Date: 6/30/2017 1:44:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeQualification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[QualificationId] [int] NOT NULL,
	[Institution] [nvarchar](250) NOT NULL,
	[City] [nvarchar](250) NULL,
	[ValidFrom] [date] NULL,
	[ValidTo] [date] NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeQualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 6/30/2017 1:44:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Code] [nvarchar](100) NULL,
 CONSTRAINT [PK_QualificationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (1, N'First Name 1', N'MI1', N'Last Name 1', N'Male', CAST(N'1990-01-01' AS Date), N'email1@gosei.com.vn', N'Test Note 1')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (2, N'First Name 2', N'MI2', N'Last Name 2', N'Female', CAST(N'1990-01-02' AS Date), N'email2@gosei.com.vn', N'Test Note 2')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (3, N'First Name 3', N'MI3', N'Last Name 3', N'Male', CAST(N'1990-01-03' AS Date), N'email3@gosei.com.vn', N'Test Note 3')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (4, N'First Name 4', N'MI4', N'Last Name 4', N'Male', CAST(N'1990-01-04' AS Date), N'email4@gosei.com.vn', N'Test Note 4')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (5, N'First Name 5', N'MI5', N'Last Name 5', N'Male', CAST(N'1990-01-05' AS Date), N'email5@gosei.com.vn', N'Test Note 5')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (6, N'First Name 6', N'MI6', N'Last Name 6', N'Male', CAST(N'1990-01-06' AS Date), N'email6@gosei.com.vn', N'Test Note 6')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (7, N'First Name 7', N'MI7', N'Last Name 7', N'Male', CAST(N'1990-01-07' AS Date), N'email7@gosei.com.vn', N'Test Note 7')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (8, N'First Name 8', N'MI8', N'Last Name 8', N'Female', CAST(N'1990-01-08' AS Date), N'email8@gosei.com.vn', N'Test Note 8')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (9, N'First Name 9', N'MI9', N'Last Name 9', N'Female', CAST(N'1990-01-09' AS Date), N'email9@gosei.com.vn', N'Test Note 9')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (10, N'First Name 10', N'MI10', N'Last Name 10', N'Male', CAST(N'1990-01-10' AS Date), N'email10@gosei.com.vn', N'Test Note 10')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (11, N'First Name 11', N'MI11', N'Last Name 11', N'Male', CAST(N'1990-01-11' AS Date), N'email11@gosei.com.vn', N'Test Note 11')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (12, N'First Name 12', N'MI12', N'Last Name 12', N'Male', CAST(N'1990-01-12' AS Date), N'email12@gosei.com.vn', N'Test Note 12')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (13, N'First Name 13', N'MI13', N'Last Name 13', N'Female', CAST(N'1990-01-13' AS Date), N'email13@gosei.com.vn', N'Test Note 13')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (14, N'First Name 14', N'MI14', N'Last Name 14', N'Female', CAST(N'1990-01-14' AS Date), N'email14@gosei.com.vn', N'Test Note 14')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (15, N'First Name 15', N'MI15', N'Last Name 15', N'Male', CAST(N'1990-01-15' AS Date), N'email15@gosei.com.vn', N'Test Note 15')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (16, N'First Name 16', N'MI16', N'Last Name 16', N'Male', CAST(N'1990-01-16' AS Date), N'email16@gosei.com.vn', N'Test Note 16')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (17, N'First Name 17', N'MI17', N'Last Name 17', N'Female', CAST(N'1990-01-17' AS Date), N'email17@gosei.com.vn', N'Test Note 17')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (18, N'First Name 18', N'MI18', N'Last Name 18', N'Male', CAST(N'1990-01-18' AS Date), N'email18@gosei.com.vn', N'Test Note 18')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (19, N'First Name 19', N'MI19', N'Last Name 19', N'Male', CAST(N'1990-01-19' AS Date), N'email19@gosei.com.vn', N'Test Note 19')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (20, N'First Name 20', N'MI20', N'Last Name 20', N'Male', CAST(N'1990-01-20' AS Date), N'email20@gosei.com.vn', N'Test Note 20')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (21, N'First Name 21', N'MI21', N'Last Name 21', N'Male', CAST(N'1990-01-21' AS Date), N'email21@gosei.com.vn', N'Test Note 21')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (22, N'First Name 22', N'MI22', N'Last Name 22', N'Female', CAST(N'1990-01-22' AS Date), N'email22@gosei.com.vn', N'Test Note 22')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (24, N'First Name 24', N'MI24', N'Last Name 24', N'Male', CAST(N'1990-01-24' AS Date), N'email24@gosei.com.vn', N'Test Note 24')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (25, N'First Name 25', N'MI25', N'Last Name 25', N'Male', CAST(N'1990-01-25' AS Date), N'email25@gosei.com.vn', N'Test Note 25')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (26, N'First Name 26', N'MI26', N'Last Name 26', N'Female', CAST(N'1990-01-26' AS Date), N'email26@gosei.com.vn', N'Test Note 26')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (27, N'First Name 27', N'MI27', N'Last Name 27', N'Male', CAST(N'1990-01-27' AS Date), N'email27@gosei.com.vn', N'Test Note 27')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (28, N'First Name 28', N'MI28', N'Last Name 28', N'Male', CAST(N'1990-01-28' AS Date), N'email28@gosei.com.vn', N'Test Note 28')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (29, N'First Name 29', N'MI29', N'Last Name 29', N'Male', CAST(N'1990-01-29' AS Date), N'email29@gosei.com.vn', N'Test Note 29')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (30, N'First Name 30', N'MI30', N'Last Name 30', N'Female', CAST(N'1990-01-30' AS Date), N'email30@gosei.com.vn', N'Test Note 30')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (31, N'First Name 31', N'MI31', N'Last Name 31', N'Male', CAST(N'1990-01-31' AS Date), N'email31@gosei.com.vn', N'Test Note 31')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (32, N'First Name 32', N'MI32', N'Last Name 32', N'Male', CAST(N'1990-02-01' AS Date), N'email32@gosei.com.vn', N'Test Note 32')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (33, N'First Name 33', N'MI33', N'Last Name 33', N'Male', CAST(N'1990-02-02' AS Date), N'email33@gosei.com.vn', N'Test Note 33')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (34, N'First Name 34', N'MI34', N'Last Name 34', N'Female', CAST(N'1990-02-03' AS Date), N'email34@gosei.com.vn', N'Test Note 34')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (35, N'First Name 35', N'MI35', N'Last Name 35', N'Male', CAST(N'1990-02-04' AS Date), N'email35@gosei.com.vn', N'Test Note 35')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (36, N'First Name 36', N'MI36', N'Last Name 36', N'Male', CAST(N'1990-02-05' AS Date), N'email36@gosei.com.vn', N'Test Note 36')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (37, N'First Name 37', N'MI37', N'Last Name 37', N'Female', CAST(N'1990-02-06' AS Date), N'email37@gosei.com.vn', N'Test Note 37')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (38, N'First Name 38', N'MI38', N'Last Name 38', N'Male', CAST(N'1990-02-07' AS Date), N'email38@gosei.com.vn', N'Test Note 38')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (39, N'First Name 39', N'MI39', N'Last Name 39', N'Male', CAST(N'1990-02-08' AS Date), N'email39@gosei.com.vn', N'Test Note 39')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (40, N'First Name 40', N'MI40', N'Last Name 40', N'Male', CAST(N'1990-02-09' AS Date), N'email40@gosei.com.vn', N'Test Note 40')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (41, N'First Name 41', N'MI41', N'Last Name 41', N'Female', CAST(N'1990-02-10' AS Date), N'email41@gosei.com.vn', N'Test Note 41')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (42, N'First Name 42', N'MI42', N'Last Name 42', N'Male', CAST(N'1990-02-11' AS Date), N'email42@gosei.com.vn', N'Test Note 42')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (43, N'First Name 43', N'MI43', N'Last Name 43', N'Male', CAST(N'1990-02-12' AS Date), N'email43@gosei.com.vn', N'Test Note 43')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (44, N'First Name 44', N'MI44', N'Last Name 44', N'Male', CAST(N'1990-02-13' AS Date), N'email44@gosei.com.vn', N'Test Note 44')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (45, N'First Name 45', N'MI45', N'Last Name 45', N'Female', CAST(N'1990-02-14' AS Date), N'email45@gosei.com.vn', N'Test Note 45')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (46, N'First Name 46', N'MI46', N'Last Name 46', N'Male', CAST(N'1990-02-15' AS Date), N'email46@gosei.com.vn', N'Test Note 46')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (47, N'First Name 47', N'MI47', N'Last Name 47', N'Male', CAST(N'1990-02-16' AS Date), N'email47@gosei.com.vn', N'Test Note 47')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (48, N'First Name 48', N'MI48', N'Last Name 48', N'Male', CAST(N'1990-02-17' AS Date), N'email48@gosei.com.vn', N'Test Note 48')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (49, N'First Name 49', N'MI49', N'Last Name 49', N'Male', CAST(N'1990-02-18' AS Date), N'email49@gosei.com.vn', N'Test Note 49')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (50, N'First Name 50', N'MI50', N'Last Name 50', N'Female', CAST(N'1990-02-19' AS Date), N'email50@gosei.com.vn', N'Test Note 50')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (51, N'First Name 51', N'MI51', N'Last Name 51', N'Male', CAST(N'1990-02-20' AS Date), N'email51@gosei.com.vn', N'Test Note 51')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (52, N'First Name 52', N'MI52', N'Last Name 52', N'Male', CAST(N'1990-02-21' AS Date), N'email52@gosei.com.vn', N'Test Note 52')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (53, N'First Name 53', N'MI53', N'Last Name 53', N'Female', CAST(N'1990-02-22' AS Date), N'email53@gosei.com.vn', N'Test Note 53')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (54, N'First Name 54', N'MI54', N'Last Name 54', N'Male', CAST(N'1990-02-23' AS Date), N'email54@gosei.com.vn', N'Test Note 54')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (55, N'First Name 55', N'MI55', N'Last Name 55', N'Female', CAST(N'1990-02-24' AS Date), N'email55@gosei.com.vn', N'Test Note 55')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (56, N'First Name 56', N'MI56', N'Last Name 56', N'Female', CAST(N'1990-02-25' AS Date), N'email56@gosei.com.vn', N'Test Note 56')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (57, N'First Name 57', N'MI57', N'Last Name 57', N'Male', CAST(N'1990-02-26' AS Date), N'email57@gosei.com.vn', N'Test Note 57')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (58, N'First Name 58', N'MI58', N'Last Name 58', N'Male', CAST(N'1990-02-27' AS Date), N'email58@gosei.com.vn', N'Test Note 58')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (59, N'First Name 59', N'MI59', N'Last Name 59', N'Female', CAST(N'1990-02-28' AS Date), N'email59@gosei.com.vn', N'Test Note 59')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (60, N'First Name 60', N'MI60', N'Last Name 60', N'Male', CAST(N'1990-03-01' AS Date), N'email60@gosei.com.vn', N'Test Note 60')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (61, N'First Name 61', N'MI61', N'Last Name 61', N'Male', CAST(N'1990-03-02' AS Date), N'email61@gosei.com.vn', N'Test Note 61')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (62, N'First Name 62', N'MI62', N'Last Name 62', N'Male', CAST(N'1990-03-03' AS Date), N'email62@gosei.com.vn', N'Test Note 62')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (63, N'First Name 63', N'MI63', N'Last Name 63', N'Female', CAST(N'1990-03-04' AS Date), N'email63@gosei.com.vn', N'Test Note 63')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (64, N'First Name 64', N'MI64', N'Last Name 64', N'Male', CAST(N'1990-03-05' AS Date), N'email64@gosei.com.vn', N'Test Note 64')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (65, N'First Name 65', N'MI65', N'Last Name 65', N'Male', CAST(N'1990-03-06' AS Date), N'email65@gosei.com.vn', N'Test Note 65')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (66, N'First Name 66', N'MI66', N'Last Name 66', N'Male', CAST(N'1990-03-07' AS Date), N'email66@gosei.com.vn', N'Test Note 66')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (67, N'First Name 67', N'MI67', N'Last Name 67', N'Male', CAST(N'1990-03-08' AS Date), N'email67@gosei.com.vn', N'Test Note 67')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (68, N'First Name 68', N'MI68', N'Last Name 68', N'Female', CAST(N'1990-03-09' AS Date), N'email68@gosei.com.vn', N'Test Note 68')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (69, N'First Name 69', N'MI69', N'Last Name 69', N'Male', CAST(N'1990-03-10' AS Date), N'email69@gosei.com.vn', N'Test Note 69')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (70, N'First Name 70', N'MI70', N'Last Name 70', N'Male', CAST(N'1990-03-11' AS Date), N'email70@gosei.com.vn', N'Test Note 70')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (71, N'First Name 71', N'MI71', N'Last Name 71', N'Male', CAST(N'1990-03-12' AS Date), N'email71@gosei.com.vn', N'Test Note 71')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (72, N'First Name 72', N'MI72', N'Last Name 72', N'Female', CAST(N'1990-03-13' AS Date), N'email72@gosei.com.vn', N'Test Note 72')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (73, N'First Name 73', N'MI73', N'Last Name 73', N'Female', CAST(N'1990-03-14' AS Date), N'email73@gosei.com.vn', N'Test Note 73')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (74, N'First Name 74', N'MI74', N'Last Name 74', N'Male', CAST(N'1990-03-15' AS Date), N'email74@gosei.com.vn', N'Test Note 74')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (75, N'First Name 75', N'MI75', N'Last Name 75', N'Male', CAST(N'1990-03-16' AS Date), N'email75@gosei.com.vn', N'Test Note 75')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (76, N'First Name 76', N'MI76', N'Last Name 76', N'Male', CAST(N'1990-03-17' AS Date), N'email76@gosei.com.vn', N'Test Note 76')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (77, N'First Name 77', N'MI77', N'Last Name 77', N'Male', CAST(N'1990-03-18' AS Date), N'email77@gosei.com.vn', N'Test Note 77')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (78, N'First Name 78', N'MI78', N'Last Name 78', N'Male', CAST(N'1990-03-19' AS Date), N'email78@gosei.com.vn', N'Test Note 78')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (79, N'First Name 79', N'MI79', N'Last Name 79', N'Male', CAST(N'1990-03-20' AS Date), N'email79@gosei.com.vn', N'Test Note 79')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (80, N'First Name 80', N'MI80', N'Last Name 80', N'Male', CAST(N'1990-03-21' AS Date), N'email80@gosei.com.vn', N'Test Note 80')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (81, N'First Name 81', N'MI81', N'Last Name 81', N'Female', CAST(N'1990-03-22' AS Date), N'email81@gosei.com.vn', N'Test Note 81')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (82, N'First Name 82', N'MI82', N'Last Name 82', N'Male', CAST(N'1990-03-23' AS Date), N'email82@gosei.com.vn', N'Test Note 82')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (83, N'First Name 83', N'MI83', N'Last Name 83', N'Female', CAST(N'1990-03-24' AS Date), N'email83@gosei.com.vn', N'Test Note 83')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (84, N'First Name 84', N'MI84', N'Last Name 84', N'Male', CAST(N'1990-03-25' AS Date), N'email84@gosei.com.vn', N'Test Note 84')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (85, N'First Name 85', N'MI85', N'Last Name 85', N'Male', CAST(N'1990-03-26' AS Date), N'email85@gosei.com.vn', N'Test Note 85')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (86, N'First Name 86', N'MI86', N'Last Name 86', N'Female', CAST(N'1990-03-27' AS Date), N'email86@gosei.com.vn', N'Test Note 86')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (87, N'First Name 87', N'MI87', N'Last Name 87', N'Male', CAST(N'1990-03-28' AS Date), N'email87@gosei.com.vn', N'Test Note 87')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (88, N'First Name 88', N'MI88', N'Last Name 88', N'Male', CAST(N'1990-03-29' AS Date), N'email88@gosei.com.vn', N'Test Note 88')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (89, N'First Name 89', N'MI89', N'Last Name 89', N'Male', CAST(N'1990-03-30' AS Date), N'email89@gosei.com.vn', N'Test Note 89')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (90, N'First Name 90', N'MI90', N'Last Name 90', N'Male', CAST(N'1990-03-31' AS Date), N'email90@gosei.com.vn', N'Test Note 90')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (91, N'First Name 91', N'MI91', N'Last Name 91', N'Male', CAST(N'1990-04-01' AS Date), N'email91@gosei.com.vn', N'Test Note 91')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (92, N'First Name 92', N'MI92', N'Last Name 92', N'Male', CAST(N'1990-04-02' AS Date), N'email92@gosei.com.vn', N'Test Note 92')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (93, N'First Name 93', N'MI93', N'Last Name 93', N'Male', CAST(N'1990-04-03' AS Date), N'email93@gosei.com.vn', N'Test Note 93')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (94, N'First Name 94', N'MI94', N'Last Name 94', N'Female', CAST(N'1990-04-04' AS Date), N'email94@gosei.com.vn', N'Test Note 94')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (95, N'First Name 95', N'MI95', N'Last Name 95', N'Male', CAST(N'1990-04-05' AS Date), N'email95@gosei.com.vn', N'Test Note 95')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (96, N'First Name 96', N'MI96', N'Last Name 96', N'Male', CAST(N'1990-04-06' AS Date), N'email96@gosei.com.vn', N'Test Note 96')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (97, N'First Name 97', N'MI97', N'Last Name 97', N'Male', CAST(N'1990-04-07' AS Date), N'email97@gosei.com.vn', N'Test Note 97')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (98, N'First Name 98', N'MI98', N'Last Name 98', N'Male', CAST(N'1990-04-08' AS Date), N'email98@gosei.com.vn', N'Test Note 98')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (99, N'First Name 99', N'MI99', N'Last Name 99', N'Male', CAST(N'1990-04-09' AS Date), N'email99@gosei.com.vn', N'Test Note 99')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (100, N'First Name 100', N'MI100', N'Last Name 100', N'Male', CAST(N'1990-04-10' AS Date), N'email100@gosei.com.vn', N'Test Note 100')
GO
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (101, N'First Name 101', N'MI101', N'Last Name 101', N'Female', CAST(N'1990-04-11' AS Date), N'email101@gosei.com.vn', N'Test Note 101')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (102, N'First Name 102', N'MI102', N'Last Name 102', N'Male', CAST(N'1990-04-12' AS Date), N'email102@gosei.com.vn', N'Test Note 102')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (103, N'First Name 103', N'MI103', N'Last Name 103', N'Male', CAST(N'1990-04-13' AS Date), N'email103@gosei.com.vn', N'Test Note 103')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (104, N'First Name 104', N'MI104', N'Last Name 104', N'Male', CAST(N'1990-04-14' AS Date), N'email104@gosei.com.vn', N'Test Note 104')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (105, N'First Name 105', N'MI105', N'Last Name 105', N'Female', CAST(N'1990-04-15' AS Date), N'email105@gosei.com.vn', N'Test Note 105')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (106, N'First Name 106', N'MI106', N'Last Name 106', N'Male', CAST(N'1990-04-16' AS Date), N'email106@gosei.com.vn', N'Test Note 106')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (107, N'First Name 107', N'MI107', N'Last Name 107', N'Male', CAST(N'1990-04-17' AS Date), N'email107@gosei.com.vn', N'Test Note 107')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (108, N'First Name 108', N'MI108', N'Last Name 108', N'Male', CAST(N'1990-04-18' AS Date), N'email108@gosei.com.vn', N'Test Note 108')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (109, N'First Name 109', N'MI109', N'Last Name 109', N'Male', CAST(N'1990-04-19' AS Date), N'email109@gosei.com.vn', N'Test Note 109')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (110, N'First Name 110', N'MI110', N'Last Name 110', N'Male', CAST(N'1990-04-20' AS Date), N'email110@gosei.com.vn', N'Test Note 110')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (111, N'First Name 111', N'MI111', N'Last Name 111', N'Male', CAST(N'1990-04-21' AS Date), N'email111@gosei.com.vn', N'Test Note 111')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (112, N'First Name 112', N'MI112', N'Last Name 112', N'Female', CAST(N'1990-04-22' AS Date), N'email112@gosei.com.vn', N'Test Note 112')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (113, N'First Name 113', N'MI113', N'Last Name 113', N'Male', CAST(N'1990-04-23' AS Date), N'email113@gosei.com.vn', N'Test Note 113')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (114, N'First Name 114', N'MI114', N'Last Name 114', N'Female', CAST(N'1990-04-24' AS Date), N'email114@gosei.com.vn', N'Test Note 114')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (115, N'First Name 115', N'MI115', N'Last Name 115', N'Male', CAST(N'1990-04-25' AS Date), N'email115@gosei.com.vn', N'Test Note 115')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (116, N'First Name 116', N'MI116', N'Last Name 116', N'Male', CAST(N'1990-04-26' AS Date), N'email116@gosei.com.vn', N'Test Note 116')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (117, N'First Name 117', N'MI117', N'Last Name 117', N'Male', CAST(N'1990-04-27' AS Date), N'email117@gosei.com.vn', N'Test Note 117')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (118, N'First Name 118', N'MI118', N'Last Name 118', N'Male', CAST(N'1990-04-28' AS Date), N'email118@gosei.com.vn', N'Test Note 118')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (119, N'First Name 119', N'MI119', N'Last Name 119', N'Male', CAST(N'1990-04-29' AS Date), N'email119@gosei.com.vn', N'Test Note 119')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (120, N'First Name 120', N'MI120', N'Last Name 120', N'Male', CAST(N'1990-04-30' AS Date), N'email120@gosei.com.vn', N'Test Note 120')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (121, N'First Name 121', N'MI121', N'Last Name 121', N'Male', CAST(N'1990-05-01' AS Date), N'email121@gosei.com.vn', N'Test Note 121')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (122, N'First Name 122', N'MI122', N'Last Name 122', N'Male', CAST(N'1990-05-02' AS Date), N'email122@gosei.com.vn', N'Test Note 122')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (123, N'First Name 123', N'MI123', N'Last Name 123', N'Male', CAST(N'1990-05-03' AS Date), N'email123@gosei.com.vn', N'Test Note 123')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (124, N'First Name 124', N'MI124', N'Last Name 124', N'Male', CAST(N'1990-05-04' AS Date), N'email124@gosei.com.vn', N'Test Note 124')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (125, N'First Name 125', N'MI125', N'Last Name 125', N'Male', CAST(N'1990-05-05' AS Date), N'email125@gosei.com.vn', N'Test Note 125')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (126, N'First Name 126', N'MI126', N'Last Name 126', N'Male', CAST(N'1990-05-06' AS Date), N'email126@gosei.com.vn', N'Test Note 126')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (127, N'First Name 127', N'MI127', N'Last Name 127', N'Male', CAST(N'1990-05-07' AS Date), N'email127@gosei.com.vn', N'Test Note 127')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (128, N'First Name 128', N'MI128', N'Last Name 128', N'Male', CAST(N'1990-05-08' AS Date), N'email128@gosei.com.vn', N'Test Note 128')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (129, N'First Name 129', N'MI129', N'Last Name 129', N'Male', CAST(N'1990-05-09' AS Date), N'email129@gosei.com.vn', N'Test Note 129')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (130, N'First Name 130', N'MI130', N'Last Name 130', N'Male', CAST(N'1990-05-10' AS Date), N'email130@gosei.com.vn', N'Test Note 130')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (131, N'First Name 131', N'MI131', N'Last Name 131', N'Male', CAST(N'1990-05-11' AS Date), N'email131@gosei.com.vn', N'Test Note 131')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (132, N'First Name 132', N'MI132', N'Last Name 132', N'Male', CAST(N'1990-05-12' AS Date), N'email132@gosei.com.vn', N'Test Note 132')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (133, N'First Name 133', N'MI133', N'Last Name 133', N'Female', CAST(N'1990-05-13' AS Date), N'email133@gosei.com.vn', N'Test Note 133')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (134, N'First Name 134', N'MI134', N'Last Name 134', N'Male', CAST(N'1990-05-14' AS Date), N'email134@gosei.com.vn', N'Test Note 134')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (135, N'First Name 135', N'MI135', N'Last Name 135', N'Male', CAST(N'1990-05-15' AS Date), N'email135@gosei.com.vn', N'Test Note 135')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (136, N'First Name 136', N'MI136', N'Last Name 136', N'Male', CAST(N'1990-05-16' AS Date), N'email136@gosei.com.vn', N'Test Note 136')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (137, N'First Name 137', N'MI137', N'Last Name 137', N'Male', CAST(N'1990-05-17' AS Date), N'email137@gosei.com.vn', N'Test Note 137')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (138, N'First Name 138', N'MI138', N'Last Name 138', N'Male', CAST(N'1990-05-18' AS Date), N'email138@gosei.com.vn', N'Test Note 138')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (139, N'First Name 139', N'MI139', N'Last Name 139', N'Male', CAST(N'1990-05-19' AS Date), N'email139@gosei.com.vn', N'Test Note 139')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (140, N'First Name 140', N'MI140', N'Last Name 140', N'Male', CAST(N'1990-05-20' AS Date), N'email140@gosei.com.vn', N'Test Note 140')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (141, N'First Name 141', N'MI141', N'Last Name 141', N'Female', CAST(N'1990-05-21' AS Date), N'email141@gosei.com.vn', N'Test Note 141')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (142, N'First Name 142', N'MI142', N'Last Name 142', N'Male', CAST(N'1990-05-22' AS Date), N'email142@gosei.com.vn', N'Test Note 142')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (143, N'First Name 143', N'MI143', N'Last Name 143', N'Male', CAST(N'1990-05-23' AS Date), N'email143@gosei.com.vn', N'Test Note 143')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (144, N'First Name 144', N'MI144', N'Last Name 144', N'Male', CAST(N'1990-05-24' AS Date), N'email144@gosei.com.vn', N'Test Note 144')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (145, N'First Name 145', N'MI145', N'Last Name 145', N'Male', CAST(N'1990-05-25' AS Date), N'email145@gosei.com.vn', N'Test Note 145')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (146, N'First Name 146', N'MI146', N'Last Name 146', N'Female', CAST(N'1990-05-26' AS Date), N'email146@gosei.com.vn', N'Test Note 146')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (147, N'First Name 147', N'MI147', N'Last Name 147', N'Male', CAST(N'1990-05-27' AS Date), N'email147@gosei.com.vn', N'Test Note 147')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (148, N'First Name 148', N'MI148', N'Last Name 148', N'Male', CAST(N'1990-05-28' AS Date), N'email148@gosei.com.vn', N'Test Note 148')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (149, N'First Name 149', N'MI149', N'Last Name 149', N'Male', CAST(N'1990-05-29' AS Date), N'email149@gosei.com.vn', N'Test Note 149')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (150, N'First Name 150', N'MI150', N'Last Name 150', N'Male', CAST(N'1990-05-30' AS Date), N'email150@gosei.com.vn', N'Test Note 150')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (151, N'First Name 151', N'MI151', N'Last Name 151', N'Male', CAST(N'1990-05-31' AS Date), N'email151@gosei.com.vn', N'Test Note 151')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (152, N'First Name 152', N'MI152', N'Last Name 152', N'Male', CAST(N'1990-06-01' AS Date), N'email152@gosei.com.vn', N'Test Note 152')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (153, N'First Name 153', N'MI153', N'Last Name 153', N'Female', CAST(N'1990-06-02' AS Date), N'email153@gosei.com.vn', N'Test Note 153')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (154, N'First Name 154', N'MI154', N'Last Name 154', N'Male', CAST(N'1990-06-03' AS Date), N'email154@gosei.com.vn', N'Test Note 154')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (155, N'First Name 155', N'MI155', N'Last Name 155', N'Female', CAST(N'1990-06-04' AS Date), N'email155@gosei.com.vn', N'Test Note 155')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (156, N'First Name 156', N'MI156', N'Last Name 156', N'Male', CAST(N'1990-06-05' AS Date), N'email156@gosei.com.vn', N'Test Note 156')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (157, N'First Name 157', N'MI157', N'Last Name 157', N'Male', CAST(N'1990-06-06' AS Date), N'email157@gosei.com.vn', N'Test Note 157')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (158, N'First Name 158', N'MI158', N'Last Name 158', N'Male', CAST(N'1990-06-07' AS Date), N'email158@gosei.com.vn', N'Test Note 158')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (159, N'First Name 159', N'MI159', N'Last Name 159', N'Female', CAST(N'1990-06-08' AS Date), N'email159@gosei.com.vn', N'Test Note 159')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (160, N'First Name 160', N'MI160', N'Last Name 160', N'Male', CAST(N'1990-06-09' AS Date), N'email160@gosei.com.vn', N'Test Note 160')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (161, N'First Name 161', N'MI161', N'Last Name 161', N'Male', CAST(N'1990-06-10' AS Date), N'email161@gosei.com.vn', N'Test Note 161')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (162, N'First Name 162', N'MI162', N'Last Name 162', N'Male', CAST(N'1990-06-11' AS Date), N'email162@gosei.com.vn', N'Test Note 162')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (163, N'First Name 163', N'MI163', N'Last Name 163', N'Male', CAST(N'1990-06-12' AS Date), N'email163@gosei.com.vn', N'Test Note 163')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (164, N'First Name 164', N'MI164', N'Last Name 164', N'Male', CAST(N'1990-06-13' AS Date), N'email164@gosei.com.vn', N'Test Note 164')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (165, N'First Name 165', N'MI165', N'Last Name 165', N'Male', CAST(N'1990-06-14' AS Date), N'email165@gosei.com.vn', N'Test Note 165')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (166, N'First Name 166', N'MI166', N'Last Name 166', N'Male', CAST(N'1990-06-15' AS Date), N'email166@gosei.com.vn', N'Test Note 166')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (167, N'First Name 167', N'MI167', N'Last Name 167', N'Male', CAST(N'1990-06-16' AS Date), N'email167@gosei.com.vn', N'Test Note 167')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (168, N'First Name 168', N'MI168', N'Last Name 168', N'Male', CAST(N'1990-06-17' AS Date), N'email168@gosei.com.vn', N'Test Note 168')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (169, N'First Name 169', N'MI169', N'Last Name 169', N'Female', CAST(N'1990-06-18' AS Date), N'email169@gosei.com.vn', N'Test Note 169')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (170, N'First Name 170', N'MI170', N'Last Name 170', N'Male', CAST(N'1990-06-19' AS Date), N'email170@gosei.com.vn', N'Test Note 170')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (171, N'First Name 171', N'MI171', N'Last Name 171', N'Male', CAST(N'1990-06-20' AS Date), N'email171@gosei.com.vn', N'Test Note 171')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (172, N'First Name 172', N'MI172', N'Last Name 172', N'Male', CAST(N'1990-06-21' AS Date), N'email172@gosei.com.vn', N'Test Note 172')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (173, N'First Name 173', N'MI173', N'Last Name 173', N'Male', CAST(N'1990-06-22' AS Date), N'email173@gosei.com.vn', N'Test Note 173')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (174, N'First Name 174', N'MI174', N'Last Name 174', N'Female', CAST(N'1990-06-23' AS Date), N'email174@gosei.com.vn', N'Test Note 174')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (175, N'First Name 175', N'MI175', N'Last Name 175', N'Male', CAST(N'1990-06-24' AS Date), N'email175@gosei.com.vn', N'Test Note 175')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (176, N'First Name 176', N'MI176', N'Last Name 176', N'Male', CAST(N'1990-06-25' AS Date), N'email176@gosei.com.vn', N'Test Note 176')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (177, N'First Name 177', N'MI177', N'Last Name 177', N'Male', CAST(N'1990-06-26' AS Date), N'email177@gosei.com.vn', N'Test Note 177')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (178, N'First Name 178', N'MI178', N'Last Name 178', N'Female', CAST(N'1990-06-27' AS Date), N'email178@gosei.com.vn', N'Test Note 178')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (179, N'First Name 179', N'MI179', N'Last Name 179', N'Male', CAST(N'1990-06-28' AS Date), N'email179@gosei.com.vn', N'Test Note 179')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (180, N'First Name 180', N'MI180', N'Last Name 180', N'Male', CAST(N'1990-06-29' AS Date), N'email180@gosei.com.vn', N'Test Note 180')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (181, N'First Name 181', N'MI181', N'Last Name 181', N'Male', CAST(N'1990-06-30' AS Date), N'email181@gosei.com.vn', N'Test Note 181')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (182, N'First Name 182', N'MI182', N'Last Name 182', N'Male', CAST(N'1990-07-01' AS Date), N'email182@gosei.com.vn', N'Test Note 182')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (183, N'First Name 183', N'MI183', N'Last Name 183', N'Male', CAST(N'1990-07-02' AS Date), N'email183@gosei.com.vn', N'Test Note 183')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (184, N'First Name 184', N'MI184', N'Last Name 184', N'Male', CAST(N'1990-07-03' AS Date), N'email184@gosei.com.vn', N'Test Note 184')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (185, N'First Name 185', N'MI185', N'Last Name 185', N'Male', CAST(N'1990-07-04' AS Date), N'email185@gosei.com.vn', N'Test Note 185')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (186, N'First Name 186', N'MI186', N'Last Name 186', N'Male', CAST(N'1990-07-05' AS Date), N'email186@gosei.com.vn', N'Test Note 186')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (187, N'First Name 187', N'MI187', N'Last Name 187', N'Male', CAST(N'1990-07-06' AS Date), N'email187@gosei.com.vn', N'Test Note 187')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (188, N'First Name 188', N'MI188', N'Last Name 188', N'Male', CAST(N'1990-07-07' AS Date), N'email188@gosei.com.vn', N'Test Note 188')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (189, N'First Name 189', N'MI189', N'Last Name 189', N'Male', CAST(N'1990-07-08' AS Date), N'email189@gosei.com.vn', N'Test Note 189')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (190, N'First Name 190', N'MI190', N'Last Name 190', N'Male', CAST(N'1990-07-09' AS Date), N'email190@gosei.com.vn', N'Test Note 190')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (191, N'First Name 191', N'MI191', N'Last Name 191', N'Male', CAST(N'1990-07-10' AS Date), N'email191@gosei.com.vn', N'Test Note 191')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (192, N'First Name 192', N'MI192', N'Last Name 192', N'Male', CAST(N'1990-07-11' AS Date), N'email192@gosei.com.vn', N'Test Note 192')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (193, N'First Name 193', N'MI193', N'Last Name 193', N'Male', CAST(N'1990-07-12' AS Date), N'email193@gosei.com.vn', N'Test Note 193')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (194, N'First Name 194', N'MI194', N'Last Name 194', N'Male', CAST(N'1990-07-13' AS Date), N'email194@gosei.com.vn', N'Test Note 194')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (195, N'First Name 195', N'MI195', N'Last Name 195', N'Male', CAST(N'1990-07-14' AS Date), N'email195@gosei.com.vn', N'Test Note 195')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (196, N'First Name 196', N'MI196', N'Last Name 196', N'Male', CAST(N'1990-07-15' AS Date), N'email196@gosei.com.vn', N'Test Note 196')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (197, N'First Name 197', N'MI197', N'Last Name 197', N'Male', CAST(N'1990-07-16' AS Date), N'email197@gosei.com.vn', N'Test Note 197')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (198, N'First Name 198', N'MI198', N'Last Name 198', N'Male', CAST(N'1990-07-17' AS Date), N'email198@gosei.com.vn', N'Test Note 198')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (199, N'First Name 199', N'MI199', N'Last Name 199', N'Male', CAST(N'1990-07-18' AS Date), N'email199@gosei.com.vn', N'Test Note 199')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [BirthDate], [Email], [Note]) VALUES (200, N'First Name 200', N'MI200', N'Last Name 200', N'Male', CAST(N'1990-07-19' AS Date), N'email200@gosei.com.vn', N'Test Note 200')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeQualification] ON 

INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (2, 1, 1, N'Test Institution 1', N'Hanoi', CAST(N'2012-06-30' AS Date), CAST(N'2020-06-30' AS Date), N'Test Note 1')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (3, 2, 2, N'Test Institution 2', N'Hanoi', CAST(N'2012-07-01' AS Date), CAST(N'2020-07-01' AS Date), N'Test Note 2')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (4, 3, 3, N'Test Institution 3', N'Hanoi', CAST(N'2012-07-02' AS Date), CAST(N'2020-07-02' AS Date), N'Test Note 3')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (5, 4, 4, N'Test Institution 4', N'Hanoi', CAST(N'2012-07-03' AS Date), CAST(N'2020-07-03' AS Date), N'Test Note 4')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (6, 5, 1, N'Test Institution 5', N'HCM City', CAST(N'2012-07-04' AS Date), CAST(N'2020-07-04' AS Date), N'Test Note 5')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (7, 6, 2, N'Test Institution 6', N'HCM City', CAST(N'2012-07-05' AS Date), CAST(N'2020-07-05' AS Date), N'Test Note 6')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (8, 7, 3, N'Test Institution 7', N'HCM City', CAST(N'2012-07-06' AS Date), CAST(N'2020-07-06' AS Date), N'Test Note 7')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (9, 8, 4, N'Test Institution 8', N'HCM City', CAST(N'2012-07-07' AS Date), CAST(N'2020-07-07' AS Date), N'Test Note 8')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (10, 9, 1, N'Test Institution 9', N'HCM City', CAST(N'2012-07-08' AS Date), CAST(N'2020-07-08' AS Date), N'Test Note 9')
INSERT [dbo].[EmployeeQualification] ([Id], [EmployeeId], [QualificationId], [Institution], [City], [ValidFrom], [ValidTo], [Note]) VALUES (11, 10, 2, N'Test Institution 10', N'HCM City', CAST(N'2012-07-09' AS Date), CAST(N'2020-07-09' AS Date), N'Test Note 10')
SET IDENTITY_INSERT [dbo].[EmployeeQualification] OFF
SET IDENTITY_INSERT [dbo].[Qualification] ON 

INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (1, N'Bachelors Degree', N'BD')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (2, N'Diploma', N'D')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (3, N'Qualification 3', N'Q3')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (4, N'Qualification 4', N'Q4')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (5, N'Qualification 5', N'Q5')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (6, N'Qualification 6', N'Q6')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (7, N'Qualification 7', N'Q7')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (8, N'Qualification 8', N'Q8')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (9, N'Qualification 9', N'Q9')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (10, N'Qualification 10', N'Q10')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (11, N'Qualification 11', N'Q11')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (12, N'Qualification 12', N'Q12')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (13, N'Qualification 13', N'Q13')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (14, N'Qualification 14', N'Q14')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (15, N'Qualification 15', N'Q15')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (16, N'Qualification 16', N'Q16')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (17, N'Qualification 17', N'Q17')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (18, N'Qualification 18', N'Q18')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (19, N'Qualification 19', N'Q19')
INSERT [dbo].[Qualification] ([Id], [Name], [Code]) VALUES (20, N'Qualification 20', N'Q20')
SET IDENTITY_INSERT [dbo].[Qualification] OFF
ALTER TABLE [dbo].[EmployeeQualification]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeQualification_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeQualification] CHECK CONSTRAINT [FK_EmployeeQualification_Employee]
GO
ALTER TABLE [dbo].[EmployeeQualification]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeQualification_Qualification] FOREIGN KEY([QualificationId])
REFERENCES [dbo].[Qualification] ([Id])
GO
ALTER TABLE [dbo].[EmployeeQualification] CHECK CONSTRAINT [FK_EmployeeQualification_Qualification]
GO
