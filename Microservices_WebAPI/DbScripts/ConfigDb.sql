USE [ConfigDb]
GO
/****** Object:  Table [dbo].[E_Geo_Location]    Script Date: 4/8/2020 4:04:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Geo_Location](
	[Geo_Location_Id] [uniqueidentifier] NOT NULL,
	[Currency_Type] [varchar](10) NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
	[Country_Code] [varchar](50) NULL,
	[Language_Code] [varchar](50) NULL,
	[Status] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Geo_Location_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[E_Geo_Location] ([Geo_Location_Id], [Currency_Type], [Update_User], [Update_Date], [Create_User], [Create_Date], [Country_Code], [Language_Code], [Status]) VALUES (N'cd822d89-bc5f-46d1-8e0f-2861c2067ef7', N'USD', N'SYSUSER', CAST(N'2020-03-09T17:17:08.6850000' AS DateTime2), N'SYSUSER', CAST(N'2020-03-09T17:17:08.6850000' AS DateTime2), N'US', N'EN', N'A')
ALTER TABLE [dbo].[E_Geo_Location] ADD  DEFAULT (newid()) FOR [Geo_Location_Id]
GO
ALTER TABLE [dbo].[E_Geo_Location] ADD  DEFAULT (getdate()) FOR [Create_Date]
GO
/****** Object:  StoredProcedure [dbo].[S_Get_Geolocation]    Script Date: 4/8/2020 4:04:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[S_Get_Geolocation] 
	
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT Geo_Location_Id as GeoLocationId
      ,Currency_Type as CurrencyType
      ,Country_Code as CountryCode
      ,Language_Code as LanguageCode
      ,Status as Status
  FROM E_Geo_Location

END
GO
