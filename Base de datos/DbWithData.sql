USE [master]
GO
/****** Object:  Database [Obligatorio1DA2]    Script Date: 26/11/2020 16:28:00 ******/
CREATE DATABASE [Obligatorio1DA2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Obligatorio1DA2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Obligatorio1DA2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Obligatorio1DA2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Obligatorio1DA2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/11/2020 16:28:00 ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 26/11/2020 16:28:00 ******/
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
/****** Object:  Table [dbo].[Lodgings]    Script Date: 26/11/2020 16:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lodgings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TouristicPointId] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Direction] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Stars] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Images] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Capacity] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Score] [float] NOT NULL,
 CONSTRAINT [PK_Lodgings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 26/11/2020 16:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[PersonType] [int] NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 26/11/2020 16:28:00 ******/
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
/****** Object:  Table [dbo].[Reservations]    Script Date: 26/11/2020 16:28:00 ******/
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
/****** Object:  Table [dbo].[Reviews]    Script Date: 26/11/2020 16:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Score] [int] NOT NULL,
	[ClientId] [int] NULL,
	[ReservationId] [int] NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 26/11/2020 16:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristicPoints]    Script Date: 26/11/2020 16:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristicPoints](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[RegionId] [int] NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_TouristicPoints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristicPointsCategory]    Script Date: 26/11/2020 16:28:00 ******/
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
/****** Object:  Table [dbo].[UserSessions]    Script Date: 26/11/2020 16:28:00 ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201123182821_InitialMigration', N'3.1.8')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Ciudades')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Pueblos')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Areas protegidas')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Playas')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Etc')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Lodgings] ON 

INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (1, N'Casa Mara', 1, N'Rancho en la playa', N'Calle de la cruz 123', N'098259045', 2, 40.5, N'\images\casaMara.jpg', 0, 1, CAST(N'2020-11-26T16:26:36.1166667' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (2, N'El Sol', 2, N'Casita en la playa El Barco', N'calle 1', N'091657314', 3, 45, N'\images\elSol.jpg', 0, 1, CAST(N'2020-11-26T16:26:36.1166667' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (3, N'Radisson Hotel', 3, N'Hotel 5 estrellas ubicado en las afueras de Colonia', N'Calle La Esperanza 343', N'091677842', 5, 1000, N'\images\radissonColonia.jpg', 0, 0, CAST(N'2020-11-26T16:26:36.1166667' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (4, N'Apart Hotel Aguasol', 4, N'A 10 km de Salto, y ofrece jardín y conexión WiFi gratuita.', N'calle de la cruz 123', N'098259045', 2, 250.5, N'\images\aguasol.jpg', 0, 0, CAST(N'2020-11-26T16:26:36.1166667' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (5, N'Hostel Compay', 9, N'Hostel con buenas vibras', N'26 de marzo 220', N'098252245', 2, 15, N'\images\compay.jpg', 0, 0, CAST(N'2020-11-26T16:26:36.1166667' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (6, N'Chacra La Esmaralda', 5, N'Spa y Resort', N'camino de las chacras', N'098252245', 2, 100, N'\images\chacra.jpg', 0, 1, CAST(N'2020-11-26T16:26:36.1200000' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (7, N'Hotel El Burgo', 6, N'Hotel de Paso', N'Ruta 110 km 210', N'098252245', 2, 20, N'\images\elBurgo.jpg', 0, 0, CAST(N'2020-11-26T16:26:36.1200000' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (8, N'Hotel lo de Feli', 7, N'La casa de Felipe', N'18 de julio 112', N'098123345', 2, 34, N'\images\loDeFeli.jpg', 0, 1, CAST(N'2020-11-26T16:26:36.1200000' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (9, N'Cabañas Quebradas', 8, N'Cabaña nativa', N'al costado de la quebrada', N'59898252245', 2, 10.5, N'\images\cabanas_quebradas.jpg', 0, 1, CAST(N'2020-10-29T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Lodgings] ([Id], [Name], [TouristicPointId], [Description], [Direction], [Phone], [Stars], [Price], [Images], [IsDeleted], [Capacity], [CreatedDate], [Score]) VALUES (10, N'Rancho El Aguila', 8, N'Rancho El Aguila', N'en el camino de la quebrada', N'09655440', 2, 30, N'\images\elAguila.jpg', 0, 1, CAST(N'2020-11-26T16:26:36.1200000' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Lodgings] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [Name], [Surname], [Mail], [PersonType], [Password]) VALUES (1, N'Admin', N'', N'admin@g.com', 2, N'admin')
INSERT [dbo].[Persons] ([Id], [Name], [Surname], [Mail], [PersonType], [Password]) VALUES (2, N'Admin2', N'', N'admin2@g.com', 2, N'admin2')
INSERT [dbo].[Persons] ([Id], [Name], [Surname], [Mail], [PersonType], [Password]) VALUES (3, N'Jose', N'Hernandez', N'jh@hotmail.com', 1, NULL)
INSERT [dbo].[Persons] ([Id], [Name], [Surname], [Mail], [PersonType], [Password]) VALUES (4, N'Laura', N'Fernandez', N'lau.f@gmail.com', 1, NULL)
INSERT [dbo].[Persons] ([Id], [Name], [Surname], [Mail], [PersonType], [Password]) VALUES (5, N'Pepe', N'Gomez', N'pepe@hotmail.com', 1, NULL)
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
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([Id], [Code], [LodgingId], [ClientId], [CheckIn], [CheckOut], [StateId], [StateDescription], [Price]) VALUES (1, N'b46f3fd5-398d-4499-b6f7-7bed9a016899', 2, 3, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), CAST(N'2020-10-12T00:00:00.0000000' AS DateTime2), 3, N'Aceptada', 90)
INSERT [dbo].[Reservations] ([Id], [Code], [LodgingId], [ClientId], [CheckIn], [CheckOut], [StateId], [StateDescription], [Price]) VALUES (2, N'f836048e-049f-4cd2-bef1-3c7e6f3fca5c', 8, 4, CAST(N'2020-12-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-31T00:00:00.0000000' AS DateTime2), 4, N'Rechazada por falta de fondos en tarjeta', 45)
INSERT [dbo].[Reservations] ([Id], [Code], [LodgingId], [ClientId], [CheckIn], [CheckOut], [StateId], [StateDescription], [Price]) VALUES (3, N'95806721-7d5a-4e46-9eab-69c2f1cd13cd', 2, 5, CAST(N'2020-11-25T00:00:00.0000000' AS DateTime2), CAST(N'2020-11-28T00:00:00.0000000' AS DateTime2), 3, N'Aceptada', 30)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [Description], [Score], [ClientId], [ReservationId]) VALUES (1, N'Espectacular para una escapada de fin de semana! Recomendado.', 4, 3, 1)
INSERT [dbo].[Reviews] ([Id], [Description], [Score], [ClientId], [ReservationId]) VALUES (2, N'Excelente atencion!!', 4, 3, 2)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id], [Name]) VALUES (1, N'Creada')
INSERT [dbo].[State] ([Id], [Name]) VALUES (2, N'Pendiente Pago')
INSERT [dbo].[State] ([Id], [Name]) VALUES (3, N'Aceptada')
INSERT [dbo].[State] ([Id], [Name]) VALUES (4, N'Rechazada')
INSERT [dbo].[State] ([Id], [Name]) VALUES (5, N'Expirada')
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[TouristicPoints] ON 

INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (1, N'Punta del Este', N'Balneario de playa', 3, N'\images\pde.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (2, N'La Paloma', N'Balneario de playa', 3, N'\images\paloma.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (3, N'Colonia', N'Pueblo Colonial', 1, N'\images\colonia.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (4, N'Termas del Daymán', N'Fuente termal', 5, N'\images\termas.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (5, N'Villa Soriano', N'Pueblo Colonial', 5, N'\images\villa_soriano.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (6, N'Artigas', N'Ciudad capital de artigas', 4, N'\images\artigas.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (7, N'Melo', N'Ciudad capital de Cerro Largo', 3, N'\images\melo.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (8, N'Quebrada de los Cuervos', N' Paisaje Protegido de Uruguay', 2, N'\images\quebrada.jpg')
INSERT [dbo].[TouristicPoints] ([Id], [Name], [Description], [RegionId], [Image]) VALUES (9, N'Montevideo', N'Capital de Uruguay', 1, N'\images\montevideo.jpg')
SET IDENTITY_INSERT [dbo].[TouristicPoints] OFF
GO
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (1, 1)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (2, 1)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (3, 1)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (6, 1)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (7, 1)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (9, 1)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (5, 2)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (3, 3)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (4, 3)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (5, 3)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (8, 3)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (1, 4)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (2, 4)
INSERT [dbo].[TouristicPointsCategory] ([TouristicPointId], [CategoryId]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[UserSessions] ON 

INSERT [dbo].[UserSessions] ([Id], [Token], [UserId], [ConnectedAt]) VALUES (1, N'6F9619FF-8B86-D011-B42D-00C04FC964FF', 1, CAST(N'2020-10-14T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UserSessions] OFF
GO
/****** Object:  Index [IX_Lodgings_TouristicPointId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_Lodgings_TouristicPointId] ON [dbo].[Lodgings]
(
	[TouristicPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_ClientId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_ClientId] ON [dbo].[Reservations]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_LodgingId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_LodgingId] ON [dbo].[Reservations]
(
	[LodgingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_StateId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_StateId] ON [dbo].[Reservations]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_ClientId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_ClientId] ON [dbo].[Reviews]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_ReservationId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_ReservationId] ON [dbo].[Reviews]
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TouristicPoints_RegionId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_TouristicPoints_RegionId] ON [dbo].[TouristicPoints]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TouristicPointsCategory_CategoryId]    Script Date: 26/11/2020 16:28:00 ******/
CREATE NONCLUSTERED INDEX [IX_TouristicPointsCategory_CategoryId] ON [dbo].[TouristicPointsCategory]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserSessions_UserId]    Script Date: 26/11/2020 16:28:00 ******/
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
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Persons_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Persons_ClientId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Reservations_ReservationId] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservations] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Reservations_ReservationId]
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
