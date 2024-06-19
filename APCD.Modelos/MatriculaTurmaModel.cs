using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace APCD.Modelos
{
    public class MatriculaTurma
    {
        [Key]
        public int MatriculaTurmaId
        {
            get;
            set;
        }

        public int MatriculaId
        {
            get;
            set;
        }

        public int TurmaId
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Turmas> Turma
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Matriculas> Matricula
        {
            get;
            set;
        }
    }
}
