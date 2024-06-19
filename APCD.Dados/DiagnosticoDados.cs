using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace APCD.Dados
{
    public class DiagnosticoDados
    {
        public IList<Modelos.Diagnosticos> RetornaDiagnosticos()
        { 
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.DiagnosticoSet.ToList();
            }
        }

        public Modelos.Diagnosticos RetornaDiagnosticoPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.DiagnosticoSet.Find(Id);
            }
        }

        public void Salvar(Modelos.Diagnosticos Diagnostico)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Diagnostico).State = Diagnostico.DiagnosticoId == 0 ? EntityState.Added : EntityState.Modified;
                Context.SaveChanges();
            }
        }
    }
}
