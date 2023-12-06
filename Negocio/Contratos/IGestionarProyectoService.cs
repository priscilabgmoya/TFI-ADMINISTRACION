using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public interface IGestionarProyectoService
    {
        void AsignarEmpleadoAEquipo(int legajoSeleccionado, int numeroDeEquipo);
        List<Empleado> ObtenerEmpleados();
        Equipo ObtenerEquipo(int numeroDeEquipo);
        List<Equipo> ObtenerEquipos();
    }
}
