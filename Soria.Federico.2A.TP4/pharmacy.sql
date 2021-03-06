USE [master]
GO
/****** Object:  Database [storage_pharmacy]    Script Date: 22/11/2020 18:51:22 ******/
CREATE DATABASE [storage_pharmacy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'storage_pharmacy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\storage_pharmacy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'storage_pharmacy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\storage_pharmacy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [storage_pharmacy] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [storage_pharmacy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [storage_pharmacy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [storage_pharmacy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [storage_pharmacy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [storage_pharmacy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [storage_pharmacy] SET ARITHABORT OFF 
GO
ALTER DATABASE [storage_pharmacy] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [storage_pharmacy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [storage_pharmacy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [storage_pharmacy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [storage_pharmacy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [storage_pharmacy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [storage_pharmacy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [storage_pharmacy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [storage_pharmacy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [storage_pharmacy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [storage_pharmacy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [storage_pharmacy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [storage_pharmacy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [storage_pharmacy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [storage_pharmacy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [storage_pharmacy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [storage_pharmacy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [storage_pharmacy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [storage_pharmacy] SET  MULTI_USER 
GO
ALTER DATABASE [storage_pharmacy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [storage_pharmacy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [storage_pharmacy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [storage_pharmacy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [storage_pharmacy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [storage_pharmacy] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [storage_pharmacy] SET QUERY_STORE = OFF
GO
USE [storage_pharmacy]
GO
/****** Object:  Table [dbo].[storage_meds]    Script Date: 22/11/2020 18:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[storage_meds](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[origen] [varchar](50) NOT NULL,
 CONSTRAINT [PK_storage_meds] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[storage_supplements]    Script Date: 22/11/2020 18:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[storage_supplements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[formato] [varchar](50) NOT NULL,
	[empaque] [varchar](50) NOT NULL,
 CONSTRAINT [PK_storage_supplements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[storage_meds] ON 

INSERT [dbo].[storage_meds] ([id], [nombre], [tipo], [precio], [marca], [origen]) VALUES (43, N'ibuprofeno', N'analgesico', 234, N'gador', N'alemania')
INSERT [dbo].[storage_meds] ([id], [nombre], [tipo], [precio], [marca], [origen]) VALUES (44, N'dexibuprofeno', N'analgesico', 666, N'elea', N'brasil')
INSERT [dbo].[storage_meds] ([id], [nombre], [tipo], [precio], [marca], [origen]) VALUES (46, N'loratadina', N'antihistaminico', 500, N'raffo', N'argentina')
INSERT [dbo].[storage_meds] ([id], [nombre], [tipo], [precio], [marca], [origen]) VALUES (47, N'paracetamol', N'analgesico', 450, N'bayer', N'alemania')
INSERT [dbo].[storage_meds] ([id], [nombre], [tipo], [precio], [marca], [origen]) VALUES (50, N'diclofenac', N'analgesico', 1000, N'bayer', N'alemania')
SET IDENTITY_INSERT [dbo].[storage_meds] OFF
GO
SET IDENTITY_INSERT [dbo].[storage_supplements] ON 

INSERT [dbo].[storage_supplements] ([id], [nombre], [tipo], [precio], [formato], [empaque]) VALUES (40, N'isolated protein ', N'suplemento', 400, N'polvo', N'frasco')
INSERT [dbo].[storage_supplements] ([id], [nombre], [tipo], [precio], [formato], [empaque]) VALUES (41, N'centrum', N'multivitaminico', 1500, N'capsulas', N'frasco')
INSERT [dbo].[storage_supplements] ([id], [nombre], [tipo], [precio], [formato], [empaque]) VALUES (42, N'whey protein', N'suplemento', 1000, N'polvo', N'frasco')
INSERT [dbo].[storage_supplements] ([id], [nombre], [tipo], [precio], [formato], [empaque]) VALUES (43, N'omega', N'multivitaminico', 500, N'capsulas', N'frasco')
INSERT [dbo].[storage_supplements] ([id], [nombre], [tipo], [precio], [formato], [empaque]) VALUES (44, N'antioxidantes', N'multivitaminico', 1000, N'capsulas', N'frasco')
SET IDENTITY_INSERT [dbo].[storage_supplements] OFF
GO
USE [master]
GO
ALTER DATABASE [storage_pharmacy] SET  READ_WRITE 
GO
