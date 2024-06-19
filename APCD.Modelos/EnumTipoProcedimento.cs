using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace APCD.Modelos
{
    public enum EnumTipoProcedimento
    {
        [Description("Por Elemento")]
        Elemento = 1,
        [Description("Por Intervenção")]
        Intervencao =2
    }
}
