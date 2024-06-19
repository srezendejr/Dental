using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class Matriculas
    {
        [Key]
        public int MatriculaId
        {
            get;
            set;
        }

        public int AlunoId
        {
            get;
            set;
        }

        [DisplayName("Como Conheceu o curso?")]
        [Required(ErrorMessage = "Informe como conheceu o curso")]
        public int MidiaId
        {
            get;
            set;
        }

        [DisplayName("Porque resolveu fazer este curso?")]
        [Required(ErrorMessage="Informe a razão pela qual optou pelo curso")]
        public string MatriculaOpcaoCurso
        {
            get;
            set;
        }

        [DisplayName("Data da Matrícula:")]
        public DateTime MatriculaData
        {
            get;
            set;
        }

        [DisplayName("Status:")]
        public int MatriculaStatus
        {
            get;
            set;
        }

        [DisplayName("Faça uma breve descrição da experiência do aluno")]
        [Required(ErrorMessage="Informe as experiências anteriores do aluno")]
        public string MatriculaMiniCurriculum
        {
            get;
            set;
        }

        [DisplayName("Ano Graduação:")]
        public int MatriculaAnoGraduacao
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Alunos> Alunos
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.MatriculaTurma> Turmas
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Midias> Midias
        {
            get;
            set;
        }
    }
}
