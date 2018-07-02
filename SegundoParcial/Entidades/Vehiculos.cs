﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId{ get; set; }
        public string Descripcion { get; set; }
        public int Mantenimiento { get; set; }
        public DateTime Fecha { get; set; }


        public Vehiculos()
        {
                
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
