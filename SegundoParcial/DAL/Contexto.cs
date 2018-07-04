using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Talleres> Talleres { get; set; }
        public DbSet<EntradaArticulo> EntradaArticulo { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Articulos> Articulos { get; set; }

        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
