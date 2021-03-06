USE [master]
GO
/****** Object:  Database [shopthoitrang]    Script Date: 6/15/2021 11:08:59 AM ******/
CREATE DATABASE [shopthoitrang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'shopthoitrang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\shopthoitrang.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'shopthoitrang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\shopthoitrang_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [shopthoitrang] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [shopthoitrang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [shopthoitrang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [shopthoitrang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [shopthoitrang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [shopthoitrang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [shopthoitrang] SET ARITHABORT OFF 
GO
ALTER DATABASE [shopthoitrang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [shopthoitrang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [shopthoitrang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [shopthoitrang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [shopthoitrang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [shopthoitrang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [shopthoitrang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [shopthoitrang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [shopthoitrang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [shopthoitrang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [shopthoitrang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [shopthoitrang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [shopthoitrang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [shopthoitrang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [shopthoitrang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [shopthoitrang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [shopthoitrang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [shopthoitrang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [shopthoitrang] SET  MULTI_USER 
GO
ALTER DATABASE [shopthoitrang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [shopthoitrang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [shopthoitrang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [shopthoitrang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [shopthoitrang] SET DELAYED_DURABILITY = DISABLED 
GO
USE [shopthoitrang]
GO
/****** Object:  Table [dbo].[giohang]    Script Date: 6/15/2021 11:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giohang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_sanpham] [int] NULL,
	[id_nguoidung] [int] NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_giohang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaisanpham]    Script Date: 6/15/2021 11:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaisanpham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](250) NULL,
 CONSTRAINT [PK_loaisanpham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nguoidung]    Script Date: 6/15/2021 11:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nguoidung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](250) NULL,
	[email] [nvarchar](250) NULL,
	[pass] [nvarchar](250) NULL,
	[sdt] [nvarchar](250) NULL,
	[diachi] [nvarchar](250) NULL,
 CONSTRAINT [PK_nguoidung] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 6/15/2021 11:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_loaisanpham] [int] NULL,
	[ten] [nvarchar](250) NULL,
	[hinhanh] [text] NULL,
	[giaban] [int] NULL,
	[soluong] [int] NULL,
	[kichthuoc] [nvarchar](5) NULL,
	[mota] [text] NULL,
 CONSTRAINT [PK_sanpham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[giohang]  WITH CHECK ADD  CONSTRAINT [FK_giohang_nguoidung] FOREIGN KEY([id_nguoidung])
REFERENCES [dbo].[nguoidung] ([id])
GO
ALTER TABLE [dbo].[giohang] CHECK CONSTRAINT [FK_giohang_nguoidung]
GO
ALTER TABLE [dbo].[giohang]  WITH CHECK ADD  CONSTRAINT [FK_giohang_sanpham] FOREIGN KEY([id_sanpham])
REFERENCES [dbo].[sanpham] ([id])
GO
ALTER TABLE [dbo].[giohang] CHECK CONSTRAINT [FK_giohang_sanpham]
GO
ALTER TABLE [dbo].[sanpham]  WITH CHECK ADD  CONSTRAINT [FK_sanpham_loaisanpham] FOREIGN KEY([id_loaisanpham])
REFERENCES [dbo].[loaisanpham] ([id])
GO
ALTER TABLE [dbo].[sanpham] CHECK CONSTRAINT [FK_sanpham_loaisanpham]
GO
USE [master]
GO
ALTER DATABASE [shopthoitrang] SET  READ_WRITE 
GO
