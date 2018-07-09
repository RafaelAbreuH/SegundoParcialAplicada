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
    public class MantenimientoBLL
    {
        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }

        public static decimal CalcularItbis(decimal subtotal)
        {
            return subtotal * Convert.ToDecimal(0.18);
        }

        public static decimal Total(decimal subtotal, decimal itbis)
        {
            return subtotal + itbis;
        }

        public static bool Guardar(Mantenimientos mantenimiento)
        {
            bool paso = false;
            Vehiculos vehiculos = new Vehiculos();
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Mantenimientos.Add(mantenimiento) != null)
                {
                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                    }
                    contexto.Vehiculos.Find(mantenimiento.VehiculoId).Mantenimiento += Convert.ToInt32(mantenimiento.Total);

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

        public static bool Modificar(Mantenimientos mantenimiento)
        {

            bool paso = false;

            Contexto contexto = new Contexto();
            var Mantenimiento = BLL.MantenimientoBLL.Buscar(mantenimiento.MantenimientoId);
            try
            {
                if (Mantenimiento != null)
                {


                    foreach (var item in Mantenimiento.Detalle)
                    {

                        contexto.Articulos.Find(item.ArticuloId).Inventario += item.Cantidad;


                        if (!mantenimiento.Detalle.ToList().Exists(v => v.Id == item.Id))
                        {
                            contexto.EntradaArticulos.Find(item.ArticuloId).Cantidad -= item.Cantidad;

                            item.Articulos = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in mantenimiento.Detalle)
                    {
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }
                
                    contexto.Entry(mantenimiento).State = EntityState.Modified;

                    if (contexto.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                    contexto.Dispose();
                }
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

                Mantenimientos mantenimiento = contexto.Mantenimientos.Find(id);

                contexto.Mantenimientos.Remove(mantenimiento);
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

        public static Mantenimientos Buscar(int id)
        {

            Mantenimientos mantenimiento = new Mantenimientos();
            Contexto contexto = new Contexto();

            try
            {
                mantenimiento = contexto.Mantenimientos.Find(id);
                mantenimiento.Detalle.Count();

                foreach (var item in mantenimiento.Detalle)
                {
                    string s = item.Articulos.Descripcion;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {

                throw;

            }

            return mantenimiento;

        }

        public static List<Mantenimientos> GetList(Expression<Func<Mantenimientos, bool>> expression)
        {

            List<Mantenimientos> Mantenimiento = new List<Mantenimientos>();
            Contexto contexto = new Contexto();

            try
            {

                Mantenimiento = contexto.Mantenimientos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Mantenimiento;
        }
    }
}
