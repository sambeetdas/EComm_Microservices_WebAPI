USE [UserDb]
GO
/****** Object:  Table [dbo].[E_User]    Script Date: 4/8/2020 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_User](
	[User_Id] [uniqueidentifier] NOT NULL,
	[User_Name] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
	[Status] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_User_Detail]    Script Date: 4/8/2020 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_User_Detail](
	[User_Detail_Id] [uniqueidentifier] NOT NULL,
	[User_Id] [uniqueidentifier] NOT NULL,
	[Geo_Location_Id] [uniqueidentifier] NOT NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
	[Prefix] [varchar](50) NULL,
	[First_Name] [varchar](50) NULL,
	[Middle_Init] [varchar](50) NULL,
	[Last_Name] [varchar](50) NULL,
	[Suffix] [varchar](50) NULL,
	[Marital_Status] [varchar](2) NULL,
	[Gender] [varchar](2) NULL,
	[Birth_Date] [datetime2](3) NULL,
	[CompanyName] [varchar](50) NULL,
	[Join_Date] [datetime2](3) NULL,
	[Source_Code] [varchar](50) NULL,
	[Primary_Phone_Number] [varchar](50) NULL,
	[Secondary_Phone_Number] [varchar](50) NULL,
	[Primary_Phone_Country_Code] [varchar](50) NULL,
	[Secondary_Phone_Country_Code] [varchar](50) NULL,
	[Accepts_Text] [varchar](5) NULL,
	[Primary_Email] [varchar](50) NULL,
	[Secondary_Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_User_SocialTag]    Script Date: 4/8/2020 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_User_SocialTag](
	[Socialtag_Id] [uniqueidentifier] NOT NULL,
	[User_Detail_Id] [uniqueidentifier] NULL,
	[Social_Tag_Code] [varchar](50) NULL,
	[Social_User_Name] [varchar](50) NULL,
	[Url] [varchar](50) NULL,
	[Update_User] [varchar](50) NULL,
	[Update_Date] [datetime2](3) NULL,
	[Create_User] [varchar](50) NULL,
	[Create_Date] [datetime2](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Socialtag_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[E_User] ADD  DEFAULT (newid()) FOR [User_Id]
GO
ALTER TABLE [dbo].[E_User_Detail] ADD  DEFAULT (newid()) FOR [User_Detail_Id]
GO
ALTER TABLE [dbo].[E_User_SocialTag] ADD  DEFAULT (newid()) FOR [Socialtag_Id]
GO
ALTER TABLE [dbo].[E_User_Detail]  WITH CHECK ADD  CONSTRAINT [FK_E_USER_DETAIL_E_USER] FOREIGN KEY([User_Id])
REFERENCES [dbo].[E_User] ([User_Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[E_User_Detail] CHECK CONSTRAINT [FK_E_USER_DETAIL_E_USER]
GO
ALTER TABLE [dbo].[E_User_SocialTag]  WITH CHECK ADD  CONSTRAINT [FK_E_USER_SOCIALTAG_E_USER_DETAIL] FOREIGN KEY([User_Detail_Id])
REFERENCES [dbo].[E_User_Detail] ([User_Detail_Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[E_User_SocialTag] CHECK CONSTRAINT [FK_E_USER_SOCIALTAG_E_USER_DETAIL]
GO
/****** Object:  StoredProcedure [dbo].[S_Get_User_By_Id]    Script Date: 4/8/2020 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Get_User_By_Id] 

	@USERID UNIQUEIDENTIFIER
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
	 U.USER_ID as UserId
	,U.USER_NAME as UserName
	,U.STATUS as Status
	,UD.Geo_Location_Id as GeoLocationId
	,UD.PREFIX as Prefix
	,UD.FIRST_NAME as FirstName
	,UD.MIDDLE_INIT as MiddleInit
	,UD.LAST_NAME as LastName
	,UD.SUFFIX as Suffix
	,UD.MARITAL_STATUS as MaritialStatus
	,UD.GENDER as Gender
	,UD.BIRTH_DATE as BirthDate
	,UD.COMPANYNAME as CompanyName
	,UD.JOIN_DATE as JoinDate
	,UD.SOURCE_CODE as SourceCode
	,UD.PRIMARY_PHONE_NUMBER as PrimaryPhoneNumber
	,UD.SECONDARY_PHONE_NUMBER as SecondaryPhoneNumber
	,UD.PRIMARY_PHONE_COUNTRY_CODE as PrimaryCountryCode
	,UD.SECONDARY_PHONE_COUNTRY_CODE as SecondaryCountryCode
	,UD.ACCEPTS_TEXT as AcceptsText
	,UD.PRIMARY_EMAIL as PrimaryEmail
	,UD.SECONDARY_EMAIL as SecondaryEmail
	,US.SOCIAL_TAG_CODE as SocialTagCode
	,US.SOCIAL_USER_NAME as SocialUserName
	,US.URL as Url
	
	FROM E_USER U
	INNER JOIN E_USER_DETAIL UD ON U.USER_ID = UD.USER_ID
	INNER JOIN E_User_SocialTag US ON UD.User_Detail_Id = US.User_Detail_Id
	WHERE U.USER_ID = @USERID AND U.STATUS='A'

END
GO
/****** Object:  StoredProcedure [dbo].[S_Get_User_By_User_Name]    Script Date: 4/8/2020 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Get_User_By_User_Name] 

	@USERNAME VARCHAR(50)
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
	 U.USER_ID as UserId
	,U.USER_NAME as UserName
	,U.STATUS as Status
	,UD.Geo_Location_Id as GeoLocationId
	,UD.PREFIX as Prefix
	,UD.FIRST_NAME as FirstName
	,UD.MIDDLE_INIT as MiddleInit
	,UD.LAST_NAME as LastName
	,UD.SUFFIX as Suffix
	,UD.MARITAL_STATUS as MaritialStatus
	,UD.GENDER as Gender
	,UD.BIRTH_DATE as BirthDate
	,UD.COMPANYNAME as CompanyName
	,UD.JOIN_DATE as JoinDate
	,UD.SOURCE_CODE as SourceCode
	,UD.PRIMARY_PHONE_NUMBER as PrimaryPhoneNumber
	,UD.SECONDARY_PHONE_NUMBER as SecondaryPhoneNumber
	,UD.PRIMARY_PHONE_COUNTRY_CODE as PrimaryCountryCode
	,UD.SECONDARY_PHONE_COUNTRY_CODE as SecondaryCountryCode
	,UD.ACCEPTS_TEXT as AcceptsText
	,UD.PRIMARY_EMAIL as PrimaryEmail
	,UD.SECONDARY_EMAIL as SecondaryEmail
	,US.SOCIAL_TAG_CODE as SocialTagCode
	,US.SOCIAL_USER_NAME as SocialUserName
	,US.URL as Url
	
	FROM E_USER U
	INNER JOIN E_USER_DETAIL UD ON U.USER_ID = UD.USER_ID
	INNER JOIN E_User_SocialTag US ON UD.User_Detail_Id = US.User_Detail_Id
	WHERE U.USER_NAME = @USERNAME AND U.STATUS='A'

END
GO
/****** Object:  StoredProcedure [dbo].[S_Process_User]    Script Date: 4/8/2020 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[S_Process_User]
	@USERNAME VARCHAR(50),
	@PASSWORD VARCHAR(50),
	@GEOLOCATIONID UNIQUEIDENTIFIER,
	@FIRSTNAME VARCHAR(50),
	@LASTNAME VARCHAR(50),
	@PREFIX VARCHAR(50) = NULL,
    @MIDDLEINIT VARCHAR(50) = NULL,
    @SUFFIX VARCHAR(50) = NULL,
    @MARITALSTATUS VARCHAR(50) = NULL,
    @GENDER VARCHAR(50) = NULL,
    @BIRTHDATE DATETIME,
    @COMPANYNAME VARCHAR(50) = NULL,
    @SOURCECODE VARCHAR(50) = NULL,
    @PRIMARYPHONENUMBER VARCHAR(50),
    @SECONDARYPHONENUMBER VARCHAR(50) = NULL,
    @PRIMARYPHONECOUNTRYCODE VARCHAR(50),
    @SECONDARYPHONECOUNTRYCODE VARCHAR(50) = NULL,
    @ACCEPTSTEXT VARCHAR(50) = NULL,
    @PRIMARYEMAIL VARCHAR(50),
    @SECONDARYEMAIL VARCHAR(50) = NULL,
	@SOCIALTAGCODE VARCHAR(50) = NULL,
	@SOCIALUSERNAME VARCHAR(50) = NULL,
	@URL VARCHAR(50) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @USERAVAILABLE INT
	SET @USERAVAILABLE = (SELECT COUNT(*) FROM E_USER WHERE USER_NAME = @USERNAME)

	IF (@USERAVAILABLE = 0)

		BEGIN
	DECLARE @USERID UNIQUEIDENTIFIER
	SET @USERID = NEWID()

	DECLARE @USERDETAILID UNIQUEIDENTIFIER
	SET @USERDETAILID = NEWID()


		INSERT INTO E_User
           (User_Id,
		   User_Name
           ,Password
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date
		   ,Status)
     VALUES
           (@USERID
		   ,@USERNAME
           ,@PASSWORD
           ,@USERNAME
           ,SYSDATETIME()
           ,@USERNAME
           ,SYSDATETIME()
		   ,'A')

		INSERT INTO E_User_Detail
           (User_Detail_Id
		   ,User_Id
		   ,Geo_Location_Id
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date
           ,Prefix
           ,First_Name
           ,Middle_Init
           ,Last_Name
           ,Suffix
           ,Marital_Status
           ,Gender
           ,Birth_Date
           ,CompanyName
           ,Join_Date
           ,Source_Code
           ,Primary_Phone_Number
           ,Secondary_Phone_Number
           ,Primary_Phone_Country_Code
           ,Secondary_Phone_Country_Code
           ,Accepts_Text
           ,Primary_Email
           ,Secondary_Email)
     VALUES
           (@USERDETAILID
		   ,@USERID
		   ,@GEOLOCATIONID
           ,@USERNAME
           ,SYSDATETIME()
           ,@USERNAME
           ,SYSDATETIME()
           ,@PREFIX
           ,@FIRSTNAME
           ,@MIDDLEINIT
           ,@LASTNAME
           ,@SUFFIX
           ,@MARITALSTATUS
           ,@GENDER
           ,@BIRTHDATE
           ,@COMPANYNAME
           ,SYSDATETIME()
           ,@SOURCECODE
           ,@PRIMARYPHONENUMBER
           ,@SECONDARYPHONENUMBER
           ,@PRIMARYPHONECOUNTRYCODE
           ,@SECONDARYPHONECOUNTRYCODE
           ,@ACCEPTSTEXT
           ,@PRIMARYEMAIL
           ,@SECONDARYEMAIL)

		INSERT INTO E_User_SocialTag
           (User_Detail_Id
           ,Social_Tag_Code
           ,Social_User_Name
           ,Url
           ,Update_User
           ,Update_Date
           ,Create_User
           ,Create_Date)
     VALUES
           (@USERDETAILID
           ,@SOCIALTAGCODE
           ,@SOCIALUSERNAME
           ,@URL
           ,@USERNAME
           ,SYSDATETIME()
           ,@USERNAME
           ,SYSDATETIME())
	END

	ELSE

		BEGIN

	DECLARE @USERIDOLD UNIQUEIDENTIFIER
	SET @USERIDOLD = (SELECT USER_ID FROM E_USER WHERE USER_NAME = @USERNAME)

			UPDATE E_User_Detail
   SET Update_User = @USERNAME
      ,Update_Date = SYSDATETIME()
      ,Prefix = @PREFIX
	  ,Geo_Location_Id = @GEOLOCATIONID
      ,First_Name = @FIRSTNAME
      ,Middle_Init = @MIDDLEINIT
      ,Last_Name = @LASTNAME
      ,Suffix = @SUFFIX
      ,Marital_Status = @MARITALSTATUS
      ,Gender = @GENDER
      ,Birth_Date = @BIRTHDATE
      ,CompanyName = @COMPANYNAME
      ,Source_Code = @SOURCECODE
      ,Primary_Phone_Number = @PRIMARYPHONENUMBER
      ,Secondary_Phone_Number = @SECONDARYPHONENUMBER
      ,Primary_Phone_Country_Code = @PRIMARYPHONECOUNTRYCODE
      ,Secondary_Phone_Country_Code = @SECONDARYPHONECOUNTRYCODE
      ,Accepts_Text = @ACCEPTSTEXT
      ,Primary_Email = @PRIMARYEMAIL
      ,Secondary_Email = @SECONDARYEMAIL
	 WHERE user_Id = @USERIDOLD 
	END

	SELECT 
	 U.USER_ID as UserId
	,U.USER_NAME as UserName
	,U.STATUS as Status
	,UD.Geo_Location_Id as GeoLocationId
	,UD.PREFIX as Prefix
	,UD.FIRST_NAME as FirstName
	,UD.MIDDLE_INIT as MiddleInit
	,UD.LAST_NAME as LastName
	,UD.SUFFIX as Suffix
	,UD.MARITAL_STATUS as MaritialStatus
	,UD.GENDER as Gender
	,UD.BIRTH_DATE as BirthDate
	,UD.COMPANYNAME as CompanyName
	,UD.JOIN_DATE as JoinDate
	,UD.SOURCE_CODE as SourceCode
	,UD.PRIMARY_PHONE_NUMBER as PrimaryPhoneNumber
	,UD.SECONDARY_PHONE_NUMBER as SecondaryPhoneNumber
	,UD.PRIMARY_PHONE_COUNTRY_CODE as PrimaryCountryCode
	,UD.SECONDARY_PHONE_COUNTRY_CODE as SecondaryCountryCode
	,UD.ACCEPTS_TEXT as AcceptsText
	,UD.PRIMARY_EMAIL as PrimaryEmail
	,UD.SECONDARY_EMAIL as SecondaryEmail
	,US.SOCIAL_TAG_CODE as SocialTagCode
	,US.SOCIAL_USER_NAME as SocialUserName
	,US.URL as Url
	
	FROM E_USER U
	INNER JOIN E_USER_DETAIL UD ON U.USER_ID = UD.USER_ID
	INNER JOIN E_User_SocialTag US ON UD.User_Detail_Id = US.User_Detail_Id
	WHERE U.USER_NAME = @USERNAME AND U.STATUS='A'

END
GO
