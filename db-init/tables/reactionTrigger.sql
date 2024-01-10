USE [AreaDB]
GO

/****** Object:  Table [dbo].[ReactionTrigger]    Script Date: 10/01/2024 19:50:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReactionTrigger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[From] [nvarchar](max) NOT NULL,
	[To] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[AreaId] [int] NOT NULL,
 CONSTRAINT [PK_ReactionTrigger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReactionTrigger]  WITH CHECK ADD  CONSTRAINT [FK_ReactionTrigger_Area_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ReactionTrigger] CHECK CONSTRAINT [FK_ReactionTrigger_Area_AreaId]
GO


