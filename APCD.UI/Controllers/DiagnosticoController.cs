using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCD.Negocios;
using System.Collections.Specialized;

namespace APCD.UI.Controllers
{
    public class DiagnosticoController : Controller
    {
        //
        // GET: /Diagnostico/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PreencherGrid(string sidx, string sord, int page, int rows)
        {
            IList<Modelos.Diagnosticos> LstDiagnosticos = new DiagnosticoNegocios().RetornaDiagnosticos();
            var JsonResult = new
            {
                total = LstDiagnosticos.Count / rows,
                page = page,
                records = LstDiagnosticos.Count,
                rows = (from f in LstDiagnosticos
                        select new
                        {
                            cell = new string[] {f.DiagnosticoId.ToString(), f.DiagnosticoData.ToShortDateString(), 
                            new PacienteNegocios().RetornaPacientePorId(f.PacienteId).PacienteNome, 
                            new DiagnosticoProcedimentoNegocios().RetornaProcedimentosPorDiagnostico(f.DiagnosticoId).Sum(a =>a.ProcedimentoValor).ToString("C2") }
                        }
                            ).ToArray()
            };

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Novo()
        {

            return View();
        }

        public MultiSelectList PreencheTratamento()
        {
            IList<Modelos.Procedimentos> LstProcedimento = new ProcedimentoNegocios().RetornarProcedimentos();
            return new MultiSelectList(LstProcedimento, "ProcedimentoId", "ProcedimentoNome");
        }

        [HttpPost]
        public ActionResult InserirDente(FormCollection frm)
        {
            NameValueCollection ChaveValor = new NameValueCollection();
            //TempData["LstDente"] = null;

            int j = 1;
            for (int i = 0; i < frm.AllKeys.Count(); i++)
            {
                string nome = "txtDentes" + j;
                if (frm.Keys[i] == nome)
                {
                    string[] Dente1 = frm[nome].Split(',');
                    foreach (string s in Dente1)
                    {
                        ChaveValor.Add(s, ((Modelos.EnumCheckList)j).ToString());
                    }
                    j++;
                }
            }


            TempData["LstDente"] = ChaveValor;

            return PartialView("_FormDiagnosticoDente");
        }

        [HttpPost]
        public ActionResult ListarChkDentes(string Dente)
        {
            NameValueCollection ChaveValor = new NameValueCollection();
            IList<KeyValuePair<string, string>> lstresult = new List<KeyValuePair<string, string>>();
            if (TempData["LstDente"] != null)
            {
                ChaveValor = (NameValueCollection)TempData["LstDente"];
            }

            foreach (string s in ChaveValor)
            {
                if (s == Dente)
                {

                    Array enumValores = Enum.GetValues(typeof(Modelos.EnumCheckList));
                    foreach (Enum Valor in enumValores)
                    {
                        string descricao = string.Empty;
                        string[] SplitChaveValor = ChaveValor[s].Split(',');
                        foreach (string t in SplitChaveValor)
                        {
                            if (Valor.ToString() == t)
                                descricao = Comuns.Comuns.ObterDescricao(Valor);
                        }
                        if (!string.IsNullOrEmpty(descricao))
                            lstresult.Add(new KeyValuePair<string, string>(s, descricao));
                    }
                }
            }

            return PartialView("_FormListaCheckList", lstresult);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InserirProcedimento(string proc, string diagid)
        {
            IList<Modelos.DiagnosticoTratamentos> LstProcedimento;


            if (TempData["Procedimento"] != null)
                LstProcedimento = (List<Modelos.DiagnosticoTratamentos>)TempData["Procedimento"];
            else
                LstProcedimento = new List<Modelos.DiagnosticoTratamentos>();

            Modelos.Procedimentos Procedimento = new ProcedimentoNegocios().RetornaProcedimentoPorId(Convert.ToInt32(proc));

            Modelos.DiagnosticoTratamentos DiagnosticoTratamento = new Modelos.DiagnosticoTratamentos();
            DiagnosticoTratamento.DiagnosticoTratamentoStatus = 1;
            DiagnosticoTratamento.ProcedimentoId = Convert.ToInt32(proc);
            DiagnosticoTratamento.ProcedimentoValor = Procedimento.ProcedimentoValor;
            DiagnosticoTratamento.ProcedimentoNome = Procedimento.ProcedimentoNome;

            if (!string.IsNullOrEmpty(diagid) && TempData["Procedimento"] == null)
            {
                LstProcedimento = new DiagnosticoProcedimentoNegocios().RetornaProcedimentosPorDiagnostico(Convert.ToInt32(diagid));
            }

            LstProcedimento.Add(DiagnosticoTratamento);

            TempData["Procedimento"] = LstProcedimento;
            ViewData["ValorTotal"] = LstProcedimento.Sum(a => a.ProcedimentoValor).ToString("N2");

            return PartialView("_FormDiagnosticoTratamento", LstProcedimento);
        }

        [HttpGet]
        public ActionResult ExcluirProcedimento(string proc, string diagid)
        {
            IList<Modelos.DiagnosticoTratamentos> LstProcedimento;
            if (TempData["Procedimento"] == null)
                LstProcedimento = new DiagnosticoProcedimentoNegocios().RetornaProcedimentosPorDiagnostico(Convert.ToInt32(diagid));
            else
                LstProcedimento = (List<Modelos.DiagnosticoTratamentos>)TempData["Procedimento"];


            TempData["Procedimento"] = null;
            for (int i = 0; i < LstProcedimento.Count; i++)
            {
                if (LstProcedimento[i].ProcedimentoId == Convert.ToInt32(proc))
                {
                    LstProcedimento.Remove(LstProcedimento[i]);
                }
            }
            TempData["Procedimento"] = LstProcedimento;
            ViewData["ValorTotal"] = LstProcedimento.Sum(a => a.ProcedimentoValor).ToString("N2");
            return PartialView("_FormDiagnosticoTratamento", LstProcedimento);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MudarEstadoProcedimento(string proc, string diagid)
        {

            IList<Modelos.DiagnosticoTratamentos> LstProcedimento = (List<Modelos.DiagnosticoTratamentos>)TempData["Procedimento"];


            if (diagid != null && TempData["Procedimento"] == null)
            {
                LstProcedimento = new DiagnosticoProcedimentoNegocios().RetornaProcedimentosPorDiagnostico(Convert.ToInt32(diagid));
            }


            for (int i = 0; i < LstProcedimento.Count; i++)
            {
                if (LstProcedimento[i].ProcedimentoId == Convert.ToInt32(proc))
                {
                    if (LstProcedimento[i].DiagnosticoTratamentoStatus == 1)
                        LstProcedimento[i].DiagnosticoTratamentoStatus = 2;
                    else
                        LstProcedimento[i].DiagnosticoTratamentoStatus = 1;
                }
            }
            TempData["Procedimento"] = LstProcedimento;
            ViewData["ValorTotal"] = LstProcedimento.Sum(a => a.ProcedimentoValor).ToString("N2");

            return PartialView("_FormDiagnosticoTratamento", LstProcedimento);
        }

        [HttpPost]
        public ActionResult Salvar(FormCollection frm, Modelos.Diagnosticos Diagnostico, Modelos.DiagnosticoDentes dd)
        {
            Diagnostico.DiagnosticoData = DateTime.Now.Date;
            string pathArquivo = this.Server.MapPath("~/uploads/");
            if (TempData["ImagemFrontal"] != null)
                //Diagnostico.ImagemFrontal = Comuns.Comuns.setImage(System.Drawing.Bitmap.FromFile(pathArquivo + TempData["ImagemFrontal"].ToString()));
                Diagnostico.ImagemFrontal = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemFrontal"]);
            else
                Diagnostico.ImagemFrontal = null;

            if (TempData["ImagemInferior"] != null)
                //Diagnostico.ImagemInferior = Comuns.Comuns.setImage(System.Drawing.Bitmap.FromFile(pathArquivo + TempData["ImagemInferior"].ToString()));
                Diagnostico.ImagemInferior = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemInferior"]);
            else
                Diagnostico.ImagemInferior = null;

            if (TempData["ImagemRx"] != null)
                //Diagnostico.ImagemRx = Comuns.Comuns.setImage(System.Drawing.Bitmap.FromFile(pathArquivo + TempData["ImagemRx"].ToString()));
                Diagnostico.ImagemRx = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemRx"]);
            else
                Diagnostico.ImagemRx = null;

            if (TempData["ImagemSuperior"] != null)
                //Diagnostico.ImagemSuperior = Comuns.Comuns.setImage(System.Drawing.Bitmap.FromFile(pathArquivo + TempData["ImagemSuperior"].ToString()));
                Diagnostico.ImagemSuperior = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemSuperior"]);
            else
                Diagnostico.ImagemSuperior = null;

            new DiagnosticoNegocios().Salvar(Diagnostico);
            if (TempData["Procedimento"] != null)
            {
                IList<Modelos.DiagnosticoTratamentos> LstProc = (List<Modelos.DiagnosticoTratamentos>)TempData["Procedimento"];
                foreach (Modelos.DiagnosticoTratamentos Procedimentos in LstProc)
                {
                    Procedimentos.DiagnosticoId = Diagnostico.DiagnosticoId;
                    new DiagnosticoProcedimentoNegocios().SalvarDiagnosticoProcedimento(Procedimentos);
                }
            }
            new DiagnosticoDenteNegocios().RemoverDiagnosticoDente(Diagnostico.DiagnosticoId);
            int j = 1;
            for (int i = 0; i < frm.AllKeys.Count(); i++)
            {
                string nome = "txtDentes" + j;
                if (frm.Keys[i] == nome)
                {
                    string[] Dente1 = frm[nome].Split(',');
                    foreach (string s in Dente1)
                    {
                        Modelos.DiagnosticoDentes DDentes = new Modelos.DiagnosticoDentes();
                        if (!string.IsNullOrEmpty(s))
                        {
                            Modelos.EnumCheckList Valor = (Modelos.EnumCheckList)j;
                            DDentes.DiagnosticoDenteDiag = Convert.ToInt32(Valor);
                            DDentes.DiagnosticoId = Diagnostico.DiagnosticoId;
                            DDentes.DenteId = Convert.ToInt32(s);
                            //DDentes.DiagnosticoDenteId = new DiagnosticoDenteNegocios().RetornaIdDiagnosticoDente(DDentes.DenteId, DDentes.DiagnosticoId, j);
                            DDentes.DiagnosticoDenteDificuldade = dd.DiagnosticoDenteDificuldade;
                            DDentes.DiagnosticoDenteDensidade = dd.DiagnosticoDenteDensidade;
                            DDentes.DiagnosticoDenteDimensao = dd.DiagnosticoDenteDimensao;
                            DDentes.DiagnosticoDenteEspessura = dd.DiagnosticoDenteEspessura;
                            DDentes.DiagnosticoDenteFadiga = dd.DiagnosticoDenteFadiga;
                            DDentes.DiagnosticoDenteLesao = dd.DiagnosticoDenteLesao;
                            DDentes.DiagnosticoDenteOssoAnc = dd.DiagnosticoDenteOssoAnc;
                            DDentes.DiagnosticoDenteParafuncao = dd.DiagnosticoDenteParafuncao;
                            DDentes.DiagnosticoDentePerda = dd.DiagnosticoDentePerda;
                            DDentes.DiagnosticoDentePerfil = dd.DiagnosticoDentePerfil;
                            DDentes.DiagnosticoDenteSintArt = dd.DiagnosticoDenteSintArt;
                            DDentes.DiagnosticoDenteTomografia = dd.DiagnosticoDenteTomografia;

                            //DDentes.DiagnosticoDenteDificuldade = Convert.ToBoolean(frm["chkDifcAbrir"].Split(',')[0].ToString());
                            //DDentes.DiagnosticoDenteDensidade = Convert.ToInt32(frm["rdbDensidade"]);
                            //DDentes.DiagnosticoDenteDimensao = Convert.ToInt32(frm["rbdDimensao"]);
                            //DDentes.DiagnosticoDenteEspessura = Convert.ToInt32(frm["rdbEspessura"]);
                            //DDentes.DiagnosticoDenteFadiga = Convert.ToBoolean(frm["chkFadiga"].Split(',')[0].ToString());
                            //DDentes.DiagnosticoDenteLesao = Convert.ToBoolean(frm["chkLesoes"].Split(',')[0].ToString());
                            //DDentes.DiagnosticoDenteOssoAnc = Convert.ToBoolean(frm["chkOssoAncoragem"].Split(',')[0].ToString());
                            //DDentes.DiagnosticoDenteParafuncao = Convert.ToBoolean(frm["chkParafuncao"].Split(',')[0].ToString());
                            //DDentes.DiagnosticoDentePerda = Convert.ToBoolean(frm["chkPerdaAltura"].Split(',')[0].ToString());
                            //DDentes.DiagnosticoDentePerfil = Convert.ToInt32(frm["rdbClasse"]);
                            //DDentes.DiagnosticoDenteSintArt = Convert.ToBoolean(frm["chkSintomasArt"].Split(',')[0].ToString());
                            //DDentes.DiagnosticoDenteTomografia = string.IsNullOrEmpty(frm["txtEspesTom"].ToString()) == true ? 0M : Convert.ToDecimal(frm["txtEspesTom"]);

                            new DiagnosticoDenteNegocios().SalvarDiagnosticoDente(DDentes);
                            DDentes = null;
                        }
                    }
                    j++;
                }
            }

            TempData.Remove("Procedimento");
            TempData.Remove("LstDente");
            return RedirectToAction("Index", "Diagnostico");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PesquisaProcedimentoPorNome(string Proced)
        {
            IList<Modelos.Procedimentos> LstProcedimento = new List<Modelos.Procedimentos>();
            LstProcedimento = new ProcedimentoNegocios().RetornaProcedimentosPorNome(Proced);
            return PartialView("_FormPesquisaTratamento", LstProcedimento);
        }

        public void RetornaDentesPorPosicao(IList<Modelos.DiagnosticoDentes> LstDentes)
        {
            for (int i = 1; i <= 14; i++)
            {
                string RetornoDentes = string.Empty;
                foreach (var item in LstDentes)
                {
                    if (item.DiagnosticoDenteDiag == i)
                        RetornoDentes = string.IsNullOrEmpty(RetornoDentes) == true ? item.DenteId.ToString() : RetornoDentes + "," + item.DenteId.ToString();
                }
                ViewData["Dente" + i] = RetornoDentes;
            }
        }

        public ActionResult Editar(int Id)
        {
            Modelos.Diagnosticos Diagnostico = new DiagnosticoNegocios().RetornaDiagnosticosPorId(Id);
            //TempData["LstDente"] = new DiagnosticoDenteNegocios().RetornaDentesPorDiagnostico(Id);
            RetornaDentesPorPosicao(new DiagnosticoDenteNegocios().RetornaDentesPorDiagnostico(Id));
            TempData["Procedimento"] = new DiagnosticoProcedimentoNegocios().RetornaProcedimentosPorDiagnostico(Id);
            ViewData["ValorTotal"] = ((List<Modelos.DiagnosticoTratamentos>)TempData["Procedimento"]).Sum(a => a.ProcedimentoValor);
            if (Diagnostico.ImagemSuperior != null)
                TempData["ImagemSuperior"] = Comuns.Comuns.getImage(Diagnostico.ImagemSuperior);
            if (Diagnostico.ImagemRx != null)
                TempData["ImagemRx"] = Comuns.Comuns.getImage(Diagnostico.ImagemRx);
            if (Diagnostico.ImagemInferior != null)
                TempData["ImagemInferior"] = Comuns.Comuns.getImage(Diagnostico.ImagemInferior);
            if (Diagnostico.ImagemFrontal != null)
                TempData["ImagemFrontal"] = Comuns.Comuns.getImage(Diagnostico.ImagemFrontal);

            return View("Editar", Diagnostico);
        }

        public ActionResult ImagemInferior(int Id)
        {
            if (TempData["ImagemInferior"] == null)
            {
                byte[] ArByte = new DiagnosticoNegocios().RetornaDiagnosticosPorId(Id).ImagemInferior;
                string caminho = Server.MapPath("/Content/images/semImg.png");
                System.Drawing.Bitmap Transp = new System.Drawing.Bitmap(caminho, true);
                if (ArByte != null)
                    TempData["ImagemInferior"] = Comuns.Comuns.getImage(ArByte);
                else
                    ArByte = Comuns.Comuns.setImage(Transp);
                return File(ArByte, "image/png");
            }
            else
            {
                byte[] ArByte = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemInferior"]);
                return File(ArByte, "image/png");
            }
        }

        public ActionResult ImagemSuperior(int Id)
        {
            if (TempData["ImagemSuperior"] == null)
            {
                byte[] ArByte = new DiagnosticoNegocios().RetornaDiagnosticosPorId(Id).ImagemSuperior;
                string caminho = Server.MapPath("/Content/images/semImg.png");
                System.Drawing.Bitmap Transp = new System.Drawing.Bitmap(caminho, true);
                if (ArByte != null)
                    TempData["ImagemSuperior"] = Comuns.Comuns.getImage(ArByte);
                else
                    ArByte = Comuns.Comuns.setImage(Transp);
                return File(ArByte, "image/png");
            }
            else
            {
                byte[] ArByte = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemSuperior"]);
                return File(ArByte, "image/png");
            }
        }

        public ActionResult ImagemRx(int Id)
        {
            if (TempData["ImagemRx"] == null)
            {
                byte[] ArByte = new DiagnosticoNegocios().RetornaDiagnosticosPorId(Id).ImagemRx;
                string caminho = Server.MapPath("/Content/images/semImg.png");
                System.Drawing.Bitmap Transp = new System.Drawing.Bitmap(caminho, true);
                if (ArByte != null)
                    TempData["ImagemRx"] = Comuns.Comuns.getImage(ArByte);
                else
                    ArByte = Comuns.Comuns.setImage(Transp);
                return File(ArByte, "image/png");
            }
            else
            {
                byte[] ArByte = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemRx"]);
                return File(ArByte, "image/png");
            }
        }

        public ActionResult ImagemFrontal(int Id)
        {
            if (TempData["ImagemFrontal"] == null)
            {
                byte[] ArByte = new DiagnosticoNegocios().RetornaDiagnosticosPorId(Id).ImagemFrontal;
                string caminho = Server.MapPath("/Content/images/semImg.png");
                System.Drawing.Bitmap Transp = new System.Drawing.Bitmap(caminho, true);
                if (ArByte != null)
                    TempData["ImagemFrontal"] = Comuns.Comuns.getImage(ArByte);
                else
                    ArByte = Comuns.Comuns.setImage(Transp);
                return File(ArByte, "image/png");
            }
            else 
            {
                byte[] ArByte = Comuns.Comuns.setImage((System.Drawing.Image)TempData["ImagemFrontal"]);
                return File(ArByte, "image/png");
            }
        }

        public string UploadRx(HttpPostedFileBase fileData)
        {
            System.Drawing.Bitmap Imagem = new System.Drawing.Bitmap(fileData.InputStream);
            byte[] Arbyte = Comuns.Comuns.setImage(Imagem);
            TempData["ImagemRx"] = Comuns.Comuns.getImage(Arbyte);

            Guid guidArquivo = Guid.NewGuid();
            string ExtensaoArquivo = System.IO.Path.GetExtension(fileData.FileName);
            string NomeArquivo = string.Format("{0}{1}", guidArquivo.ToString(), ExtensaoArquivo);
            var fileName = this.Server.MapPath("~/uploads/" + System.IO.Path.GetFileName(NomeArquivo));
            fileData.SaveAs(fileName);

            return NomeArquivo;
        }

        public string UploadFrontal(HttpPostedFileBase fileData)
        {
            System.Drawing.Bitmap Imagem = new System.Drawing.Bitmap(fileData.InputStream);
            byte[] Arbyte = Comuns.Comuns.setImage(Imagem);
            TempData["ImagemFrontal"] = Comuns.Comuns.getImage(Arbyte);

            Guid guidArquivo = Guid.NewGuid();
            string ExtensaoArquivo = System.IO.Path.GetExtension(fileData.FileName);
            string NomeArquivo = string.Format("{0}{1}", guidArquivo.ToString(), ExtensaoArquivo);
            var fileName = this.Server.MapPath("~/uploads/" + System.IO.Path.GetFileName(NomeArquivo));
            fileData.SaveAs(fileName);
            return NomeArquivo;
        }

        public string UploadSuperior(HttpPostedFileBase fileData)
        {

            System.Drawing.Bitmap Imagem = new System.Drawing.Bitmap(fileData.InputStream);
            byte[] Arbyte = Comuns.Comuns.setImage(Imagem);
            TempData["ImagemSuperior"] = Comuns.Comuns.getImage(Arbyte);
            Guid guidArquivo = Guid.NewGuid();
            string ExtensaoArquivo = System.IO.Path.GetExtension(fileData.FileName);
            string NomeArquivo = string.Format("{0}{1}", guidArquivo.ToString(), ExtensaoArquivo);
            var fileName = this.Server.MapPath("~/uploads/" + System.IO.Path.GetFileName(NomeArquivo));
            fileData.SaveAs(fileName);

            return NomeArquivo;
        }

        public string UploadInferior(HttpPostedFileBase fileData)
        {
            System.Drawing.Bitmap Imagem = new System.Drawing.Bitmap(fileData.InputStream);
            byte[] Arbyte = Comuns.Comuns.setImage(Imagem);
            TempData["ImagemInferior"] = Comuns.Comuns.getImage(Arbyte);

            Guid guidArquivo = Guid.NewGuid();
            string ExtensaoArquivo = System.IO.Path.GetExtension(fileData.FileName);
            string NomeArquivo = string.Format("{0}{1}", guidArquivo.ToString(), ExtensaoArquivo);
            var fileName = this.Server.MapPath("~/uploads/" + System.IO.Path.GetFileName(NomeArquivo));
            fileData.SaveAs(fileName);
            return NomeArquivo;
        }


        public ActionResult AbrirPopUpImagem(string Imagem)
        {
            return View();
        }
    }
}
