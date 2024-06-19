using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class DiagnosticoDentes
    {
        [Key]
        public int DiagnosticoDenteId
        {
            get;
            set;
        }

        [DisplayName("Dente:")]
        [Required(ErrorMessage="Informe o dente")]
        public int DenteId
        {
            get;
            set;
        }

        public int DiagnosticoId
        {
            get;
            set;
        }

        public bool DiagnosticoDenteOssoAnc
        {
            get;
            set;
        }

        public int DiagnosticoDenteEspaco
        {
            get;
            set;
        }

        public int DiagnosticoDenteEspessura
        {
            get;
            set;
        }

        public decimal DiagnosticoDenteTomografia
        {
            get;
            set;
        }

        public int DiagnosticoDenteDensidade
        {
            get;
            set;
        }

        public bool DiagnosticoDentePerda
        {
            get;
            set;
        }

        public int DiagnosticoDentePerfil
        {
            get;
            set;
        }

        public int DiagnosticoDenteDimensao
        {
            get;
            set;
        }

        public bool DiagnosticoDenteSintArt
        {
            get;
            set;
        }

        public bool DiagnosticoDenteParafuncao
        {
            get;
            set;
        }

        public bool DiagnosticoDenteFadiga
        {
            get;
            set;
        }

        public bool DiagnosticoDenteLesao
        {
            get;
            set;
        }

        public bool DiagnosticoDenteDificuldade
        {
            get;
            set;
        }

        public int DiagnosticoDenteDiag
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Diagnosticos> Diagnosticos
        {
            get;
            set;
        }
    }
}
