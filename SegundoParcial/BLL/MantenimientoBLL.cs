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

        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Mantenimiento.Add(mantenimiento) != null)
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

        public static bool Modificar(Mantenimiento mantenimiento)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                //todo: buscar las entidades que no estan para removerlas

                //recorrer el detalle
                foreach (var item in mantenimiento.Detalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
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

                Mantenimiento mantenimiento = contexto.Mantenimiento.Find(id);

                contexto.Mantenimiento.Remove(mantenimiento);
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

        public static Mantenimiento Buscar(int id)
        {

            Mantenimiento mantenimiento = new Mantenimiento();
            Contexto contexto = new Contexto();

            try
            {
                mantenimiento = contexto.Mantenimiento.Find(id);
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

        public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento, bool>> expression)
        {

            List<Mantenimiento> Mantenimiento = new List<Mantenimiento>();
            Contexto contexto = new Contexto();

            try
            {

                Mantenimiento = contexto.Mantenimiento.Where(expression).ToList();
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
