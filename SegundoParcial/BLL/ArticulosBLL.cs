using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Articulos.Add(articulo) != null)
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

        public static bool Modificar(Articulos articulo)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
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

                Articulos articulo = contexto.Articulos.Find(id);
                contexto.Articulos.Remove(articulo);
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

        public static Articulos Buscar(int id)
        {

            Articulos articulo = new Articulos();
            Contexto contexto = new Contexto();

            try
            {
                articulo = contexto.Articulos.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return articulo;

        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {

            List<Articulos> Articulos = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {

                Articulos = contexto.Articulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Articulos;
        }
    }
}
