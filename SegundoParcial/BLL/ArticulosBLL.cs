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
    public class ArticulosBLL
    {

        public static decimal PorcientoGanancia(decimal precio, decimal costo)
        {
            return (precio - costo) / costo * 100;
        }

        public static decimal Precio(decimal costo, decimal ganancia)
        {
            return (costo * ganancia) / 100 + costo;
        }

        public static decimal Costo(decimal precio, decimal ganancia)
        {
            return precio / ((100 + ganancia) / 100); 
                /*digamos que el precio es 200 y el porciento de ganancia es 100% 
                  200 / (100% + 100) / 100%) =  100% de ganancia
                */
        }

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
        public static string RetornarDescripcion(string nombre)
        {
            string descripcion = string.Empty;
            var lista = GetList(x => x.Descripcion.Equals(nombre));
            foreach (var item in lista)
            {
                descripcion = item.Descripcion;
            }

            return descripcion;
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
