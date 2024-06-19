using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;

namespace APCD.UI.Controllers
{
    public class MidiaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Midias> LstMidias = new MidiaNegocios().RetornaMidias();

            var JsonResult = new
            {
                total = LstMidias.Count / rows,
                page = page,
                records = LstMidias.Count,
                rows = (from f in LstMidias
                        select new
                        {
                            cell = new string[] { f.MidiaId.ToString(), f.MidiaNome }
                        }
                ).ToArray()
            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Midias Midia)
        {
            if (ModelState.IsValid)
            {
                new MidiaNegocios().InserirMidia(Midia);
                return RedirectToAction("Index", "Midia");
            }
            else
            {
                return View("Novo", Midia);
            }
        }

        public ActionResult Editar(int Id)
        {
            Modelos.Midias Midia = new MidiaNegocios().RetornaMidiaPorId(Id);
            return View("Editar", Midia);
        }

        [HttpPost]
        public ActionResult Atualizar(FormCollection frm, Modelos.Midias Midia)
        {
            if (ModelState.IsValid)
            {
                new MidiaNegocios().AtualizaMidia(Midia);
                return RedirectToAction("Index", "Midia");
            }
            else
            {
                return View("Editar", Midia);
            }
        }

        public ActionResult Excluir(int Id)
        {
            MidiaNegocios Negocios = new MidiaNegocios();
            Modelos.Midias Midia = new MidiaNegocios().RetornaMidiaPorId(Id);
            if (Negocios.VerificaExclusao(Id) > 0)
                ModelState.AddModelError("Erro na Exclusão", "A mídia não pode ser excluída pois está ligada a outros cadastros.");

            if (ModelState.IsValid)
            {
                Negocios.RemoverMidia(Midia);
                return RedirectToAction("Index", "Midia");
            }
            else
            {
                return View("Editar", Midia);
            }
        }
    }
}
