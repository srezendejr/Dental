using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class DiagnosticoTratamentos
    {
        [Key]
        public int DiagnosticoTratamentoId
        {
            get;
            set;
        }

        [DisplayName("Procedimento:")]
        [Required(ErrorMessage="Informe o procedimento do tratamento")]
        public int ProcedimentoId
        {
            get;
            set;
        }

        public int DiagnosticoId
        {
            get;
            set;
        }

        public decimal ProcedimentoValor
        {
            get;
            set;
        }

        public int DiagnosticoTratamentoStatus
        {
            get;
            set;
        }

        [NotMapped]
        public string ProcedimentoNome
        {
            get;
            set;
        }

        public ICollection<Modelos.Diagnosticos> Diagnosticos
        {
            get;
            set;
        }
        public ICollection<Modelos.Procedimentos> Procedimentos
        {
            get;
            set;
        }
    }
}
