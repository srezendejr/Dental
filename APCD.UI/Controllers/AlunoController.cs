using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;

namespace APCD.UI.Controllers
{
    public class AlunoController : Controller
    {
        //
        // GET: /Aluno/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Alunos> LstAlunos = new AlunoNegocios().RetornaAlunos();
            var JsonResult = new
            {
                total = LstAlunos.Count /rows,
                page = page,
                records = LstAlunos.Count,
                rows = (from f in LstAlunos
                        select new { cell = new string[] { f.AlunoId.ToString(), f.AlunoNome, f.DataNascimento == null ? string.Empty : f.DataNascimento.Value.ToString("dd/MM/yyyy"), f.AlunoCPF, f.AlunoFoneResidencial } }
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
            LstSexo.Add(new SelectListItem() {Text="Masculino", Value="1" });
            LstSexo.Add(new SelectListItem() {Text="Feminino", Value="2" });
            LstSexo.Insert(0, new SelectListItem() { Text = "Selecione", Value = "0" });
            ViewData["Sexo"] = LstSexo;
        }

        [HttpPost]
        public ActionResult PesquisarCep(string CodigoCep)
        {
            Modelos.Cep Cep = new AlunoNegocios().PesquisarCep(CodigoCep.Replace("-", ""));
            if (Cep != null)
            {
                var JsonResult = new { Cep.CepId, Cep.CepCodigo, Cep.CepTipoLogradouro, Cep.CepLogradouro, Cep.CepComplementoLog, Cep.CepBairro, Cep.CepCidade, Cep.CepUF };
                return Json(JsonResult, JsonRequestBehavior.AllowGet);
            }
            return
                Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Alunos Aluno)
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
                return RedirectToAction("Index", "Aluno");
            }
            else
            {
                if (Aluno.AlunoId == 0)
                    return View("Novo", Aluno);
                else
                    return View("Editar", Aluno);
            }
        }

        public ActionResult Editar(int Id)
        {
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboSexo();
            Modelos.Alunos Aluno = new AlunoNegocios().RetonaAlunoPorId(Id);
            return View(Aluno);
        }

        public ActionResult Excluir(int Id)
        {
            int i = new AlunoNegocios().VerificaExclusao(Id);
            Modelos.Alunos Aluno = new AlunoNegocios().RetonaAlunoPorId(Id);
            if (i > 0)
            {
                ModelState.AddModelError("txtNomeAluno", "O Aluno não pode ser excluído pois contém vínculo com pacientes");
            }
            if (ModelState.IsValid)
            {
                new AlunoNegocios().ExcluirAluno(Aluno);
                return RedirectToAction("Index", "Aluno");
            }
            else
            {
                PreencheComboTipoLog();
                PreencheComboUf();
                PreencheComboSexo();
                return View("Editar", Aluno);
            }
        }

    }
}
