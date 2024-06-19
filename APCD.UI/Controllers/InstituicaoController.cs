using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;

namespace APCD.UI.Controllers
{
    public class InstituicaoController : Controller
    {
        //
        // GET: /Instituicao/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Instituicoes> LstInstituicoes = new InstituicaoNegocios().RetornaInstituicoes();
            var JsonResult = new
            {
                total = LstInstituicoes.Count / rows,
                page = page,
                records = LstInstituicoes.Count,
                rows = (from f in LstInstituicoes
                        select new { cell = new string[] { f.InstituicaoId.ToString(), f.InstituicaoNome, f.InstituicaoCoordenador.ToString(), f.InstituicaoEmail, f.InstituicaoFone } }
                            ).ToArray()
            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Instituicoes Instituicao)
        {
            if (ModelState.IsValid)
            {
                Instituicao.InstituicaoFone = Instituicao.InstituicaoFone.Replace("(", "").Replace(")", "").Replace("-", "");
                new InstituicaoNegocios().SalvarInstituicao(Instituicao);
                return RedirectToAction("Index", "Instituicao");
            }
            else
            {
                return View("Novo", Instituicao);
            }
        }

        public ActionResult Editar(int Id)
        {
            Modelos.Instituicoes Instituicao = new InstituicaoNegocios().RetornaInsituicaoPorId(Id);
            return View(Instituicao);
        }

        public ActionResult Excluir(int Id)
        {
            Modelos.Instituicoes Instituicao = new InstituicaoNegocios().RetornaInsituicaoPorId(Id);
            if (new InstituicaoNegocios().VerificaExclusao(Id) > 0)
            {
                ModelState.AddModelError("", "Não foi possível excluir, pois existem cursos vinculados a esta Instituição");
                return View("Editar", Instituicao);
            }
            else 
            {
                new InstituicaoNegocios().ExcluirInstituicao(Instituicao);
                return RedirectToAction("Index", "Instituicao");
            }
        }
    }
}
