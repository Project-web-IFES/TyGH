USE [TyGH]
GO

/****** Object:  Table [dbo].[agenda]    Script Date: 30/6/2018 19:25:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[agenda](
	[idAgenda] [int] IDENTITY(1,1) NOT NULL,
	[diaHoraInicio] [datetime] NULL,
	[diaHoraFinal] [datetime] NULL,
	[idMedico] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[agenda]  WITH CHECK ADD FOREIGN KEY([idMedico])
REFERENCES [dbo].[medico] ([idMedico])
GO

