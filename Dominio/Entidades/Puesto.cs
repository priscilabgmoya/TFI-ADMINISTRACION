using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Puesto
    {
        public int PuestoId { get; set; }
        public string? Descripcion { get; set; }
        public string? Seniority { get; set; }
    }
}
