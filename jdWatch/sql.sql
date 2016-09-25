USE [master]
GO
/****** Object:  Database [jdWatch_New]    Script Date: 2016-09-26 2:53:44 ******/
CREATE DATABASE [jdWatch_New]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'jdWatch_New', FILENAME = N'D:\Publish\Data\jdWatch_new.mdf' , SIZE = 11264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'jdWatch_New_log', FILENAME = N'D:\Publish\Data\jdWatch_new_log.ldf' , SIZE = 76736KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [jdWatch_New] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [jdWatch_New].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [jdWatch_New] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [jdWatch_New] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [jdWatch_New] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [jdWatch_New] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [jdWatch_New] SET ARITHABORT OFF 
GO
ALTER DATABASE [jdWatch_New] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [jdWatch_New] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [jdWatch_New] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [jdWatch_New] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [jdWatch_New] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [jdWatch_New] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [jdWatch_New] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [jdWatch_New] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [jdWatch_New] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [jdWatch_New] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [jdWatch_New] SET  DISABLE_BROKER 
GO
ALTER DATABASE [jdWatch_New] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [jdWatch_New] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [jdWatch_New] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [jdWatch_New] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [jdWatch_New] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [jdWatch_New] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [jdWatch_New] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [jdWatch_New] SET RECOVERY FULL 
GO
ALTER DATABASE [jdWatch_New] SET  MULTI_USER 
GO
ALTER DATABASE [jdWatch_New] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [jdWatch_New] SET DB_CHAINING OFF 
GO
ALTER DATABASE [jdWatch_New] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [jdWatch_New] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'jdWatch_New', N'ON'
GO
USE [jdWatch_New]
GO
/****** Object:  StoredProcedure [dbo].[proc_DeleteBaseData]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_DeleteBaseData]
@ID uniqueidentifier
as
declare @CurLevel int
select @CurLevel=Base_Type from product_base where ID=@ID;

create table #tt(
	ID uniqueidentifier
)
insert into #tt
select @ID

while @CurLevel<=5
begin

	insert into #tt
	select ID from product_base where PID in (
		select ID from #tt
	);

	set @CurLevel=@CurLevel+1 
end

delete from product_base where ID in (
		select ID from #tt
	);
GO
/****** Object:  Table [dbo].[conf]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conf](
	[ID] [uniqueidentifier] NOT NULL,
	[conf_lock] [bit] NULL,
	[conf_frq] [int] NOT NULL,
	[conf_start] [bit] NULL,
 CONSTRAINT [PK_conf] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[login_infor]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[login_infor](
	[login_id] [uniqueidentifier] NOT NULL,
	[login_user] [varchar](50) NOT NULL,
	[login_pwd] [varchar](50) NOT NULL,
	[login_user_type] [int] NOT NULL,
	[login_state] [tinyint] NULL,
	[login_account_state] [tinyint] NOT NULL,
	[login_ip] [varchar](15) NULL,
	[login_time] [datetime] NULL,
 CONSTRAINT [PK_login_infor] PRIMARY KEY CLUSTERED 
(
	[login_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product_base]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product_base](
	[ID] [uniqueidentifier] NOT NULL,
	[PID] [uniqueidentifier] NULL,
	[Base_Key] [varchar](100) NOT NULL,
	[Base_Type] [tinyint] NOT NULL,
 CONSTRAINT [PK_product_base] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product_infor]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product_infor](
	[product_id] [uniqueidentifier] NOT NULL,
	[product_skuid] [varchar](50) NOT NULL,
	[product_seller] [varchar](50) NULL,
	[product_base_type] [uniqueidentifier] NULL,
	[product_warn_price] [money] NULL,
	[produect_warn_direct] [varchar](50) NULL,
	[produect_describe] [varchar](100) NULL,
 CONSTRAINT [PK_product_infor] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product_price]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product_price](
	[product_id] [uniqueidentifier] NOT NULL,
	[product_skuid] [varchar](50) NOT NULL,
	[product_warn_price] [money] NULL,
	[product_jd_price] [money] NULL,
	[product_app_price] [money] NULL,
	[product_weixin_price] [money] NULL,
	[product_qq_price] [money] NULL,
	[product_stock] [nchar](10) NULL,
	[product_get_time] [datetime] NULL,
	[produect_url] [text] NULL,
 CONSTRAINT [PK_product_price] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product_status]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product_status](
	[ID] [uniqueidentifier] NOT NULL,
	[SKU] [varchar](50) NOT NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_product_status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Menu]    Script Date: 2016-09-26 2:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Menu](
	[ID] [uniqueidentifier] NOT NULL,
	[PID] [uniqueidentifier] NULL,
	[Name] [varchar](20) NOT NULL,
	[Icon] [varchar](50) NULL,
	[Url] [varchar](500) NOT NULL,
	[Sequence] [int] NOT NULL,
	[Rec_CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Sys_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Sys_Menu] ADD  CONSTRAINT [DF_Sys_Menu_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'整个数据库的锁，当进行写操作时要检查此值，预防出现窜改，暂时为预留' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'conf', @level2type=N'COLUMN',@level2name=N'conf_lock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采集频率，最低为15分钟，单位为分钟' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'conf', @level2type=N'COLUMN',@level2name=N'conf_frq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开启监控【0，停止监控；1，开启监控】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'conf', @level2type=N'COLUMN',@level2name=N'conf_start'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置标识，只有一行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'conf'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor', @level2type=N'COLUMN',@level2name=N'login_user'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor', @level2type=N'COLUMN',@level2name=N'login_pwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型【0：管理员；1：员工】
超级用户：拥有整个系统的最高权限，有且只有一个账号（root）.
管理员：拥有管理员工的权限，添加、修改或删除员工账号，其他权限与超级用户一样，只是不能对超级用户进行管理.
员工：只有浏览的权限，如浏览监控数据，修改自己的密码。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor', @level2type=N'COLUMN',@level2name=N'login_user_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录状态【0：离线；1：在线】上线后，往此填写状态信息，只作显示，用户不能编辑' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor', @level2type=N'COLUMN',@level2name=N'login_state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号状态【0，正常；1，停用】如果停用，则不能登录，提示用户账号停用，根据权限来显示，管理员以上可以使用这字段管理员工' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor', @level2type=N'COLUMN',@level2name=N'login_account_state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户当前登录的IP地址，只作显示，不编辑。时间紧可以不暂时不处理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor', @level2type=N'COLUMN',@level2name=N'login_ip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次登录的时间。只作显示，不编辑。时间紧可以不暂时不处理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor', @level2type=N'COLUMN',@level2name=N'login_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用于记录注册用户的信息。由前端处理，server不处理此表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'login_infor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：品牌 1：系列 2：颜色 3：版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_base', @level2type=N'COLUMN',@level2name=N'Base_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用于用户建立商品基本信息
1，由前端在【录入功能-基本信息建立】并填充到此表中；
2，此表与product_infor表的name,serial,color,version对应' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_base'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号。注意，不能包含空格，如果记录有空格，取出使用时要过滤掉。由用户录入得到。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_infor', @level2type=N'COLUMN',@level2name=N'product_skuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家名称。一般由server端根据skuid获取得到' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_infor', @level2type=N'COLUMN',@level2name=N'product_seller'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应product_base中的ID，只取版本的ID存储' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_infor', @level2type=N'COLUMN',@level2name=N'product_base_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警价格，如果低于这个价格就报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_infor', @level2type=N'COLUMN',@level2name=N'product_warn_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警价格的方向【暂时预留】报警价格可以根据这个方向来判断，价格高于报警价格或是低于报警价格才报警。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_infor', @level2type=N'COLUMN',@level2name=N'produect_warn_direct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品信息描述，由用户输入skuid后，server获取反馈到表中，前端再从此表读取出来' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_infor', @level2type=N'COLUMN',@level2name=N'produect_describe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'此表记录商品的基本信息
1，其中此表的数据来源于【录入功能】；
2，管理员用户可以在【录入功能】对对本表进行操作进行增删或修改；
3，删除此表的数据的同时，也要删除product_price表中的对应的数据，关联是标识：product_skuid。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_infor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号，与表product_infor的一致' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_skuid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报警价格，低于此价格则报警' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_warn_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'京东价格，由server获取后填充到此，前端显示到监控表上' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_jd_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'APP价格，由server获取后填充到此，前端显示到监控表上' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_app_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信价格，由server获取后填充到此，前端显示到监控表上' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_weixin_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ价格，由server获取后填充到此，前端显示到监控表上' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_qq_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存，显示当前商品的库存状态，由server获取后填充到此，前端显示到监控表上' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'server获取此商品价格的时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price', @level2type=N'COLUMN',@level2name=N'product_get_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品监控表，此表由server获取到填充到此，前端只是显示在监控表就可以
1，当用户在【历史数据功能】可以删除这表信息。如果要清空skuid下的数据，则只清空此表对应的数据即可。
2，用户在【录入数据功能】删除一条商品信息时，要清空这此表对应的数据，以skuid为准，删除。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应product_infor表中的skuid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_status', @level2type=N'COLUMN',@level2name=N'SKU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前产品状态： 0：正在监控 1：异常数据 2：我的异常数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'product_status', @level2type=N'COLUMN',@level2name=N'Status'
GO
USE [master]
GO
ALTER DATABASE [jdWatch_New] SET  READ_WRITE 
GO
