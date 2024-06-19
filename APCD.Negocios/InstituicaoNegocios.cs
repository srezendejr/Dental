using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class InstituicaoNegocios
    {
        public void SalvarInstituicao(Modelos.Instituicoes Instituicao)
        {
            new InstituicaoDados().SalvarInstituicao(Instituicao);
            
        }

        public IList<Modelos.Instituicoes> RetornaInstituicoes()
        {
            return new InstituicaoDados().RetornaInstituicoes();
        }

        public Modelos.Instituicoes RetornaInsituicaoPorId(int Id)
        {
            return new InstituicaoDados().RetornaInstituicaoPorId(Id);
        }

        public void ExcluirInstituicao(Modelos.Instituicoes Instituicao)
        {
            new InstituicaoDados().ExcluirInstituicao(Instituicao);
        }

        public int VerificaExclusao(int Id)
        {
            return new InstituicaoDados().VereificaExclusao(Id);
        }

        public Modelos.Instituicoes RetornaInstituicaoPorTurma(int Turma)
        {
            return new InstituicaoDados().RetornaInstituicaoPorTurma(Turma);
        }
    }
}
