using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Sueldo
    {
        public int SueldoId { get; set; }
        public float Bruto { get; set; } = 0;
        public double DescuentoJubilacion { get; set; } = 0.11;
        public double DescuentoObraSocial { get; set; } = 0.03;
    }
}
