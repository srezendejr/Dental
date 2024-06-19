using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace APCD.Modelos
{
    public class CursoTurmas
    {
        [Key]
        public int CursoTurmaId
        {
            get;
            set;
        }

        public int CursoId
        {
            get;
            set;
        }

        public int TurmaId
        {
            get;
            set;
        }

        //public virtual ICollection<Modelos.Cursos> Cursos
        //{
        //    get;
        //    set;
        //}

        //public virtual ICollection<Modelos.Turmas> Turmas
        //{
        //    get;
        //    set;
        //}
    }
}
