using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;

namespace Vista.Pages.Administrativo
{
    [BindProperties]

    public class GestionarEmpleadosModel : PageModel
    {
        public List<Empleado>? Empleados { get; set; } = new List<Empleado>();
        public int LegajoSeleccionado { get; set; }

        private IEmpleadoService _servicio;

        public GestionarEmpleadosModel(IEmpleadoService servicio)
        {
            _servicio = servicio;
        }

        public void OnGet()
        {
            //cargarMockupEmpleados();
            Empleados = _servicio.ObtenerEmpleados();
        }


        public void OnPostDelete()  
        {
            _servicio.EliminarEmpleado(LegajoSeleccionado);
            OnGet();
        }


        #region
        private void cargarMockupEmpleados()
        {
            Empleado e1 = new Empleado()
            {
                Nombre = "Juan",
                Apellido = "Perez",
                Legajo = 2000,
            };
            Empleado e2 = new Empleado()
            {
                Nombre = "Maria",
                Apellido = "Gomez",
                Legajo = 2001,
            };

            Empleado e3 = new Empleado()
            {
                Nombre = "Carlos",
                Apellido = "Rodriguez",
                Legajo = 2002,
            };
            Empleados.Add(e1);
            Empleados.Add(e2);
            Empleados.Add(e3);
        }
        #endregion
    }
}
