using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;
using APCD.Modelos;
using APCD.Comuns;

namespace APCD.UI.Controllers
{
    public class ProdutoController : Controller
    {
        //
        // GET: /Produto/

        public ActionResult Index()
        {
            return View("Index", "Home");
            //return View();
        }

        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Produtos> LstProduto = new ProdutoNegocios().RetornaProdutos();

            var JsonResult = new
                {
                    total = LstProduto.Count / rows,
                    page = page,
                    records = LstProduto.Count,
                    rows = (from f in LstProduto
                            select new {cell = new string[] {f.ProdutoId.ToString(), f.ProdutoNome, 
                                f.ProdutoTipo == 1? "Produto": "Serviço", 
                                f.ProdutoStatus == 0 ? "Desativado":"Ativado"} 
                            }).ToArray()
                };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {
            return View("Index", "Home");
            //PreencheTipo();
            //PreencheStatus();
            //return View();
        }

        public void PreencheTipo()
        {
            IList<SelectListItem> lstTipo = new List<SelectListItem>();
            lstTipo.Add(new SelectListItem() {Value = "1", Text="Produto" });
            lstTipo.Add(new SelectListItem() { Value = "2", Text = "Serviço" });
            lstTipo.Insert(0, new SelectListItem() {Value = "0", Text="Selecione" });
            ViewData["Tipo"] = lstTipo.OrderBy(a => a.Value).ToList();
        }

        public void PreencheStatus()
        {
            Array enumValor = Enum.GetValues(typeof(EnumStatus));
            var Lista = Comuns.Comuns.PreencheComboEnum(enumValor).OrderBy(a => a.Text).ToList();
            Lista.Insert(0, new SelectListItem() { Value = "-1", Text = "Selecione"});
            ViewData["Status"] = Lista;
        }

        public ActionResult Editar(int Id)
        {
            return View("Index", "Home");
            //PreencheStatus();
            //PreencheTipo();
            //Modelos.Produtos Produto = new ProdutoNegocios().RetornaProdutoPorId(Id);
            //return View("Editar", Produto);
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Produtos Produto)
        {
            if (Produto.ProdutoTipo == 0)
                ModelState.AddModelError("ProdutoTipo", "Informe o tipo");
            if (Produto.ProdutoStatus == -1)
                ModelState.AddModelError("ProdutoStatus", "Informe o Status");
            if (ModelState.IsValid)
            {
                new ProdutoNegocios().InserirProduto(Produto);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                PreencheStatus();
                PreencheTipo();
                return View("Novo", Produto);
            }
        }

        [HttpPost]
        public ActionResult Atualizar(FormCollection frm, Modelos.Produtos Produto)
        {
            if (Produto.ProdutoTipo == 0)
                ModelState.AddModelError("ProdutoTipo", "Informe o tipo");
            if (Produto.ProdutoStatus == -1)
                ModelState.AddModelError("ProdutoStatus", "Informe o Status");

            if (ModelState.IsValid)
            {
                new ProdutoNegocios().AtualizarProduto(Produto);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return View("Editar", Produto);
            }
        }

        public ActionResult Excluir(int Id)
        {
            return View("Index", "Home");
            //ProdutoNegocios Negocio = new ProdutoNegocios();
            //Modelos.Produtos Produto = new ProdutoNegocios().RetornaProdutoPorId(Id);
            //if (Negocio.VerificaExclusao(Id) > 0)
            //    ModelState.AddModelError("Error", "Não é possível excluir o produto, pois ele está relacionado a outro cadastro");
            //if (ModelState.IsValid)
            //{
            //    Negocio.RemoverProduto(Produto);
            //    return RedirectToAction("Index", "Produto");
            //}
            //else
            //{
            //    return View("Editar", Produto);
            //}
        }
    }
}
