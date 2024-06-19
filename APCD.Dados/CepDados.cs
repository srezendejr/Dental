using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APCD.Dados
{
    public class CepDados
    {
        public IList<Modelos.Cep> RetornaCep()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.CepSet.ToList();
            }
        }

        public Modelos.Cep RetornaCepPorCodigo(string Codigo)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.CepSet.Where(a => a.CepCodigo == Codigo).FirstOrDefault();
            }
        }

        public IList<string> RetornaTipoLogr()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.CepSet.Select(a => a.CepTipoLogradouro).Distinct().ToList();
            }
        }

        public IList<string> RetornaUF()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.CepSet.Select(a => a.CepUF).Distinct().ToList();
            }
        }
    }
}
