using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;
using Vista.Pages.Login;

namespace Vista.Pages.LiderDeProyecto
{
    [BindProperties]
    public class CalendarioModel : PageModel
    {
        private IAsignarTareasService _servicio;
        public Proyecto Proyecto { get; set; }
        #region
        public List<string> Numeros { get; set; }
        public List<string> Descripciones { get; set; }
        public List<int> DiasFin { get; set; } = new List<int>();
        public List<int> MesesFin { get; set; } = new List<int>();
		public List<int> AnosFin { get; set; } = new List<int>();
        public List<Tarea> TareasActivas { get; set; }
        #endregion



        public CalendarioModel(IAsignarTareasService servicio)
        {
            _servicio = servicio;
        }

        public void OnGet()
        {
            Proyecto = _servicio.ObtenerProyectoActual(IniciarSesionModel.EmpleadoId);//IniciarSesionModel.EmpleadoId
			if (Proyecto != null)
                CargarDatos();
        }


        #region
        public void CargarDatos()
        {
            TareasActivas = Proyecto.Tareas.Where(x => x.Estado != Dominio.Enum.EstadoTarea.Terminada).ToList();
            foreach(var tarea in TareasActivas)
            {
                DiasFin.Add(tarea.FechaFinalEstimada.Day);
                MesesFin.Add(tarea.FechaFinalEstimada.Month);
                AnosFin.Add(tarea.FechaFinalEstimada.Year);
            }
		}
        #endregion
    }
}
