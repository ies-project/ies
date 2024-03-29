USE [master]
GO
/****** Object:  Database [ICT]    Script Date: 25/05/2022 11:31:03 ******/
CREATE DATABASE [ICT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ICT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ICT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ICT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ICT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ICT] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ICT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ICT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ICT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ICT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ICT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ICT] SET ARITHABORT OFF 
GO
ALTER DATABASE [ICT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ICT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ICT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ICT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ICT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ICT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ICT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ICT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ICT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ICT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ICT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ICT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ICT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ICT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ICT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ICT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ICT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ICT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ICT] SET  MULTI_USER 
GO
ALTER DATABASE [ICT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ICT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ICT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ICT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ICT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ICT] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ICT] SET QUERY_STORE = OFF
GO
USE [ICT]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actions](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[Id] [int] NOT NULL,
	[Id_Building] [int] NOT NULL,
	[Id_Type] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Floor] [varchar](32) NOT NULL,
	[NumFireballs] [int] NOT NULL,
	[NumSpringles] [int] NOT NULL,
	[NumBocasSingulares] [int] NOT NULL,
	[NumBocasSiameses] [int] NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreaTypes]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaTypes](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NOT NULL,
 CONSTRAINT [PK_AreaTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Address] [varchar](32) NOT NULL,
	[Type] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceRequestedReads]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceRequestedReads](
	[Id] [int] NOT NULL,
	[Id_Device] [uniqueidentifier] NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[ResponseDate] [datetime] NULL,
	[ResponseStatus] [varchar](50) NULL,
	[ResponseBody] [varchar](500) NULL,
 CONSTRAINT [PK_DeviceRequestedReads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Id] [uniqueidentifier] NOT NULL,
	[Id_Area] [int] NULL,
	[Id_DeviceType] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NOT NULL,
	[State] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[DeviceSubmittedActions]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceSubmittedActions](
	[Id] [int] NOT NULL,
	[Id_Action] [int] NOT NULL,
	[Id_Device] [uniqueidentifier] NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[ResponseDate] [datetime] NULL,
	[ResponseStatus] [varchar](50) NULL,
 CONSTRAINT [PK_ControllerSubmittedActions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceTypes]    Script Date: 25/05/2022 11:31:03 ******/
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
/****** Object:  Table [dbo].[Extinguishers]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extinguishers](
	[Id] [int] NOT NULL,
	[Id_Area] [int] NULL,
	[Type] [varchar](64) NOT NULL,
	[Description] [varchar](64) NOT NULL,
	[ManufacturedDate] [datetime] NOT NULL,
	[LastManteinanceDate] [datetime] NULL,
	[ManteinanceDueDate] [datetime] NULL,
 CONSTRAINT [PK_Extinguishers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FireHoseReels]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FireHoseReels](
	[Id] [int] NOT NULL,
	[Id_Area] [int] NULL,
	[Type] [varchar](64) NOT NULL,
	[Description] [varchar](64) NOT NULL,
	[ManufacturedDate] [datetime] NOT NULL,
	[LastManteinanceDate] [datetime] NULL,
	[ManteinanceDueDate] [datetime] NULL,
 CONSTRAINT [PK_FireHoseReels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportDevices]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportDevices](
	[Id_Report] [int] NOT NULL,
	[Id_Device] [uniqueidentifier] NOT NULL,
	[Id_Area] [int] NOT NULL,
	[State] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReportDevices_1] PRIMARY KEY CLUSTERED 
(
	[Id_Report] ASC,
	[Id_Device] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Criteria] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurroundingAreas]    Script Date: 25/05/2022 11:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurroundingAreas](
	[Id] [int] NOT NULL,
	[Id_Area] [int] NOT NULL,
 CONSTRAINT [PK_SurroundingAreas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Id_Area] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_AreaTypes] FOREIGN KEY([Id_Type])
REFERENCES [dbo].[AreaTypes] ([Id])
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_AreaTypes]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Buildings] FOREIGN KEY([Id_Building])
REFERENCES [dbo].[Buildings] ([Id])
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Buildings]
GO
ALTER TABLE [dbo].[DeviceRequestedReads]  WITH CHECK ADD  CONSTRAINT [FK_DeviceRequestedReads_Devices] FOREIGN KEY([Id_Device])
REFERENCES [dbo].[Devices] ([Id])
GO
ALTER TABLE [dbo].[DeviceRequestedReads] CHECK CONSTRAINT [FK_DeviceRequestedReads_Devices]
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_Devices_Areas] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_Devices_Areas]
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_Devices_DeviceTypes] FOREIGN KEY([Id_DeviceType])
REFERENCES [dbo].[DeviceTypes] ([Id])
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_Devices_DeviceTypes]
GO
ALTER TABLE [dbo].[DeviceSubmittedActions]  WITH CHECK ADD  CONSTRAINT [FK_DeviceSubmittedActions_Actions] FOREIGN KEY([Id_Action])
REFERENCES [dbo].[Actions] ([Id])
GO
ALTER TABLE [dbo].[DeviceSubmittedActions] CHECK CONSTRAINT [FK_DeviceSubmittedActions_Actions]
GO
ALTER TABLE [dbo].[DeviceSubmittedActions]  WITH CHECK ADD  CONSTRAINT [FK_DeviceSubmittedActions_Devices] FOREIGN KEY([Id_Device])
REFERENCES [dbo].[Devices] ([Id])
GO
ALTER TABLE [dbo].[DeviceSubmittedActions] CHECK CONSTRAINT [FK_DeviceSubmittedActions_Devices]
GO
ALTER TABLE [dbo].[Extinguishers]  WITH CHECK ADD  CONSTRAINT [FK_Extinguishers_Areas] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[Extinguishers] CHECK CONSTRAINT [FK_Extinguishers_Areas]
GO
ALTER TABLE [dbo].[FireHoseReels]  WITH CHECK ADD  CONSTRAINT [FK_FireHoseReels_Areas] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[FireHoseReels] CHECK CONSTRAINT [FK_FireHoseReels_Areas]
GO
ALTER TABLE [dbo].[ReportDevices]  WITH CHECK ADD  CONSTRAINT [FK_ReportDevices_Areas] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[ReportDevices] CHECK CONSTRAINT [FK_ReportDevices_Areas]
GO
ALTER TABLE [dbo].[ReportDevices]  WITH CHECK ADD  CONSTRAINT [FK_ReportDevices_Devices] FOREIGN KEY([Id_Device])
REFERENCES [dbo].[Devices] ([Id])
GO
ALTER TABLE [dbo].[ReportDevices] CHECK CONSTRAINT [FK_ReportDevices_Devices]
GO
ALTER TABLE [dbo].[ReportDevices]  WITH CHECK ADD  CONSTRAINT [FK_ReportDevices_Reports] FOREIGN KEY([Id_Report])
REFERENCES [dbo].[Reports] ([Id])
GO
ALTER TABLE [dbo].[ReportDevices] CHECK CONSTRAINT [FK_ReportDevices_Reports]
GO
ALTER TABLE [dbo].[SurroundingAreas]  WITH CHECK ADD  CONSTRAINT [FK_SurroundingAreas_Areas] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[SurroundingAreas] CHECK CONSTRAINT [FK_SurroundingAreas_Areas]
GO
ALTER TABLE [dbo].[SurroundingAreas]  WITH CHECK ADD  CONSTRAINT [FK_SurroundingAreas_Areas1] FOREIGN KEY([Id])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[SurroundingAreas] CHECK CONSTRAINT [FK_SurroundingAreas_Areas1]
GO
USE [master]
GO
ALTER DATABASE [ICT] SET  READ_WRITE 
GO
