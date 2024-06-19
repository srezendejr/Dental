using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;

namespace APCD.UI.Controllers
{
    public class PacienteController : Controller
    {
        //
        // GET: /Paciente/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboMidia();
            ViewData["Instituicao"] = PreencheInstituicao();
            ViewData["Cursos"] = PreencheComboCurso(0);
            ViewData["Turmas"] = PreencheComboTurma(0);
            ViewData["Alunos"] = PrencheComboAluno(0);
            PreencheComboSexo();
            return View();
        }

        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Pacientes> LstPaciente = new PacienteNegocios().RetornaPacientes();

            var JsonResult = new
            {
                total = LstPaciente.Count / rows,
                page = page,
                records = LstPaciente.Count,
                rows = (from f in LstPaciente
                        select new
                        {
                            cell = new string[] { f.PacienteId.ToString(), f.PacienteNome, f.DataNascimento == null ? string.Empty : f.DataNascimento.Value.ToShortDateString(), f.PacienteCPF, f.PacienteFoneResidencial }
                        }).ToArray()
            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public MultiSelectList PreencheInstituicao()
        {
            IList<Modelos.Instituicoes> LstInstituicao = new InstituicaoNegocios().RetornaInstituicoes();
            LstInstituicao.Insert(0, new Modelos.Instituicoes() { InstituicaoId = 0, InstituicaoNome = "Selecione" });

            return new MultiSelectList(LstInstituicao, "InstituicaoId", "InstituicaoNome");
        }

        public void PreencheComboTipoLog()
        {
            IList<string> lst = new PacienteNegocios().RetornaTipoLogr();
            IList<SelectListItem> ListaTipoLog = new List<SelectListItem>();

            for (int i = 0; i < lst.Count; i++)
            {
                ListaTipoLog.Add(new SelectListItem() { Value = lst[i].ToString(), Text = lst[i].ToString() });
            }
            //ListaTipoLog.Add(new SelectListItem() {Value="Rua", Text="Rua" });
            //ListaTipoLog.Add(new SelectListItem() { Value = "Avenida", Text = "Avenida" });
            //ListaTipoLog.Add(new SelectListItem() { Value = "Praça", Text = "Praça" });
            //ListaTipoLog.Add(new SelectListItem() { Value = "Travessa", Text = "Travessa" });

            ListaTipoLog.Insert(0, new SelectListItem() { Value = "0", Text = "Selecione" });

            ViewData["TipoLog"] = ListaTipoLog.OrderBy(a => a.Value).ToList();
        }

        public void PreencheComboUf()
        {
            IList<string> lst = new PacienteNegocios().RetornaUf();
            IList<SelectListItem> ListaUf = new List<SelectListItem>();

            for (int i = 0; i < lst.Count; i++)
            {
                ListaUf.Add(new SelectListItem() { Value = lst[i].ToString(), Text = lst[i].ToString() });
            }

            ListaUf.Insert(0, new SelectListItem() { Value = "0", Text = "Selecione" });

            ViewData["Uf"] = ListaUf.OrderBy(a => a.Value).ToList();
        }

        public void PreencheComboMidia()
        {
            IList<Modelos.Midias> ListaMidia = new MidiaNegocios().RetornaMidias();
            IList<SelectListItem> lst = new List<SelectListItem>();
            for (int i = 0; i < ListaMidia.Count; i++)
            {
                lst.Add(new SelectListItem() { Value = ListaMidia[i].MidiaId.ToString(), Text = ListaMidia[i].MidiaNome });
            }

            lst.Insert(0, new SelectListItem() { Value = "0", Text = "Selecione" });

            ViewData["Midia"] = lst;
        }

        public JsonResult RetornaCursoPorInstituicao(int Instituicao)
        {
            var LstCurso = new CursoNegocios().RetornaCursos().Where(a => a.InstituicaoId == Instituicao).ToList();
            LstCurso.Insert(0, new Modelos.Cursos() {CursoId = 0, CursoNome="Selecione" });
            var JsonResult = from s in LstCurso select new {s.CursoId, s.CursoNome };
            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RetornaTurmaPorCurso(int Curso)
        {
            var LstTurmas = new TurmaNegocios().RetornaTurmas().Where(a => a.CursoId == Curso).ToList();
            LstTurmas.Insert(0, new Modelos.Turmas() {TurmaId = 0, TurmaNome="Selecione" });
            var JsonResult = from s in LstTurmas select new { s.TurmaId, s.TurmaNome };
            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RetornaAlunosPorTurma(int Turma)
        {
            var LstMatTurma = new MatriculaNegocios().RetornaAlunosMatriculadosPorTurma(Turma);
            LstMatTurma.Insert(0, new Modelos.Alunos() {AlunoId = 0, AlunoNome="Selecione" });
            var Jsonresult = from s in LstMatTurma select new { s.AlunoId, s.AlunoNome };
            return Json(Jsonresult, JsonRequestBehavior.AllowGet);
        }

        private MultiSelectList PreencheComboCurso(int? InstituicaoId)
        {
            IList<Modelos.Cursos> LstCurso;
            if (InstituicaoId == 0)
                LstCurso = new CursoNegocios().RetornaCursos();
            else
                LstCurso = new CursoNegocios().RetornaCursos().Where(a => a.InstituicaoId == InstituicaoId).ToList();

            LstCurso.Insert(0, new Modelos.Cursos() { CursoId = 0, CursoNome = "Selecione" });

            return new MultiSelectList(LstCurso, "CursoId", "CursoNome");
        }

        private MultiSelectList PrencheComboAluno(int? Turma)
        {
            IList<Modelos.Alunos> LstAlunos;
            if(Turma ==0)
                LstAlunos = new MatriculaNegocios().RetornaAlunosMatriculadosPorTurma(Convert.ToInt32(Turma));
            else
                LstAlunos = new AlunoNegocios().RetornaAlunos();
            LstAlunos.Insert(0, new Modelos.Alunos() {AlunoId = 0, AlunoNome="Selecione" });

            return new MultiSelectList(LstAlunos, "AlunoId", "AlunoNome");
        }

        private void PreencheComboSexo()
        {
            IList<SelectListItem> LstSexo = new List<SelectListItem>();
            LstSexo.Add(new SelectListItem() { Text = "Masculino", Value = "1" });
            LstSexo.Add(new SelectListItem() { Text = "Feminino", Value = "2" });
            LstSexo.Insert(0, new SelectListItem() { Text = "Selecione", Value = "0" });
            ViewData["Sexo"] = LstSexo;
        }

        [HttpPost]
        public ActionResult PesquisarCep(string CodigoCep)
        {
            Modelos.Cep Cep = new PacienteNegocios().PesquisarCep(CodigoCep.Replace("-", ""));
            if (Cep != null)
            {
                var JsonResult = new { Cep.CepId, Cep.CepCodigo, Cep.CepTipoLogradouro, Cep.CepLogradouro, Cep.CepComplementoLog, Cep.CepBairro, Cep.CepCidade, Cep.CepUF };
                return Json(JsonResult, JsonRequestBehavior.AllowGet);
            }
            return
                Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Pacientes Paciente)
        {
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboMidia();
            ViewData["Instituicao"] = PreencheInstituicao();
            ViewData["Cursos"] = PreencheComboCurso(Paciente.InstituicaoId);
            ViewData["Turmas"] = PreencheComboTurma(Paciente.CursoId);
            ViewData["Alunos"] = PrencheComboAluno(Paciente.TurmaId);
            PreencheComboSexo();
            if (ModelState.IsValid)
            {
                Paciente.PacienteCPF = Paciente.PacienteCPF.Replace(".", "").Replace("-", "");
                Paciente.PacienteCep = Paciente.PacienteCep.Replace("-", "");
                Paciente.PacienteFoneCelular = Paciente.PacienteFoneCelular != null ? Paciente.PacienteFoneCelular.Replace("(", "").Replace(")", "").Replace("-", "") : null;
                Paciente.PacienteFoneComercial = Paciente.PacienteFoneComercial != null ? Paciente.PacienteFoneComercial.Replace("(", "").Replace(")", "").Replace("-", "") : null;
                Paciente.PacienteFoneResidencial = Paciente.PacienteFoneResidencial.Replace("(", "").Replace(")", "").Replace("-", "");
                Paciente.PacienteDataCadastro = DateTime.Now;
                Paciente.AlunoId = Paciente.AlunoId == 0 ? null : Paciente.AlunoId;
                Paciente.MidiaId = Paciente.MidiaId == 0 ? null : Paciente.MidiaId;
                Paciente.InstituicaoId = Paciente.InstituicaoId == 0 ? null : Paciente.InstituicaoId;
                Paciente.TurmaId = Paciente.TurmaId == 0 ? null : Paciente.TurmaId;
                Paciente.CursoId = Paciente.CursoId == 0 ? null : Paciente.CursoId;
                //Paciente.InstituicaoId = Convert.ToInt32(frm["cboInstituicao"]);
                //Paciente.TurmaId = Convert.ToInt32(frm["cboTurma"]);
                //Paciente.CursoId = Convert.ToInt32(frm["cboCurso"]);
                //Paciente.AlunoId = Convert.ToInt32(frm["cboAluno"]);
                new PacienteNegocios().InserirPaciente(Paciente);
                return RedirectToAction("Index", "Paciente");
            }
            else
            {
                return View("Novo", Paciente);
            }
        }

        public ActionResult Editar(int Id)
        {
            Modelos.Pacientes Paciente = new PacienteNegocios().RetornaPacientePorId(Id);
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboMidia();
            ViewData["Instituicao"] = PreencheInstituicao();
            ViewData["Cursos"] = PreencheComboCurso(Paciente.InstituicaoId);
            ViewData["Turmas"] = PreencheComboTurma(Paciente.CursoId);
            ViewData["Alunos"] = PrencheComboAluno(Paciente.TurmaId);
            PreencheComboSexo();
            return View("Editar", Paciente);
        }

        private MultiSelectList PreencheComboTurma(int? Curso)
        {
            IList<Modelos.Turmas> LstTurmas;
            if (Curso == 0)
                LstTurmas = new TurmaNegocios().RetornaTurmas();
            else
                LstTurmas = new TurmaNegocios().RetornaTurmas().Where(a => a.CursoId == Curso).ToList();

            LstTurmas.Insert(0, new Modelos.Turmas() { TurmaId = 0, TurmaNome="Selecione"});

            return new MultiSelectList(LstTurmas, "TurmaId", "TurmaNome");
        }

        public ActionResult Atualizar(FormCollection frm, Modelos.Pacientes Paciente)
        {
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboMidia();
            PreencheComboCurso(Paciente.InstituicaoId);
            ViewData["Cursos"] = PreencheComboCurso(Paciente.InstituicaoId);
            ViewData["Instituicao"] = PreencheInstituicao();
            ViewData["Alunos"] = PrencheComboAluno(Paciente.TurmaId);
            PreencheComboSexo();
            if (ModelState.IsValid)
            {
                Paciente.PacienteCPF = Paciente.PacienteCPF.Replace(".", "").Replace("-", "");
                Paciente.PacienteCep = Paciente.PacienteCep.Replace("-", "");
                Paciente.PacienteFoneCelular = Paciente.PacienteFoneCelular != null ? Paciente.PacienteFoneCelular.Replace("(", "").Replace(")", "").Replace("-", "") : null;
                Paciente.PacienteFoneComercial = Paciente.PacienteFoneComercial != null ? Paciente.PacienteFoneComercial.Replace("(", "").Replace(")", "").Replace("-", "") : null;
                Paciente.PacienteFoneResidencial = Paciente.PacienteFoneResidencial.Replace("(", "").Replace(")", "").Replace("-", "");
                Paciente.AlunoId = Paciente.AlunoId == 0 ? null : Paciente.AlunoId;
                Paciente.MidiaId = Paciente.MidiaId == 0 ? null : Paciente.MidiaId;
                Paciente.InstituicaoId = Paciente.InstituicaoId == 0 ? null : Paciente.InstituicaoId;
                Paciente.TurmaId = Paciente.TurmaId == 0 ? null : Paciente.TurmaId;
                Paciente.CursoId = Paciente.CursoId == 0 ? null : Paciente.CursoId;
                //Paciente.PacienteDataCadastro = DateTime.Now;
                //Paciente.InstituicaoId = Convert.ToInt32(frm["cboInstituicao"]);
                //Paciente.TurmaId = Convert.ToInt32(frm["cboTurma"]);
                //Paciente.CursoId = Convert.ToInt32(frm["cboCurso"]);
                //Paciente.AlunoId = Convert.ToInt32(frm["cboAluno"]);
                new PacienteNegocios().Atualizar(Paciente);
                return RedirectToAction("Index", "Paciente");
            }
            else
            {
                return View("Editar", Paciente);
            }
        }

        public ActionResult Excluir(int Id)
        {
            Modelos.Pacientes Paciente = new PacienteNegocios().RetornaPacientePorId(Id);
            if (ModelState.IsValid)
            {
                new PacienteNegocios().Excluir(Paciente);
                return RedirectToAction("Index", "Paciente");
            }
            else
            {
                return View("Editar", Paciente);
            }
        }

        public ActionResult PesquisaPaciente(string Paciente)
        {
            
            return View(new PacienteNegocios().RetornaPacientes());
        }
        
        public ActionResult PesquisaPacientePorNome(FormCollection frm)
        {
            IList<Modelos.Pacientes> LstPaciente = new List<Modelos.Pacientes>();
            string Paciente = frm["txtPesquisa"].ToString();
            LstPaciente = new PacienteNegocios().RetornaPacientes().Where(a => a.PacienteNome.Contains(Paciente)).ToList();

            return PartialView("_TabelaResultadoPaciente", LstPaciente);
        }

        public ActionResult VisualizacaoPaciente(int Id)
        {
            Modelos.Pacientes Paciente = new PacienteNegocios().RetornaPacientePorId(Id);
            PreencheComboTipoLog();
            PreencheComboUf();
            PreencheComboMidia();
            ViewData["Instituicao"] = PreencheInstituicao();
            ViewData["Cursos"] = PreencheComboCurso(Paciente.InstituicaoId);
            ViewData["Turmas"] = PreencheComboTurma(Paciente.CursoId);
            ViewData["Alunos"] = PrencheComboAluno(Paciente.TurmaId);
            PreencheComboSexo();
            

            return View(Paciente);
        }
    }
}
