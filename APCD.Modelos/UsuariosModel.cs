using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class UsuariosModel
    {
        public UsuariosModel()
        {
            Perfil = new Perfis();
        }

        [Key]
        public int UsuarioId
        {
            get;
            set;
        }

        [Required(ErrorMessage="Informe o nome do usuário")]
        [DisplayName("Nome:")]
        public string UsuarioNome
        {
            get;
            set;
        }

        [Required(ErrorMessage="Informe o Email do Usuário")]
        [DisplayName("Email:")]
        public string UsuarioEmail
        {
            get;
            set;
        }

        [Required(ErrorMessage="Informe a senha")]
        [DisplayName("Senha:")]
        public string UsuarioSenha
        {
            get;
            set;
        }

        [Required(ErrorMessage="Informe o perfil do usuário")]
        [DisplayName("Perfil:")]
        public int PerfilId
        {
            get;
            set;
        }

        public virtual Modelos.Perfis Perfil
        {
            get;
            set;
        }

        [DisplayName("Status:")]
        public virtual EnumStatus Status
        {
            get;
            set;
        }
    }
}
