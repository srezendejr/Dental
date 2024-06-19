using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;

namespace APCD.UI.Controllers
{
    public class ProcedimentoController : Controller
    {
        //
        // GET: /Procedimento/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PreencherGrid(string sidx, string sordx, int page, int rows)
        {
            IList<Modelos.Procedimentos> LstProcedimentos = new ProcedimentoNegocios().RetornarProcedimentos();
            var JsonResult = new
            {
                total = LstProcedimentos.Count / rows,
                page = page,
                records = LstProcedimentos.Count,
                rows = (from f in LstProcedimentos
                        select new { cell = new string[]{f.ProcedimentoId.ToString(),f.ProcedimentoNome, f.ProcedimentoDescricao, 
                            f.ProcedimentoValor.ToString("C2"), Comuns.Comuns.ObterDescricao(((Modelos.EnumTipoProcedimento)f.ProcedimentoTipo))} }
                            ).ToArray()
            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {
            ViewData["TipoProc"] = PreencheTipoProcedimento();
            return View();
        }

        public MultiSelectList PreencheTipoProcedimento()
        {
            Array enumValores = Enum.GetValues(typeof(Modelos.EnumTipoProcedimento));
            IList<KeyValuePair<int, string>> KvEnum = new List<KeyValuePair<int, string>>();
            foreach (Enum evalor in enumValores)
            {
                KvEnum.Add(new KeyValuePair<int, string>(Convert.ToInt32(evalor), Comuns.Comuns.ObterDescricao(evalor)));
            }
            KvEnum.Insert(0, new KeyValuePair<int, string>(0, "Selecione"));
            return new MultiSelectList(KvEnum, "Key","Value");
        }

        public ActionResult Editar(int Id)
        {
            ViewData["TipoProc"] = PreencheTipoProcedimento();
            Modelos.Procedimentos Procedimento = new ProcedimentoNegocios().RetornaProcedimentoPorId(Id);
            return View(Procedimento);
        }

        public ActionResult Salvar(FormCollection frm, Modelos.Procedimentos Procedimento)
        {
            ViewData["TipoProc"] = PreencheTipoProcedimento();
            //if (Procedimento.ProcedimentoTipo == 0)
            //    ModelState.AddModelError("cboTipo", "Informe o tipo do procedimento");
            if (ModelState.IsValid)
            {
                new ProcedimentoNegocios().SalvarProcedimento(Procedimento);
                return RedirectToAction("Index", "Procedimento");
            }
            else 
            {
                if (Procedimento.ProcedimentoId == 0)
                    return View("Novo", Procedimento);
                else
                    return View("Editar", Procedimento);
            }
        }

        public ActionResult Excluir(int Id)
        {
            ViewData["TipoProc"] = PreencheTipoProcedimento();
            if (new ProcedimentoNegocios().VerificaExcluscao(Id))
            {
                ProcedimentoNegocios Negocios = new ProcedimentoNegocios();
                Modelos.Procedimentos Procedimento = Negocios.RetornaProcedimentoPorId(Id);
                Negocios.ExcluirProcedimento(Procedimento);
                return RedirectToAction("Index", "Procedimento");
            }
            else
            {
                ModelState.AddModelError("txtNome", "Este procedimento não pode ser excluído");
                return View("Editar", new ProcedimentoNegocios().RetornaProcedimentoPorId(Id));
            }
        }
    }
}
