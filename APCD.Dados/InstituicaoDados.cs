using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class InstituicaoDados
    {
        public IList<Modelos.Instituicoes> RetornaInstituicoes()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.InstituicaoSet.ToList();
            }
        }

        public Modelos.Instituicoes RetornaInstituicaoPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.InstituicaoSet.Find(Id);
            }
        }

        public void SalvarInstituicao(Modelos.Instituicoes Instituicao)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Instituicao).State = Instituicao.InstituicaoId == 0 ? EntityState.Added : EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void ExcluirInstituicao(Modelos.Instituicoes Instituicao)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Instituicao).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public int VereificaExclusao(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                IQueryable<Modelos.Instituicoes> q;
                q = from i in Context.InstituicaoSet
                    join c in Context.CursoSet
                    on i.InstituicaoId equals c.InstituicaoId
                    where i.InstituicaoId == Id
                    select i;
                return q.Count<Modelos.Instituicoes>();
            }
        }

        public Modelos.Instituicoes RetornaInstituicaoPorTurma(int Turma)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                var q = from c in Context.CursoSet
                        join i in Context.InstituicaoSet
                        on c.InstituicaoId equals i.InstituicaoId
                        join t in Context.TurmaSet
                        on c.CursoId equals t.CursoId
                        where t.TurmaId.Equals(Turma)
                        select i;
                return q.FirstOrDefault();

            }
        }
    }
}
