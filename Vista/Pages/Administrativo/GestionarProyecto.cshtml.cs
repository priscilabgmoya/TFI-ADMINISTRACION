using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;
using Vista.Pages.Login;

namespace Vista.Pages.LiderDeProyecto
{
    [BindProperties]

    public class GestionarProyectoModel : PageModel
    {
        private IGestionarProyectoService _servicio;
        public List<Empleado> Empleados { get; set; }
        public List<Equipo> Equipos { get; set; } = new List<Equipo>(); 
        public Equipo Equipo { get; set; } = new Equipo()
        {
            Empleados = new List<Empleado>()
        };
        public int LegajoAgregar { get; set; }  
        public int LegajoBorrar { get; set; }  
        public int NumeroDeEquipo { get; set; }  



        public GestionarProyectoModel(IGestionarProyectoService servicio)
        {
            _servicio = servicio;
        }

        public void OnGet()
        {
            Empleados = _servicio.ObtenerEmpleados();
            Equipos = _servicio.ObtenerEquipos();
            if(NumeroDeEquipo == 0)
                Equipo = _servicio.ObtenerEquipo(1);
            else
                Equipo = _servicio.ObtenerEquipo(NumeroDeEquipo);
        }

        public void OnPost()
        {
            if (LegajoAgregar != 0)
                _servicio.AsignarEmpleadoAEquipo(LegajoAgregar, NumeroDeEquipo);
            OnGet();
        }

        public void OnPostCambiarEquipo()
        {
            Equipo = _servicio.ObtenerEquipo(NumeroDeEquipo);
            OnGet();
        }
    }
}
