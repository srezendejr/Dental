using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class CursoDados
    {
        public IList<Modelos.Cursos> RetornaCursos()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.CursoSet.ToList();
            }
        }

        public Modelos.Cursos RetornaCursoPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.CursoSet.Where(a => a.CursoId == Id).FirstOrDefault();
            }
        }

        public int InserirCurso(Modelos.Cursos Curso)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Curso).State = EntityState.Added;
                return Context.SaveChanges();
            }
        }

        public void AlterarCurso(Modelos.Cursos Curso)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Curso).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void RemoverCurso(Modelos.Cursos Curso)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Curso).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public Modelos.Cursos RetornaCursoPorTurma(int TurmaId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                var q = from c in Context.CursoSet
                    join t in Context.TurmaSet
                    on c.CursoId equals t.CursoId
                    where t.TurmaId.Equals(TurmaId)
                    select c;

                return q.FirstOrDefault();
            }
        }
    }
}
