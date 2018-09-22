USE [TyGH]
GO

/****** Object:  Table [dbo].[empleado]    Script Date: 30/6/2018 19:25:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[legajo] [varchar](60) NULL,
	[consulta] [decimal](18, 0) NULL,
	[idPersona] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[empleado]  WITH CHECK ADD FOREIGN KEY([idPersona])
REFERENCES [dbo].[persona] ([idPersona])
GO

