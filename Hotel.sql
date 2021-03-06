USE [Hotel]
GO
/****** Object:  Table [dbo].[FeedBack]    Script Date: 12/7/2018 2:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBack](
	[UserName] [nchar](50) NOT NULL,
	[HotelName] [nchar](50) NOT NULL,
	[Feedback] [nvarchar](max) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_FeedBack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[General]    Script Date: 12/7/2018 2:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[General](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Email] [char](50) NOT NULL,
	[Password] [char](20) NOT NULL,
	[ConfirmPassword] [char](20) NOT NULL,
	[Type] [nchar](25) NOT NULL,
 CONSTRAINT [PK_General] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HotelData]    Script Date: 12/7/2018 2:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HotelData](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nchar](50) NOT NULL,
	[Ratings] [real] NULL,
	[Category] [nchar](10) NOT NULL,
	[FreeWifi] [bit] NOT NULL,
	[PriceRangeUpper] [real] NOT NULL,
	[PriceRangeLower] [real] NOT NULL,
	[RoomAvailable] [int] NOT NULL,
	[SwimmingPool] [bit] NOT NULL,
	[CarPark] [bit] NOT NULL,
	[FreeBreakfast] [bit] NOT NULL,
	[PrivateParking] [bit] NOT NULL,
	[PlayLand] [bit] NOT NULL,
	[About] [varchar](max) NULL,
 CONSTRAINT [PK_HotelData] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserData]    Script Date: 12/7/2018 2:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserData](
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nchar](50) NULL,
	[Adress] [nvarchar](max) NULL,
	[City] [nchar](50) NULL,
	[Country] [nchar](50) NULL,
	[PostalCode] [nchar](50) NULL,
	[About] [nvarchar](max) NULL,
	[UserID] [nchar](10) NOT NULL,
	[ID] [int] NULL,
 CONSTRAINT [PK_UserData] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[UserData]  WITH CHECK ADD  CONSTRAINT [FK_UserData_General] FOREIGN KEY([ID])
REFERENCES [dbo].[General] ([ID])
GO
ALTER TABLE [dbo].[UserData] CHECK CONSTRAINT [FK_UserData_General]
GO
