USE [AreaDB]
GO

/****** Object:  Table [dbo].[ActionTrigger]    Script Date: 10/01/2024 19:47:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActionTrigger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[nbMin] [int] NOT NULL,
	[NextTrigger] [datetime2](7) NOT NULL,
	[AreaId] [int] NOT NULL,
 CONSTRAINT [PK_ActionTrigger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActionTrigger]  WITH CHECK ADD  CONSTRAINT [FK_ActionTrigger_Area_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ActionTrigger] CHECK CONSTRAINT [FK_ActionTrigger_Area_AreaId]
GO


