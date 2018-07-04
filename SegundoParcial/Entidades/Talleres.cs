using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial.Entidades
{
    public class Talleres
    {
        [Key]
        public int TallerId { get; set; }
        public string Nombre { get; set; }


        public Talleres()
        {

        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
