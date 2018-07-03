using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
    public class MantenimientoDetalle
    {
        [Key]
        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public string Servicio { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }

        public MantenimientoDetalle()
        {
            this.Id = 0;
            this.MantenimientoId = 0;

        }

        public MantenimientoDetalle(int id, int mantenimientoId, int vehiculoId, string servicio, int cantidad, int precio)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            VehiculoId = vehiculoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
