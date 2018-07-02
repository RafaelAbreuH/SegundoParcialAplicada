using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SegundoParcial.Entidades;
using System.Data.Entity;

namespace SegundoParcial.BLL
{
    public class VehiculosBLL
    {
        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {

            List<Vehiculos> Vehiculos = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {

                Vehiculos = contexto.Vehiculos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Vehiculos;
        }
    }
}
