USE [master]
GO
/****** Object:  Database [Obligatorio1DA2]    Script Date: 13/10/2020 17:14:09 ******/
CREATE DATABASE [Obligatorio1DA2]
 CONTAINMENT = NONE
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Obligatorio1DA2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Obligatorio1DA2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Obligatorio1DA2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Obligatorio1DA2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Obligatorio1DA2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Obligatorio1DA2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Obligatorio1DA2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Obligatorio1DA2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Obligatorio1DA2] SET  MULTI_USER 
GO
ALTER DATABASE [Obligatorio1DA2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Obligatorio1DA2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Obligatorio1DA2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Obligatorio1DA2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Obligatorio1DA2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Obligatorio1DA2] SET QUERY_STORE = OFF
GO
USE [Obligatorio1DA2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lodgings]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lodgings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[TouristicPointId] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Direction] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Stars] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Images] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Capacity] [bit] NOT NULL,
 CONSTRAINT [PK_Lodgings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NULL,
	[PersonType] [int] NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[LodgingId] [int] NULL,
	[ClientId] [int] NULL,
	[CheckIn] [datetime2](7) NOT NULL,
	[CheckOut] [datetime2](7) NOT NULL,
	[StateId] [int] NULL,
	[StateDescription] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristicPoints]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristicPoints](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[RegionId] [int] NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_TouristicPoints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristicPointsCategory]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristicPointsCategory](
	[TouristicPointId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_TouristicPointsCategory] PRIMARY KEY CLUSTERED 
(
	[TouristicPointId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSessions]    Script Date: 13/10/2020 17:14:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[ConnectedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserSessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201012184504_InitialMigration', N'3.1.8')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Ciudades')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Pueblos')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Areas protegidas')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Playas')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Etc')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [Name], [Surname], [Mail], [PersonType], [Password]) VALUES (1, N'admin', N'', N'admin', 2, N'admin')
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([Id], [Name]) VALUES (1, N'Región metropolitana')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (2, N'Región Centro Sur')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (3, N'Región Este')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (4, N'Región Litoral Norte')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (5, N'Región “Corredor Pájaros Pintados”')
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id], [Name]) VALUES (1, N'Creada')
INSERT [dbo].[State] ([Id], [Name]) VALUES (2, N'Pendiente Pago')
INSERT [dbo].[State] ([Id], [Name]) VALUES (3, N'Aceptada')
INSERT [dbo].[State] ([Id], [Name]) VALUES (4, N'Rechazada')
INSERT [dbo].[State] ([Id], [Name]) VALUES (5, N'Expirada')
SET IDENTITY_INSERT [dbo].[State] OFF
GO
/****** Object:  Index [IX_Lodgings_TouristicPointId]    Script Date: 13/10/2020 17:14:11 ******/
CREATE NONCLUSTERED INDEX [IX_Lodgings_TouristicPointId] ON [dbo].[Lodgings]
(
	[TouristicPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_ClientId]    Script Date: 13/10/2020 17:14:11 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_ClientId] ON [dbo].[Reservations]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_LodgingId]    Script Date: 13/10/2020 17:14:11 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_LodgingId] ON [dbo].[Reservations]
(
	[LodgingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_StateId]    Script Date: 13/10/2020 17:14:11 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_StateId] ON [dbo].[Reservations]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TouristicPoints_RegionId]    Script Date: 13/10/2020 17:14:11 ******/
CREATE NONCLUSTERED INDEX [IX_TouristicPoints_RegionId] ON [dbo].[TouristicPoints]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TouristicPointsCategory_CategoryId]    Script Date: 13/10/2020 17:14:11 ******/
CREATE NONCLUSTERED INDEX [IX_TouristicPointsCategory_CategoryId] ON [dbo].[TouristicPointsCategory]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserSessions_UserId]    Script Date: 13/10/2020 17:14:11 ******/
CREATE NONCLUSTERED INDEX [IX_UserSessions_UserId] ON [dbo].[UserSessions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Lodgings]  WITH CHECK ADD  CONSTRAINT [FK_Lodgings_TouristicPoints_TouristicPointId] FOREIGN KEY([TouristicPointId])
REFERENCES [dbo].[TouristicPoints] ([Id])
GO
ALTER TABLE [dbo].[Lodgings] CHECK CONSTRAINT [FK_Lodgings_TouristicPoints_TouristicPointId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Lodgings_LodgingId] FOREIGN KEY([LodgingId])
REFERENCES [dbo].[Lodgings] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Lodgings_LodgingId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Persons_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Persons_ClientId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_State_StateId]
GO
ALTER TABLE [dbo].[TouristicPoints]  WITH CHECK ADD  CONSTRAINT [FK_TouristicPoints_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO
ALTER TABLE [dbo].[TouristicPoints] CHECK CONSTRAINT [FK_TouristicPoints_Regions_RegionId]
GO
ALTER TABLE [dbo].[TouristicPointsCategory]  WITH CHECK ADD  CONSTRAINT [FK_TouristicPointsCategory_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristicPointsCategory] CHECK CONSTRAINT [FK_TouristicPointsCategory_Categories_CategoryId]
GO
ALTER TABLE [dbo].[TouristicPointsCategory]  WITH CHECK ADD  CONSTRAINT [FK_TouristicPointsCategory_TouristicPoints_TouristicPointId] FOREIGN KEY([TouristicPointId])
REFERENCES [dbo].[TouristicPoints] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristicPointsCategory] CHECK CONSTRAINT [FK_TouristicPointsCategory_TouristicPoints_TouristicPointId]
GO
ALTER TABLE [dbo].[UserSessions]  WITH CHECK ADD  CONSTRAINT [FK_UserSessions_Persons_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[UserSessions] CHECK CONSTRAINT [FK_UserSessions_Persons_UserId]
GO
USE [master]
GO
ALTER DATABASE [Obligatorio1DA2] SET  READ_WRITE 
GO
