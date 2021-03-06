USE [band_tracker_test]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 6/16/2017 4:54:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tours]    Script Date: 6/16/2017 4:54:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tours](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 6/16/2017 4:54:22 PM ******/
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

INSERT [dbo].[bands] ([id], [name]) VALUES (2, N'Guitar Hero')
INSERT [dbo].[bands] ([id], [name]) VALUES (3, N'Banjo Hero')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[tours] ON 

INSERT [dbo].[tours] ([id], [band_id], [venue_id]) VALUES (4, 1, 2)
INSERT [dbo].[tours] ([id], [band_id], [venue_id]) VALUES (3, 1, 2)
SET IDENTITY_INSERT [dbo].[tours] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (3, N'Mom''s Basement')
INSERT [dbo].[venues] ([id], [name]) VALUES (2, N'Dad''s Garage')
SET IDENTITY_INSERT [dbo].[venues] OFF
