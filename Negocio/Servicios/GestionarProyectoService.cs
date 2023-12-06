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
    public class GestionarProyectoService : IGestionarProyectoService
    {
        private DatosContexto _contexto = new DatosContexto();

        public void AsignarEmpleadoAEquipo(int legajoSeleccionado, int numeroDeEquipo)
        {
            var empleado = _contexto.Empleados.Include(t => t.Tareas).FirstOrDefault(e => e.Legajo == legajoSeleccionado);
            var equipo = _contexto.Equipos.Include(eq => eq.Empleados).FirstOrDefault(eq => eq.EquipoId == numeroDeEquipo);

            if(!equipo.Empleados.Contains(empleado))
            {
                empleado.LiderDeProyecto = false;
                empleado.Tareas.RemoveAll(t => t.Estado != Dominio.Enum.EstadoTarea.Terminada);
                equipo.Empleados.Add(empleado);
                _contexto.Equipos.Update(equipo);
                _contexto.Empleados.Update(empleado);
                _contexto.SaveChanges();
            }
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _contexto.Empleados
                .Include(e => e.Area)
                .Include(e => e.Puesto)
                .Include(e => e.Sueldo)
                .Where(e => e.Puesto.Descripcion != "Administrativo")
                .ToList();          
        }

        public Equipo ObtenerEquipo(int numeroDeEquipo)
        {
            return _contexto.Equipos
                .Include(eq => eq.Empleados)
                .ThenInclude(em => em.Puesto)
                .Include(eq => eq.Empleados)
                .ThenInclude(em => em.Area)
                .FirstOrDefault(eq => eq.EquipoId == numeroDeEquipo);
        }

        public List<Equipo> ObtenerEquipos()
        {
            return _contexto.Equipos
                .Include(eq => eq.Empleados)
                .ThenInclude(em => em.Puesto)
                .Include(eq => eq.Empleados)
                .ThenInclude(em => em.Area)
                .ToList();
        }
    }
}
