using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class ProcedimentoNegocios
    {
        public void SalvarProcedimento(Modelos.Procedimentos Procedimento)
        {
            new ProcedimentoDados().SalvarProcedimento(Procedimento);
        }

        public IList<Modelos.Procedimentos> RetornarProcedimentos()
        {
            return new ProcedimentoDados().RetornarProcedimentos();
        }

        public Modelos.Procedimentos RetornaProcedimentoPorId(int Id)
        {
            return new ProcedimentoDados().RetornaProcedimentoPorId(Id);
        }

        public bool VerificaExcluscao(int Id)
        {
            if (new ProcedimentoDados().ValidaExclusao(Id) > 0)
                return false;
            else
                return true;
        }

        public void ExcluirProcedimento(Modelos.Procedimentos Procedimento)
        {
            new ProcedimentoDados().ExcluirProcedimento(Procedimento);
        }

        public IList<Modelos.Procedimentos> RetornaProcedimentosPorNome(string Proced)
        {
            return new ProcedimentoDados().RetornaProcedimentosPorNome(Proced);
        }
    }
}
