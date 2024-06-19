using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APCD.Modelos
{
    public class Perfis
    {
        public Perfis()
        { 

        }

        [Key]
        public int Id
        {
            get;
            set;
        }

        [DisplayName("Nome Perfil:")]
        public string Nome
        {
            get;
            set;
        }

        [DisplayName("Lista de Permissões:")]
        public IList<string> Permissao
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Perfis> lstPerfil
        {
            get;
            set;
        }


    }
}
