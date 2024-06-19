using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class CursoNegocios
    {
        public IList<Modelos.Cursos> RetornaCursos()
        {
            return new CursoDados().RetornaCursos();
        }

        public int InserirCurso(Modelos.Cursos Curso)
        {
            return new CursoDados().InserirCurso(Curso);
        }

        public void AtualizarCurso(Modelos.Cursos Curso)
        {
            new CursoDados().AlterarCurso(Curso);
        }

        public Modelos.Cursos RetornaCursoPorId(int Id)
        {
            return new CursoDados().RetornaCursoPorId(Id);
        }

        public void RemoverCurso(Modelos.Cursos Curso)
        {
            new CursoDados().RemoverCurso(Curso);
        }

        public IList<Modelos.Turmas> RetornaTurmasPorCurso(int CursoId)
        {
            return new CursoTurmaDados().RetornaTurmasPorCurso(CursoId);
        }

        public void InserirCursoTurma(int CursoId, int[] TurmaId)
        {
            new CursoTurmaDados().InserirCursoTurmas(CursoId, TurmaId);
        }

        public Modelos.Cursos RetornaCursoPorTurma(int TurmaId)
        {
            return new CursoTurmaDados().RetornaCursoPorTurma(TurmaId);
        }

        public void RemoverCursoTurma(int CursoId)
        {
            new CursoTurmaDados().RemoverCursoTurma(CursoId);
        }

    }
}
