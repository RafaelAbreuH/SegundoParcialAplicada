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
        public static bool Guardar(EntradaArticulos entradaArt)
        {
            bool paso = false;
            Repositorio<Articulos> articulos = new Repositorio<Articulos>(new Contexto());
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.EntradaArticulos.Add(entradaArt) != null)
                {
                    foreach (var item in articulos.GetList(x => x.Descripcion == entradaArt.Articulo))
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario += entradaArt.Cantidad;
                    }
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

        public static bool Modificar(EntradaArticulos entradaArt)
        {

            bool paso = false;
            Repositorio<Articulos> articulos = new Repositorio<Articulos>(new Contexto());
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(entradaArt).State = EntityState.Modified;

                foreach (var item in articulos.GetList(x => x.Descripcion == entradaArt.Articulo))
                {
                    contexto.Articulos.Find(item.ArticuloId).Inventario = entradaArt.Cantidad;
                }

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

                EntradaArticulos entradaArt = contexto.EntradaArticulos.Find(id);
                contexto.EntradaArticulos.Remove(entradaArt);

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

        public static EntradaArticulos Buscar(int id)
        {

            EntradaArticulos entradaArt = new EntradaArticulos();
            Contexto contexto = new Contexto();

            try
            {
                entradaArt = contexto.EntradaArticulos.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return entradaArt;

        }

        public static List<EntradaArticulos> GetList(Expression<Func<EntradaArticulos, bool>> expression)
        {

            List<EntradaArticulos> EntradaArticulo = new List<EntradaArticulos>();
            Contexto contexto = new Contexto();

            try
            {

                EntradaArticulo = contexto.EntradaArticulos.Where(expression).ToList();
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
