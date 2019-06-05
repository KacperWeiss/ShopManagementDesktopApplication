USE [master]
GO
/****** Object:  Database [studia_sklep]    Script Date: 21.05.2019 10:26:35 ******/
CREATE DATABASE [studia_sklep]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'studia_sklep', FILENAME = N'C:\Repos\Bazdy_Danych\studia_sklep.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'studia_sklep_log', FILENAME = N'C:\Repos\Bazdy_Danych\studia_sklep_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [studia_sklep] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [studia_sklep].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [studia_sklep] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [studia_sklep] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [studia_sklep] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [studia_sklep] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [studia_sklep] SET ARITHABORT OFF 
GO
ALTER DATABASE [studia_sklep] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [studia_sklep] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [studia_sklep] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [studia_sklep] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [studia_sklep] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [studia_sklep] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [studia_sklep] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [studia_sklep] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [studia_sklep] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [studia_sklep] SET  DISABLE_BROKER 
GO
ALTER DATABASE [studia_sklep] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [studia_sklep] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [studia_sklep] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [studia_sklep] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [studia_sklep] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [studia_sklep] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [studia_sklep] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [studia_sklep] SET RECOVERY FULL 
GO
ALTER DATABASE [studia_sklep] SET  MULTI_USER 
GO
ALTER DATABASE [studia_sklep] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [studia_sklep] SET DB_CHAINING OFF 
GO
ALTER DATABASE [studia_sklep] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [studia_sklep] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [studia_sklep] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'studia_sklep', N'ON'
GO
ALTER DATABASE [studia_sklep] SET QUERY_STORE = OFF
GO
USE [studia_sklep]
GO
/****** Object:  User [technik]    Script Date: 21.05.2019 10:26:35 ******/
CREATE USER [technik] FOR LOGIN [technik] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [sprzedawca]    Script Date: 21.05.2019 10:26:35 ******/
CREATE USER [sprzedawca] FOR LOGIN [sprzedawca] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [magazynier]    Script Date: 21.05.2019 10:26:35 ******/
CREATE USER [magazynier] FOR LOGIN [magazynier] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [administrator]    Script Date: 21.05.2019 10:26:35 ******/
CREATE USER [administrator] FOR LOGIN [administrator] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [technik_rola]    Script Date: 21.05.2019 10:26:35 ******/
CREATE ROLE [technik_rola]
GO
/****** Object:  DatabaseRole [sprzedawca_rola]    Script Date: 21.05.2019 10:26:35 ******/
CREATE ROLE [sprzedawca_rola]
GO
/****** Object:  DatabaseRole [magazynier_rola]    Script Date: 21.05.2019 10:26:35 ******/
CREATE ROLE [magazynier_rola]
GO
/****** Object:  DatabaseRole [administrator_rola]    Script Date: 21.05.2019 10:26:35 ******/
CREATE ROLE [administrator_rola]
GO
ALTER ROLE [technik_rola] ADD MEMBER [technik]
GO
ALTER ROLE [sprzedawca_rola] ADD MEMBER [sprzedawca]
GO
ALTER ROLE [magazynier_rola] ADD MEMBER [magazynier]
GO
ALTER ROLE [administrator_rola] ADD MEMBER [administrator]
GO
/****** Object:  Table [dbo].[graphics_cards]    Script Date: 21.05.2019 10:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[graphics_cards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[brand] [nvarchar](50) NOT NULL,
	[price] [decimal](7, 2) NOT NULL,
	[amount] [int] NULL,
	[image_source] [nvarchar](128) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_graphics_cards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cases]    Script Date: 21.05.2019 10:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[price] [decimal](7, 2) NOT NULL,
	[amount] [int] NULL,
	[image_source] [nvarchar](128) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_cases] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[motherboards]    Script Date: 21.05.2019 10:26:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[motherboards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[cpu_socket] [nvarchar](50) NOT NULL,
	[ram_memory_type] [nvarchar](50) NOT NULL,
	[ram_memory_slots] [int] NOT NULL,
	[price] [decimal](7, 2) NOT NULL,
	[amount] [int] NULL,
	[image_source] [nvarchar](128) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_motherboards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[processors]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[processors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[brand] [nvarchar](50) NOT NULL,
	[socket] [nvarchar](50) NOT NULL,
	[price] [decimal](7, 2) NOT NULL,
	[amount] [int] NULL,
	[image_source] [nvarchar](128) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_processors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ram_memories]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ram_memories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[capacity_gb] [int] NOT NULL,
	[price] [decimal](7, 2) NOT NULL,
	[amount] [int] NULL,
	[image_source] [nvarchar](128) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ram_memory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wholesalers]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wholesalers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company] [nvarchar](50) NULL,
 CONSTRAINT [PK_wholesalers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[warehouse_orders]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[warehouse_orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_wholesaler] [int] NOT NULL,
	[id_motherboard] [int] NULL,
	[motherboard_amount] [int] NULL,
	[id_processor] [int] NULL,
	[processor_amount] [int] NULL,
	[id_graphics_card] [int] NULL,
	[graphics_card_amount] [int] NULL,
	[id_case] [int] NULL,
	[case_amount] [int] NULL,
	[id_ram_memory] [int] NULL,
	[ram_memory_amount] [int] NULL,
	[additional_information] [nvarchar](500) NULL,
	[order_date] [datetime] NULL,
	[status] [smallint] NOT NULL,
	[order_price] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_warehouse_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[warehouse_order_view]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[warehouse_order_view]
AS
SELECT        dbo.warehouse_orders.status, dbo.warehouse_orders.order_date, dbo.warehouse_orders.additional_information, dbo.wholesalers.company, dbo.warehouse_orders.order_price, dbo.cases.model AS case_model, 
                         dbo.warehouse_orders.case_amount, dbo.cases.price AS case_price, dbo.graphics_cards.model AS graphics_card_model, dbo.warehouse_orders.graphics_card_amount, dbo.graphics_cards.price AS graphics_card_price, 
                         dbo.motherboards.model AS motherboard_model, dbo.warehouse_orders.motherboard_amount, dbo.motherboards.price AS motherboard_price, dbo.processors.model AS processor_model, 
                         dbo.warehouse_orders.processor_amount, dbo.processors.price AS processor_price, dbo.ram_memories.model AS ram_memory_model, dbo.warehouse_orders.ram_memory_amount, 
                         dbo.ram_memories.price AS rem_memory_price
FROM            dbo.warehouse_orders INNER JOIN
                         dbo.wholesalers ON dbo.warehouse_orders.id_wholesaler = dbo.wholesalers.id LEFT OUTER JOIN
                         dbo.cases ON dbo.warehouse_orders.id_case = dbo.cases.id LEFT OUTER JOIN
                         dbo.graphics_cards ON dbo.warehouse_orders.id_graphics_card = dbo.graphics_cards.id LEFT OUTER JOIN
                         dbo.motherboards ON dbo.warehouse_orders.id_motherboard = dbo.motherboards.id LEFT OUTER JOIN
                         dbo.processors ON dbo.warehouse_orders.id_processor = dbo.processors.id LEFT OUTER JOIN
                         dbo.ram_memories ON dbo.warehouse_orders.id_ram_memory = dbo.ram_memories.id
GO
/****** Object:  Table [dbo].[clients]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[city] [nvarchar](40) NOT NULL,
	[street] [nvarchar](40) NULL,
	[building_number] [nvarchar](7) NOT NULL,
	[apartment_number] [nvarchar](5) NULL,
	[post_code] [nchar](6) NOT NULL,
	[phone_number] [nvarchar](16) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[services]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service] [nvarchar](64) NOT NULL,
	[price] [decimal](7, 2) NULL,
 CONSTRAINT [PK_services] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[client_order_sets]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client_order_sets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_client] [int] NOT NULL,
	[id_motherboard] [int] NULL,
	[motherboard_amount] [int] NULL,
	[id_processor] [int] NULL,
	[processor_amount] [int] NULL,
	[id_graphics_card] [int] NULL,
	[graphics_card_amount] [int] NULL,
	[id_case] [int] NULL,
	[case_amount] [int] NULL,
	[id_ram_memory] [int] NULL,
	[ram_memory_amount] [int] NULL,
	[id_service] [int] NULL,
	[additional_information] [nvarchar](500) NULL,
	[order_date] [datetime] NULL,
	[status] [smallint] NOT NULL,
	[order_price] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_client_order_set] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[client_order_set_view]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[client_order_set_view]
AS
SELECT        dbo.client_order_sets.status, dbo.client_order_sets.order_date, dbo.client_order_sets.additional_information, dbo.client_order_sets.order_price, dbo.cases.model AS case_model, dbo.client_order_sets.case_amount, 
                         dbo.cases.price AS case_price, dbo.graphics_cards.model AS graphics_card_model, dbo.client_order_sets.graphics_card_amount, dbo.graphics_cards.price AS graphics_card_price, 
                         dbo.motherboards.model AS motherboard_model, dbo.client_order_sets.motherboard_amount, dbo.motherboards.price AS motherboard_price, dbo.processors.model AS processor_model, 
                         dbo.client_order_sets.processor_amount, dbo.processors.price AS processor_price, dbo.ram_memories.model AS ram_memory_model, dbo.client_order_sets.ram_memory_amount, 
                         dbo.ram_memories.price AS ram_memory_price, dbo.services.service, dbo.services.price AS service_price
FROM            dbo.client_order_sets INNER JOIN
                         dbo.clients ON dbo.client_order_sets.id_client = dbo.clients.id LEFT OUTER JOIN
                         dbo.graphics_cards ON dbo.client_order_sets.id_graphics_card = dbo.graphics_cards.id LEFT OUTER JOIN
                         dbo.motherboards ON dbo.client_order_sets.id_motherboard = dbo.motherboards.id LEFT OUTER JOIN
                         dbo.processors ON dbo.client_order_sets.id_processor = dbo.processors.id LEFT OUTER JOIN
                         dbo.ram_memories ON dbo.client_order_sets.id_ram_memory = dbo.ram_memories.id LEFT OUTER JOIN
                         dbo.services ON dbo.client_order_sets.id_service = dbo.services.id LEFT OUTER JOIN
                         dbo.cases ON dbo.client_order_sets.id_case = dbo.cases.id
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[activation_code] [nchar](20) NOT NULL,
	[access_level] [smallint] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 21.05.2019 10:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[access_level] [smallint] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [model_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [model_asc] ON [dbo].[cases]
(
	[model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [price_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [price_asc] ON [dbo].[cases]
(
	[price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [status_desc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [status_desc] ON [dbo].[client_order_sets]
(
	[status] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [city_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [city_asc] ON [dbo].[clients]
(
	[city] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [name_surname_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [name_surname_asc] ON [dbo].[clients]
(
	[name] ASC,
	[surname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [model_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [model_asc] ON [dbo].[graphics_cards]
(
	[model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [price_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [price_asc] ON [dbo].[graphics_cards]
(
	[price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [model_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [model_asc] ON [dbo].[motherboards]
(
	[model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [price_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [price_asc] ON [dbo].[motherboards]
(
	[price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [model_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [model_asc] ON [dbo].[processors]
(
	[model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [price_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [price_asc] ON [dbo].[processors]
(
	[price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [model_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [model_asc] ON [dbo].[ram_memories]
(
	[model] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [price_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [price_asc] ON [dbo].[ram_memories]
(
	[price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [price_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [price_asc] ON [dbo].[services]
(
	[price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [service_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [service_asc] ON [dbo].[services]
(
	[service] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [status_desc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [status_desc] ON [dbo].[warehouse_orders]
(
	[status] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [company_asc]    Script Date: 21.05.2019 10:26:36 ******/
