using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class DiagnosticoDenteNegocios
    {
        public void SalvarDiagnosticoDente(Modelos.DiagnosticoDentes Dentes)
        {
            new DiagnosticoDenteDados().SalvarDiagnosticoDente(Dentes);
        }

        public IList<Modelos.DiagnosticoDentes> RetornaDentesPorDiagnostico(int Id)
        {
            return new DiagnosticoDenteDados().RetornaDentePorDiagnostico(Id);
        }

        public int RetornaIdDiagnosticoDente(int Dente, int DiagnosticoId, int Posicao)
        { 
            return new DiagnosticoDenteDados().RetornaIdDiagnosticoDente(Dente, DiagnosticoId, Posicao);
        }

        public void RemoverDiagnosticoDente(int DiagnosticoId)
        {
            new DiagnosticoDenteDados().RemoverDiagnosticoDente(DiagnosticoId);
        }
    }
}
