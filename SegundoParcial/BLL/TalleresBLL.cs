using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.BLL
{
    public class TalleresBLL
    {
        public static bool Guardar(Talleres tallere)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Talleres.Add(tallere) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Talleres taller)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(taller).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;

                }

                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }
        
            return paso;
        }

        public static bool Eliminar(int id)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                Talleres tallere = contexto.Talleres.Find(id);
                contexto.Talleres.Remove(tallere);
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;

                }

                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return paso;

        }

        public static Talleres Buscar(int id)
        {

            Talleres tallere = new Talleres();
            Contexto contexto = new Contexto();

            try
            {
                tallere = contexto.Talleres.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return tallere;

        }

        public static List<Talleres> GetList(Expression<Func<Talleres, bool>> expression)
        {

            List<Talleres> Talleres = new List<Talleres>();
            Contexto contexto = new Contexto();

            try
            {

                Talleres = contexto.Talleres.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Talleres;
        }
    }
}
