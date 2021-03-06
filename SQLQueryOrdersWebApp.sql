USE [Homework1]
GO

/****** Object:  Table [dbo].[ORDERS]    Script Date: 03.07.2021 23:42:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ORDERS](
	[ORDER_ID] [int] NOT NULL,
	[ORDER_DATE] [date] NOT NULL,
	[GAME_ID] [int] NOT NULL,
	[NET_AMOUNT] [money] NOT NULL,
	[DISCOUNT] [decimal](5, 2) NULL,
	[GROSS_AMOUNT] [money] NOT NULL,
 CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED 
(
	[ORDER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD  CONSTRAINT [FK_ORDERS_GAMES] FOREIGN KEY([GAME_ID])
REFERENCES [dbo].[GAMES] ([GAME_ID])
GO

ALTER TABLE [dbo].[ORDERS] CHECK CONSTRAINT [FK_ORDERS_GAMES]
GO


