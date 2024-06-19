using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class MatriculaNegocios
    {
        public IList<Modelos.Matriculas> RetornaMatriculas()
        {
            return new MatriculaDados().RetornaMatriculas();
        }

        public void ConcluirMatricula(Modelos.Matriculas Matricula)
        {
            new MatriculaDados().ConcluirMatricula(Matricula);
        }

        public Modelos.Matriculas RetornaMatriculaPorId(int Id)
        {
            return new MatriculaDados().RetornaMatriculaPorId(Id);
        }

        public IList<Modelos.Turmas> PesquisaTurma(string param)
        {
            return new MatriculaDados().PesquisaTurma(param);
        }

        public void InserirMatriculaTurma(Modelos.MatriculaTurma matturma)
        {
            new MatriculaDados().InserirMatriculaTurma(matturma);
        }

        public void ExcluirMatriculaTurma(Modelos.MatriculaTurma matturma)
        {
            new MatriculaDados().ExcluirMatriculaturma(matturma);
        }

        public IList<Modelos.Alunos> RetornaAlunosMatriculadosPorTurma(int TurmaId)
        {
            return new MatriculaDados().RetornaAlunosMatriculadosPorTurma(TurmaId);
        }
    }
}
