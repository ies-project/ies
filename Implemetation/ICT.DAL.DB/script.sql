USE [master]
GO
/****** Object:  Database [IES]    Script Date: 16/05/2022 21:58:32 ******/
CREATE DATABASE [IES]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IES', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IES.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IES_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IES_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IES] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IES].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IES] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IES] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IES] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IES] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IES] SET ARITHABORT OFF 
GO
ALTER DATABASE [IES] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IES] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IES] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IES] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IES] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IES] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IES] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IES] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IES] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IES] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IES] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IES] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IES] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IES] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IES] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IES] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IES] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IES] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IES] SET  MULTI_USER 
GO
ALTER DATABASE [IES] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IES] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IES] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IES] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IES] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IES] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [IES] SET QUERY_STORE = OFF
GO
USE [IES]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actions](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NULL,
	[Description] [varchar](64) NULL,
 CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Floor] [varchar](32) NOT NULL,
	[Id_Building] [int] NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NULL,
	[Address] [varchar](32) NULL,
	[Type] [varchar](32) NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControllerActions]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControllerActions](
	[Id] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Id_Action] [int] NULL,
	[Id_Controller] [int] NULL,
 CONSTRAINT [PK_ControllerActions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Controllers]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Controllers](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NULL,
	[LastActionDate] [datetime] NOT NULL,
	[LastAction] [varchar](64) NOT NULL,
	[ManufacturedDate] [datetime] NULL,
	[LastManteinanceDate] [datetime] NOT NULL,
	[ManteinanceDueDate] [datetime] NOT NULL,
	[ManufacturedBy] [varchar](32) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy_users] [int] NOT NULL,
	[ModifiedBy_users] [int] NULL,
	[Id_ControllerType] [int] NOT NULL,
	[Id_Area] [int] NULL,
 CONSTRAINT [PK_Controllers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControllerTypes]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControllerTypes](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](32) NOT NULL,
 CONSTRAINT [PK_ControllerTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SensorReads]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SensorReads](
	[Id] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Value] [varchar](64) NULL,
	[Id_Sensor] [int] NULL,
 CONSTRAINT [PK_SensorReads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sensors]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sensors](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NULL,
	[ManufacturedDate] [datetime] NULL,
	[LastManteinanceDate] [datetime] NOT NULL,
	[ManteinanceDueDate] [datetime] NOT NULL,
	[ManufacturedBy] [datetime] NULL,
	[CreatedBy_users] [int] NOT NULL,
	[ModifiedBy_users] [int] NULL,
	[Id_SensorType] [int] NOT NULL,
	[Id_Area] [int] NOT NULL,
 CONSTRAINT [PK_Sensors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SensorTypes]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SensorTypes](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NULL,
	[Description] [varchar](64) NULL,
 CONSTRAINT [PK_SensorTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurroundedAreas]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurroundedAreas](
	[id_Area] [int] NOT NULL,
	[id_SurroundedArea] [int] NOT NULL,
 CONSTRAINT [PK_SurroundedAreas] PRIMARY KEY CLUSTERED 
(
	[id_Area] ASC,
	[id_SurroundedArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NULL,
	[CreateUsers] [bit] NOT NULL,
	[UpdateUsers] [bit] NOT NULL,
	[DeleteUsers] [bit] NOT NULL,
	[CreateAreas] [bit] NOT NULL,
	[UpdateAreas] [bit] NOT NULL,
	[DeleteAreas] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/05/2022 21:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[Id_UserRole] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Buildings] FOREIGN KEY([Id_Building])
REFERENCES [dbo].[Buildings] ([Id])
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Buildings]
GO
ALTER TABLE [dbo].[ControllerActions]  WITH CHECK ADD  CONSTRAINT [FK_ControllerActions_Actions] FOREIGN KEY([Id_Action])
REFERENCES [dbo].[Actions] ([Id])
GO
ALTER TABLE [dbo].[ControllerActions] CHECK CONSTRAINT [FK_ControllerActions_Actions]
GO
ALTER TABLE [dbo].[ControllerActions]  WITH CHECK ADD  CONSTRAINT [FK_ControllerActions_Controllers] FOREIGN KEY([Id_Controller])
REFERENCES [dbo].[Controllers] ([Id])
GO
ALTER TABLE [dbo].[ControllerActions] CHECK CONSTRAINT [FK_ControllerActions_Controllers]
GO
ALTER TABLE [dbo].[Controllers]  WITH CHECK ADD  CONSTRAINT [FK_Controllers_Areas] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[Controllers] CHECK CONSTRAINT [FK_Controllers_Areas]
GO
ALTER TABLE [dbo].[Controllers]  WITH CHECK ADD  CONSTRAINT [FK_Controllers_ControllerTypes] FOREIGN KEY([Id_ControllerType])
REFERENCES [dbo].[ControllerTypes] ([Id])
GO
ALTER TABLE [dbo].[Controllers] CHECK CONSTRAINT [FK_Controllers_ControllerTypes]
GO
ALTER TABLE [dbo].[SensorReads]  WITH CHECK ADD  CONSTRAINT [FK_SensorReads_Sensors] FOREIGN KEY([Id_Sensor])
REFERENCES [dbo].[Sensors] ([Id])
GO
ALTER TABLE [dbo].[SensorReads] CHECK CONSTRAINT [FK_SensorReads_Sensors]
GO
ALTER TABLE [dbo].[Sensors]  WITH CHECK ADD  CONSTRAINT [FK_Sensors_Areas] FOREIGN KEY([Id_Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[Sensors] CHECK CONSTRAINT [FK_Sensors_Areas]
GO
ALTER TABLE [dbo].[Sensors]  WITH CHECK ADD  CONSTRAINT [FK_Sensors_SensorTypes] FOREIGN KEY([Id_SensorType])
REFERENCES [dbo].[SensorTypes] ([Id])
GO
ALTER TABLE [dbo].[Sensors] CHECK CONSTRAINT [FK_Sensors_SensorTypes]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([Id_UserRole])
REFERENCES [dbo].[UserRoles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRoles]
GO
USE [master]
GO
ALTER DATABASE [IES] SET  READ_WRITE 
GO
