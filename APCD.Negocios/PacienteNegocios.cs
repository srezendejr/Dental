using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class PacienteNegocios
    {

        public Modelos.Cep PesquisarCep(string CodigoCep)
        {
            return new CepDados().RetornaCepPorCodigo(CodigoCep);
        }

        public IList<string> RetornaTipoLogr()
        {
            return new CepDados().RetornaTipoLogr();
        }

        public IList<string> RetornaUf()
        {
            return new CepDados().RetornaUF();
        }

        public void InserirPaciente(Modelos.Pacientes Paciente)
        {
            new PacienteDados().InserirPaciente(Paciente);
        }

        public Modelos.Pacientes RetornaPacientePorId(int Id)
        {
            return new PacienteDados().RetornaPacientePorId(Id);
        }

        public IList<Modelos.Pacientes> RetornaPacientes()
        {
            return new PacienteDados().RetornaPacientes();
        }

        public void Atualizar(Modelos.Pacientes Paciente)
        {
            new PacienteDados().AtualizarPaciente(Paciente);
        }

        public void Excluir(Modelos.Pacientes Paciente)
        {
            new PacienteDados().ExcluirPaciente(Paciente);
        }
    }
}
