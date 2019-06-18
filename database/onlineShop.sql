USE [OnlineShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/19/2019 1:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Type] [int] NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [nchar](10) NULL,
	[Status] [nchar](10) NULL,
 CONSTRAINT [PK__Category__3214EC277BF7C56C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/19/2019 1:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[CustomerFullName] [varchar](100) NOT NULL,
	[CustomerPhoneNumber] [varchar](10) NOT NULL,
	[CustomerEmail] [varchar](50) NOT NULL,
	[CustomerPassword] [varchar](45) NOT NULL,
	[Type] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 6/19/2019 1:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](500) NULL,
	[ProductID] [int] NULL,
	[Status] [nchar](10) NULL,
 CONSTRAINT [PK__Image__3214EC27E485D78D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 6/19/2019 1:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/19/2019 1:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[Status] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/19/2019 1:03:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Code] [varchar](250) NULL,
	[CategoryID] [int] NOT NULL,
	[Size] [nvarchar](10) NULL,
	[Description] [nvarchar](4000) NULL,
	[Colors] [nvarchar](50) NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[Price] [decimal](18, 0) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[Status] [nchar](10) NULL,
 CONSTRAINT [PK__Product__3214EC27658B278C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (1, N'Long Sleeves', 1, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (2, N'Short Sleeves', 1, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (3, N'Polo', 1, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (4, N'Long sleeves', 2, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (5, N'Short sleeves', 2, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (6, N'Polo', 2, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (7, N'Apple', 2, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (8, N'Croptop', 2, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (9, N'Boys', 3, NULL, NULL, NULL)
INSERT [dbo].[Category] ([ID], [Name], [Type], [Description], [CreatedDate], [Status]) VALUES (10, N'Girls', 3, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ID], [Path], [ProductID], [Status]) VALUES (1, N'/Content/images/longmen1.jpg', 1, NULL)
INSERT [dbo].[Image] ([ID], [Path], [ProductID], [Status]) VALUES (2, N'/Content/images/longmen2.jpg', 1, NULL)
INSERT [dbo].[Image] ([ID], [Path], [ProductID], [Status]) VALUES (3, N'/Content/images/longmen2.jpg', 2, NULL)
INSERT [dbo].[Image] ([ID], [Path], [ProductID], [Status]) VALUES (4, N'/Content/images/boy4.jpg', 2, NULL)
INSERT [dbo].[Image] ([ID], [Path], [ProductID], [Status]) VALUES (5, N'/Content/images/boy4.jpg', 3, NULL)
INSERT [dbo].[Image] ([ID], [Path], [ProductID], [Status]) VALUES (6, N'/Content/images/longmen2.jpg', 4, NULL)
SET IDENTITY_INSERT [dbo].[Image] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Code], [CategoryID], [Size], [Description], [Colors], [PromotionPrice], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (1, N'Stockholm Lazer Cat', N' SST00129763', 1, N'S', N' public string Description { get; set; }', N'B', CAST(1 AS Decimal(18, 0)), CAST(19 AS Decimal(18, 0)), NULL, NULL, N'1         ')
INSERT [dbo].[Product] ([ID], [Name], [Code], [CategoryID], [Size], [Description], [Colors], [PromotionPrice], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (2, N'Stockholm Like Adults', N' SST00129763', 1, N'M', N' public string Description { get; set; }', N'R', CAST(10 AS Decimal(18, 0)), CAST(19 AS Decimal(18, 0)), NULL, NULL, N'1         ')
INSERT [dbo].[Product] ([ID], [Name], [Code], [CategoryID], [Size], [Description], [Colors], [PromotionPrice], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (3, N'Stockholm Bike Front', N' SST00129763', 1, N'L', N' public string Description { get; set; }', N'B', CAST(5 AS Decimal(18, 0)), CAST(18 AS Decimal(18, 0)), NULL, NULL, N'1         ')
INSERT [dbo].[Product] ([ID], [Name], [Code], [CategoryID], [Size], [Description], [Colors], [PromotionPrice], [Price], [CreatedDate], [CreatedBy], [Status]) VALUES (4, N'Stockholm Caffeine Kic', N' SST00129763', 1, N'M', N' public string Description { get; set; }', N'Y', CAST(0 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), NULL, NULL, N'1         ')
SET IDENTITY_INSERT [dbo].[Product] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__CUSTOMER__AEB4E9D9C2E8A0AA]    Script Date: 6/19/2019 1:03:27 AM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[CustomerPhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK__Image__Status__4F7CD00D] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK__Image__Status__4F7CD00D]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Produ__4316F928] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__Produ__4316F928]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Status__3C69FB99] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Status__3C69FB99]
GO
