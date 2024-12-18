USE [master]
GO
/****** Object:  Database [Fitpas]    Script Date: 7/13/2024 8:14:57 AM ******/
CREATE DATABASE [Fitpas]

GO
ALTER DATABASE [Fitpas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fitpas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fitpas] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [Fitpas] SET ANSI_NULLS ON 
GO
ALTER DATABASE [Fitpas] SET ANSI_PADDING ON 
GO
ALTER DATABASE [Fitpas] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [Fitpas] SET ARITHABORT ON 
GO
ALTER DATABASE [Fitpas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fitpas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fitpas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fitpas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fitpas] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [Fitpas] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [Fitpas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fitpas] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [Fitpas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fitpas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fitpas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fitpas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fitpas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fitpas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fitpas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fitpas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fitpas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fitpas] SET RECOVERY FULL 
GO
ALTER DATABASE [Fitpas] SET  MULTI_USER 
GO
ALTER DATABASE [Fitpas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fitpas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fitpas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fitpas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fitpas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fitpas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Fitpas] SET QUERY_STORE = OFF
GO
USE [Fitpas]
GO
/****** Object:  Table [dbo].[Clanarina]    Script Date: 7/13/2024 8:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clanarina](
	[idClanarine] [int] IDENTITY(1,1) NOT NULL,
	[datumOd] [datetime] NOT NULL,
	[idKorisnika] [int] NOT NULL,
	[idPaketa] [int] NOT NULL,
	[idKategorije] [int] NOT NULL,
	[datumDo] [datetime] NOT NULL,
	[cena] [int] NOT NULL,
 CONSTRAINT [PK_Clanarina] PRIMARY KEY CLUSTERED 
(
	[idClanarine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategorija]    Script Date: 7/13/2024 8:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorija](
	[idKategorije] [int] IDENTITY(1,1) NOT NULL,
	[imeKategorije] [varchar](50) NOT NULL,
	[kolicinaPopusta] [int] NOT NULL,
 CONSTRAINT [PK_Kategorija] PRIMARY KEY CLUSTERED 
(
	[idKategorije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 7/13/2024 8:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[idKorisnika] [int] IDENTITY(1,1) NOT NULL,
	[datumRodjenja] [datetime] NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[prezime] [varchar](50) NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[idKorisnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paket]    Script Date: 7/13/2024 8:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paket](
	[idPaketa] [int] IDENTITY(1,1) NOT NULL,
	[imePaketa] [varchar](50) NOT NULL,
	[cena] [int] NOT NULL,
 CONSTRAINT [PK_Paket] PRIMARY KEY CLUSTERED 
(
	[idPaketa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paket-Teretana]    Script Date: 7/13/2024 8:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paket-Teretana](
	[idPaketa] [int] NOT NULL,
	[idTeretane] [int] NOT NULL,
 CONSTRAINT [PK_Paket-Teretana] PRIMARY KEY CLUSTERED 
(
	[idPaketa] ASC,
	[idTeretane] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teretana]    Script Date: 7/13/2024 8:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teretana](
	[idTeretane] [int] IDENTITY(1,1) NOT NULL,
	[imeTeretane] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Teretana] PRIMARY KEY CLUSTERED 
(
	[idTeretane] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/13/2024 8:14:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[ime] [varchar](50) NULL,
	[prezime] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clanarina] ON 

INSERT [dbo].[Clanarina] ([idClanarine], [datumOd], [idKorisnika], [idPaketa], [idKategorije], [datumDo], [cena]) VALUES (8013, CAST(N'2024-07-05T21:48:05.000' AS DateTime), 12019, 2, 1, CAST(N'2024-08-04T21:48:05.000' AS DateTime), 4000)
INSERT [dbo].[Clanarina] ([idClanarine], [datumOd], [idKorisnika], [idPaketa], [idKategorije], [datumDo], [cena]) VALUES (8014, CAST(N'2024-07-08T08:57:24.000' AS DateTime), 12012, 2, 1, CAST(N'2024-08-07T08:57:24.000' AS DateTime), 4000)
SET IDENTITY_INSERT [dbo].[Clanarina] OFF
GO
SET IDENTITY_INSERT [dbo].[Kategorija] ON 

INSERT [dbo].[Kategorija] ([idKategorije], [imeKategorije], [kolicinaPopusta]) VALUES (1, N'Student', 20)
INSERT [dbo].[Kategorija] ([idKategorije], [imeKategorije], [kolicinaPopusta]) VALUES (3, N'Srednjoškolac', 25)
INSERT [dbo].[Kategorija] ([idKategorije], [imeKategorije], [kolicinaPopusta]) VALUES (4, N'Porodica zaposlenog', 30)
INSERT [dbo].[Kategorija] ([idKategorije], [imeKategorije], [kolicinaPopusta]) VALUES (5, N'Zaposleni', 70)
INSERT [dbo].[Kategorija] ([idKategorije], [imeKategorije], [kolicinaPopusta]) VALUES (6, N'Regular', 0)
SET IDENTITY_INSERT [dbo].[Kategorija] OFF
GO
SET IDENTITY_INSERT [dbo].[Korisnik] ON 

INSERT [dbo].[Korisnik] ([idKorisnika], [datumRodjenja], [ime], [prezime]) VALUES (12012, CAST(N'1999-07-03T11:20:17.000' AS DateTime), N'Teodora', N'Todorovic')
INSERT [dbo].[Korisnik] ([idKorisnika], [datumRodjenja], [ime], [prezime]) VALUES (12013, CAST(N'2001-07-03T11:20:40.000' AS DateTime), N'Jovana', N'Jovic')
INSERT [dbo].[Korisnik] ([idKorisnika], [datumRodjenja], [ime], [prezime]) VALUES (12014, CAST(N'2024-07-03T11:20:58.000' AS DateTime), N'Ognjen', N'Dimitrov')
INSERT [dbo].[Korisnik] ([idKorisnika], [datumRodjenja], [ime], [prezime]) VALUES (12016, CAST(N'2001-08-26T14:12:10.000' AS DateTime), N'Andrej', N'Krkic')
INSERT [dbo].[Korisnik] ([idKorisnika], [datumRodjenja], [ime], [prezime]) VALUES (12019, CAST(N'2024-07-05T21:46:15.000' AS DateTime), N'pavle', N'lalic')
SET IDENTITY_INSERT [dbo].[Korisnik] OFF
GO
SET IDENTITY_INSERT [dbo].[Paket] ON 

INSERT [dbo].[Paket] ([idPaketa], [imePaketa], [cena]) VALUES (2, N'Zlatni Paket', 5000)
INSERT [dbo].[Paket] ([idPaketa], [imePaketa], [cena]) VALUES (3003, N'Dorcol', 6000)
INSERT [dbo].[Paket] ([idPaketa], [imePaketa], [cena]) VALUES (6004, N'Zemun', 2000)
INSERT [dbo].[Paket] ([idPaketa], [imePaketa], [cena]) VALUES (6005, N'banjica', 3455)
INSERT [dbo].[Paket] ([idPaketa], [imePaketa], [cena]) VALUES (6006, N'Vozdovac', 2000)
INSERT [dbo].[Paket] ([idPaketa], [imePaketa], [cena]) VALUES (7005, N'Srebrni paket', 4000)
SET IDENTITY_INSERT [dbo].[Paket] OFF
GO
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (2, 12112)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (2, 12115)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (6004, 16113)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (6005, 12114)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (6005, 12115)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (6006, 14112)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (7005, 12114)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (7005, 12115)
INSERT [dbo].[Paket-Teretana] ([idPaketa], [idTeretane]) VALUES (7005, 12116)
GO
SET IDENTITY_INSERT [dbo].[Teretana] ON 

INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (12112, N'Iron-blok 44')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (12113, N'Kocovic-blok 44')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (12114, N'Sparta')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (12115, N'Ahilej-studenjak')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (12116, N'Komando')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (12117, N'Ahilej-Dorcol')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (12118, N'25. maj')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (14112, N'NonStop autokomanda')
INSERT [dbo].[Teretana] ([idTeretane], [imeTeretane]) VALUES (16113, N'NonStopZemun')
SET IDENTITY_INSERT [dbo].[Teretana] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [username], [password], [ime], [prezime]) VALUES (1, N'milan', N'milan', N'milan', N'kaurin')
INSERT [dbo].[User] ([id], [username], [password], [ime], [prezime]) VALUES (2, N'taca', N'taca', N'tatjana', N'stojanovic')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Clanarina]  WITH CHECK ADD  CONSTRAINT [FK_Clanarina_Kategorija] FOREIGN KEY([idKategorije])
REFERENCES [dbo].[Kategorija] ([idKategorije])
GO
ALTER TABLE [dbo].[Clanarina] CHECK CONSTRAINT [FK_Clanarina_Kategorija]
GO
ALTER TABLE [dbo].[Clanarina]  WITH CHECK ADD  CONSTRAINT [FK_Clanarina_Korisnik] FOREIGN KEY([idKorisnika])
REFERENCES [dbo].[Korisnik] ([idKorisnika])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clanarina] CHECK CONSTRAINT [FK_Clanarina_Korisnik]
GO
ALTER TABLE [dbo].[Clanarina]  WITH CHECK ADD  CONSTRAINT [FK_Clanarina_Paket] FOREIGN KEY([idPaketa])
REFERENCES [dbo].[Paket] ([idPaketa])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Clanarina] CHECK CONSTRAINT [FK_Clanarina_Paket]
GO
ALTER TABLE [dbo].[Paket-Teretana]  WITH CHECK ADD  CONSTRAINT [FK_Paket-Teretana_Paket] FOREIGN KEY([idPaketa])
REFERENCES [dbo].[Paket] ([idPaketa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Paket-Teretana] CHECK CONSTRAINT [FK_Paket-Teretana_Paket]
GO
ALTER TABLE [dbo].[Paket-Teretana]  WITH CHECK ADD  CONSTRAINT [FK_Paket-Teretana_Teretana] FOREIGN KEY([idTeretane])
REFERENCES [dbo].[Teretana] ([idTeretane])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Paket-Teretana] CHECK CONSTRAINT [FK_Paket-Teretana_Teretana]
GO
USE [master]
GO
ALTER DATABASE [Fitpas] SET  READ_WRITE 
GO
