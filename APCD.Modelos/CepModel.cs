using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace APCD.Modelos
{
    public class Cep
    {
        [Key]
        public int CepId
        {
            get;
            set;
        }

        public string CepCodigo
        {
            get;
            set;
        }

        public string CepTipoLogradouro
        {
            get;
            set;
        }

        public string CepLogradouro
        {
            get;
            set;
        }

        public string CepComplementoLog
        {
            get;
            set;
        }

        public string CepBairro
        {
            get;
            set;
        }

        public string CepCidade
        {
            get;
            set;
        }

        public string CepUF
        {
            get;
            set;
        }
    }
}
