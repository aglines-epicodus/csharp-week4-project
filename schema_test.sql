CREATE DATABASE [band_tracker_test]
GO
USE [band_tracker_test]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 6/16/2017 8:26:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[join_bands_venues]    Script Date: 6/16/2017 8:26:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues_join](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_bands] [int] NULL,
	[id_venues] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 6/16/2017 8:26:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (1, N'Amon Tobin')
INSERT [dbo].[bands] ([id], [name]) VALUES (2, N'Magnetic Fields')
INSERT [dbo].[bands] ([id], [name]) VALUES (3, N'Origin Master')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[bands_venues_join] ON 

INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (1, 1, 1)
INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (2, 1, 2)
INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (3, 1, 3)
INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (4, 2, 1)
INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (5, 2, 2)
INSERT [dbo].[bands_venues_join] ([id], [id_bands], [id_venues]) VALUES (6, 3, 1)
SET IDENTITY_INSERT [dbo].[bands_venues_join] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (1, N'The Showbox')
INSERT [dbo].[venues] ([id], [name]) VALUES (2, N'The Crocodile')
INSERT [dbo].[venues] ([id], [name]) VALUES (3, N'The Black Cat')
SET IDENTITY_INSERT [dbo].[venues] OFF
