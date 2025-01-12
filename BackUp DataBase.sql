CREATE DATABASE [TestMillonDB];
GO

USE [TestMillonDB]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 1/11/2025 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[IdOwner] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Address] [nchar](100) NOT NULL,
	[Photo] [image] NULL,
	[Birthday] [date] NOT NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[IdOwner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Properties]    Script Date: 1/11/2025 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Properties](
	[IdProperty] [uniqueidentifier] NOT NULL,
	[IdOwner] [int] NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Address] [nchar](100) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[CodeInternal] [nchar](20) NOT NULL,
	[Year] [smallint] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[IdProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyImages]    Script Date: 1/11/2025 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImages](
	[IdPropertyImage] [int] IDENTITY(1,1) NOT NULL,
	[IdProperty] [uniqueidentifier] NOT NULL,
	[FileImage] [image] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyImages] PRIMARY KEY CLUSTERED 
(
	[IdPropertyImage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyTraces]    Script Date: 1/11/2025 10:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTraces](
	[IdPropertyTrace] [int] NOT NULL,
	[IdProperty] [uniqueidentifier] NOT NULL,
	[DateSale] [date] NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Value] [nchar](10) NOT NULL,
	[Tax] [smallint] NOT NULL,
 CONSTRAINT [PK_PropertyTraces] PRIMARY KEY CLUSTERED 
(
	[IdPropertyTrace] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Properties]  WITH NOCHECK ADD  CONSTRAINT [FK_Properties_Owners] FOREIGN KEY([IdOwner])
REFERENCES [dbo].[Owners] ([IdOwner])
GO
ALTER TABLE [dbo].[Properties] NOCHECK CONSTRAINT [FK_Properties_Owners]
GO
ALTER TABLE [dbo].[PropertyImages]  WITH NOCHECK ADD  CONSTRAINT [FK_PropertyImages_Properties] FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Properties] ([IdProperty])
GO
ALTER TABLE [dbo].[PropertyImages] NOCHECK CONSTRAINT [FK_PropertyImages_Properties]
GO
ALTER TABLE [dbo].[PropertyTraces]  WITH NOCHECK ADD  CONSTRAINT [FK_PropertyTraces_Properties] FOREIGN KEY([IdProperty])
REFERENCES [dbo].[Properties] ([IdProperty])
GO
ALTER TABLE [dbo].[PropertyTraces] NOCHECK CONSTRAINT [FK_PropertyTraces_Properties]
GO
