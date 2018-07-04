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
    public class EntradaArticuloBLL
    {
        public static bool Guardar(EntradaArticulo entradaArt)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.EntradaArticulo.Add(entradaArt) != null)
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

        public static bool Modificar(EntradaArticulo taller)
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

                EntradaArticulo entradaArt = contexto.EntradaArticulo.Find(id);
                contexto.EntradaArticulo.Remove(entradaArt);
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

        public static EntradaArticulo Buscar(int id)
        {

            EntradaArticulo entradaArt = new EntradaArticulo();
            Contexto contexto = new Contexto();

            try
            {
                entradaArt = contexto.EntradaArticulo.Find(id);
                entradaArt.Detalle.Count();

                foreach (var item in entradaArt.Detalle)
                {
                    string s = item.Articulo.Descripcion;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {

                throw;

            }

            return entradaArt;

        }

        public static List<EntradaArticulo> GetList(Expression<Func<EntradaArticulo, bool>> expression)
        {

            List<EntradaArticulo> EntradaArticulo = new List<EntradaArticulo>();
            Contexto contexto = new Contexto();

            try
            {

                EntradaArticulo = contexto.EntradaArticulo.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return EntradaArticulo;
        }
    }
}
