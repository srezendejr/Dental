using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;
using System.Collections;

namespace APCD.UI.Controllers
{
    public class MatriculaController : Controller
    {
        //
        // GET: /Matricula/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Matriculas> LstMatriculas = new MatriculaNegocios().RetornaMatriculas();
            var JsonResult = new
            {
                total = LstMatriculas.Count / rows,
                page = page,
                records = LstMatriculas.Count,
                rows = (from f in LstMatriculas
                        select new { cell = new string[] {f.MatriculaId.ToString(), f.MatriculaData.ToShortDateString(), new AlunoNegocios().RetonaAlunoPorId(f.AlunoId).AlunoNome,
                            f.MatriculaAnoGraduacao.ToString(), f.MatriculaMiniCurriculum, f.MatriculaOpcaoCurso
                            } }
                        ).ToArray()

            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboSexo();
            return View();
        }

        public void PreencheComboTipoLog()
        {
            IList<string> lst = new AlunoNegocios().RetornaTipoLogr();
            IList<SelectListItem> ListaTipoLog = new List<SelectListItem>();

            for (int i = 0; i < lst.Count; i++)
            {
                ListaTipoLog.Add(new SelectListItem() { Value = lst[i].ToString(), Text = lst[i].ToString() });
            }

            ListaTipoLog.Insert(0, new SelectListItem() { Value = "0", Text = "Selecione" });

            ViewData["TipoLog"] = ListaTipoLog.OrderBy(a => a.Value).ToList();
        }

        public void PreencheComboUf()
        {
            IList<string> lst = new AlunoNegocios().RetornaUf();
            IList<SelectListItem> ListaUf = new List<SelectListItem>();

            for (int i = 0; i < lst.Count; i++)
            {
                ListaUf.Add(new SelectListItem() { Value = lst[i].ToString(), Text = lst[i].ToString() });
            }

            ListaUf.Insert(0, new SelectListItem() { Value = "0", Text = "Selecione" });

            ViewData["Uf"] = ListaUf.OrderBy(a => a.Value).ToList();
        }

        public void PreencheComboSexo()
        {
            IList<SelectListItem> LstSexo = new List<SelectListItem>();
            LstSexo.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
            LstSexo.Add(new SelectListItem() { Text = "Feminino", Value = "2" });
            LstSexo.Insert(0, new SelectListItem() { Text = "Selecione", Value = "0" });
            ViewData["Sexo"] = LstSexo;
        }

        [HttpPost]
        public ActionResult SalvarAluno(FormCollection frm, Modelos.Alunos Aluno)
        {
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboSexo();
            if (ModelState.IsValid)
            {
                Aluno.AlunoCPF = Aluno.AlunoCPF.Replace(".", "").Replace("-", "");
                Aluno.AlunoCep = Aluno.AlunoCep.Replace("-", "");
                Aluno.AlunoFoneCelular = Aluno.AlunoFoneCelular != null ? Aluno.AlunoFoneCelular.Replace("(", "").Replace(")", "").Replace("-", "") : null;
                Aluno.AlunoFoneComercial = Aluno.AlunoFoneComercial != null ? Aluno.AlunoFoneComercial.Replace("(", "").Replace(")", "").Replace("-", "") : null;
                Aluno.AlunoFoneResidencial = Aluno.AlunoFoneResidencial.Replace("(", "").Replace(")", "").Replace("-", "");
                Aluno.AlunoDataCadastro = DateTime.Now;
                new AlunoNegocios().InserirAluno(Aluno);
                return RedirectToAction("Concluir", "Matricula", new { IdAluno = Aluno.AlunoId });
            }
            else
            {
                return View("Novo", Aluno);

            }
        }

        public ActionResult Concluir(int IdAluno)
        {
            ViewData["Midia"] = PreecheMidia();
            TempData["MatTurma"] = null;
            ViewData["Instituicao"] = PreencheInstituicao();
            PreencheComboStatus();
            PreencheComboAnoGrad();
            Modelos.Matriculas Matricula = new Modelos.Matriculas();
            Matricula.AlunoId = IdAluno;
            Matricula.MatriculaData = DateTime.Now.Date;
            Matricula.MatriculaStatus = Convert.ToInt32(Modelos.EnumStatus.Ativo);
            return View("Concluir", Matricula);
        }

