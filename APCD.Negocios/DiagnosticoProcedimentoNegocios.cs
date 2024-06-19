using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class DiagnosticoProcedimentoNegocios
    {
        public void SalvarDiagnosticoProcedimento(Modelos.DiagnosticoTratamentos Procedimentos)
        {
            new DiagnosticoProcedimentoDados().SalvarDiagnosticoProcedimento(Procedimentos);
        }

        public IList<Modelos.DiagnosticoTratamentos> RetornaProcedimentosPorDiagnostico(int Id)
        {
            IList<Modelos.DiagnosticoTratamentos> LstProcDiag = new DiagnosticoProcedimentoDados().RetornaProcedimentoPorDiagnostico(Id);
            for(int i = 0; i < LstProcDiag.Count; i++)
            {
                LstProcDiag[i].ProcedimentoNome = new ProcedimentoDados().RetornaProcedimentoPorId(LstProcDiag[i].ProcedimentoId).ProcedimentoNome;
            }

            return LstProcDiag;
        }
    }
}
