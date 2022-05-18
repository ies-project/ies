USE [ICT]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 18/05/2022 11:59:39 ******/
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
/****** Object:  Table [dbo].[Areas]    Script Date: 18/05/2022 11:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[Id] [int] NOT NULL,
	[Id_Building] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Floor] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 18/05/2022 11:59:39 ******/
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
/****** Object:  Table [dbo].[DeviceRequestedReads]    Script Date: 18/05/2022 11:59:39 ******/
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
/****** Object:  Table [dbo].[Devices]    Script Date: 18/05/2022 11:59:39 ******/
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
/****** Object:  Table [dbo].[DeviceSubmittedActions]    Script Date: 18/05/2022 11:59:39 ******/
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
/****** Object:  Table [dbo].[DeviceTypes]    Script Date: 18/05/2022 11:59:39 ******/
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
/****** Object:  Table [dbo].[SurroundingAreas]    Script Date: 18/05/2022 11:59:39 ******/
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
