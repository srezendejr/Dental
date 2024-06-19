using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APCD.Dados
{
    public class CursoTurmaDados
    {
        public IList<Modelos.Turmas> RetornaTurmasPorCurso(int CursoId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                IQueryable<Modelos.Turmas> q;
                    q = from t in Context.TurmaSet
                        join c in Context.CursoTurmaSet
                        on t.TurmaId equals c.TurmaId
                        where c.CursoId == CursoId
                        select t;
                return q.ToList();
            }
        }

        public void InserirCursoTurmas(int CursoId, int[] TurmaId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                foreach (int i in TurmaId)
                {
                    Context.CursoTurmaSet.Add(new Modelos.CursoTurmas() { CursoId = CursoId, TurmaId = i });
                    Context.SaveChanges();
                }
            }
        }

        public void RemoverCursoTurma(int CursoId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                IList<Modelos.CursoTurmas> cursoturma = Context.CursoTurmaSet.Where(a => a.CursoId == CursoId).ToList();
                foreach (Modelos.CursoTurmas ct in cursoturma)
                {
                    Context.CursoTurmaSet.Remove(ct);
                    Context.SaveChanges();
                }
            }
        }


        public Modelos.Cursos RetornaCursoPorTurma(int TurmaId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                IQueryable<Modelos.Cursos> q;
                q = from t in Context.CursoSet
                    join c in Context.TurmaSet
                    on t.CursoId equals c.CursoId
                    where c.TurmaId == TurmaId
                    select t;
                return q.FirstOrDefault();
            }
        }
    }
}
