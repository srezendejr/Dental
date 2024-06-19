using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace APCD.Modelos
{
    public enum EnumStatus
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Desativo")]
        Desativado = 0
    }
}
