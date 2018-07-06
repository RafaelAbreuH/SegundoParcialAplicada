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

        public static bool Guardar(Mantenimientos mantenimiento)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Mantenimientos.Add(mantenimiento) != null)
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

        public static bool Modificar(Mantenimientos mantenimiento)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
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
                    string s = item.Vehiculos.Descripcion;
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
