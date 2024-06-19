using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web;

namespace APCD.Modelos
{
    public class Diagnosticos
    {
        [Key]
        public int DiagnosticoId
        {
            get;
            set;
        }

        [DisplayName("Paciente:")]
        [Required(ErrorMessage="Informe o paciente do diagnóstico.")]
        public int PacienteId
        {
            get;
            set;
        }

        [DisplayName("Data Diagnóstico:")]
        public DateTime DiagnosticoData
        {
            get;
            set;
        }

        [DisplayName("Imagem Frontal:")]
        public Byte[] ImagemFrontal
        {
            get;
            set;
        }

        [DisplayName("Imagem RX:")]
        public Byte[] ImagemRx
        {
            get;
            set;
        }

        [DisplayName("Imagem Superior:")]
        public Byte[] ImagemSuperior
        {
            get;
            set;
        }

        [DisplayName("Imagem Inferior:")]
        public Byte[] ImagemInferior
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Pacientes> Pacientes { get; set; }
        public virtual ICollection<Modelos.DiagnosticoDentes> DiagnosticoDentes { get; set; }
        public virtual ICollection<Modelos.DiagnosticoTratamentos> DiagnosticoTratamento { get; set; }
    }
}
