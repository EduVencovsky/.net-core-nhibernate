USE [Venkos]
GO

/****** Object:  Table [dbo].[BOOK]    Script Date: 07/10/2019 10:55:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BOOK](
	[ID] [uniqueidentifier] NOT NULL,
	[TITLE] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

