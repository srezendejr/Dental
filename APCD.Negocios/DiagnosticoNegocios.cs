using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class DiagnosticoNegocios
    {
        public IList<Modelos.Diagnosticos> RetornaDiagnosticos()
        {
            return new DiagnosticoDados().RetornaDiagnosticos();
        }

        public Modelos.Diagnosticos RetornaDiagnosticosPorId(int Id)
        {
            return new DiagnosticoDados().RetornaDiagnosticoPorId(Id);
        }

        public void Salvar(Modelos.Diagnosticos Diagnostico)
        {
            new DiagnosticoDados().Salvar(Diagnostico);
        }
    }
}
