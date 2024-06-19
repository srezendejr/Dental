using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class MidiaNegocios
    {
        public IList<Modelos.Midias> RetornaMidias()
        {
            return new MidiaDados().RetornaMidias();
        }

        public Modelos.Midias RetornaMidiaPorId(int Id)
        {
            return new MidiaDados().RetonaMidiaPorId(Id);
        }

        public void InserirMidia(Modelos.Midias Midia)
        {
            new MidiaDados().InserirMidia(Midia);
        }

        public void AtualizaMidia(Modelos.Midias Midia)
        {
            new MidiaDados().AtualizarMidia(Midia);
        }

        public void RemoverMidia(Modelos.Midias Midia)
        {
            new MidiaDados().RemoverMidia(Midia);
        }

        public int VerificaExclusao(int Id)
        {
            return new PacienteDados().RetornaPacientesPorMidia(Id).Count;
        }
    }
}
