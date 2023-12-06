using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFinalizacionEstimada { get; set; }
        public DateTime FechaDeFinalizacionReal { get; set; }
        public EstadoProyecto Estado { get; set; } = EstadoProyecto.Activo;
        public float Costo { get; set; }

        public Cliente? Cliente { get; set; }
        public Equipo? Equipo { get; set; }
        public List<Tarea>? Tareas { get; set; }
    }
}