        [HttpPost]
        public ActionResult PesquisaTurma(string param)
        {
            IList<Modelos.Turmas> LstMatTur = new List<Modelos.Turmas>();
            LstMatTur = new MatriculaNegocios().PesquisaTurma(param);
            return PartialView("_FormPesquisaTurma", LstMatTur);
        }

        [HttpPost]
        public ActionResult IncluirTurma(string turma, string matricula)
        {
            IList<Modelos.MatriculaTurma> LstMatTurma;
            Modelos.MatriculaTurma MatTurma = new Modelos.MatriculaTurma();
            if (TempData["MatTurma"] == null)
                LstMatTurma = new TurmaNegocios().RetornaTurmasPorMatricula(Convert.ToInt32(matricula));
            else
                LstMatTurma = (List<Modelos.MatriculaTurma>)TempData["MatTurma"];

            MatTurma.TurmaId = Convert.ToInt32(turma);
            LstMatTurma.Add(MatTurma);

            TempData["MatTurma"] = LstMatTurma;

            return PartialView("_FormMatriculaTurma", LstMatTurma);
        }

        public MultiSelectList PreecheMidia()
        {
            IList<Modelos.Midias> LstMidia = new MidiaNegocios().RetornaMidias();
            return new MultiSelectList(LstMidia, "MidiaId", "MidiaNome");
        }

        public MultiSelectList PreencheInstituicao()
        {
            IList<Modelos.Instituicoes> LstInstituicao = new InstituicaoNegocios().RetornaInstituicoes();
            return new MultiSelectList(LstInstituicao, "InstituicaoId", "InstituicaoNome");
        }

        public void PreencheComboStatus()
        {
            Array arr = Enum.GetValues(typeof(Modelos.EnumStatus));
            ViewData["Status"] = Comuns.Comuns.PreencheComboEnum(arr).OrderBy(a => a.Text).ToList();
        }

        public void PreencheComboAnoGrad()
        {
            IList<SelectListItem> LstItens = new List<SelectListItem>();
            for (int i = DateTime.Now.Year - 20; i <= DateTime.Now.Year; i++)
            {
                LstItens.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
            ViewData["AnoGrad"] = LstItens.OrderByDescending(a=>a.Value).ToList();
        }

        public ActionResult ConcluirMatricula(FormCollection frm, Modelos.Matriculas Matricula)
        {
            if (ModelState.IsValid)
            {
                Matricula.MatriculaStatus = Convert.ToInt32(Modelos.EnumStatus.Ativo);
                new MatriculaNegocios().ConcluirMatricula(Matricula);
                IList<Modelos.MatriculaTurma> lst = (List<Modelos.MatriculaTurma>)TempData["MatTurma"];
                foreach (Modelos.MatriculaTurma matturma in lst)
                {
                    matturma.MatriculaId = Matricula.MatriculaId;
                    new MatriculaNegocios().InserirMatriculaTurma(matturma);
                }
                return RedirectToAction("Index", "Matricula");
            }
            else
            {
                return View("Concluir", Matricula);
            }
        }

        public ActionResult Editar(int Id)
        {
            PreencheComboStatus();
            PreencheComboAnoGrad();
            Modelos.Matriculas Matricula = new MatriculaNegocios().RetornaMatriculaPorId(Id);
            TempData["MatTurma"] = new TurmaNegocios().RetornaTurmasPorMatricula(Id);
            ViewData["Midia"] = PreecheMidia();
            ViewData["Instituicao"] = PreencheInstituicao();

            return View("Editar", Matricula);
        }

        [HttpPost]
        public ActionResult ExcluirTurma(string Matricula, string Turma)
        {
            IList<Modelos.MatriculaTurma> lstMatturma;
            if (TempData["MatTurma"] == null)
                lstMatturma = new TurmaNegocios().RetornaTurmasPorMatricula(Convert.ToInt32(Matricula));
            else
                lstMatturma = (List<Modelos.MatriculaTurma>)TempData["MatTurma"];

            for (int i = 0; i < lstMatturma.Count; i++)
            {
                if (lstMatturma[i].MatriculaId == Convert.ToInt32(Matricula) && lstMatturma[i].TurmaId == Convert.ToInt32(Turma))
                {
                    lstMatturma.Remove(lstMatturma[i]);
                }
            }

            TempData["MatTurma"] = lstMatturma;
            return PartialView("_FormMatriculaTurma", lstMatturma);
        }
    }
}
