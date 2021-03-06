USE [master]
GO
/****** Object:  Database [Farmacia]    Script Date: 12/04/2022 11:01:52 p. m. ******/
CREATE DATABASE [Farmacia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Farmacia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Farmacia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Farmacia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Farmacia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Farmacia] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Farmacia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Farmacia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Farmacia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Farmacia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Farmacia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Farmacia] SET ARITHABORT OFF 
GO
ALTER DATABASE [Farmacia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Farmacia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Farmacia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Farmacia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Farmacia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Farmacia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Farmacia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Farmacia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Farmacia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Farmacia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Farmacia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Farmacia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Farmacia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Farmacia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Farmacia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Farmacia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Farmacia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Farmacia] SET RECOVERY FULL 
GO
ALTER DATABASE [Farmacia] SET  MULTI_USER 
GO
ALTER DATABASE [Farmacia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Farmacia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Farmacia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Farmacia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Farmacia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Farmacia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Farmacia', N'ON'
GO
ALTER DATABASE [Farmacia] SET QUERY_STORE = OFF
GO
USE [Farmacia]
GO
/****** Object:  User [IIS APPPOOL\Farmacia]    Script Date: 12/04/2022 11:01:52 p. m. ******/
CREATE USER [IIS APPPOOL\Farmacia] FOR LOGIN [IIS APPPOOL\Farmacia] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Farmacia]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [IIS APPPOOL\Farmacia]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [IIS APPPOOL\Farmacia]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\Farmacia]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\Farmacia]
GO
/****** Object:  Table [dbo].[Concentracion]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concentracion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Concentracion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domiciliario]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domiciliario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Domiciliario] [text] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domicilio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[Concentracion] [varchar](50) NOT NULL,
	[Presentacion] [varchar](50) NOT NULL,
	[CodigoProducto] [varchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[NombreUsuario] [text] NOT NULL,
	[ApellidosUsuario] [text] NOT NULL,
	[IdUsuario] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Barrio] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Domiciliario] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estante]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoEstante] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [varchar](50) NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[Concentracion] [varchar](max) NULL,
	[Presentacion] [varchar](50) NOT NULL,
	[FechaInventario] [date] NOT NULL,
	[NoEstante] [varchar](50) NULL,
	[FechaVencimiento] [date] NULL,
	[Cantidad] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentacion]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Presentacion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recurso]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Recurso] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SQF]    Script Date: 12/04/2022 11:01:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SQF](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [text] NOT NULL,
	[Apellidos] [text] NOT NULL,
	[Identificacion] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Barrio] [varchar](50) NOT NULL,
	[Email] [varchar](500) NOT NULL,
	[Recurso] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Situacion] [text] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Farmacia] SET  READ_WRITE 
GO
