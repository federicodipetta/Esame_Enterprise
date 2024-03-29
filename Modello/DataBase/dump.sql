USE [master]
GO
/****** Object:  Database [LibriApplication]    Script Date: 03/03/2024 18:59:09 ******/
CREATE DATABASE [LibriApplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibriApplication', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LibriApplication.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibriApplication_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LibriApplication_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LibriApplication] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibriApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibriApplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibriApplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibriApplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibriApplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibriApplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibriApplication] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibriApplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibriApplication] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibriApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibriApplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibriApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibriApplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibriApplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibriApplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibriApplication] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibriApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibriApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibriApplication] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibriApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibriApplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibriApplication] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibriApplication] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibriApplication] SET RECOVERY FULL 
GO
ALTER DATABASE [LibriApplication] SET  MULTI_USER 
GO
ALTER DATABASE [LibriApplication] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibriApplication] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibriApplication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibriApplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibriApplication] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibriApplication] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibriApplication', N'ON'
GO
ALTER DATABASE [LibriApplication] SET QUERY_STORE = ON
GO
ALTER DATABASE [LibriApplication] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LibriApplication]
GO
/****** Object:  Table [dbo].[Autore]    Script Date: 03/03/2024 18:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autore](
	[nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Autore] PRIMARY KEY CLUSTERED 
(
	[nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutoreLibro]    Script Date: 03/03/2024 18:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoreLibro](
	[autorinome] [varchar](100) NOT NULL,
	[libriid] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AutoreLibro] PRIMARY KEY CLUSTERED 
(
	[autorinome] ASC,
	[libriid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 03/03/2024 18:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaLibro]    Script Date: 03/03/2024 18:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaLibro](
	[libriid] [varchar](50) NOT NULL,
	[categorienome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CategoriaLibro] PRIMARY KEY CLUSTERED 
(
	[libriid] ASC,
	[categorienome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 03/03/2024 18:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[id] [varchar](50) NOT NULL,
	[titolo] [varchar](700) NULL,
	[editore] [varchar](50) NULL,
	[anno] [varchar](50) NULL,
	[descrizione] [varchar](max) NULL,
	[img] [varchar](400) NULL,
	[isbn] [varchar](50) NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recensione]    Script Date: 03/03/2024 18:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recensione](
	[idLibro] [varchar](50) NOT NULL,
	[idUtente] [int] NOT NULL,
	[recensione] [varchar](max) NULL,
	[voto] [int] NULL,
	[stato] [int] NOT NULL,
	[periodo] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Recensione] PRIMARY KEY CLUSTERED 
(
	[idLibro] ASC,
	[idUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 03/03/2024 18:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[password] [varchar](256) NULL,
	[salt] [varchar](256) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AutoreLibro]  WITH CHECK ADD  CONSTRAINT [FK_AutoreLibro_AutoreLibro] FOREIGN KEY([autorinome])
REFERENCES [dbo].[Autore] ([nome])
GO
ALTER TABLE [dbo].[AutoreLibro] CHECK CONSTRAINT [FK_AutoreLibro_AutoreLibro]
GO
ALTER TABLE [dbo].[AutoreLibro]  WITH CHECK ADD  CONSTRAINT [FK_AutoreLibro_Libro] FOREIGN KEY([libriid])
REFERENCES [dbo].[Libro] ([id])
GO
ALTER TABLE [dbo].[AutoreLibro] CHECK CONSTRAINT [FK_AutoreLibro_Libro]
GO
ALTER TABLE [dbo].[CategoriaLibro]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaLibro_Categoria] FOREIGN KEY([categorienome])
REFERENCES [dbo].[Categoria] ([nome])
GO
ALTER TABLE [dbo].[CategoriaLibro] CHECK CONSTRAINT [FK_CategoriaLibro_Categoria]
GO
ALTER TABLE [dbo].[CategoriaLibro]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaLibro_Libro] FOREIGN KEY([libriid])
REFERENCES [dbo].[Libro] ([id])
GO
ALTER TABLE [dbo].[CategoriaLibro] CHECK CONSTRAINT [FK_CategoriaLibro_Libro]
GO
ALTER TABLE [dbo].[Recensione]  WITH CHECK ADD  CONSTRAINT [FK_Recensione_Libro] FOREIGN KEY([idLibro])
REFERENCES [dbo].[Libro] ([id])
GO
ALTER TABLE [dbo].[Recensione] CHECK CONSTRAINT [FK_Recensione_Libro]
GO
ALTER TABLE [dbo].[Recensione]  WITH CHECK ADD  CONSTRAINT [FK_Recensione_Utente] FOREIGN KEY([idUtente])
REFERENCES [dbo].[Utente] ([id])
GO
ALTER TABLE [dbo].[Recensione] CHECK CONSTRAINT [FK_Recensione_Utente]
GO
USE [master]
GO
ALTER DATABASE [LibriApplication] SET  READ_WRITE 
GO
