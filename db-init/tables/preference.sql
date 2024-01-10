USE [AreaDB]
GO

/****** Object:  Table [dbo].[Preference]    Script Date: 10/01/2024 19:49:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Preference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ActiveNotifications] [bit] NOT NULL,
	[ActiveEmail] [bit] NOT NULL,
	[ActiveSMS] [bit] NOT NULL,
 CONSTRAINT [PK_Preference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Preference]  WITH CHECK ADD  CONSTRAINT [FK_Preference_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Preference] CHECK CONSTRAINT [FK_Preference_Users_UserId]
GO


