using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class DiagnosticoDenteDados
    {
        public IList<Modelos.DiagnosticoDentes> RetornaDentePorDiagnostico(int DiagnosticoId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.DiagnosticoDenteSet.Where(a => a.DiagnosticoId == DiagnosticoId).ToList();
            }
        }

        public void SalvarDiagnosticoDente(Modelos.DiagnosticoDentes Dentes)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Dentes).State = Dentes.DiagnosticoDenteId == 0 ? EntityState.Added : EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public int RetornaIdDiagnosticoDente(int Dente, int DiagnosticoId, int Posicao)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                var q = from s in Context.DiagnosticoDenteSet
                        where s.DenteId == Dente && s.DiagnosticoDenteDiag == Posicao && s.DiagnosticoId == DiagnosticoId
                        select s.DiagnosticoDenteId;
                return q.FirstOrDefault();

            }
        }

        public void RemoverDiagnosticoDente(int DiagnosticoId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                IList<Modelos.DiagnosticoDentes> LstDD = this.RetornaDentePorDiagnostico(DiagnosticoId);
                //for (int i = 0; i < LstDD.Count; i++ )
                foreach (Modelos.DiagnosticoDentes item in LstDD)
                {
                    Context.Entry(item).State = EntityState.Deleted;
                    Context.SaveChanges();
                }
            }
        }
    }
}
