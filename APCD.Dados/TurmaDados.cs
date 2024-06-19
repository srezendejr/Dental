using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class TurmaDados
    {
        public IList<Modelos.Turmas> RetornaTurmas()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.TurmaSet.ToList() ;
            }
        }

        public IList<Modelos.Turmas> RetornaTurmasValidas()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                DateTime Data = DateTime.Now.Date;
                IEnumerable<Modelos.Turmas> q = from f in Context.TurmaSet
                                                where f.TurmaDataInicio <= Data
                                                && f.TurmaDataFim >= Data
                                                select f;
                return q.ToList();
            }
        }

        public Modelos.Turmas RetornaTurmaPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.TurmaSet.Where(a => a.TurmaId == Id).FirstOrDefault();
            }
        }

        public void InserirTurma(Modelos.Turmas Turma)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Turma).State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void AtualizarTurma(Modelos.Turmas Turma)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Turma).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void RemoverTurma(Modelos.Turmas Turma)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Turma).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public IList<Modelos.MatriculaTurma> RetornaTurmasPorMatricula(int matricula)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.MatriculaTurmaSet.Where(a => a.MatriculaId == matricula).ToList();
            }
        }
    }
}
