using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;

namespace APCD.Dados
{
    public class ModelosContext : DbContext
    {

        public ModelosContext()
            : base("name=OrtoCnn")
        {

        }

        private ModelosContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = true;
        }
        public DbSet<Modelos.Midias> MidiasSet { get; set; }
        public DbSet<Modelos.Produtos> ProdutosSet { get; set; }
        public DbSet<Modelos.Pacientes> PacientesSet { get; set; }
        public DbSet<Modelos.Cep> CepSet { get; set; }
        public DbSet<Modelos.Turmas> TurmaSet { get; set; }
        public DbSet<Modelos.Cursos> CursoSet { get; set; }
        public DbSet<Modelos.CursoTurmas> CursoTurmaSet { get; set; }
        public DbSet<Modelos.Alunos> AlunoSet { get; set; }
        public DbSet<Modelos.Instituicoes> InstituicaoSet { get; set; }
        public DbSet<Modelos.Matriculas> MatriculaSet { get; set; }
        public DbSet<Modelos.Diagnosticos> DiagnosticoSet { get; set; }
        public DbSet<Modelos.DiagnosticoDentes> DiagnosticoDenteSet { get; set; }
        public DbSet<Modelos.Procedimentos> ProcedimentoSet { get; set; }
        public DbSet<Modelos.DiagnosticoTratamentos> DiagnosticoTratamentoSet { get; set; }
        public DbSet<Modelos.MatriculaTurma> MatriculaTurmaSet { get; set; }
        }
}
