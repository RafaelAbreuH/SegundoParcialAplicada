using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
    public class Mantenimientos
    {
        [Key]
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal itbis { get; set; }
        public decimal Total { get; set; }


        public virtual ICollection<MantenimientoDetalle> Detalle { get; set; }

        public Mantenimientos()
        {
            MantenimientoId = 0;
            Fecha = DateTime.Now;
            Subtotal = 0;
            itbis = 0;
            Total = 0;
            this.Detalle = new List<MantenimientoDetalle>();
        }

        public void AgregarDetalle(int id, int mantenimientoId, int vehiculoId, int tallerId, int articuloId, int cantidad, int precio, int importe)
        {
            this.Detalle.Add(new MantenimientoDetalle(id, mantenimientoId, vehiculoId, tallerId, articuloId, cantidad, precio, importe));
        }
    }
}
