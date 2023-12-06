using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string? Estado { get; set; }

        public List<Empleado>? Empleados { get; set; }
    }
}
