using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class DiagnosticoProcedimentoDados
    {
        public IList<Modelos.DiagnosticoTratamentos> RetornaProcedimentoPorDiagnostico(int DiagnosticoId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.DiagnosticoTratamentoSet.Where(a => a.DiagnosticoId == DiagnosticoId).ToList();
            }
        }

        public void SalvarDiagnosticoProcedimento(Modelos.DiagnosticoTratamentos Procedimento)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Procedimento).State = Procedimento.DiagnosticoTratamentoId == 0 ? EntityState.Added : EntityState.Modified;
                Context.SaveChanges();
            }
        }
    }
}
