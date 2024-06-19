using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace APCD.Modelos
{
    public enum EnumCheckList
    {
        [Description("Lesão de furca com comunicação vestíbulo-lingual maior do que 5mm")]
        Lesao = 1,
        [Description("Bolsa em região sem possibilidade de raspar")]
        Bolsa = 2,
        [Description("Mobilidade não reversível")]
        Mobilidade = 3,
        [Description("Fratura longitudinal da raiz")]
        Fratura = 4,
        [Description("Cárie envolvendo furca")]
        Carie = 5,
        [Description("Trepanação radicular com lesão")]
        Trepanacao = 6,
        [Description("Posicionamento que impede reabilitação")]
        Posicionamento = 7,
        [Description("Pino soltando ou muito curto")]
        Pino = 8,
        [Description("Coroa soltando ou antiestética")]
        Coroa = 9,
        [Description("Lesão periapical")]
        Periapical = 10,
        [Description("Doença periodontal inicial")]
        Doenca = 11,
        [Description("Fenótipo periodontal fino")]
        Fenotipo = 12,
        [Description("Fenótipo periodontal sem tecido queratinizado")]
        Queratinizado = 13,
        [Description("Região para o espaço protético")]
        Regiao = 14
    }
}
