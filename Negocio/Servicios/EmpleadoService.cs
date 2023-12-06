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
    public class EmpleadoService : IEmpleadoService
    {
        private DatosContexto _contexto = new DatosContexto();


        public List<Empleado> ObtenerEmpleados()
        {
            return _contexto.Empleados
                .Include(x => x.Puesto)
                .Include(x => x.Sueldo)
                .ToList();
        }

        public Empleado? BuscarEmpleado(int legajo)
        {
            return _contexto.Empleados
                .Include(x => x.Puesto)
                .Include(x => x.Sueldo)
                .Include(x => x.Usuario)
                .Include(x => x.Area)
                .FirstOrDefault(x => x.Legajo == legajo);
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            _contexto.Empleados.Add(empleado);
            _contexto.SaveChanges();
        }

        public void EliminarEmpleado(int legajo)
        {
            var empleado = _contexto.Empleados.FirstOrDefault(emp => emp.Legajo.Equals(legajo));
            if (empleado != null)
            {
                _contexto.Empleados.Remove(empleado);
                _contexto.SaveChanges();
            }
        }

        public bool LegajoValido(int legajo)
        {
            var empleado = _contexto.Empleados.FirstOrDefault(emp => emp.Legajo.Equals(legajo));
            if (empleado != default)
                return false;
            return true;
        }

        public List<Area> ObtenerAreasLaborales()
        {
            return _contexto.Areas.ToList();
        }

        public void ActualizarEmpleado(Empleado empledo)
        {
            _contexto.Empleados.Update(empledo);
            _contexto.SaveChanges();
        }
    }
}
