using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;
using Vista.Pages.Login;

namespace Vista.Pages.LiderDeProyecto
{
    [BindProperties]
    [Authorize(Policy = "DebeSerLiderDeProyecto")]
    public class AsignarTareasModel : PageModel
    {
        private IAsignarTareasService _servicio;
        public Proyecto Proyecto { get; set; }
        public List<Empleado>? EmpleadosDisponibles { get; set; }
        public Tarea Tarea { get; set; }
        public int EmpleadoLegajo { get; set; }
        public int TareaIDSeleccionada { get; set; }

        public AsignarTareasModel(IAsignarTareasService servicio)
        {
            _servicio = servicio;
        }

        public void OnGet()
        {
            Proyecto = _servicio.ObtenerProyectoActual(IniciarSesionModel.EmpleadoId);
            if (Proyecto != null)
                EmpleadosDisponibles = _servicio.ObtenerEmpleadosDisponibles(Proyecto.Equipo.EquipoId);
        }

        public void OnPost()
        {
            if (ValidarDatos())
                _servicio.AgregarTarea(EmpleadoLegajo, Tarea, IniciarSesionModel.EmpleadoId);
            OnGet();
        }

        public void OnPostDelete()
        {
            _servicio.EliminarTarea(TareaIDSeleccionada);
            OnGet();
        }
        public void OnPostUpdate()
        {
            _servicio.ActualizarTarea(TareaIDSeleccionada);
            OnGet();
        }
        public void OnPostState()
        {
            _servicio.ActualizarEstado(TareaIDSeleccionada); 
            OnGet();
        }
        private bool ValidarDatos()
        {
            return Tarea.FechaFinalEstimada > DateTime.UtcNow
                && Tarea.HorasDedicacionEstimadas > 0
                && !string.IsNullOrEmpty(Tarea.Descripcion);
        }

    }
}
