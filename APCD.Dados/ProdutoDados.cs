using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity.Validation;

namespace APCD.Dados
{
    public class ProdutoDados
    {

        public IList<Modelos.Produtos> RetornaProdutos()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.ProdutosSet.ToList();
            }
        }

        public Modelos.Produtos RetornaProdutoPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.ProdutosSet.Where(a => a.ProdutoId == Id).FirstOrDefault();
            }
        }

        public void InserirProduto(Modelos.Produtos Produto)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                try
                {
                    Context.Entry(Produto).State = EntityState.Added;
                    Context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
        }

        public void AtualizarProduto(Modelos.Produtos Produto)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                try
                {
                    Context.Entry(Produto).State = EntityState.Modified;
                    Context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
        }

        public void DeletarProduto(Modelos.Produtos Produto)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                try
                {
                    Context.Entry(Produto).State = EntityState.Deleted;
                    Context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
        }

        public void RemoverProduto(Modelos.Produtos Produto)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Produto).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }
    }
}
