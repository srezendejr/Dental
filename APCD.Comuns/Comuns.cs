using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APCD.Comuns
{
    public static class Comuns
    {
        /// <summary>
        /// Retorna um SelectListItem para preencher um dropdownlist
        /// </summary>
        /// <param name="tipo">Enum para criar um SelectListItem</param>
        /// <returns></returns>
        public static IList<SelectListItem> PreencheComboEnum(Array tipo)
        {
            IList<SelectListItem> lstRetorno = new List<SelectListItem>();
            foreach (var enm in tipo)
            {
                lstRetorno.Add(new SelectListItem() {Value = Convert.ToInt32(enm).ToString(), Text = enm.ToString() });
            }

            return lstRetorno;
        }

        /// <summary>
        /// Converte uma string para Inteiro
        /// </summary>
        /// <param name="Valor">Valor para a conversão em Inteiro</param>
        /// <returns></returns>
        public static Int32 ToInt32(this string Valor)
        {
            int OutInt = 0;
            Int32.TryParse(Valor, out OutInt);

            return OutInt;
        }

        /// <summary>
        /// Método que transforma uma imagem em array de bytes
        /// </summary>
        /// <param name="Imagem">Parametro de imagem que será transformada em um array de bytes</param>
        /// <returns>Retorna um array de byte</returns>
        public static byte[] setImage(Image Imagem)
        {
            MemoryStream ms = new MemoryStream();
            Imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        /// <summary>
        /// Método que transforma o array de bytes em imagem
        /// </summary>
        /// <param name="ArrayBytes">Parametro de array de bytes para converter em imagem</param>
        /// <returns>Retorna uma imagem convertida a partir de um array de bytes</returns>
        public static Image getImage(byte[] ArrayBytes)
        {
            Image foto;
            Stream bs = new MemoryStream();
            bs.Write(ArrayBytes, 0, ArrayBytes.Length);

            return foto = Image.FromStream(bs);
        }

        public static String ObterDescricao(Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());

            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
        }

        /// <summary>
        /// Método que valida o CPF e o CNPJ informado. Calcula o valor dos dígitos e compara com os valores informados.
        /// </summary>
        /// <param name="CpfCnpj">Valor do CPF ou CNPJ sem os caracteres especiais</param>
        /// <returns>Retorna um boolenado confirmado o valor informado.</returns>
        public static ValidationResult ValidaCpfCnpj(string CpfCnpj)
        {
            if(CpfCnpj == null)
                return new ValidationResult("CPF/CNPJ Inválido. Informe um valor válido");

            CpfCnpj = CpfCnpj.Replace(".", "").Replace("-", "");
            int Tamanho = CpfCnpj.Length;
            int Soma = 0;
            int Digito1 = 0;
            int Digito2 = 0;
            int Contador = 0;

            if (Tamanho == 14)
                Contador = 5;
            else
                Contador = Tamanho - 1;

            for (int i = 0; i < Tamanho - 2; i++)
            {
                int numero = int.Parse(CpfCnpj.Substring(i, 1));
                Soma += int.Parse(CpfCnpj.Substring(i, 1)) * (Contador - i);
                if ((Contador - i) == 2)
                    Contador = 10 + i;
            }

            Digito1 = (11 - (Soma % 11));

            if (Digito1 >= 10)
                Digito1 = 0;

            Soma = 0;
            if (Tamanho == 14)
                Contador = 6;
            else
                Contador = Tamanho;

            for (int i = 0; i < Tamanho - 1; i++)
            {
                int numero = int.Parse(CpfCnpj.Substring(i, 1));
                Soma += int.Parse(CpfCnpj.Substring(i, 1)) * (Contador - i);
                if ((Contador - i) == 2)
                    Contador = 10 + i;
            }

            Digito2 = (11 - (Soma % 11));
            if (Digito2 >= 10)
                Digito2 = 0;

            if (Digito1 == int.Parse(CpfCnpj.Substring(Tamanho - 2, 1))
                && Digito2 == int.Parse(CpfCnpj.Substring(Tamanho - 1, 1)))
                return ValidationResult.Success;
            else
                return new ValidationResult("CPF/CNPJ Inválido. Informe um valor válido");

        }

        public static ValidationResult Validate(DateTime? Datas)
        {
            if (Datas <= DateTime.Parse("1900-01-01 00:00:00"))
            {
                return new ValidationResult("Data inválida. Informe uma data válida");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
