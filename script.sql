USE [master]
GO
/****** Object:  Database [EjercicioBlazor]    Script Date: 29/08/2022 11:43:13 a. m. ******/
CREATE DATABASE [EjercicioBlazor]
GO
USE [EjercicioBlazor]
GO
/****** Object:  Table [dbo].[Metas]    Script Date: 29/08/2022 11:43:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metas](
	[MetaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreMeta] [nvarchar](80) NULL,
	[Fecha] [datetime] NULL,
	[Estatus] [bit] NULL,
 CONSTRAINT [PK_Metas] PRIMARY KEY CLUSTERED 
(
	[MetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 29/08/2022 11:43:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[TareaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreTarea] [nvarchar](80) NULL,
	[Fecha] [datetime] NULL,
	[Estatus] [bit] NULL,
	[Importante] [bit] NULL,
	[MetaId] [int] NULL,
	[Seleccionado] [bit] NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[TareaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tareas]    Script Date: 29/08/2022 11:43:13 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tareas] ON [dbo].[Tareas]
(
	[NombreTarea] ASC,
	[MetaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Metas] FOREIGN KEY([MetaId])
REFERENCES [dbo].[Metas] ([MetaId])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Metas]
GO
USE [master]
GO
ALTER DATABASE [EjercicioBlazor] SET  READ_WRITE 
GO
