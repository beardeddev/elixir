USE [Identity]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 11/13/2014 17:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[CreatedOn] [smalldatetime] NOT NULL,
	[UpdatedOn] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Statuses_Name] ON [dbo].[Statuses] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/13/2014 17:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [varchar](128) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[CreateOn] [smalldatetime] NOT NULL,
	[UpdatedOn] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Roles_Name] ON [dbo].[Roles] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/13/2014 17:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [varchar](512) NOT NULL,
	[SecurityStamp] [varchar](512) NULL,
	[PhoneNumber] [varchar](32) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[FailedLoginCount] [int] NOT NULL,
	[PerishableToken] [uniqueidentifier] NULL,
	[LastLoginDate] [smalldatetime] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[CreatedOn] [smalldatetime] NOT NULL,
	[UpdatedOn] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Users_Email] ON [dbo].[Users] 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Users_Name] ON [dbo].[Users] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Users_PerishableToken] ON [dbo].[Users] 
(
	[PerishableToken] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Users_PhoneNumber] ON [dbo].[Users] 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Default [DF_Statuses_CreatedOn]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Statuses] ADD  CONSTRAINT [DF_Statuses_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_Statuses_UpdatedOn]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Statuses] ADD  CONSTRAINT [DF_Statuses_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_Table_1_CreateDate]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Table_1_CreateDate]  DEFAULT (getdate()) FOR [CreateOn]
GO
/****** Object:  Default [DF_Roles_UpdatedOn]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_Users_EmailConfirmed]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_EmailConfirmed]  DEFAULT ((0)) FOR [EmailConfirmed]
GO
/****** Object:  Default [DF_Users_PhoneNumberConfirmed]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_PhoneNumberConfirmed]  DEFAULT ((0)) FOR [PhoneNumberConfirmed]
GO
/****** Object:  Default [DF_Users_TwoFactorEnabled]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_TwoFactorEnabled]  DEFAULT ((0)) FOR [TwoFactorEnabled]
GO
/****** Object:  Default [DF_Users_LockoutEnabled]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LockoutEnabled]  DEFAULT ((0)) FOR [LockoutEnabled]
GO
/****** Object:  Default [DF_Users_FailedLoginCount]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_FailedLoginCount]  DEFAULT ((0)) FOR [FailedLoginCount]
GO
/****** Object:  Default [DF_Users_LastLoginDate]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LastLoginDate]  DEFAULT (getdate()) FOR [LastLoginDate]
GO
/****** Object:  Default [DF_Users_StatusId]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_StatusId]  DEFAULT ((0)) FOR [StatusId]
GO
/****** Object:  Default [DF_Users_CreatedOn]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_Users_UpdatedOn]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  ForeignKey [FK_Users_Statuses]    Script Date: 11/13/2014 17:43:36 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Statuses]
GO
