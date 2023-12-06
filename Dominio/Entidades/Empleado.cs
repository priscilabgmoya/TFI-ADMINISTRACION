using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Empleado
    {
        public int Legajo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public long CUIT { get; set; }
        public bool LiderDeProyecto { get; set; } = false;


        public Usuario? Usuario { get; set; }
        public Sueldo? Sueldo { get; set; }
        public Area? Area { get; set; }
        public Puesto? Puesto { get; set; }
        public List<Tarea>? Tareas { get; set; }
    }
}
