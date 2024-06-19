using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class Instituicoes
    {
        [Key]
        public int InstituicaoId
        {
            get;
            set;
        }

        [DisplayName("Nome:")]
        public string InstituicaoNome
        {
            get;
            set;
        }

        [DisplayName("Coordenador:")]
        [Required(ErrorMessage="Informe o nome do Coordenador")]
        public string InstituicaoCoordenador
        {
            get;
            set;
        }

        [DisplayName("Telefone Instituição:")]
        [Required(ErrorMessage="Informe o telefone da instituição")]
        public string InstituicaoFone
        {
            get;
            set;
        }

        [DisplayName("Email Instituição:")]
        [Required(ErrorMessage="Informe um e-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Informe um e-mail válido.")]
        [DataType(DataType.EmailAddress)]
        public string InstituicaoEmail
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Cursos> Cursos
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
