using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class AlunoNegocios
    {
        public IList<Modelos.Alunos> RetornaAlunos()
        {
            return new AlunoDados().RetornaAlunos();
        }

        public void InserirAluno(Modelos.Alunos Aluno)
        {
            new AlunoDados().InserirAluno(Aluno);
        }

        public IList<string> RetornaTipoLogr()
        {
            return new CepDados().RetornaTipoLogr();
        }

        public IList<string> RetornaUf()
        {
            return new CepDados().RetornaUF();
        }

        public Modelos.Cep PesquisarCep(string CodigoCep)
        {
            return new CepDados().RetornaCepPorCodigo(CodigoCep);
        }

        public Modelos.Alunos RetonaAlunoPorId(int Id)
        {
            return new AlunoDados().RetornaAlunoPorId(Id);
        }

        public int VerificaExclusao(int Id)
        {
            return new AlunoDados().VerificaExclusao(Id);
        }

        public void ExcluirAluno(Modelos.Alunos Aluno)
        {
            new AlunoDados().ExcluirAluno(Aluno);
        }
    }
}