CREATE NONCLUSTERED INDEX [company_asc] ON [dbo].[wholesalers]
(
	[company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[client_order_sets]  WITH CHECK ADD  CONSTRAINT [FK_client_order_sets_cases] FOREIGN KEY([id_case])
REFERENCES [dbo].[cases] ([id])
GO
ALTER TABLE [dbo].[client_order_sets] CHECK CONSTRAINT [FK_client_order_sets_cases]
GO
ALTER TABLE [dbo].[client_order_sets]  WITH CHECK ADD  CONSTRAINT [FK_client_order_sets_clients] FOREIGN KEY([id_client])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[client_order_sets] CHECK CONSTRAINT [FK_client_order_sets_clients]
GO
ALTER TABLE [dbo].[client_order_sets]  WITH CHECK ADD  CONSTRAINT [FK_client_order_sets_graphics_cards] FOREIGN KEY([id_graphics_card])
REFERENCES [dbo].[graphics_cards] ([id])
GO
ALTER TABLE [dbo].[client_order_sets] CHECK CONSTRAINT [FK_client_order_sets_graphics_cards]
GO
ALTER TABLE [dbo].[client_order_sets]  WITH CHECK ADD  CONSTRAINT [FK_client_order_sets_motherboards] FOREIGN KEY([id_motherboard])
REFERENCES [dbo].[motherboards] ([id])
GO
ALTER TABLE [dbo].[client_order_sets] CHECK CONSTRAINT [FK_client_order_sets_motherboards]
GO
ALTER TABLE [dbo].[client_order_sets]  WITH CHECK ADD  CONSTRAINT [FK_client_order_sets_processors] FOREIGN KEY([id_processor])
REFERENCES [dbo].[processors] ([id])
GO
ALTER TABLE [dbo].[client_order_sets] CHECK CONSTRAINT [FK_client_order_sets_processors]
GO
ALTER TABLE [dbo].[client_order_sets]  WITH CHECK ADD  CONSTRAINT [FK_client_order_sets_ram_memories] FOREIGN KEY([id_ram_memory])
REFERENCES [dbo].[ram_memories] ([id])
GO
ALTER TABLE [dbo].[client_order_sets] CHECK CONSTRAINT [FK_client_order_sets_ram_memories]
GO
ALTER TABLE [dbo].[client_order_sets]  WITH CHECK ADD  CONSTRAINT [FK_client_order_sets_services] FOREIGN KEY([id_service])
REFERENCES [dbo].[services] ([id])
GO
ALTER TABLE [dbo].[client_order_sets] CHECK CONSTRAINT [FK_client_order_sets_services]
GO
ALTER TABLE [dbo].[warehouse_orders]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_orders_cases] FOREIGN KEY([id_case])
REFERENCES [dbo].[cases] ([id])
GO
ALTER TABLE [dbo].[warehouse_orders] CHECK CONSTRAINT [FK_warehouse_orders_cases]
GO
ALTER TABLE [dbo].[warehouse_orders]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_orders_graphics_cards] FOREIGN KEY([id_graphics_card])
REFERENCES [dbo].[graphics_cards] ([id])
GO
ALTER TABLE [dbo].[warehouse_orders] CHECK CONSTRAINT [FK_warehouse_orders_graphics_cards]
GO
ALTER TABLE [dbo].[warehouse_orders]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_orders_motherboards] FOREIGN KEY([id_motherboard])
REFERENCES [dbo].[motherboards] ([id])
GO
ALTER TABLE [dbo].[warehouse_orders] CHECK CONSTRAINT [FK_warehouse_orders_motherboards]
GO
ALTER TABLE [dbo].[warehouse_orders]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_orders_processors] FOREIGN KEY([id_processor])
REFERENCES [dbo].[processors] ([id])
GO
ALTER TABLE [dbo].[warehouse_orders] CHECK CONSTRAINT [FK_warehouse_orders_processors]
GO
ALTER TABLE [dbo].[warehouse_orders]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_orders_ram_memories] FOREIGN KEY([id_ram_memory])
REFERENCES [dbo].[ram_memories] ([id])
GO
ALTER TABLE [dbo].[warehouse_orders] CHECK CONSTRAINT [FK_warehouse_orders_ram_memories]
GO
ALTER TABLE [dbo].[warehouse_orders]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_orders_wholesalers] FOREIGN KEY([id_wholesaler])
REFERENCES [dbo].[wholesalers] ([id])
GO
ALTER TABLE [dbo].[warehouse_orders] CHECK CONSTRAINT [FK_warehouse_orders_wholesalers]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[46] 4[15] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "client_order_sets"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 355
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "clients"
            Begin Extent = 
               Top = 6
               Left = 286
               Bottom = 236
               Right = 477
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "graphics_cards"
            Begin Extent = 
               Top = 6
               Left = 515
               Bottom = 188
               Right = 685
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "motherboards"
            Begin Extent = 
               Top = 6
               Left = 723
               Bottom = 226
               Right = 912
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "processors"
            Begin Extent = 
               Top = 6
               Left = 950
               Bottom = 206
               Right = 1120
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ram_memories"
            Begin Extent = 
               Top = 192
               Left = 517
               Bottom = 391
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "services"
            Begin Extent = 
               Top = 258
               Left = 289
               Bottom = 371
               Right = 459
            End
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'client_order_set_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'         DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cases"
            Begin Extent = 
               Top = 210
               Left = 950
               Bottom = 375
               Right = 1120
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 1110
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'client_order_set_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'client_order_set_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[46] 4[19] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "warehouse_orders"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 348
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "wholesalers"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 102
               Right = 455
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cases"
            Begin Extent = 
               Top = 6
               Left = 493
               Bottom = 174
               Right = 663
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "graphics_cards"
            Begin Extent = 
               Top = 6
               Left = 701
               Bottom = 187
               Right = 871
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "motherboards"
            Begin Extent = 
               Top = 6
               Left = 909
               Bottom = 222
               Right = 1098
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "processors"
            Begin Extent = 
               Top = 114
               Left = 303
               Bottom = 311
               Right = 473
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ram_memories"
            Begin Extent = 
               Top = 191
               Left = 503
               Bottom = 389
               Right = 673
            End
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'warehouse_order_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'         DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'warehouse_order_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'warehouse_order_view'
GO
USE [master]
GO
ALTER DATABASE [studia_sklep] SET  READ_WRITE 
GO
