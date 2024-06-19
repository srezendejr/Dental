using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class MatriculaDados
    {
        public IList<Modelos.Matriculas> RetornaMatriculas()
        {
            using (ModelosContext Context = new ModelosContext())
            {

                return Context.MatriculaSet.ToList();
            }
        }

        public void ConcluirMatricula(Modelos.Matriculas Matricula)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry<Modelos.Matriculas>(Matricula).State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public Modelos.Matriculas RetornaMatriculaPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.MatriculaSet.Find(Id);
            }
        }

        public IList<Modelos.Turmas> PesquisaTurma(string param)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                var q = from c in Context.CursoSet
                        join t in Context.TurmaSet
                        on c.CursoId equals t.CursoId
                        where c.CursoNome.Contains(param) || t.TurmaNome.Contains(param)
                        select t;

                return q.ToList();
            }
        }

        public void InserirMatriculaTurma(Modelos.MatriculaTurma matturma)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry<Modelos.MatriculaTurma>(matturma).State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void ExcluirMatriculaturma(Modelos.MatriculaTurma matturma)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry<Modelos.MatriculaTurma>(matturma).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public IList<Modelos.Alunos> RetornaAlunosMatriculadosPorTurma(int TurmaId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                var q = from t in Context.TurmaSet
                        join mt in Context.MatriculaTurmaSet
                        on t.TurmaId equals mt.TurmaId
                        join m in Context.MatriculaSet
                        on mt.MatriculaId equals m.MatriculaId
                        join a in Context.AlunoSet
                        on m.AlunoId equals a.AlunoId
                        where t.TurmaId == TurmaId
                        select a;
                return q.ToList();
            }
        }
    }
}
