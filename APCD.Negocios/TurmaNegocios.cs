using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class TurmaNegocios
    {
        public IList<Modelos.Turmas> RetornaTurmas()
        {
            return new TurmaDados().RetornaTurmas();
        }

        public Modelos.Turmas RetornaTurmaPorId(int Id)
        {
            return new TurmaDados().RetornaTurmaPorId(Id);
        }

        public void InserirTurma(Modelos.Turmas Turma)
        {
            new TurmaDados().InserirTurma(Turma);
        }

        public void AtualizarTurma(Modelos.Turmas Turma)
        {
            new TurmaDados().AtualizarTurma(Turma);
        }

        public void RemoverTurma(Modelos.Turmas Turma)
        {
            new TurmaDados().RemoverTurma(Turma);
        }

        public IList<Modelos.Turmas> RetornaTurmasValidas()
        {
            return new TurmaDados().RetornaTurmasValidas();
        }

        public IList<Modelos.MatriculaTurma> RetornaTurmasPorMatricula(int matricula)
        {
            return new TurmaDados().RetornaTurmasPorMatricula(matricula);
        }
    }
}
