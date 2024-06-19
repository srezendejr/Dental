using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class ProcedimentoDados
    {
        public void SalvarProcedimento(Modelos.Procedimentos Procedimento)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Procedimento).State = Procedimento.ProcedimentoId == 0 ? EntityState.Added : EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public IList<Modelos.Procedimentos> RetornarProcedimentos()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.ProcedimentoSet.ToList();
            }
        }

        public Modelos.Procedimentos RetornaProcedimentoPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.ProcedimentoSet.Find(Id);
            }
        }

        public int ValidaExclusao(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                IQueryable<Modelos.Procedimentos> q;
                q = from d in Context.DiagnosticoTratamentoSet
                    join p in Context.ProcedimentoSet
                    on d.ProcedimentoId equals p.ProcedimentoId
                    where p.ProcedimentoId == Id
                    select p;
                return q.Count();
            }
        }

        public void ExcluirProcedimento(Modelos.Procedimentos Procedimento)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Procedimento).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public IList<Modelos.Procedimentos> RetornaProcedimentosPorNome(string Proced)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.ProcedimentoSet.Where(a => a.ProcedimentoNome.Contains(Proced)).ToList();
            }
        }
    }
}
