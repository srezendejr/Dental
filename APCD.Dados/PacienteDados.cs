using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity.Validation;

namespace APCD.Dados
{
    public class PacienteDados
    {
        public IList<Modelos.Pacientes> RetornaPacientesPorMidia(int MidiaId)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.PacientesSet.Where(a => a.MidiaId == MidiaId).ToList();
            }
        }


        public void InserirPaciente(Modelos.Pacientes Paciente)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Paciente).State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public IList<Modelos.Pacientes> RetornaPacientes()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.PacientesSet.ToList();
            }
        }

        public void AtualizarPaciente(Modelos.Pacientes Paciente)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Paciente).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void ExcluirPaciente(Modelos.Pacientes Paciente)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Paciente).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public Modelos.Pacientes RetornaPacientePorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.PacientesSet.Where(a => a.PacienteId == Id).FirstOrDefault();
            }
        }
    }
}
