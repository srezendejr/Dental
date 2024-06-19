using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class Turmas
    {
        public Turmas()
        { }

        [Key]
        public int TurmaId
        {
            get;
            set;
        }

        [DisplayName("Nome:")]
        public string TurmaNome
        {
            get;
            set;
        }

        [DisplayName("Data Início:")]
        [Required(ErrorMessage = "Data de Início é necessário")]
        public DateTime TurmaDataInicio
        {
            get;
            set;
        }

        [DisplayName("Data Final:")]
        [CustomValidation(typeof(Comuns.Comuns), "Validate")]
        public DateTime? TurmaDataFim
        {
            get;
            set;
        }

        [DisplayName("Curso:")]
        public int CursoId
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Cursos> Cursos
        {
            get;
            set;
        }
        public virtual ICollection<Modelos.MatriculaTurma> Matriculas
        {
            get;
            set;
        }
        public virtual ICollection<Modelos.Pacientes> Pacientes
        {
            get;
            set;
        }
    }
}
