using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int MantenimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public float Monto { get; set; }


        public virtual ICollection<MantenimientoDetalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientoDetalle>();
        }

        public void AgregarDetalle(int id, int MantenimientoId, int VehiculoId, string Servicio, int Cantidad, int Precio)
        {
            this.Detalle.Add(new MantenimientoDetalle(id, MantenimientoId, VehiculoId, Servicio, Cantidad, Precio));
        }

    }
}
