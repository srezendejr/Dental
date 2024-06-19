using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace APCD.Modelos
{
    public class Cursos
    {
        public Cursos()
        {
        }

        [Key]
        public int CursoId
        {
            get;
            set;
        }

        [DisplayName("Nome Curso:")]
        [Required(ErrorMessage="Informe o nome do curso")]
        public string CursoNome
        {
            get;
            set;
        }

        [DisplayName("Especialidade:")]
        [Required(ErrorMessage="Informe a especialidade")]
        public string CursoEspecialidade
        {
            get;
            set;
        }

        public int InstituicaoId
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Pacientes> Pacientes
        {
            get;
            set;
        }
        public virtual ICollection<Modelos.Turmas> Turmas
        {
            get;
            set;
        }
        public virtual ICollection<Modelos.Instituicoes> Instituicoes
        {
            get;
            set;
        }
    }
}
