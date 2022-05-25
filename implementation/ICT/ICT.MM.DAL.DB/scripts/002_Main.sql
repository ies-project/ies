USE [master]
GO
/****** Object:  Database [ICTMM]    Script Date: 25/05/2022 11:00:56 ******/
CREATE DATABASE [ICTMM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ICTMM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ICTMM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ICTMM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ICTMM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ICTMM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ICTMM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ICTMM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ICTMM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ICTMM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ICTMM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ICTMM] SET ARITHABORT OFF 
GO
ALTER DATABASE [ICTMM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ICTMM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ICTMM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ICTMM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ICTMM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ICTMM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ICTMM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ICTMM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ICTMM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ICTMM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ICTMM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ICTMM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ICTMM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ICTMM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ICTMM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ICTMM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ICTMM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ICTMM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ICTMM] SET  MULTI_USER 
GO
ALTER DATABASE [ICTMM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ICTMM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ICTMM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ICTMM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ICTMM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ICTMM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ICTMM] SET QUERY_STORE = OFF
GO
USE [ICTMM]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 25/05/2022 11:00:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Id] [uniqueidentifier] NOT NULL,
	[Id_DeviceType] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NOT NULL,
	[ManufacturedDate] [datetime] NOT NULL,
	[LastManteinanceDate] [datetime] NULL,
	[ManteinanceDueDate] [datetime] NULL,
	[ManufacturedBy] [varchar](50) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceTypes]    Script Date: 25/05/2022 11:00:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceTypes](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NOT NULL,
 CONSTRAINT [PK_DeviceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScenarioDevices]    Script Date: 25/05/2022 11:00:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScenarioDevices](
	[Id_Scenario] [int] NOT NULL,
	[Id_Device] [uniqueidentifier] NOT NULL,
	[ManufacturedDate] [datetime] NOT NULL,
	[LastManteinanceDate] [datetime] NULL,
	[ManteinanceDueDate] [datetime] NULL,
	[OriginalState] [varchar](50) NOT NULL,
	[CurrentState] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ScenarioDevices] PRIMARY KEY CLUSTERED 
(
	[Id_Scenario] ASC,
	[Id_Device] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scenarios]    Script Date: 25/05/2022 11:00:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scenarios](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Scenarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_Devices_DeviceTypes] FOREIGN KEY([Id_DeviceType])
REFERENCES [dbo].[DeviceTypes] ([Id])
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_Devices_DeviceTypes]
GO
ALTER TABLE [dbo].[ScenarioDevices]  WITH CHECK ADD  CONSTRAINT [FK_ScenarioDevices_Devices] FOREIGN KEY([Id_Device])
REFERENCES [dbo].[Devices] ([Id])
GO
ALTER TABLE [dbo].[ScenarioDevices] CHECK CONSTRAINT [FK_ScenarioDevices_Devices]
GO
ALTER TABLE [dbo].[ScenarioDevices]  WITH CHECK ADD  CONSTRAINT [FK_ScenarioDevices_Scenarios] FOREIGN KEY([Id_Scenario])
REFERENCES [dbo].[Scenarios] ([Id])
GO
ALTER TABLE [dbo].[ScenarioDevices] CHECK CONSTRAINT [FK_ScenarioDevices_Scenarios]
GO
USE [master]
GO
ALTER DATABASE [ICTMM] SET  READ_WRITE 
GO
