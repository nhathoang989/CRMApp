USE [HCRM]
GO
/****** Object:  Table [dbo].[CRM_User]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_User](
	[UserID] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Roles] [nvarchar](50) NULL,
 CONSTRAINT [PK_CRM_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Tags]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Tags](
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[EditedBy] [nvarchar](250) NULL,
	[Content] [nvarchar](250) NOT NULL,
	[IsView] [bit] NULL,
	[SEOKeyWords] [nvarchar](250) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Content] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Product_Details_Template]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Product_Details_Template](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Template] [nvarchar](max) NOT NULL,
	[CateID] [int] NULL,
 CONSTRAINT [PK_CRM_Product_Details_Template] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Product_Details_Template] ON
INSERT [dbo].[CRM_Product_Details_Template] ([ID], [Name], [Template], [CateID]) VALUES (1, N't1', N'[{"name":"g1","order":1,"data":[{"o1":""}]},{"name":"g2","order":0,"data":[{"o1":""}]}]', NULL)
SET IDENTITY_INSERT [dbo].[CRM_Product_Details_Template] OFF
/****** Object:  Table [dbo].[CRM_Product]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Product](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](10) NULL,
	[Title] [nvarchar](4000) NOT NULL,
	[Source] [nvarchar](250) NULL,
	[Material] [nvarchar](250) NULL,
	[Image] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[FullDetails] [nvarchar](max) NULL,
	[DealPrice] [float] NULL,
	[NormalPrice] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[Size] [nvarchar](250) NULL,
	[TotalRemain] [int] NOT NULL,
	[TotalSaled] [int] NOT NULL,
	[TotalImported] [int] NOT NULL,
	[SubImages] [nvarchar](max) NULL,
	[Language] [nchar](10) NULL,
	[Infos] [ntext] NULL,
	[Views] [int] NULL,
	[CateId] [int] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[IsDraft] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Product] ON
INSERT [dbo].[CRM_Product] ([ProductID], [Code], [Title], [Source], [Material], [Image], [Description], [FullDetails], [DealPrice], [NormalPrice], [Discount], [Size], [TotalRemain], [TotalSaled], [TotalImported], [SubImages], [Language], [Infos], [Views], [CateId], [DisplayOrder], [CreatedDate], [CreatedBy], [IsDeleted], [IsVisible], [IsDraft]) VALUES (13, N'sp1       ', N'Gạch ốp tường', N'Việt Nam', N'men', N'Files\Product\11074322_996900566987254_2933952605956397604_n.png', NULL, NULL, NULL, 10000, 20, N'viên', 10, 0, 10, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A66B00AE90AF AS DateTime), N'test', 0, 0, 0)
SET IDENTITY_INSERT [dbo].[CRM_Product] OFF
/****** Object:  Table [dbo].[CRM_Menu]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](50) NULL,
	[Path] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Level] [smallint] NOT NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_CRM_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Menu] ON
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (1, N'Nhập xuất hàng', NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (3, N'Nhập hàng', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (4, N'Xuất hàng', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (5, N'Quản lý thu chi', NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (6, N'Thu', NULL, NULL, NULL, 1, 5)
SET IDENTITY_INSERT [dbo].[CRM_Menu] OFF
/****** Object:  Table [dbo].[CRM_Employee]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NULL,
	[IDCardNumber] [nvarchar](50) NULL,
	[ProfileFilePath] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](250) NULL,
	[Age] [int] NULL,
	[Position] [nvarchar](50) NULL,
	[JobDescription] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Avatar] [nvarchar](250) NULL,
 CONSTRAINT [PK_CRM_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Employee] ON
INSERT [dbo].[CRM_Employee] ([EmployeeID], [Email], [Name], [IDCardNumber], [ProfileFilePath], [PhoneNumber], [Age], [Position], [JobDescription], [CreatedDate], [CreatedBy], [IsDeleted], [Avatar]) VALUES (1, N'nhathoang989@gmail.com', N'Nguyễn Nhật Hoàng', NULL, NULL, N'0932758850', NULL, N'Quản lý', N'ngồi chơi', CAST(0x0000A6670089DC29 AS DateTime), NULL, 0, N'Files\Product\12278658_1117338094943500_7279115126850562186_n.png')
INSERT [dbo].[CRM_Employee] ([EmployeeID], [Email], [Name], [IDCardNumber], [ProfileFilePath], [PhoneNumber], [Age], [Position], [JobDescription], [CreatedDate], [CreatedBy], [IsDeleted], [Avatar]) VALUES (2, N'anhhuynh989@gmail.com', N'Huỳnh Đức Anh', NULL, N'Files\Product\MPP_Dove TET_v0.5_20131209.pdf', N'0903130189', NULL, N'Kế toán trưởng', N'culi', CAST(0x0000A665001396B0 AS DateTime), NULL, 0, N'Files\Product\431.jpg')
SET IDENTITY_INSERT [dbo].[CRM_Employee] OFF
/****** Object:  Table [dbo].[CRM_Customer]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[Avatar] [nvarchar](250) NULL,
 CONSTRAINT [PK_CRM_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Customer] ON
INSERT [dbo].[CRM_Customer] ([CustomerID], [Email], [Name], [PhoneNumber], [IsDeleted], [CreatedDate], [CreatedBy], [Avatar]) VALUES (1, N'unilever@abc.com', N'Unilever', N'12739189', 0, CAST(0x0000A66E00B8E596 AS DateTime), N'test', N'Files\Customer\1610024_1187997401210902_9097635660165007573_n.png')
SET IDENTITY_INSERT [dbo].[CRM_Customer] OFF
/****** Object:  Table [dbo].[CRM_Provider]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Provider](
	[ProviderID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[Avatar] [nvarchar](250) NULL,
 CONSTRAINT [PK_CRM_Provider] PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Receipt_Delivery]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Delivery](
	[ReceiptID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[OrderName] [nvarchar](max) NULL,
	[OrderAddress] [nvarchar](max) NULL,
	[OrderPhone] [nvarchar](50) NULL,
	[ReceiveName] [nvarchar](max) NULL,
	[ReceiveAddress] [nvarchar](max) NULL,
	[ReceivePhone] [nvarchar](50) NULL,
	[Shipping] [float] NULL,
	[TotalReduceAmount] [float] NULL,
	[TotalAmount] [float] NULL,
	[TotalPaid] [float] NULL,
	[TotalRemain] [float] NULL,
	[IsOrdered] [bit] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[IsDeliveried] [bit] NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[Status] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[FormPayment] [nvarchar](250) NULL,
	[EmployeeID] [int] NULL,
	[CustomerID] [int] NULL,
 CONSTRAINT [PK__CRM_Or__C3905BCF0DAF0CB0] PRIMARY KEY CLUSTERED 
(
	[ReceiptID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Receipt_Delivery] ON
INSERT [dbo].[CRM_Receipt_Delivery] ([ReceiptID], [CreatedDate], [OrderName], [OrderAddress], [OrderPhone], [ReceiveName], [ReceiveAddress], [ReceivePhone], [Shipping], [TotalReduceAmount], [TotalAmount], [TotalPaid], [TotalRemain], [IsOrdered], [IsPaid], [IsDeliveried], [IsReceived], [Status], [IsDeleted], [FormPayment], [EmployeeID], [CustomerID]) VALUES (1, CAST(0x0000A66F00A55AED AS DateTime), N'Unilever', N'test address', N'12739189', NULL, NULL, NULL, NULL, 200000, 11000000, NULL, NULL, 0, 0, 0, 0, NULL, NULL, NULL, 15, 1)
INSERT [dbo].[CRM_Receipt_Delivery] ([ReceiptID], [CreatedDate], [OrderName], [OrderAddress], [OrderPhone], [ReceiveName], [ReceiveAddress], [ReceivePhone], [Shipping], [TotalReduceAmount], [TotalAmount], [TotalPaid], [TotalRemain], [IsOrdered], [IsPaid], [IsDeliveried], [IsReceived], [Status], [IsDeleted], [FormPayment], [EmployeeID], [CustomerID]) VALUES (2, CAST(0x0000A66F00A78B1B AS DateTime), N'ahdhofakljk', N'Lạc Long Quân', N'12739189', NULL, NULL, NULL, NULL, 0, 11000000, NULL, NULL, 0, 0, 0, 0, NULL, NULL, NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[CRM_Receipt_Delivery] OFF
/****** Object:  Table [dbo].[CRM_Product_Property]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Product_Property](
	[PropertyID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[Roles] [nvarchar](250) NOT NULL,
	[Key] [nvarchar](50) NOT NULL,
	[StringValue] [nvarchar](max) NULL,
	[DoubleValue] [float] NULL,
	[IntValue] [int] NULL,
 CONSTRAINT [PK_CRM_Product_Property] PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Address]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](250) NULL,
	[State] [nvarchar](250) NULL,
	[Street] [nvarchar](250) NULL,
	[Zip] [nchar](10) NULL,
	[CustomerID] [int] NULL,
	[ProviderID] [int] NULL,
	[EmployeeID] [int] NULL,
 CONSTRAINT [PK_CRM_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Address] ON
INSERT [dbo].[CRM_Address] ([AddressID], [City], [State], [Street], [Zip], [CustomerID], [ProviderID], [EmployeeID]) VALUES (14, N'Bình Tân', NULL, N'Đường số 2', NULL, NULL, NULL, 2)
INSERT [dbo].[CRM_Address] ([AddressID], [City], [State], [Street], [Zip], [CustomerID], [ProviderID], [EmployeeID]) VALUES (16, N'Phan Rang Tháp Chàm', NULL, N'6C Lạc Long Quân', NULL, NULL, NULL, 1)
INSERT [dbo].[CRM_Address] ([AddressID], [City], [State], [Street], [Zip], [CustomerID], [ProviderID], [EmployeeID]) VALUES (17, N' fasdf asdf a', NULL, N'adfa', NULL, NULL, NULL, NULL)
INSERT [dbo].[CRM_Address] ([AddressID], [City], [State], [Street], [Zip], [CustomerID], [ProviderID], [EmployeeID]) VALUES (18, N'ajflajsd', NULL, N'hasdf jaslkdfjakl ', NULL, NULL, NULL, NULL)
INSERT [dbo].[CRM_Address] ([AddressID], [City], [State], [Street], [Zip], [CustomerID], [ProviderID], [EmployeeID]) VALUES (19, N'asdfasdf as', NULL, N'test address', NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CRM_Address] OFF
/****** Object:  Table [dbo].[CRM_Role_Menu]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Role_Menu](
	[Role] [nvarchar](50) NOT NULL,
	[MenuID] [int] NOT NULL,
 CONSTRAINT [PK_CRM_Role_Menu] PRIMARY KEY CLUSTERED 
(
	[Role] ASC,
	[MenuID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 1)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 3)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 4)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 5)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 6)
/****** Object:  Table [dbo].[CRM_Receipt_Warehouse]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Warehouse](
	[ReceiptID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Price] [float] NULL,
	[Total] [float] NULL,
	[IsPaid] [bit] NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[Status] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[FormPayment] [nvarchar](250) NULL,
	[UserId] [bigint] NOT NULL,
	[ProviderID] [int] NOT NULL,
 CONSTRAINT [PK__CRM_Receipt_Warehouse] PRIMARY KEY CLUSTERED 
(
	[ReceiptID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Receipt_Return]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Return](
	[ReceiptID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Price] [float] NULL,
	[Total] [float] NULL,
	[IsPaid] [bit] NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[Status] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[FormPayment] [nvarchar](250) NULL,
	[UserID] [bigint] NULL,
	[DeliveryReceiptID] [bigint] NULL,
	[CustomerID] [int] NULL,
 CONSTRAINT [PK__CRM_Receipt_Return] PRIMARY KEY CLUSTERED 
(
	[ReceiptID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Receipt_Details]    Script Date: 09/01/2016 17:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Details](
	[ReceiptDetailsID] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptDeliveryID] [bigint] NULL,
	[ReceiptReturnID] [bigint] NULL,
	[ReceiptWarehouseID] [bigint] NULL,
	[ProductID] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[ReducePrice] [float] NOT NULL,
 CONSTRAINT [PK__CRM_Or__D3B9D36C0A9D95DB] PRIMARY KEY CLUSTERED 
(
	[ReceiptDetailsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_CRM_Customer_IsDeleted]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Customer] ADD  CONSTRAINT [DF_CRM_Customer_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_CRM_Employee_IsDeleted]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Employee] ADD  CONSTRAINT [DF_CRM_Employee_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Products_DealPrice]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_DealPrice]  DEFAULT ((0)) FOR [DealPrice]
GO
/****** Object:  Default [DF_Products_NormalPrice]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_NormalPrice]  DEFAULT ((0)) FOR [NormalPrice]
GO
/****** Object:  Default [DF_CRM_Product_NormalPrice1]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_NormalPrice1]  DEFAULT ((0)) FOR [Discount]
GO
/****** Object:  Default [DF_CRM_Product_CountRemain]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_CountRemain]  DEFAULT ((0)) FOR [TotalRemain]
GO
/****** Object:  Default [DF_CRM_Product_CountSaled]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_CountSaled]  DEFAULT ((0)) FOR [TotalSaled]
GO
/****** Object:  Default [DF_CRM_Product_CountImported]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_CountImported]  DEFAULT ((0)) FOR [TotalImported]
GO
/****** Object:  Default [DF_Products_Language]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_Language]  DEFAULT (N'vn') FOR [Language]
GO
/****** Object:  Default [DF_Products_IsDeleted]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Products_IsVisible]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO
/****** Object:  Default [DF_CRM_Products_IsDraft]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Products_IsDraft]  DEFAULT ((0)) FOR [IsDraft]
GO
/****** Object:  Default [DF_CRM_Provider_IsDeleted]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Provider] ADD  CONSTRAINT [DF_CRM_Provider_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_CRM_Receipt_IsOrdered]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery] ADD  CONSTRAINT [DF_CRM_Receipt_IsOrdered]  DEFAULT ((0)) FOR [IsOrdered]
GO
/****** Object:  Default [DF_CRM_Receipt_UserId]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery] ADD  CONSTRAINT [DF_CRM_Receipt_UserId]  DEFAULT ((0)) FOR [EmployeeID]
GO
/****** Object:  ForeignKey [FK_CRM_Address_CRM_Customer]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Address_CRM_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Address] CHECK CONSTRAINT [FK_CRM_Address_CRM_Customer]
GO
/****** Object:  ForeignKey [FK_CRM_Address_CRM_Employee]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Address_CRM_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[CRM_Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[CRM_Address] CHECK CONSTRAINT [FK_CRM_Address_CRM_Employee]
GO
/****** Object:  ForeignKey [FK_CRM_Address_CRM_Provider]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Address_CRM_Provider] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[CRM_Provider] ([ProviderID])
GO
ALTER TABLE [dbo].[CRM_Address] CHECK CONSTRAINT [FK_CRM_Address_CRM_Provider]
GO
/****** Object:  ForeignKey [FK_CRM_Product_Property_CRM_Products]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Product_Property]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Product_Property_CRM_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[CRM_Product] ([ProductID])
GO
ALTER TABLE [dbo].[CRM_Product_Property] CHECK CONSTRAINT [FK_CRM_Product_Property_CRM_Products]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Delivery_CRM_Customer]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Delivery_CRM_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Delivery] CHECK CONSTRAINT [FK_CRM_Receipt_Delivery_CRM_Customer]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Product]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH NOCHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[CRM_Product] ([ProductID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Product]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Receipt_Delivery]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH NOCHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Delivery] FOREIGN KEY([ReceiptDeliveryID])
REFERENCES [dbo].[CRM_Receipt_Delivery] ([ReceiptID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Delivery]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Receipt_Return]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Return] FOREIGN KEY([ReceiptReturnID])
REFERENCES [dbo].[CRM_Receipt_Return] ([ReceiptID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Return]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Receipt_Warehouse]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Warehouse] FOREIGN KEY([ReceiptWarehouseID])
REFERENCES [dbo].[CRM_Receipt_Warehouse] ([ReceiptID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Warehouse]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Return_CRM_Customer]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Return]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Return_CRM_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Return] CHECK CONSTRAINT [FK_CRM_Receipt_Return_CRM_Customer]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Warehouse_CRM_Provider]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Receipt_Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Warehouse_CRM_Provider] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[CRM_Provider] ([ProviderID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Warehouse] CHECK CONSTRAINT [FK_CRM_Receipt_Warehouse_CRM_Provider]
GO
/****** Object:  ForeignKey [FK_CRM_Role_Menu_CRM_Menu]    Script Date: 09/01/2016 17:29:40 ******/
ALTER TABLE [dbo].[CRM_Role_Menu]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Role_Menu_CRM_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[CRM_Menu] ([ID])
GO
ALTER TABLE [dbo].[CRM_Role_Menu] CHECK CONSTRAINT [FK_CRM_Role_Menu_CRM_Menu]
GO
