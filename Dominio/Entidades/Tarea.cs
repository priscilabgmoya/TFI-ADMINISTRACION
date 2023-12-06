using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Tarea
    {
        public int TareaId { get; set; }
        public string? Descripcion { get; set; }
        public double HorasDedicacionEstimadas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalReal { get; set; }
        public DateTime FechaFinalEstimada { get; set; }
        public EstadoTarea Estado { get; set; } = EstadoTarea.Sin_Iniciar;
        public PrioridadTarea Prioridad { get; set; } = PrioridadTarea.Baja;
    }
}
