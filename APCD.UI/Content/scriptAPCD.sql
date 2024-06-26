USE [master]
GO
/****** Object:  Database [APCD]    Script Date: 02/24/2012 13:58:06 ******/
CREATE DATABASE [APCD] ON  PRIMARY 
( NAME = N'APCD', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\APCD.mdf' , SIZE = 141312KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'APCD_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\APCD_log.ldf' , SIZE = 321088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [APCD] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APCD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [APCD] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [APCD] SET ANSI_NULLS OFF
GO
ALTER DATABASE [APCD] SET ANSI_PADDING OFF
GO
ALTER DATABASE [APCD] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [APCD] SET ARITHABORT OFF
GO
ALTER DATABASE [APCD] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [APCD] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [APCD] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [APCD] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [APCD] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [APCD] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [APCD] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [APCD] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [APCD] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [APCD] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [APCD] SET  DISABLE_BROKER
GO
ALTER DATABASE [APCD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [APCD] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [APCD] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [APCD] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [APCD] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [APCD] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [APCD] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [APCD] SET  READ_WRITE
GO
ALTER DATABASE [APCD] SET RECOVERY SIMPLE
GO
ALTER DATABASE [APCD] SET  MULTI_USER
GO
ALTER DATABASE [APCD] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [APCD] SET DB_CHAINING OFF
GO
USE [APCD]
GO
/****** Object:  Table [dbo].[Turmas]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turmas](
	[TurmaId] [int] IDENTITY(1,1) NOT NULL,
	[TurmaNome] [varchar](50) NULL,
	[TurmaDataInicio] [date] NOT NULL,
	[TurmaDataFim] [date] NULL,
 CONSTRAINT [PK_Turmas] PRIMARY KEY CLUSTERED 
(
	[TurmaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produtos](
	[ProdutoId] [int] IDENTITY(1,1) NOT NULL,
	[ProdutoNome] [varchar](50) NOT NULL,
	[ProdutoStatus] [int] NOT NULL,
	[ProdutoTipo] [int] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[ProdutoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Procedimentos]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Procedimentos](
	[ProcedimentoId] [int] IDENTITY(1,1) NOT NULL,
	[ProcedimentoNome] [varchar](50) NOT NULL,
	[ProcedimentoValor] [decimal](12, 6) NOT NULL,
	[ProcedimentoDescricao] [varchar](255) NULL,
 CONSTRAINT [PK_Tratamentos] PRIMARY KEY CLUSTERED 
(
	[ProcedimentoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Midias]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Midias](
	[MidiaId] [int] IDENTITY(1,1) NOT NULL,
	[MidiaNome] [varchar](50) NULL,
 CONSTRAINT [PK_Midias] PRIMARY KEY CLUSTERED 
(
	[MidiaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Instituicoes]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Instituicoes](
	[InstituicaoId] [int] IDENTITY(1,1) NOT NULL,
	[InstituicaoNome] [varchar](100) NOT NULL,
	[InstituicaoCoordenador] [varchar](100) NOT NULL,
	[InstituicaoFone] [varchar](10) NOT NULL,
	[InstituicaoEmail] [varchar](255) NULL,
 CONSTRAINT [PK_Instituicoes] PRIMARY KEY CLUSTERED 
(
	[InstituicaoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CEP]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CEP](
	[CepId] [int] NOT NULL,
	[CepCodigo] [varchar](10) NULL,
	[CepTipoLogradouro] [varchar](50) NULL,
	[CepLogradouro] [varchar](100) NULL,
	[CepComplementoLog] [varchar](100) NULL,
	[CepBairro] [varchar](100) NULL,
	[CepCidade] [varchar](100) NULL,
	[CepUF] [char](2) NULL,
 CONSTRAINT [PK_CEP] PRIMARY KEY CLUSTERED 
(
	[CepId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cursos](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[CursoNome] [varchar](50) NOT NULL,
	[CursoEspecialidade] [varchar](50) NOT NULL,
	[InstituicaoId] [int] NOT NULL,
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Alunos]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alunos](
	[AlunoId] [int] IDENTITY(1,1) NOT NULL,
	[AlunoNome] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NULL,
	[AlunoCPF] [varchar](11) NOT NULL,
	[AlunoRG] [varchar](10) NOT NULL,
	[AlunoMae] [varchar](50) NULL,
	[AlunoPai] [varchar](50) NULL,
	[AlunoResponsavel] [varchar](50) NULL,
	[AlunoTipoLog] [varchar](50) NOT NULL,
	[AlunoLogradouro] [varchar](100) NOT NULL,
	[AlunoCep] [varchar](8) NOT NULL,
	[AlunoComplemento] [varchar](100) NULL,
	[AlunoBairro] [varchar](50) NOT NULL,
	[AlunoCidade] [varchar](50) NOT NULL,
	[AlunoUF] [char](2) NOT NULL,
	[AlunoFoneResidencial] [varchar](12) NOT NULL,
	[AlunoFoneCelular] [varchar](12) NULL,
	[AlunoFoneComercial] [varchar](12) NULL,
	[AlunoFoneComercialRamal] [varchar](6) NULL,
	[AlunoRGExped] [varchar](10) NOT NULL,
	[AlunoEmail] [varchar](100) NULL,
	[AlunoDataCadastro] [datetime] NOT NULL,
	[TurmaId] [int] NULL,
	[AlunoNroEndereco] [varchar](5) NULL,
	[AlunoSexo] [int] NOT NULL,
 CONSTRAINT [PK_Alunos] PRIMARY KEY CLUSTERED 
(
	[AlunoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CursoTurmas]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoTurmas](
	[CursoTurmaId] [int] IDENTITY(1,1) NOT NULL,
	[CursoId] [int] NOT NULL,
	[TurmaId] [int] NOT NULL,
 CONSTRAINT [PK_CursoTurmas] PRIMARY KEY CLUSTERED 
(
	[CursoTurmaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matriculas]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Matriculas](
	[MatriculaId] [int] IDENTITY(1,1) NOT NULL,
	[AlunoId] [int] NOT NULL,
	[CursoId] [int] NOT NULL,
	[MidiaId] [int] NOT NULL,
	[MatriculaOpcaoCurso] [varchar](255) NOT NULL,
	[MatriculaAnoGraduacao] [int] NOT NULL,
	[InstituicaoId] [int] NOT NULL,
	[MatriculaMiniCurriculum] [varchar](1000) NOT NULL,
	[MatriculaData] [datetime] NOT NULL,
	[MatriculaStatus] [int] NOT NULL,
 CONSTRAINT [PK_Matriculas] PRIMARY KEY CLUSTERED 
(
	[MatriculaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pacientes](
	[PacienteId] [int] IDENTITY(1,1) NOT NULL,
	[PacienteNome] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NULL,
	[PacienteCPF] [varchar](11) NOT NULL,
	[PacienteRG] [varchar](10) NOT NULL,
	[PacienteMae] [varchar](50) NULL,
	[PacientePai] [varchar](50) NULL,
	[PacienteResponsavel] [varchar](50) NULL,
	[PacienteTipoLog] [varchar](50) NOT NULL,
	[PacienteLogradouro] [varchar](100) NOT NULL,
	[PacienteCep] [varchar](8) NOT NULL,
	[PacienteComplemento] [varchar](100) NULL,
	[PacienteBairro] [varchar](50) NOT NULL,
	[PacienteCidade] [varchar](50) NOT NULL,
	[PacienteUF] [char](2) NOT NULL,
	[PacienteFoneResidencial] [varchar](12) NOT NULL,
	[PacienteFoneCelular] [varchar](12) NULL,
	[PacienteFoneComercial] [varchar](12) NULL,
	[PacienteFoneComercialRamal] [varchar](6) NULL,
	[MidiaId] [int] NULL,
	[PacienteRGExped] [varchar](10) NOT NULL,
	[PacienteEmail] [varchar](100) NULL,
	[PacienteDataCadastro] [datetime] NOT NULL,
	[CursoId] [int] NULL,
	[PacienteNroEndereco] [char](5) NULL,
	[AlunoId] [int] NULL,
	[PacienteSexo] [int] NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[PacienteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Diagnosticos]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnosticos](
	[DiagnosticoId] [int] IDENTITY(1,1) NOT NULL,
	[DiagnosticoData] [datetime] NOT NULL,
	[PacienteId] [int] NOT NULL,
 CONSTRAINT [PK_Diagnosticos] PRIMARY KEY CLUSTERED 
(
	[DiagnosticoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiagnosticoTratamentos]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiagnosticoTratamentos](
	[DiagnosticoTratamentoId] [int] IDENTITY(1,1) NOT NULL,
	[DiagnosticoId] [int] NOT NULL,
	[ProcedimentoId] [int] NOT NULL,
	[ProcedimentoValor] [decimal](8, 2) NOT NULL,
	[DiagnosticoTratamentoStatus] [int] NOT NULL,
 CONSTRAINT [PK_DiagnosticoTratamento] PRIMARY KEY CLUSTERED 
(
	[DiagnosticoTratamentoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiagnosticoDentes]    Script Date: 02/24/2012 13:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiagnosticoDentes](
	[DiagnosticoDenteId] [int] IDENTITY(1,1) NOT NULL,
	[DenteId] [int] NOT NULL,
	[DiagnosticoId] [int] NOT NULL,
	[DiagnosticoEncontrado] [varchar](500) NOT NULL,
 CONSTRAINT [PK_DiagnosticoDente] PRIMARY KEY CLUSTERED 
(
	[DiagnosticoDenteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Alunos_AlunoSexo]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Alunos] ADD  CONSTRAINT [DF_Alunos_AlunoSexo]  DEFAULT ((0)) FOR [AlunoSexo]
GO
/****** Object:  Default [DF_Pacientes_PacienteSexo]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Pacientes] ADD  CONSTRAINT [DF_Pacientes_PacienteSexo]  DEFAULT ((0)) FOR [PacienteSexo]
GO
/****** Object:  ForeignKey [FK_Cursos_Instituicoes]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Cursos_Instituicoes] FOREIGN KEY([InstituicaoId])
REFERENCES [dbo].[Instituicoes] ([InstituicaoId])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Cursos_Instituicoes]
GO
/****** Object:  ForeignKey [FK_Alunos_Turmas]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Alunos]  WITH CHECK ADD  CONSTRAINT [FK_Alunos_Turmas] FOREIGN KEY([TurmaId])
REFERENCES [dbo].[Turmas] ([TurmaId])
GO
ALTER TABLE [dbo].[Alunos] CHECK CONSTRAINT [FK_Alunos_Turmas]
GO
/****** Object:  ForeignKey [FK_CursoTurmas_Cursos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[CursoTurmas]  WITH CHECK ADD  CONSTRAINT [FK_CursoTurmas_Cursos] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([CursoId])
GO
ALTER TABLE [dbo].[CursoTurmas] CHECK CONSTRAINT [FK_CursoTurmas_Cursos]
GO
/****** Object:  ForeignKey [FK_CursoTurmas_Turmas]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[CursoTurmas]  WITH CHECK ADD  CONSTRAINT [FK_CursoTurmas_Turmas] FOREIGN KEY([TurmaId])
REFERENCES [dbo].[Turmas] ([TurmaId])
GO
ALTER TABLE [dbo].[CursoTurmas] CHECK CONSTRAINT [FK_CursoTurmas_Turmas]
GO
/****** Object:  ForeignKey [FK_Matriculas_Alunos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Matriculas]  WITH CHECK ADD  CONSTRAINT [FK_Matriculas_Alunos] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Alunos] ([AlunoId])
GO
ALTER TABLE [dbo].[Matriculas] CHECK CONSTRAINT [FK_Matriculas_Alunos]
GO
/****** Object:  ForeignKey [FK_Matriculas_Cursos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Matriculas]  WITH CHECK ADD  CONSTRAINT [FK_Matriculas_Cursos] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([CursoId])
GO
ALTER TABLE [dbo].[Matriculas] CHECK CONSTRAINT [FK_Matriculas_Cursos]
GO
/****** Object:  ForeignKey [FK_Matriculas_Instituicoes]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Matriculas]  WITH CHECK ADD  CONSTRAINT [FK_Matriculas_Instituicoes] FOREIGN KEY([InstituicaoId])
REFERENCES [dbo].[Instituicoes] ([InstituicaoId])
GO
ALTER TABLE [dbo].[Matriculas] CHECK CONSTRAINT [FK_Matriculas_Instituicoes]
GO
/****** Object:  ForeignKey [FK_Matriculas_Midias]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Matriculas]  WITH CHECK ADD  CONSTRAINT [FK_Matriculas_Midias] FOREIGN KEY([MidiaId])
REFERENCES [dbo].[Midias] ([MidiaId])
GO
ALTER TABLE [dbo].[Matriculas] CHECK CONSTRAINT [FK_Matriculas_Midias]
GO
/****** Object:  ForeignKey [FK_Pacientes_Alunos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Alunos] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Alunos] ([AlunoId])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Alunos]
GO
/****** Object:  ForeignKey [FK_Pacientes_Cursos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Cursos] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([CursoId])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Cursos]
GO
/****** Object:  ForeignKey [FK_Pacientes_Midias]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Midias] FOREIGN KEY([MidiaId])
REFERENCES [dbo].[Midias] ([MidiaId])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Midias]
GO
/****** Object:  ForeignKey [FK_Diagnosticos_Pacientes]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[Diagnosticos]  WITH CHECK ADD  CONSTRAINT [FK_Diagnosticos_Pacientes] FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Pacientes] ([PacienteId])
GO
ALTER TABLE [dbo].[Diagnosticos] CHECK CONSTRAINT [FK_Diagnosticos_Pacientes]
GO
/****** Object:  ForeignKey [FK_DiagnosticoTratamento_Diagnosticos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[DiagnosticoTratamentos]  WITH CHECK ADD  CONSTRAINT [FK_DiagnosticoTratamento_Diagnosticos] FOREIGN KEY([DiagnosticoId])
REFERENCES [dbo].[Diagnosticos] ([DiagnosticoId])
GO
ALTER TABLE [dbo].[DiagnosticoTratamentos] CHECK CONSTRAINT [FK_DiagnosticoTratamento_Diagnosticos]
GO
/****** Object:  ForeignKey [FK_DiagnosticoTratamento_Procedimentos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[DiagnosticoTratamentos]  WITH CHECK ADD  CONSTRAINT [FK_DiagnosticoTratamento_Procedimentos] FOREIGN KEY([ProcedimentoId])
REFERENCES [dbo].[Procedimentos] ([ProcedimentoId])
GO
ALTER TABLE [dbo].[DiagnosticoTratamentos] CHECK CONSTRAINT [FK_DiagnosticoTratamento_Procedimentos]
GO
/****** Object:  ForeignKey [FK_DiagnosticoDente_Diagnosticos]    Script Date: 02/24/2012 13:58:07 ******/
ALTER TABLE [dbo].[DiagnosticoDentes]  WITH CHECK ADD  CONSTRAINT [FK_DiagnosticoDente_Diagnosticos] FOREIGN KEY([DiagnosticoId])
REFERENCES [dbo].[Diagnosticos] ([DiagnosticoId])
GO
ALTER TABLE [dbo].[DiagnosticoDentes] CHECK CONSTRAINT [FK_DiagnosticoDente_Diagnosticos]
GO
