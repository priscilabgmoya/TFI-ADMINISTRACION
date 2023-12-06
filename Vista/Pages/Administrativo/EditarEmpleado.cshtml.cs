using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;

namespace Vista.Pages.Administrativo
{

    [BindProperties]
    public class EditarEmpleadoModel : PageModel
    {
        private IEmpleadoService _servicio;

        public int Legajo { get; set; }
        public int IndiceAreaSeleccionada { get; set; }
        public Empleado Empledo { get; set; }
        public List<Area> AreasDeTrabajo { get; set; } 


        public EditarEmpleadoModel(IEmpleadoService servicio)
        {
            _servicio = servicio;
        }
        public void OnGet()
        {
            AreasDeTrabajo = _servicio.ObtenerAreasLaborales();
        }
        public void OnPostBuscar()
        {
            var emp = _servicio.BuscarEmpleado(Legajo);
            if (emp != default)
                Empledo = emp;
            OnGet();
        }
        public void OnPostUpdate() //TODO: redireccionar
        {
            Empledo.Area = _servicio.ObtenerAreasLaborales()[IndiceAreaSeleccionada];
            if (Empledo != null && DatosCompletos())
                _servicio.ActualizarEmpleado(Empledo);
        }


        #region
        private bool DatosCompletos()
        {
            return !string.IsNullOrEmpty(Empledo.Nombre)
                && !string.IsNullOrEmpty(Empledo.Apellido)
                && Empledo.FechaDeNacimiento != DateTime.MinValue
                && Empledo.CUIT > 0
                && Empledo.Sueldo.Bruto > 0
                && !string.IsNullOrEmpty(Empledo.Usuario.NombreDeUsuario)
                && !string.IsNullOrEmpty(Empledo.Usuario.Contrasena)
                && !string.IsNullOrEmpty(Empledo.Puesto.Descripcion)
                && !string.IsNullOrEmpty(Empledo.Puesto.Seniority);
        }
        #endregion
    }
}
