using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;

namespace Vista.Pages.Administrativo
{

    [BindProperties]
    public class CrearEmpleadoModel : PageModel
    {
        private IEmpleadoService _servicio;

        public Empleado Empledo { get; set; } = new Empleado();
        public Usuario Usuario { get; set; } = new Usuario();
        public Sueldo Sueldo { get; set; } = new Sueldo();
        public Puesto Puesto { get; set; } = new Puesto();
        public List<Area> AreasDeTrabajo { get; set; }
        public int IndiceAreaSeleccionada { get; set; }
        public string FechaNacimiento { get; set; }


        public CrearEmpleadoModel(IEmpleadoService servicio)
        {
            _servicio = servicio;
        }
        public void OnGet()
        {
            //cargarMockupAreas();
            AreasDeTrabajo = _servicio.ObtenerAreasLaborales();
        }

        public void OnPost()    
        {
            if (DatosCompletos())
            {
                Empledo.Area = _servicio.ObtenerAreasLaborales()[IndiceAreaSeleccionada];
                Empledo.FechaDeNacimiento = DateTime.Parse(FechaNacimiento);
                Empledo.Usuario = Usuario;
                Empledo.Sueldo = Sueldo;
                Empledo.Puesto = Puesto;
                _servicio.AgregarEmpleado(Empledo);
            } 
            else
                OnGet();
        }


        #region
        private bool DatosCompletos()
        {
                return !string.IsNullOrEmpty(Empledo.Nombre)
                && !string.IsNullOrEmpty(Empledo.Apellido)
                && !string.IsNullOrEmpty(FechaNacimiento)
                && Empledo.CUIT > 0
                && Sueldo.Bruto > 0
                && !string.IsNullOrEmpty(Usuario.NombreDeUsuario)
                && !string.IsNullOrEmpty(Usuario.Contrasena)
                && !string.IsNullOrEmpty(Puesto.Descripcion);
        }

        private void cargarMockupAreas()
        {
            AreasDeTrabajo = new List<Area>()
            {
                new Area() {AreaId=1, NombreArea="Desarrollo" },
                new Area() {AreaId=2, NombreArea="Producción" },
                new Area() {AreaId=3, NombreArea="Testing" }
            };
        }
        #endregion
    }
}
