using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class AlunoDados
    {
        public IList<Modelos.Alunos> RetornaAlunos()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.AlunoSet.ToList();
            }
        }

        public void InserirAluno(Modelos.Alunos Aluno)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Aluno).State = Aluno.AlunoId == 0 ? EntityState.Added : EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public Modelos.Alunos RetornaAlunoPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.AlunoSet.Find(Id);
            }
        }

        public void ExcluirAluno(Modelos.Alunos Aluno)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Aluno).State = EntityState.Deleted;
                Context.SaveChanges();

            }
        }

        public int VerificaExclusao(int AlunoId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                IQueryable<Modelos.Alunos> q = from a in Context.AlunoSet
                                               join p in Context.PacientesSet
                                               on a.AlunoId equals p.AlunoId
                                               where a.AlunoId == AlunoId
                                               select a;
                return q.Count<Modelos.Alunos>();
            }
        }
    }
}
