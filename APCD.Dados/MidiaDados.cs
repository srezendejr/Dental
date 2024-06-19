using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using System.Data;

namespace APCD.Dados
{
    public class MidiaDados
    {
        public IList<Modelos.Midias> RetornaMidias()
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.MidiasSet.ToList();
            }
        }

        public Modelos.Midias RetonaMidiaPorId(int Id)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                return Context.MidiasSet.Where(a => a.MidiaId == Id).FirstOrDefault();
            }
        }

        public void InserirMidia(Modelos.Midias Midia)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Midia).State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void AtualizarMidia(Modelos.Midias Midia)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Midia).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void RemoverMidia(Modelos.Midias Midia)
        {
            using (ModelosContext Context = new ModelosContext())
            {
                Context.Entry(Midia).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }
    }

}
