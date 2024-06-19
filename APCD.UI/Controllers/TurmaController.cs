using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;

namespace APCD.UI.Controllers
{
    public class TurmaController : Controller
    {
        //
        // GET: /Turma/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Turmas> LstTurma = new TurmaNegocios().RetornaTurmas();

            var JsonResult = new
            {
                total = LstTurma.Count / rows,
                page = page,
                records = LstTurma.Count,
                rows = (from f in LstTurma
                        select new 
                        {
                            cell = new string[] {f.TurmaId.ToString(), f.TurmaNome, new CursoNegocios().RetornaCursoPorId(f.CursoId).CursoNome, 
                                f.TurmaDataInicio.ToShortDateString(), f.TurmaDataFim == null ? string.Empty: f.TurmaDataFim.Value.ToShortDateString()}
                        }
                        ).ToArray()
            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public MultiSelectList BuscarCurso()
        {
            IList<Modelos.Cursos> LstCurso = new CursoNegocios().RetornaCursos();
            LstCurso.Insert(0, new Modelos.Cursos() {CursoId=0, CursoNome="Selecione" });
            return new MultiSelectList(LstCurso, "CursoId", "CursoNome");
        }

        public ActionResult RetornaInstiuicaoPorCurso(string Curso)
        {
            int IdCurso = Int32.Parse(Curso);
            string NomeInstituicao = string.Empty;
            string Especialidade = string.Empty;
            if (IdCurso > 0)
            {
                Modelos.Cursos curso = new CursoNegocios().RetornaCursoPorId(IdCurso);
                Especialidade = curso.CursoEspecialidade;
                Modelos.Instituicoes Instituicao = new InstituicaoNegocios().RetornaInsituicaoPorId(curso.InstituicaoId);
                NomeInstituicao = Instituicao.InstituicaoNome;
            }
            var JsonResult = new { NomeInstituicao, Especialidade };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {
            ViewData["Curso"] = BuscarCurso();
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Turmas Turma)
        {
            ViewData["Curso"] = BuscarCurso();
            if (Turma.CursoId == 0)
                ModelState.AddModelError("cboCurso", "Informe o curso da turma");
            if (ModelState.IsValid)
            {
                new TurmaNegocios().InserirTurma(Turma);
                return RedirectToAction("Index", "Turma");
            }
            else
            {
                return View("Novo", Turma);
            }
        }


        public ActionResult Editar(int Id)
        {
            ViewData["Curso"] = BuscarCurso();
            Modelos.Turmas Turma = new TurmaNegocios().RetornaTurmaPorId(Id);
            return View("Editar", Turma);
        }

        [HttpPost]
        public ActionResult Atualizar(FormCollection frm, Modelos.Turmas Turma)
        {
            ViewData["Curso"] = BuscarCurso();
            if (Turma.CursoId == 0)
                ModelState.AddModelError("cboCurso", "Informe o curso da turma");

            if (ModelState.IsValid)
            {
                new TurmaNegocios().AtualizarTurma(Turma);
                return RedirectToAction("Index", "Turma");
            }
            else
            {
                return View("Editar", Turma);
            }
        }

        public ActionResult Excluir(int Id)
        {
            ViewData["Curso"] = BuscarCurso();
            Modelos.Turmas Turma = new TurmaNegocios().RetornaTurmaPorId(Id);
            if (ModelState.IsValid)
            {
                new TurmaNegocios().RemoverTurma(Turma);
                return RedirectToAction("Index", "Turma");
            }
            else
            {
                return View("Editar", Turma);
            }
        }
    }
}
