using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class Produtos
    {
        public Produtos()
        { 
        }

        [Key]
        public int ProdutoId
        {
            get;
            set;
        }

        [Required(ErrorMessage="Informe o nome do produto")]
        [DisplayName("Descrição:")]
        public string ProdutoNome
        {
            get;
            set;
        }

        [Required(ErrorMessage="Informe o Status")]
        [DisplayName("Status:")]
        public int ProdutoStatus
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Informe o Tipo do Produto Mão de Obra/Produto")]
        [DisplayName("Tipo Produto:")]
        public int ProdutoTipo
        {
            get;
            set;
        }

    }
}
