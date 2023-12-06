using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public interface IEmpleadoService
    {
        public List<Empleado> ObtenerEmpleados();
        Empleado? BuscarEmpleado(int legajo);
        void AgregarEmpleado(Empleado empleado);
        void EliminarEmpleado(int legajo);
        bool LegajoValido(int legajo);
        List<Area> ObtenerAreasLaborales();
        void ActualizarEmpleado(Empleado empledo);
    }
}
