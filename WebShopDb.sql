USE [master]
GO
/****** Object:  Database [WebShop] ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'WebShop')
BEGIN
CREATE DATABASE [WebShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WebShop.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\WebShop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
ALTER DATABASE [WebShop] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebShop] SET RECOVERY FULL 
GO
ALTER DATABASE [WebShop] SET  MULTI_USER 
GO
ALTER DATABASE [WebShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WebShop] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebShop', N'ON'
GO
USE [WebShop]
GO
/****** Object:  Table [dbo].[tblCategory] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](4000) NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomer] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCustomer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[FirstName] [varchar](400) NOT NULL,
	[MiddleName] [varchar](400) NULL,
	[LastName] [varchar](400) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Phone] [varchar](100) NULL,
	[Address] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomerOrder] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCustomerOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCustomerOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_tblCustomerOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblOrder] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](100) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOrderProduct] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblOrderProduct]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblOrderProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_tblOrderProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblProduct] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProduct]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](100) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](4000) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProductCategory] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProductCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_tblProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tblProduct] ON 

GO
INSERT [dbo].[tblProduct] ([Id], [Number], [Title], [Description], [Price]) VALUES (1, N'WS-TEST', N'Test Product', N'Test product description', CAST(999.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblProduct] ([Id], [Number], [Title], [Description], [Price]) VALUES (2, N'WP-01', N'Product 01', N'Product 01 description', CAST(10.10 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblProduct] ([Id], [Number], [Title], [Description], [Price]) VALUES (3, N'WP-02', N'Product 02', N'Product 02 description', CAST(20.22 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tblCategory_Name] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND name = N'IX_tblCategory_Name')
CREATE NONCLUSTERED INDEX [IX_tblCategory_Name] ON [dbo].[tblCategory]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tblCustomer_Email] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblCustomer]') AND name = N'IX_tblCustomer_Email')
CREATE NONCLUSTERED INDEX [IX_tblCustomer_Email] ON [dbo].[tblCustomer]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tblCustomer_FirsName_LastName] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblCustomer]') AND name = N'IX_tblCustomer_FirsName_LastName')
CREATE NONCLUSTERED INDEX [IX_tblCustomer_FirsName_LastName] ON [dbo].[tblCustomer]
(
	[FirstName] ASC,
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tblCustomer_UserName] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblCustomer]') AND name = N'IX_tblCustomer_UserName')
CREATE NONCLUSTERED INDEX [IX_tblCustomer_UserName] ON [dbo].[tblCustomer]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblOrder_CreationDate] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblOrder]') AND name = N'IX_tblOrder_CreationDate')
CREATE NONCLUSTERED INDEX [IX_tblOrder_CreationDate] ON [dbo].[tblOrder]
(
	[CreationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tblOrder_Number] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblOrder]') AND name = N'IX_tblOrder_Number')
CREATE NONCLUSTERED INDEX [IX_tblOrder_Number] ON [dbo].[tblOrder]
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tblProduct_Number] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblProduct]') AND name = N'IX_tblProduct_Number')
CREATE NONCLUSTERED INDEX [IX_tblProduct_Number] ON [dbo].[tblProduct]
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tblProduct_Title] ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblProduct]') AND name = N'IX_tblProduct_Title')
CREATE NONCLUSTERED INDEX [IX_tblProduct_Title] ON [dbo].[tblProduct]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCustomerOrder_tblCustomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCustomerOrder]'))
ALTER TABLE [dbo].[tblCustomerOrder]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerOrder_tblCustomer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomer] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCustomerOrder_tblCustomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCustomerOrder]'))
ALTER TABLE [dbo].[tblCustomerOrder] CHECK CONSTRAINT [FK_tblCustomerOrder_tblCustomer]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCustomerOrder_tblOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCustomerOrder]'))
ALTER TABLE [dbo].[tblCustomerOrder]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerOrder_tblOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[tblOrder] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCustomerOrder_tblOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCustomerOrder]'))
ALTER TABLE [dbo].[tblCustomerOrder] CHECK CONSTRAINT [FK_tblCustomerOrder_tblOrder]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblOrderProduct_tblOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblOrderProduct]'))
ALTER TABLE [dbo].[tblOrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblOrderProduct_tblOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[tblOrder] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblOrderProduct_tblOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblOrderProduct]'))
ALTER TABLE [dbo].[tblOrderProduct] CHECK CONSTRAINT [FK_tblOrderProduct_tblOrder]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblOrderProduct_tblProduct]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblOrderProduct]'))
ALTER TABLE [dbo].[tblOrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblOrderProduct_tblProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tblProduct] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblOrderProduct_tblProduct]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblOrderProduct]'))
ALTER TABLE [dbo].[tblOrderProduct] CHECK CONSTRAINT [FK_tblOrderProduct_tblProduct]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProductCategory_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProductCategory]'))
ALTER TABLE [dbo].[tblProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblProductCategory_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProductCategory_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProductCategory]'))
ALTER TABLE [dbo].[tblProductCategory] CHECK CONSTRAINT [FK_tblProductCategory_tblCategory]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProductCategory_tblProduct]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProductCategory]'))
ALTER TABLE [dbo].[tblProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblProductCategory_tblProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tblProduct] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProductCategory_tblProduct]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProductCategory]'))
ALTER TABLE [dbo].[tblProductCategory] CHECK CONSTRAINT [FK_tblProductCategory_tblProduct]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllProducts] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetAllProducts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spGetAllProducts] AS' 
END
GO
-- =============================================
-- Author:		Juan Marin
-- Description:	Get all the products from the database
-- =============================================
ALTER PROCEDURE [dbo].[spGetAllProducts]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Number], [Title], [Description], [Price] 
	FROM dbo.tblProduct
END

GO
/****** Object:  StoredProcedure [dbo].[spInsertOrUpdateProduct] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertOrUpdateProduct]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spInsertOrUpdateProduct] AS' 
END
GO
-- Author:		Juan Marin
-- Description:	Inserts a new product. If it exists, returns error
-- =============================================
ALTER PROCEDURE [dbo].[spInsertOrUpdateProduct] 
(
	@Number VARCHAR(100),
	@Title VARCHAR(100),
	@Description VARCHAR(4000),
	@Price DECIMAL(18,2)
)
AS
BEGIN
	SET NOCOUNT ON;

	--Validates if the product exists
	DECLARE @ProductId BIGINT
	SELECT TOP 1 @ProductId = Id FROM dbo.tblProduct WHERE Number = @Number

	---If it does exist, updates its values
	IF @ProductId IS NOT NULL
	BEGIN
		UPDATE [dbo].[tblProduct]
		   SET [Title] = @Title
			  ,[Description] = @Description
			  ,[Price] = @Price
		 WHERE Id = @ProductId

		 RETURN 1
	END

	--If it does not exist, inserts a new record
    INSERT INTO [dbo].[tblProduct]([Number], [Title], [Description], [Price])
     VALUES (@Number, @Title, @Description, @Price)

	RETURN 1
END

GO
USE [master]
GO
ALTER DATABASE [WebShop] SET  READ_WRITE 
GO
