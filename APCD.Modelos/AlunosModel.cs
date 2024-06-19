using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using APCD.Comuns;

namespace APCD.Modelos
{
    public class Alunos
    {
        [Key]
        public int AlunoId
        {
            get;
            set;
        }

        [DisplayName("Nome Aluno:")]
        [Required(ErrorMessage = "Informe o nome do Aluno.")]
        public string AlunoNome
        {
            get;
            set;
        }

        [DisplayName("Data de Nascimento:")]
        [CustomValidation(typeof(Comuns.Comuns), "Validate")]
        public DateTime? DataNascimento
        {
            get;
            set;
        }

        [DisplayName("CPF:")]
        [Required(ErrorMessage = "Informe o CPF do Aluno.")]
        [CustomValidation(typeof(Comuns.Comuns), "ValidaCpfCnpj")]
        public string AlunoCPF
        {
            get;
            set;
        }

        [DisplayName("RG.:")]
        [Required(ErrorMessage = "Informe o RG do Aluno.")]
        public string AlunoRG
        {
            get;
            set;
        }

        [DisplayName("Orgão Expedição:")]
        [Required(ErrorMessage = "Informe o Orgão de Expedição")]
        public string AlunoRGExped
        {
            get;
            set;
        }

        [DisplayName("Mãe")]
        public string AlunoMae
        {
            get;
            set;
        }

        [DisplayName("Pai")]
        public string AlunoPai
        {
            get;
            set;
        }

        [DisplayName("Responsável:")]
        public string AlunoResponsavel
        {
            get;
            set;
        }

        public string AlunoTipoLog
        {
            get;
            set;
        }

        [DisplayName("Endereço:")]
        [Required(ErrorMessage = "Informe o endereço do Aluno.")]
        public string AlunoLogradouro
        {
            get;
            set;
        }

        [DisplayName("Cep:")]
        [Required(ErrorMessage = "Informe o cep do endereço")]
        public string AlunoCep
        {
            get;
            set;
        }

        [DisplayName("Complemento:")]
        public string AlunoComplemento
        {
            get;
            set;
        }

        [DisplayName("Bairro:")]
        [Required(ErrorMessage = "Informe o bairro do Aluno.")]
        public string AlunoBairro
        {
            get;
            set;
        }

        [DisplayName("Cidade:")]
        [Required(ErrorMessage = "Informe a cidade do Aluno.")]
        public string AlunoCidade
        {
            get;
            set;
        }

        [DisplayName("UF:")]
        public string AlunoUF
        {
            get;
            set;
        }

        [DisplayName("Telefone Residêncial:")]
        [Required(ErrorMessage = "Informe o telefone residencial")]
        public string AlunoFoneResidencial
        {
            get;
            set;
        }

        [DisplayName("Telefone Celular:")]
        public string AlunoFoneCelular
        {
            get;
            set;
        }

        [DisplayName("Telefone Comercial:")]
        public string AlunoFoneComercial
        {
            get;
            set;
        }

        [DisplayName("Ramal:")]
        public string AlunoFoneComercialRamal
        {
            get;
            set;
        }

        [DisplayName("Email:")]
        public string AlunoEmail
        {
            get;
            set;
        }

        [DisplayName("Data Cadastro:")]
        public DateTime AlunoDataCadastro
        {
            get;
            set;
        }

        public string AlunoNroEndereco
        {
            get;
            set;
        }

        [DisplayName("Sexo:")]
        public int AlunoSexo
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Pacientes> Pacientes
        {
            get;
            set;
        }
        public virtual ICollection<Modelos.Matriculas> Matriculas
        {
            get;
            set;
        }
    }
}
