using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APCD.Dados;

namespace APCD.Negocios
{
    public class ProdutoNegocios
    {
        public IList<Modelos.Produtos> RetornaProdutos()
        {
            return new ProdutoDados().RetornaProdutos();
        }

        public Modelos.Produtos RetornaProdutoPorId(int Id)
        {
            return new ProdutoDados().RetornaProdutoPorId(Id);
        }

        public void InserirProduto(Modelos.Produtos Produto)
        {
            new ProdutoDados().InserirProduto(Produto);
        }

        public void AtualizarProduto(Modelos.Produtos Produto)
        {
            new ProdutoDados().AtualizarProduto(Produto);
        }

        public int VerificaExclusao(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoverProduto(Modelos.Produtos Produto)
        {
            new ProdutoDados().RemoverProduto(Produto);
        }
    }
}
