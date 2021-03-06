USE [ProductDb]
GO
/****** Object:  Table [dbo].[E_Product]    Script Date: 4/8/2020 4:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Product](
	[Product_Id] [uniqueidentifier] NOT NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Product_Detail]    Script Date: 4/8/2020 4:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Product_Detail](
	[Product_Detail_Id] [uniqueidentifier] NOT NULL,
	[Product_Id] [uniqueidentifier] NOT NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[First_Category] [varchar](50) NULL,
	[Second_Category] [varchar](50) NULL,
	[Third_Category] [varchar](50) NULL,
	[Actual_Price] [varchar](50) NULL,
	[Discount_Price] [varchar](50) NULL,
	[Is_In_Sale] [varchar](10) NULL,
	[Sku] [varchar](50) NULL,
	[Geo_Location_Id] [uniqueidentifier] NULL,
	[Available_Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Product_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[E_Product] ADD  DEFAULT (newid()) FOR [Product_Id]
GO
ALTER TABLE [dbo].[E_Product] ADD  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [dbo].[E_Product_Detail] ADD  DEFAULT (newid()) FOR [Product_Detail_Id]
GO
ALTER TABLE [dbo].[E_Product_Detail] ADD  DEFAULT (getdate()) FOR [Create_Date]
GO
/****** Object:  StoredProcedure [dbo].[S_Get_Product_by_Id]    Script Date: 4/8/2020 4:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[S_Get_Product_by_Id]
	@PRODUCTID uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT Product_Detail_Id as ProductDetailId
      ,Product_Id as ProductId
      ,Update_User as UpdateUser
      ,Update_Date as UpdateDate
      ,Create_User as CreateUser
      ,Create_Date as CreateDate
      ,Title as Title
      ,Description as Description
      ,First_Category as FirstCategory
      ,Second_Category as SecondCategory
      ,Third_Category as ThirdCategory
      ,Available_Quantity as AvailableQuantity
      ,Actual_Price as ActualPrice
      ,Discount_Price as DiscountPrice
      ,Is_In_Sale as IsInSale
      ,Sku as Sku
	  ,Geo_Location_Id as GeoLocationId
	FROM E_Product_Detail
	WHERE Product_Id = @PRODUCTID

END
GO
/****** Object:  StoredProcedure [dbo].[S_Get_Product_by_Sku]    Script Date: 4/8/2020 4:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Get_Product_by_Sku]
	@SKU VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT Product_Detail_Id as ProductDetailId
      ,Product_Id as ProductId
      ,Update_User as UpdateUser
      ,Update_Date as UpdateDate
      ,Create_User as CreateUser
      ,Create_Date as CreateDate
      ,Title as Title
      ,Description as Description
      ,First_Category as FirstCategory
      ,Second_Category as SecondCategory
      ,Third_Category as ThirdCategory
      ,Available_Quantity as AvailableQuantity
      ,Actual_Price as ActualPrice
      ,Discount_Price as DiscountPrice
      ,Is_In_Sale as IsInSale
      ,Sku as Sku
	  ,Geo_Location_Id as GeoLocationId
	FROM E_Product_Detail
	WHERE SKU = @SKU

END
GO
/****** Object:  StoredProcedure [dbo].[S_Process_Product]    Script Date: 4/8/2020 4:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Process_Product] 
	-- Add the parameters for the stored procedure here
	@TITLE VARCHAR(50),
    @DESCRIPTION VARCHAR(50),
    @FIRSTCATEGORY VARCHAR(50),
    @SECONDCATEGORY VARCHAR(50),
    @THIRDCATEGORY VARCHAR(50) = NULL,
    @AVAILABLEQUANTITY INT,
    @ACTUALPRICE VARCHAR(50),
    @DISCOUNTPRICE VARCHAR(50) = NULL,
    @ISINSALE VARCHAR(50),
	@SKU VARCHAR(50),
	@GEOLOCATIONID UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @SKUAVAILABLE INT
	SET @SKUAVAILABLE = (SELECT COUNT(*) FROM E_Product_Detail WHERE SKU = @SKU)

	IF (@SKUAVAILABLE = 0)

		BEGIN

	DECLARE @PRODUCTID UNIQUEIDENTIFIER
	SET @PRODUCTID = NEWID()

	DECLARE @PRODUCTDETAILID UNIQUEIDENTIFIER
	SET @PRODUCTDETAILID = NEWID()


	INSERT INTO E_Product
           (Product_Id
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date)
     VALUES
           (@PRODUCTID
           ,'SYSUSER'
           ,SYSDATETIME()
           ,'SYSUSER'
           ,SYSDATETIME())

	INSERT INTO E_Product_Detail
           (Product_Detail_Id
           ,Product_Id
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date
           ,Title
           ,Description
           ,First_Category
           ,Second_Category
           ,Third_Category
           ,Available_Quantity
           ,Actual_Price
           ,Discount_Price
           ,Is_In_Sale
		   ,Sku
		   ,Geo_Location_Id)
     VALUES
           (@PRODUCTDETAILID
           ,@PRODUCTID
           ,'SYSUSER'
           ,SYSDATETIME()
           ,'SYSUSER'
           ,SYSDATETIME()
           ,@TITLE
           ,@DESCRIPTION
           ,@FIRSTCATEGORY
           ,@SECONDCATEGORY
           ,@THIRDCATEGORY
           ,@AVAILABLEQUANTITY
           ,@ACTUALPRICE
           ,@DISCOUNTPRICE
           ,@ISINSALE
		   ,@SKU
		   ,@GEOLOCATIONID)

		   END

	ELSE

		BEGIN
		UPDATE E_Product_Detail
		 SET 
       Update_User = 'SYSUSER'
      ,Update_Date = SYSDATETIME()
      ,Title = @TITLE
      ,Description = @DESCRIPTION
      ,First_Category = @FIRSTCATEGORY
      ,Second_Category = @SECONDCATEGORY
      ,Third_Category = @SECONDCATEGORY
      ,Available_Quantity = @AVAILABLEQUANTITY
      ,Actual_Price = @ACTUALPRICE
      ,Discount_Price = @DISCOUNTPRICE
      ,Is_In_Sale = @ISINSALE
	  ,Geo_Location_Id = @GEOLOCATIONID
 WHERE SKU = @SKU
		END

	SELECT Product_Detail_Id as ProductDetailId
      ,Product_Id as ProductId
      ,Update_User as UpdateUser
      ,Update_Date as UpdateDate
      ,Create_User as CreateUser
      ,Create_Date as CreateDate
      ,Title as Title
      ,Description as Description
      ,First_Category as FirstCategory
      ,Second_Category as SecondCategory
      ,Third_Category as ThirdCategory
      ,Available_Quantity as AvailableQuantity
      ,Actual_Price as ActualPrice
      ,Discount_Price as DiscountPrice
      ,Is_In_Sale as IsInSale
      ,Sku as Sku
	  ,Geo_Location_Id as GeoLocationId
	FROM E_Product_Detail
	WHERE SKU = @SKU

END
GO
/****** Object:  StoredProcedure [dbo].[S_Update_Product_Quantity]    Script Date: 4/8/2020 4:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[S_Update_Product_Quantity]
	@SKU VARCHAR(50),
	@QUANTITY INT
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE E_Product_Detail
	SET Available_Quantity = @QUANTITY
	WHERE SKU = @SKU

   SELECT Product_Detail_Id as ProductDetailId
      ,Product_Id as ProductId
      ,Update_User as UpdateUser
      ,Update_Date as UpdateDate
      ,Create_User as CreateUser
      ,Create_Date as CreateDate
      ,Title as Title
      ,Description as Description
      ,First_Category as FirstCategory
      ,Second_Category as SecondCategory
      ,Third_Category as ThirdCategory
      ,Available_Quantity as AvailableQuantity
      ,Actual_Price as ActualPrice
      ,Discount_Price as DiscountPrice
      ,Is_In_Sale as IsInSale
      ,Sku as Sku
	  ,Geo_Location_Id as GeoLocationId
	FROM E_Product_Detail
	WHERE SKU = @SKU

END
GO
