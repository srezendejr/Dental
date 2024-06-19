using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class Midias
    {
        public Midias()
        { 
        }

        [Key]
        public int MidiaId
        {
            get;
            set;
        }

        [DisplayName("Nome Mídia:")]
        [Required(ErrorMessage="Informe o nome da mídia.")]
        public string MidiaNome
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Pacientes> Pacientes
        {
            get;
            set;
        }
        public virtual ICollection<Modelos.Matriculas> Matriculas
        {
            get;
            set;
        }
    }
}
