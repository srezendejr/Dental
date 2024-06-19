using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class Procedimentos
    {
        [Key]
        public int ProcedimentoId
        {
            get;
            set;
        }

        [DisplayName("Nome:")]
        [Required(ErrorMessage="Informe o nome do tratamento.")]
        public string ProcedimentoNome
        {
            get;
            set;
        }

        [DisplayName("Descrição Procedimento:")]
        public string ProcedimentoDescricao
        {
            get;
            set;
        }

        [DisplayName("Tipo Procedimento:")]
        [CustomValidation(typeof(ValidarTipoProcedimento), "ValidarTipo")]
        public int ProcedimentoTipo
        {
            get;
            set;
        }

        [DisplayName("Valor:")]
        [Required(ErrorMessage="Informe o valor do tratamento")]
        public decimal ProcedimentoValor
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.DiagnosticoTratamentos> DiagnosticoTratamentos
        {
            get;
            set;
        }
    }

    public static class ValidarTipoProcedimento
    {
        public static ValidationResult ValidarTipo(int Tipo)
        {
            if (Tipo < 1 || Tipo > 2)
            {
                return new ValidationResult("Informe o tipo do procedimento");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
