using Datos;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Negocio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class AsignarTareasService : IAsignarTareasService
    {
        private DatosContexto _contexto = new DatosContexto();

        public Proyecto? ObtenerProyectoActual(int legajo)
        {
            return _contexto.Proyectos
                .Include(x => x.Cliente)
                .Include(t => t.Tareas)
                .Include(p => p.Equipo)
                .ThenInclude(eq => eq.Empleados)
                .FirstOrDefault(p => p.Equipo.Empleados
                .Any(e => e.Legajo == legajo 
                && e.LiderDeProyecto));
        }

        public List<Empleado>? ObtenerEmpleadosDisponibles(int equipoId)
        {
            var empleados = _contexto.Equipos
                 .Where(e => e.EquipoId == equipoId)
                 .Include(eq => eq.Empleados)
                 .SelectMany(eq => eq.Empleados)
                 .ToList();

            return empleados;
        }

        public void AgregarTarea(int empleadoLegajo, Tarea tarea, int legajo)
        {
            var proyecto = ObtenerProyectoActual(legajo);
            var empleado = _contexto.Empleados
                .Include(t => t.Tareas)
                .FirstOrDefault(e => e.Legajo.Equals(empleadoLegajo));
            if (tarea.FechaInicio.Year != 2023)
                tarea.FechaInicio = DateTime.UtcNow;

            proyecto.Tareas.Add(tarea);
            empleado.Tareas.Add(tarea);
            _contexto.Empleados.Update(empleado);
            _contexto.Proyectos.Update(proyecto);
            _contexto.SaveChanges();
        }

        public void EliminarTarea(int tareaIDSeleccionada)
        {
            var tarea = _contexto.Tareas
                .FirstOrDefault(t => t.TareaId == tareaIDSeleccionada);
            if (tarea != null)
            {
                _contexto.Tareas.Remove(tarea);
                _contexto.SaveChanges();
            }
        }
        public void ActualizarTarea(int tareaIDSeleccionada)
        {
            var tarea = _contexto.Tareas
                .FirstOrDefault(t => t.TareaId == tareaIDSeleccionada);
            switch (tarea.Estado)
            {
                case Dominio.Enum.EstadoTarea.Sin_Iniciar:
                    tarea.Estado = Dominio.Enum.EstadoTarea.Incompleta;
                    break;
                case Dominio.Enum.EstadoTarea.Incompleta:
                    tarea.Estado = Dominio.Enum.EstadoTarea.Terminada;
                    break;
                default:
                    break;
            }
            _contexto.Tareas.Update(tarea);
            _contexto.SaveChanges();
        }
        public void ActualizarEstado(int tareaIDSeleccionada)
        {
            var tarea = _contexto.Tareas
                .FirstOrDefault(t => t.TareaId == tareaIDSeleccionada);
            switch (tarea.Prioridad)
            {
                case Dominio.Enum.PrioridadTarea.Media:
                    tarea.Prioridad = Dominio.Enum.PrioridadTarea.Alta;
                    break;
                case Dominio.Enum.PrioridadTarea.Baja:
                    tarea.Prioridad = Dominio.Enum.PrioridadTarea.Media;
                    break;
                default:
                    tarea.Prioridad = Dominio.Enum.PrioridadTarea.Baja;
                    break;
            }
            _contexto.Tareas.Update(tarea);
            _contexto.SaveChanges();
        }
    }
}
