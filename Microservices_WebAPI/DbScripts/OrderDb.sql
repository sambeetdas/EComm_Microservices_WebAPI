USE [OrderDb]
GO
/****** Object:  Table [dbo].[E_Cart]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Cart](
	[Cart_Id] [uniqueidentifier] NOT NULL,
	[Product_Id] [uniqueidentifier] NULL,
	[User_Id] [uniqueidentifier] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cart_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Order]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Order](
	[Order_Id] [uniqueidentifier] NOT NULL,
	[User_Id] [uniqueidentifier] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Order_Detail]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Order_Detail](
	[Order_Detail_Id] [uniqueidentifier] NOT NULL,
	[Product_Id] [uniqueidentifier] NULL,
	[Order_Id] [uniqueidentifier] NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
	[Quantity] [int] NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Invoice_Number] [varchar](50) NULL,
	[Price] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[E_Cart] ADD  DEFAULT (newid()) FOR [Cart_Id]
GO
ALTER TABLE [dbo].[E_Cart] ADD  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [dbo].[E_Order] ADD  DEFAULT (newid()) FOR [Order_Id]
GO
ALTER TABLE [dbo].[E_Order] ADD  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [dbo].[E_Order_Detail] ADD  DEFAULT (newid()) FOR [Order_Detail_Id]
GO
ALTER TABLE [dbo].[E_Order_Detail] ADD  DEFAULT (getdate()) FOR [Create_Date]
GO
/****** Object:  StoredProcedure [dbo].[S_Add_Order]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Add_Order] 
	@PRODUCTID UNIQUEIDENTIFIER,
	@USERID UNIQUEIDENTIFIER,
	@USERNAME VARCHAR(50),
	@QUANTITY INT,
	@TITLE VARCHAR(50),
	@DESCRIPTION VARCHAR(50),
	@INVOICE VARCHAR(50),
	@PRICE VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON;

DECLARE @ORDERID UNIQUEIDENTIFIER
SET @ORDERID = NEWID()

DECLARE @ORDERDETAILID UNIQUEIDENTIFIER
SET @ORDERDETAILID = NEWID()

INSERT INTO E_Order
           (Order_Id
           ,User_Id
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date)
     VALUES
           (@ORDERID
           ,@USERID
           ,@USERNAME
           ,SYSDATETIME()
           ,@USERNAME
           ,SYSDATETIME())


INSERT INTO E_Order_Detail
           (Order_Detail_Id
           ,Product_Id
           ,Order_Id
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date
           ,Quantity
           ,Title
           ,Description
           ,Invoice_Number
           ,Price)
     VALUES
           (@ORDERDETAILID
           ,@PRODUCTID
           ,@ORDERID
           ,@USERNAME
           ,SYSDATETIME()
           ,@USERNAME
           ,SYSDATETIME()
           ,@QUANTITY
           ,@TITLE
           ,@DESCRIPTION
           ,@INVOICE
           ,@PRICE)

SELECT O.Order_Id AS OrderId
      ,O.User_Id as UserId
      ,O.Update_User as UpdateUSer
      ,O.Update_Date as UpdateDate
      ,O.Create_User as CreateUser
      ,O.Create_Date as CreateDate
	  ,OD.Order_Detail_Id as OrderDetailId
      ,OD.Product_Id as ProductId
      ,OD.Quantity as Quantity
      ,OD.Title as Title
      ,Description as Description
      ,OD.Invoice_Number as InvoiceNumber
      ,OD.Price as Price
  FROM E_Order O
  INNER JOIN E_Order_Detail OD ON O.Order_Id = OD.Order_Id
  WHERE O.Order_Id = @ORDERID

END
GO
/****** Object:  StoredProcedure [dbo].[S_Clear_Cart]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Clear_Cart] 

	@USERID UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	 DELETE FROM E_Cart WHERE User_Id = @USERID

END

GO
/****** Object:  StoredProcedure [dbo].[S_Delete_Cart]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[S_Delete_Cart] 
	@PRODUCTID UNIQUEIDENTIFIER,
	@USERID UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	 DELETE FROM E_Cart WHERE User_Id = @USERID AND Product_Id = @PRODUCTID

END

GO
/****** Object:  StoredProcedure [dbo].[S_Get_Cart_By_User_Id]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Get_Cart_By_User_Id] 

	@USERID UNIQUEIDENTIFIER

AS
BEGIN

	SET NOCOUNT ON;

SELECT Cart_Id as CartId
      ,Product_Id as ProductId
      ,User_Id as UserId
      ,Update_User as UpadateUser
      ,Update_Date as UpdateDate
      ,Create_User as CreateUser
      ,Create_Date as CreateDate
      ,Quantity as Quantity
  FROM E_Cart where User_Id = @USERID

END
GO
/****** Object:  StoredProcedure [dbo].[S_Get_Orders]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[S_Get_Orders] 

	@USERID UNIQUEIDENTIFIER

AS
BEGIN

	SET NOCOUNT ON;

SELECT O.Order_Id AS OrderId
      ,O.User_Id as UserId
      ,O.Update_User as UpdateUSer
      ,O.Update_Date as UpdateDate
      ,O.Create_User as CreateUser
      ,O.Create_Date as CreateDate
	  ,OD.Order_Detail_Id as OrderDetailId
      ,OD.Product_Id as ProductId
      ,OD.Quantity as Quantity
      ,OD.Title as Title
      ,Description as Description
      ,OD.Invoice_Number as InvoiceNumber
      ,OD.Price as Price
  FROM E_Order O
  INNER JOIN E_Order_Detail OD ON O.Order_Id = OD.Order_Id
  WHERE O.User_Id = @USERID

END
GO
/****** Object:  StoredProcedure [dbo].[S_Process_Cart]    Script Date: 4/8/2020 4:02:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Process_Cart] 
	@PRODUCTID UNIQUEIDENTIFIER,
	@USERID UNIQUEIDENTIFIER,
	@USERNAME VARCHAR(50),
	@QUANTITY INT
AS
BEGIN

	SET NOCOUNT ON;

    DECLARE @CARTAVAILABLE INT
	SET @CARTAVAILABLE = (SELECT COUNT(*) FROM E_Cart WHERE User_Id = @USERID AND Product_Id = @PRODUCTID)

	IF (@CARTAVAILABLE = 0)

	BEGIN

		DECLARE @CARTID UNIQUEIDENTIFIER
		SET @CARTID = NEWID()

		INSERT INTO E_Cart
           (Cart_Id
           ,Product_Id
           ,User_Id
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date
           ,Quantity)
     VALUES
           (@CARTID
           ,@PRODUCTID
           ,@USERID
           ,@USERNAME
           ,SYSDATETIME()
           ,@USERNAME
           ,SYSDATETIME()
           ,@QUANTITY)
	END

		ELSE

	BEGIN
		UPDATE E_Cart
	   SET Update_User = @USERNAME
		  ,Update_Date = SYSDATETIME()
		  ,Quantity = Quantity + @QUANTITY
	 WHERE User_Id = @USERID AND Product_Id = @PRODUCTID
	END

	SELECT Cart_Id as CartId
      ,Product_Id as ProductId
      ,User_Id as UserId
      ,Update_User as UpadateUser
      ,Update_Date as UpdateDate
      ,Create_User as CreateUser
      ,Create_Date as CreateDate
      ,Quantity as Quantity
  FROM E_Cart where User_Id = @USERID

END
GO
