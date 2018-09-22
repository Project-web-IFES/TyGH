USE [TyGH]
GO

/****** Object:  Table [dbo].[turno]    Script Date: 30/6/2018 19:26:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[turno](
	[idTurno] [int] IDENTITY(1,1) NOT NULL,
	[diaHoraInicio] [datetime] NULL,
	[diaHoraFinal] [datetime] NULL,
	[idPaciente] [int] NULL,
	[idAgenda] [int] NULL,
	[idSala] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[turno]  WITH CHECK ADD FOREIGN KEY([idAgenda])
REFERENCES [dbo].[agenda] ([idAgenda])
GO

ALTER TABLE [dbo].[turno]  WITH CHECK ADD FOREIGN KEY([idPaciente])
REFERENCES [dbo].[paciente] ([idPaciente])
GO

ALTER TABLE [dbo].[turno]  WITH CHECK ADD FOREIGN KEY([idSala])
REFERENCES [dbo].[sala] ([idSala])
GO

