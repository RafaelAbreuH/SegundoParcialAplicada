using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SegundoParcial.Entidades;
using System.Data.Entity;

namespace SegundoParcial.BLL
{
    public class Contexto : DbContext
    {
        public DbSet<Vehiculos> Vehiculos { get; set; }

        public Contexto() : base("ConStr") { }
    }

}
