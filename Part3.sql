USE [master]
GO
/****** Object:  Database [December30Part3]    Script Date: 11/01/2021 20:24:13 ******/
CREATE DATABASE [December30Part3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'December30Part3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\December30Part3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'December30Part3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\December30Part3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [December30Part3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [December30Part3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [December30Part3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [December30Part3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [December30Part3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [December30Part3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [December30Part3] SET ARITHABORT OFF 
GO
ALTER DATABASE [December30Part3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [December30Part3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [December30Part3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [December30Part3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [December30Part3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [December30Part3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [December30Part3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [December30Part3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [December30Part3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [December30Part3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [December30Part3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [December30Part3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [December30Part3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [December30Part3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [December30Part3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [December30Part3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [December30Part3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [December30Part3] SET RECOVERY FULL 
GO
ALTER DATABASE [December30Part3] SET  MULTI_USER 
GO
ALTER DATABASE [December30Part3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [December30Part3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [December30Part3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [December30Part3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [December30Part3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [December30Part3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'December30Part3', N'ON'
GO
ALTER DATABASE [December30Part3] SET QUERY_STORE = OFF
GO
USE [December30Part3]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/01/2021 20:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [text] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 11/01/2021 20:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [text] NOT NULL,
	[Floor] [int] NOT NULL,
	[Category_ID] [int] NOT NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Stores_Categories] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Stores_Categories]
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD  CONSTRAINT [FK_Stores_Stores] FOREIGN KEY([ID])
REFERENCES [dbo].[Stores] ([ID])
GO
ALTER TABLE [dbo].[Stores] CHECK CONSTRAINT [FK_Stores_Stores]
GO
USE [master]
GO
ALTER DATABASE [December30Part3] SET  READ_WRITE 
GO
