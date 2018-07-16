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
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.EntradaArticulos.Add(entradaArt) != null)
                {
                    var Articulo = contexto.Articulos.Find(entradaArt.ArticuloId);
                    Articulo.Inventario += entradaArt.Cantidad;
                    BLL.ArticulosBLL.Modificar(Articulo);
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
            Contexto contexto = new Contexto();

            try
            {
                EntradaArticulos EntradaAnterior = EntradaArticuloBLL.Buscar(entradaArt.EntradaId);

                int modificado = entradaArt.Cantidad - EntradaAnterior.Cantidad;

                Articulos articulo = ArticulosBLL.Buscar(entradaArt.ArticuloId);
                articulo.Inventario += modificado;
                ArticulosBLL.Modificar(articulo);

                contexto.Entry(entradaArt).State = EntityState.Modified;

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

                EntradaArticulos entradaArticulos = contexto.EntradaArticulos.Find(id);

                Articulos articulo = ArticulosBLL.Buscar(entradaArticulos.ArticuloId);
                articulo.Inventario -= entradaArticulos.Cantidad;
                ArticulosBLL.Modificar(articulo);

                contexto.EntradaArticulos.Remove(entradaArticulos);

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
