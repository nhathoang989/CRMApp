USE [CRM]
GO
/****** Object:  Table [dbo].[CRM_User]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Tags]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Product_Details_Template]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Product]    Script Date: 09/01/2016 10:07:22 ******/
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
	[CountRemain] [int] NOT NULL,
	[CountSaled] [int] NOT NULL,
	[CountImported] [int] NOT NULL,
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
/****** Object:  Table [dbo].[CRM_Menu]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Employee]    Script Date: 09/01/2016 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](250) NULL,
	[Age] [int] NULL,
	[Position] [nvarchar](50) NULL,
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
/****** Object:  Table [dbo].[CRM_Customer]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Provider]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Receipt_Delivery]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Product_Property]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Address]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Role_Menu]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Receipt_Warehouse]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Receipt_Return]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Table [dbo].[CRM_Receipt_Details]    Script Date: 09/01/2016 10:07:22 ******/
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
/****** Object:  Default [DF_CRM_Customer_IsDeleted]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Customer] ADD  CONSTRAINT [DF_CRM_Customer_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_CRM_Employee_IsDeleted]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Employee] ADD  CONSTRAINT [DF_CRM_Employee_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Products_DealPrice]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_DealPrice]  DEFAULT ((0)) FOR [DealPrice]
GO
/****** Object:  Default [DF_Products_NormalPrice]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_NormalPrice]  DEFAULT ((0)) FOR [NormalPrice]
GO
/****** Object:  Default [DF_CRM_Product_NormalPrice1]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_NormalPrice1]  DEFAULT ((0)) FOR [Discount]
GO
/****** Object:  Default [DF_CRM_Product_CountRemain]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_CountRemain]  DEFAULT ((0)) FOR [CountRemain]
GO
/****** Object:  Default [DF_CRM_Product_CountSaled]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_CountSaled]  DEFAULT ((0)) FOR [CountSaled]
GO
/****** Object:  Default [DF_CRM_Product_CountImported]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Product_CountImported]  DEFAULT ((0)) FOR [CountImported]
GO
/****** Object:  Default [DF_Products_Language]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_Language]  DEFAULT (N'vn') FOR [Language]
GO
/****** Object:  Default [DF_Products_IsDeleted]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Products_IsVisible]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_Products_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO
/****** Object:  Default [DF_CRM_Products_IsDraft]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product] ADD  CONSTRAINT [DF_CRM_Products_IsDraft]  DEFAULT ((0)) FOR [IsDraft]
GO
/****** Object:  Default [DF_CRM_Provider_IsDeleted]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Provider] ADD  CONSTRAINT [DF_CRM_Provider_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_CRM_Receipt_IsOrdered]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery] ADD  CONSTRAINT [DF_CRM_Receipt_IsOrdered]  DEFAULT ((0)) FOR [IsOrdered]
GO
/****** Object:  Default [DF_CRM_Receipt_UserId]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery] ADD  CONSTRAINT [DF_CRM_Receipt_UserId]  DEFAULT ((0)) FOR [EmployeeID]
GO
/****** Object:  ForeignKey [FK_CRM_Address_CRM_Customer]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Address_CRM_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Address] CHECK CONSTRAINT [FK_CRM_Address_CRM_Customer]
GO
/****** Object:  ForeignKey [FK_CRM_Address_CRM_Employee]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Address_CRM_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[CRM_Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[CRM_Address] CHECK CONSTRAINT [FK_CRM_Address_CRM_Employee]
GO
/****** Object:  ForeignKey [FK_CRM_Address_CRM_Provider]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Address_CRM_Provider] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[CRM_Provider] ([ProviderID])
GO
ALTER TABLE [dbo].[CRM_Address] CHECK CONSTRAINT [FK_CRM_Address_CRM_Provider]
GO
/****** Object:  ForeignKey [FK_CRM_Product_Property_CRM_Products]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Product_Property]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Product_Property_CRM_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[CRM_Product] ([ProductID])
GO
ALTER TABLE [dbo].[CRM_Product_Property] CHECK CONSTRAINT [FK_CRM_Product_Property_CRM_Products]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Delivery_CRM_Customer]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Delivery_CRM_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Delivery] CHECK CONSTRAINT [FK_CRM_Receipt_Delivery_CRM_Customer]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Product]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH NOCHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[CRM_Product] ([ProductID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Product]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Receipt_Delivery]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH NOCHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Delivery] FOREIGN KEY([ReceiptDeliveryID])
REFERENCES [dbo].[CRM_Receipt_Delivery] ([ReceiptID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Delivery]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Receipt_Return]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Return] FOREIGN KEY([ReceiptReturnID])
REFERENCES [dbo].[CRM_Receipt_Return] ([ReceiptID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Return]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Details_CRM_Receipt_Warehouse]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Warehouse] FOREIGN KEY([ReceiptWarehouseID])
REFERENCES [dbo].[CRM_Receipt_Warehouse] ([ReceiptID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_Receipt_Details_CRM_Receipt_Warehouse]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Return_CRM_Customer]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Return]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Return_CRM_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Return] CHECK CONSTRAINT [FK_CRM_Receipt_Return_CRM_Customer]
GO
/****** Object:  ForeignKey [FK_CRM_Receipt_Warehouse_CRM_Provider]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Receipt_Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Receipt_Warehouse_CRM_Provider] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[CRM_Provider] ([ProviderID])
GO
ALTER TABLE [dbo].[CRM_Receipt_Warehouse] CHECK CONSTRAINT [FK_CRM_Receipt_Warehouse_CRM_Provider]
GO
/****** Object:  ForeignKey [FK_CRM_Role_Menu_CRM_Menu]    Script Date: 09/01/2016 10:07:22 ******/
ALTER TABLE [dbo].[CRM_Role_Menu]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Role_Menu_CRM_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[CRM_Menu] ([ID])
GO
ALTER TABLE [dbo].[CRM_Role_Menu] CHECK CONSTRAINT [FK_CRM_Role_Menu_CRM_Menu]
GO
