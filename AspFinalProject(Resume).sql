USE [master]
GO
/****** Object:  Database [MyCV]    Script Date: 5/31/2019 9:24:14 PM ******/
CREATE DATABASE [MyCV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyCV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MyCV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyCV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MyCV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MyCV] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyCV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyCV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyCV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyCV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyCV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyCV] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyCV] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyCV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyCV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyCV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyCV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyCV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyCV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyCV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyCV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyCV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyCV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyCV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyCV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyCV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyCV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyCV] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MyCV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyCV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyCV] SET  MULTI_USER 
GO
ALTER DATABASE [MyCV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyCV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyCV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyCV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyCV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyCV] SET QUERY_STORE = OFF
GO
USE [MyCV]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/31/2019 9:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AcademicBackgrounds]    Script Date: 5/31/2019 9:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicBackgrounds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Qualification] [nvarchar](max) NULL,
	[Degree] [nvarchar](max) NULL,
	[UniversityName] [nvarchar](max) NULL,
	[YearOfObtention] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[imgPathAc] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.AcademicBackgrounds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/31/2019 9:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 5/31/2019 9:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FromEmail] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[SendingDate] [datetime] NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[isAnswered] [bit] NOT NULL,
	[isRead] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorHistories]    Script Date: 5/31/2019 9:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](max) NULL,
	[ControllerName] [nvarchar](max) NULL,
	[ActionName] [nvarchar](max) NULL,
	[ErrorCode] [int] NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.ErrorHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 5/31/2019 9:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Age] [int] NOT NULL,
	[Location] [nvarchar](max) NULL,
	[Experience] [nvarchar](max) NULL,
	[Degree] [nvarchar](max) NULL,
	[CareerLevel] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[imgPath] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessionalExperiences]    Script Date: 5/31/2019 9:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessionalExperiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobTitle] [nvarchar](max) NULL,
	[CompanyName] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[Duration] [nvarchar](max) NULL,
	[imgPath] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.ProfessionalExperiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 5/31/2019 9:24:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[YourDescription] [nvarchar](max) NULL,
	[SkillLevel] [int] NULL,
	[SkillDescription] [nvarchar](max) NULL,
	[DisplayAsBar] [bit] NULL,
	[DisplayAsTag] [bit] NULL,
	[TypeOfSkill] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialProfiles]    Script Date: 5/31/2019 9:24:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialProfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Facebook] [nvarchar](max) NULL,
	[Google] [nvarchar](max) NULL,
	[Skype] [nvarchar](max) NULL,
	[LinkIN] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.SocialProfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfSkills]    Script Date: 5/31/2019 9:24:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedId] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedId] [int] NULL,
 CONSTRAINT [PK_dbo.TypeOfSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201905311319159_initial', N'AspFinalProject.Migrations.Configuration', 0x1F8B0800000000000400ED5CDB72E3B8117D4F55FE41A5A7A46AD6B43D2FC994BC5B1AD9DE4C321E3B23CFA6F20851908C98041512F45ADF96877C527E21E01D3792006F6B7B505335653588D300883EDD049BFDBFFFFC77F1D3B3EFCD9E6018A1005FCCCF4E4EE73388DD608BF0FE621E93DD0F7F9AFFF4E3EF7FB7B8DAFACFB35F8AEBDE27D7D19E38BA983F1072F8E03891FB007D109DF8C80D8328D8911337F01DB00D9CF3D3D33F3B67670EA410738A359B2DBEC698201FA63FE8CF55805D782031F06E822DF4A25C4E5BD629EAEC0BF06174002EBC982FA3C335C2C0BB0B837F41979C643DE6B3A587001DCD1A7ABBF90C601C1040E8583F7C8BE09A8401DEAF0F5400BCFBE301D2EB76C08B603E870FD5E5BAD3393D4FA6E3541D0B28378E48E01B029EBDCFD7C711BB775AE579B97E7405AFE84A936332EB7415E902BA600B69FF8FC07DDC87418CB7F399A8F6C3CA0B932E75CB7D92A19EC858EF66428F77E5AEA19B2BF9F76EB68A3D1287F002C39884C07B37BB8B371E72FF068FF7C123C41738F63C760E7416B48D135011C53FC0901CBFC25D3EB34F74260EDFCF113B96DD983ED94C3F61F2FE7C3EFB4295838D07CB2DC2ACCA9A0421FC1962180202B777801018E20403A6CB21691774FD9D6E70B4436E7E6733B57473525B9BCF6EC0F36788F7E4E1624EFF9CCFAED133DC16927C28DF30A2A6493B9130866DDA2EE13E84707435F4E2943EC831F93DBABA7F4210DEEE6E372459F24956910094F0CBC87A90BFA7FBE961E98EAE6915C264F75ED2FF0A5DC9DFF7C8D7ED2AD94C732F4A1974D777D358F4355479093DD8718E79D746850BA762D546AE5D51A5FB203C7667D802C1F26ABDAE4988C79ACD84661360025CD2C36A32006B34F5BA685C1C4E6238D761E05FF9D4898EAE691D6F929B3CBA9E1B1845603FFECAAD214E9EC3D4E6286D8D66AC258E7E85E1F8614C942982E54EFE18041E04D878C028FA0A416F146D46D3E6A6AB300CC2BF20CA4B7DDC3A8B6259AA61DB52D7398D7BA71E230C3C6F22525CBAC9EA4CA22ADD6A2B7AB9512890F69A8AE86C6C355D6C7547A925796EEECA5C597FCB59F5BAAE29F43424B2176DDAD03B7E0E263A8BBA7AA6BF10C4EEF88B32D1B1D70A502DE167F804C78F6BA7899EAF13949175DC3D0478FC7BF30FB88910195F4F7E6637FEAA8128FA3508B7D60FBF253F1C063B1A5E51F6051E4B8F9DFDB212CFFAE97A5D7F0D36F78878533C5BF80780A7793F32994B9FEAC5C8651C4E33A1A9D8DC92EC7424BB7E445EB247BB926AD6DF9268BDAE695EFA067178092337448749A820BDED5C6CAFB5EBD36E538EF31245070F1C97D147501EED9627A59A5DEFC1DEB06B72F1ED2E9DEC048F59C50B54CBCA6F87950317A55CBA431EECC3CE1C8E65E97A5DD7C0859B20781CDD8C7E0E82FD0411F5FA91E28F1F4B23FCF8E98BA59E37443D9CEFEACA3B0C88259D7A5D362DE72D184F9A4A83E81EC811FDE3EAE9729348E1B32A43E75B0473338AF23BC80F30435D43D2908E5C8D274BE856E4194B131771ABC85142AB9ADA308A3C2419A2686941E0B3052418BEB905AB787327A1140D6DFD6B4E1C65BC9A0B5BF08B876D09AF6868EB2F8485328E70410B1EC7F51218D7AA328772E3976D0B27FB1C21172C9C9AEF161637E070A074C77CC7904B66EBEC2386D50F6BF3CC7E3FC370DC4891E05F8EB6D444F714D843A135D9D35B788DC288500A011B9010EE6AEB4B97F1665EB3D085AE5A4B169D5875178AAEC9DF7977B5CF6D47AD96F79ACED8A7CE299D3C2C87A933B41466ED020F840A97B90ABCD8C7756EB7A9B790F3CF02094DFA98C52B4E16AC90E9A38889FB2C9AD8A68F2AE5E7B3B052A3C99CF3E3667ED2B9501F87C9B3679118B13E16177BB0685C83319EB8E118B13E161FA6B0707C8B39A2383C566E723F999886BFA74C83319E3838462C632D1C813744BA7224BE12C26D9109B578B20C3F0660C73A2C0D4EACEF3A0E13CA2C63CA2DD6DEACBD75B1B73C561FC2DCD4503AD656D7731C63ABB2FB39B75E4AF59198F47D168A11EB639509FA2C522934308D222F95B38B4268301E36C19E1B13DBA08F5724D9B35085CC20446172E8B91885919BA06579F43C52261B9F3E7E2393E79EAB07B0FB263C0DE36FEE3E0E035499F3DC6E2CA5066E52488DE77CA5D066303E26039E1B2123D7476392DC5930466C88A5A418BEC5062E367029DA4761B1FC5C6F00FE52236930575DC77138ABCA9CE7428D526AC02EA2E92ECD2CB64AA363412AA9019B3007A81C97D41EAC36A10D73F4C325AF730CC23618CC518E0F8D63C334FD9CBBED8940BF7F9E5ACE22E4227D8C32719C452985C6874CCA2326A3399589DFDCB44AA9F540D60315EDE37820F59BA0213C9216B28E87D2041AC7635539E42C46253589B29924713EC4661A7E0B0F36D4D17B95C9CD0195D2E9F9D5B2A265C50EAC98BFCF1E8005D5481AAC57D7F1A51EDD4B19DCDC6B41B1D1E0048FC9D4E60EF018B9215AED30E55683DDCD656A731B9C6BE9809826702B11D3167D442E238205AC4D9568C6ABD26CF8470C75F24D2392E569CBD31D789ACF171A82AF1B117578BB0560A4739532FD9B7FC02EA4FA48457E378B53C84C78364DDFE6C9351519C4B779723617DDE632CB2C96598AF6519885F58803D04A039C06A734F67EA901A1353C6B78B58627A5E08A9794DA7349F9BB4CC1CDD35FDBEB894BF9B0D925F3195DA427B44D7261D7C78840FF24B9E064FD6F6FE5213ADFEA821B80D10E4624FB9A637E7E7A762E94237F39A5C19D28DA7A8AF461E61399B65CD9293E4E41C9FAB67E7E6258ED48597E1B3F81D07D00E11F7CF0FC4716D2BCD6502F287519ED5E9035A5B27BCE98ABFAD00B4B2A79DD0B4DF121D096FE4D8462990650C27634C3507D26D4753CF267431D06A4F888A8EB78A48F8A5A87635E30FB6D50CE60B66C77F79BD8DDAA24D057BBB9C50AD2BD36B85425BA179A5009BA17965004B5DFB8E48ACEAA6DDAA1A2733F4F2C556DDE20623C20BE62731784CE56DCAD7AF3DB3043B144723F3FA32C83DC0B522E75DC0B4E2A67DCC15BA88A1B5BF7DC8CF51DB86755B2E3ABA505B10A713F1BDED7995BA73AC3FD0840AA25FC529EE1153581FBCD74B07888A9EDDB0B87ABDFDB0B49A8D13BC441C23033146AED5AB7D08CF53DB8058D0CC357EB26C422B83DA347A9D06D2FBC41FDC69047976251DA17435F9671DE02E3A8B2FB5E2DC30CF73E435D05B6DF818C54E9B5C3A6AAABFBDA8F6214B55D8533152318A6CE6B07182E0570905099AFEB6A49AF19EB7B20BD86D4B8574B7E62E1D55EFB9C2FAEDA93F78E876190F822A9D68EBF7B3BAE4D477BB5466CDFE2DA0D2E964195CB28F2C319ACCC69968E46176213D0A9648397AF6BAF86A9550F55A52C6F451A153735EAA52A35648DEDF846D554559A982B74E673D7567155A5E30E0607391D7EF86AAC4ADDCA6B354AAFB6956E55291BABACAB52D768A55F55DA980B22354968148795335017CED718276496FDA24F8C685F412C282686E9CBD20AB4B8E613DE0505C3D169B2232A2E91D21608A0E4099621413B6A5DB4D94DB6465285FB17E0C58935F81BCA90F8362687982CA308FA1B8FFB2E6BE134EB4F2BE0F2635EDCA68FC0D11053A0C34409FFDFE28F31F2B6E5B8AF65A75D0791D0741E09D051AD491211EC8F25D217A940441D50BE7C97F000711247DC439F3E571318DDE23578825DC6F62D829FE11EB8C7BB3C91B81EA4FD46F0CBBEB844601F023FCA31AAFEF427DDC35BFFF9C7FF038F8C2AE7FE890000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[AcademicBackgrounds] ON 

INSERT [dbo].[AcademicBackgrounds] ([Id], [Qualification], [Degree], [UniversityName], [YearOfObtention], [Details], [imgPathAc], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (1, N'2009 - 2016', N'MBA', N'ADA University', N'2016', N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. ', N'2019_05_31_05_25_00company-logo-2.jpg', CAST(N'2019-05-31T17:25:00.747' AS DateTime), NULL, CAST(N'2019-05-31T17:25:14.157' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[AcademicBackgrounds] ([Id], [Qualification], [Degree], [UniversityName], [YearOfObtention], [Details], [imgPathAc], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (2, N'2016- 2019', N'MBA', N'ADA University', N'2018', N' by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text.  by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text.  by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. ', NULL, CAST(N'2019-05-31T17:25:34.333' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AcademicBackgrounds] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (1, N'Web Design', CAST(N'2019-05-31T17:19:38.133' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (2, N'Development', CAST(N'2019-05-31T17:19:38.133' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (3, N'Graphic Design', CAST(N'2019-05-31T17:19:38.133' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [UserName], [FromEmail], [Subject], [Message], [SendingDate], [Answer], [isAnswered], [isRead], [DeletedDate]) VALUES (1, N'ihasanli2021', N'iqbal.hoff@list.ru', N'CV', N'as', CAST(N'2019-05-31T17:20:39.307' AS DateTime), N'SALAM', 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([Id], [FullName], [Age], [Location], [Experience], [Degree], [CareerLevel], [Email], [Fax], [Phone], [Website], [imgPath], [Password], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (1, N'Igbal Hasanli', 20, N'Baku', N'4 Years', N'MBA', N'Hight', N'iqbal.hoff@list.ru', N'(800) 123-4568', N'+994506705569', N'myCv.az', N'2019_05_31_05_58_1844104149_570911740031254_7311507352660738048_n.jpg', N'11', CAST(N'2019-05-31T17:19:38.123' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[ProfessionalExperiences] ON 

INSERT [dbo].[ProfessionalExperiences] ([Id], [JobTitle], [CompanyName], [Location], [Details], [Duration], [imgPath], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (1, N'WORDPRESS DEVELOPER', N'Market Network', N'San Francisco, California, USA', N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet.', N'2002 - 2008', N'2019_05_31_05_24_20company-logo-1.jpg', NULL, NULL, CAST(N'2019-05-31T17:25:43.520' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ProfessionalExperiences] ([Id], [JobTitle], [CompanyName], [Location], [Details], [Duration], [imgPath], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (2, N'WORDPRESS DEVELOPER', N'Market Network', N'San Francisco, California, USA', N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.', N'2010 - 2012', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProfessionalExperiences] OFF
SET IDENTITY_INSERT [dbo].[Skills] ON 

INSERT [dbo].[Skills] ([Id], [Name], [YourDescription], [SkillLevel], [SkillDescription], [DisplayAsBar], [DisplayAsTag], [TypeOfSkill], [Category], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (1, NULL, N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.', 45, N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.', 1, 1, N'HTML 5', N'Development', CAST(N'2019-05-31T17:23:09.210' AS DateTime), NULL, CAST(N'2019-05-31T17:51:30.113' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Skills] ([Id], [Name], [YourDescription], [SkillLevel], [SkillDescription], [DisplayAsBar], [DisplayAsTag], [TypeOfSkill], [Category], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (2, NULL, N'All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.', 98, N'All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.All the Lorem Ipsum generators on the Internet tend.', 1, 1, N'SASS', N'Web Design', CAST(N'2019-05-31T17:44:44.450' AS DateTime), NULL, CAST(N'2019-05-31T17:58:05.117' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Skills] OFF
SET IDENTITY_INSERT [dbo].[SocialProfiles] ON 

INSERT [dbo].[SocialProfiles] ([Id], [Facebook], [Google], [Skype], [LinkIN], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (1, N'Facebook', N'Google', N'iqbalhasanli1', N'LinkIN', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SocialProfiles] OFF
SET IDENTITY_INSERT [dbo].[TypeOfSkills] ON 

INSERT [dbo].[TypeOfSkills] ([Id], [Name], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (1, N'HTML 5', CAST(N'2019-05-31T17:19:38.137' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TypeOfSkills] ([Id], [Name], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (2, N'CSS', CAST(N'2019-05-31T17:19:38.137' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TypeOfSkills] ([Id], [Name], [CreatedDate], [CreatedId], [ModifiedDate], [ModifiedId], [DeletedDate], [DeletedId]) VALUES (3, N'SASS', CAST(N'2019-05-31T17:19:38.137' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TypeOfSkills] OFF
USE [master]
GO
ALTER DATABASE [MyCV] SET  READ_WRITE 
GO
