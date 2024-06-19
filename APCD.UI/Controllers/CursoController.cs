using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;
using APCD.Comuns;

namespace APCD.UI.Controllers
{
    public class CursoController : Controller
    {
        //
        // GET: /Curso/
        public ActionResult Index()
        {
            return View();
        }

        //private MultiSelectList PreencheListaTurmas()
        //{
        //    IList<Modelos.Turmas> LstTurmas = new TurmaNegocios().RetornaTurmasValidas();
        //    return new MultiSelectList(LstTurmas, "TurmaId", "TurmaNome");
        //}

        //private MultiSelectList PreencheListaCursoTurmas(int CursoId)
        //{
        //    IList<Modelos.Turmas> LstTurmas = new CursoNegocios().RetornaTurmasPorCurso(CursoId);
        //    return new MultiSelectList(LstTurmas, "TurmaId", "TurmaNome");
        //}

        private MultiSelectList PreencheListaInstituicoes()
        {
            IList<Modelos.Instituicoes> LstInstituicoes = new InstituicaoNegocios().RetornaInstituicoes();
            LstInstituicoes.Insert(0, new Modelos.Instituicoes() { InstituicaoId = 0, InstituicaoNome = "Selecione" });
            return new MultiSelectList(LstInstituicoes, "InstituicaoId", "InstituicaoNome");
        }

        [HttpGet]
        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Cursos> LstCursos = new CursoNegocios().RetornaCursos();

            var JsonResult = new
            {
                total = LstCursos.Count / rows,
                page = page,
                records = LstCursos.Count,
                rows = (from f in LstCursos
                        select new {cell = new string[]{f.CursoId.ToString(), f.CursoNome, f.CursoEspecialidade, new InstituicaoNegocios().RetornaInsituicaoPorId(f.InstituicaoId).InstituicaoNome} 
                        }).ToArray()
            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {
            //ViewData["Turmas"] = PreencheListaTurmas();
            //ViewData["CursoTurmas"] = PreencheListaCursoTurmas(0);
            ViewData["Instituicao"] = PreencheListaInstituicoes();
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Cursos Curso)
        {
            if (Curso.InstituicaoId == 0)
                ModelState.AddModelError("cbInstituicao", "Informe a instituição");
            //ViewData["Turmas"] = PreencheListaTurmas();
            //ViewData["CursoTurmas"] = PreencheListaCursoTurmas(0);
            ViewData["Instituicao"] = PreencheListaInstituicoes();
            //var TurmasSelecionadas = frm["txtSelect"].Split(',');
            //int[] TurmaId = new int[TurmasSelecionadas.Length];
            //for (int i = 0; i < TurmasSelecionadas.Length; i++)
            //{
            //    TurmaId[i] = TurmasSelecionadas[i].ToInt32();
            //}
            if (ModelState.IsValid)
            {
                new CursoNegocios().InserirCurso(Curso);
                //new CursoNegocios().InserirCursoTurma(Curso.CursoId, TurmaId);
                return RedirectToAction("Index", "Curso");
            }
            else
            {
                return View("Novo", Curso);
            }
        }

        public ActionResult Editar(int Id)
        {
            //var q = PreencheListaTurmas();
            //var t = PreencheListaCursoTurmas(Id);
            //MultiSelectList ms = q;
            //foreach (var a in q)
            //{
            //    foreach (var b in t)
            //    {
            //        ms =new MultiSelectList(q.Where(c => c.Value != b.Value).ToList(), "Value", "Text");
            //    }
            //}
            //ViewData["Turmas"] = ms;
            //ViewData["CursoTurmas"] = t;
            ViewData["Instituicao"] = PreencheListaInstituicoes();
            Modelos.Cursos Curso = new CursoNegocios().RetornaCursoPorId(Id);
            return View("Editar", Curso);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Atualizar(FormCollection frm, Modelos.Cursos Curso)
        {
            if (Curso.InstituicaoId == 0)
                ModelState.AddModelError("cbInstituicao", "Informe a instituição");
            //ViewData["Turmas"] = PreencheListaTurmas();
            //ViewData["CursoTurmas"] = PreencheListaCursoTurmas(Curso.CursoId);
            ViewData["Instituicao"] = PreencheListaInstituicoes();
            //var TurmasSelecionadas = frm["txtSelect"].Trim().Split(',');
            //int[] TurmaId = new int[TurmasSelecionadas.Length];
            //for (int i = 0; i < TurmasSelecionadas.Length; i++)
            //{
            //    if (TurmasSelecionadas[i].ToInt32() != 0)
            //        TurmaId[i] = TurmasSelecionadas[i].ToInt32();
            //}

            if (ModelState.IsValid)
            {
                //new CursoNegocios().RemoverCursoTurma(Curso.CursoId);
                new CursoNegocios().AtualizarCurso(Curso);
                //new CursoNegocios().InserirCursoTurma(Curso.CursoId, TurmaId);

                return RedirectToAction("Index", "Curso");
            }
            else
            {
                return View("Editar", Curso);
            }
        }

        public ActionResult Excluir(int Id)
        {
            //ViewData["Turmas"] = PreencheListaTurmas();
            //ViewData["CursoTurmas"] = PreencheListaCursoTurmas(Id);
            ViewData["Instituicao"] = PreencheListaInstituicoes();
            Modelos.Cursos Curso = new CursoNegocios().RetornaCursoPorId(Id);
            if (ModelState.IsValid)
            {
                new CursoNegocios().RemoverCurso(Curso);
                return RedirectToAction("Index", "Curso");
            }
            else
            {
                return View("Editar", Curso);
            }
        }
    }
}
