using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APCD.Modelos
{
    public class Pacientes
    {
        public Pacientes()
        {

        }

        [Key]
        public int PacienteId
        {
            get;
            set;
        }

        [DisplayName("Nome Paciente:")]
        [Required(ErrorMessage = "Informe o nome do paciente.")]
        public string PacienteNome
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
        [Required(ErrorMessage = "Informe o CPF do paciente.")]
        [CustomValidation(typeof(Comuns.Comuns), "ValidaCpfCnpj")]
        public string PacienteCPF
        {
            get;
            set;
        }

        [DisplayName("RG.:")]
        [Required(ErrorMessage = "Informe o RG do paciente.")]
        public string PacienteRG
        {
            get;
            set;
        }

        [DisplayName("Orgão Expedição:")]
        [Required(ErrorMessage = "Informe o Orgão de Expedição")]
        public string PacienteRGExped
        {
            get;
            set;
        }

        [DisplayName("Mãe")]
        public string PacienteMae
        {
            get;
            set;
        }

        [DisplayName("Pai")]
        public string PacientePai
        {
            get;
            set;
        }

        [DisplayName("Responsável:")]
        public string PacienteResponsavel
        {
            get;
            set;
        }

        public string PacienteTipoLog
        {
            get;
            set;
        }

        [DisplayName("Endereço:")]
        [Required(ErrorMessage = "Informe o endereço do paciente.")]
        public string PacienteLogradouro
        {
            get;
            set;
        }

        [DisplayName("Cep:")]
        [Required(ErrorMessage = "Informe o cep do endereço")]
        public string PacienteCep
        {
            get;
            set;
        }

        [DisplayName("Complemento:")]
        public string PacienteComplemento
        {
            get;
            set;
        }

        [DisplayName("Bairro:")]
        [Required(ErrorMessage = "Informe o bairro do paciente.")]
        public string PacienteBairro
        {
            get;
            set;
        }

        [DisplayName("Cidade:")]
        [Required(ErrorMessage = "Informe a cidade do paciente.")]
        public string PacienteCidade
        {
            get;
            set;
        }

        [DisplayName("UF:")]
        public string PacienteUF
        {
            get;
            set;
        }

        [DisplayName("Telefone Residêncial:")]
        [Required(ErrorMessage = "Informe o telefone residencial")]
        public string PacienteFoneResidencial
        {
            get;
            set;
        }

        [DisplayName("Telefone Celular:")]
        public string PacienteFoneCelular
        {
            get;
            set;
        }

        [DisplayName("Telefone Comercial:")]
        public string PacienteFoneComercial
        {
            get;
            set;
        }

        [DisplayName("Ramal:")]
        public string PacienteFoneComercialRamal
        {
            get;
            set;
        }

        [DisplayName("Email:")]
        public string PacienteEmail
        {
            get;
            set;
        }

        [DisplayName("Informe como conheceu a APCD:")]
        public int? MidiaId
        {
            get;
            set;
        }

        public DateTime PacienteDataCadastro
        {
            get;
            set;
        }

        [DisplayName("Curso de Atendimento:")]
        public int? CursoId
        {
            get;
            set;
        }

        [DisplayName("Instituição:")]
        public int? InstituicaoId
        {
            get;
            set;
        }

        [DisplayName("Turma:")]
        public int? TurmaId
        {
            get;
            set;
        }

        public string PacienteNroEndereco
        {
            get;
            set;
        }

        [DisplayName("Aluno do Responsável:")]
        public int? AlunoId
        {
            get;
            set;
        }

        [DisplayName("Sexo:")]
        public int PacienteSexo
        {
            get;
            set;
        }


        public virtual ICollection<Modelos.Alunos> Alunos
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Cursos> Cursos
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Midias> Midias
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Diagnosticos> Diagnosticos
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Instituicoes> Instituicoes
        {
            get;
            set;
        }

        public virtual ICollection<Modelos.Turmas> Turmas
        {
            get;
            set;
        }
    }
}
