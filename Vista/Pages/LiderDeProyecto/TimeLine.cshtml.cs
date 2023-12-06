using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Vista.Pages.Login;

namespace Vista.Pages.LiderDeProyecto
{
    [BindProperties]
    [Authorize(Policy = "DebeSerLiderDeProyecto")]
    public class TimeLineModel : PageModel
    {
        private IAsignarTareasService _servicio;
        public Proyecto Proyecto { get; set; }
        #region
        public List<string> Numeros { get; set; }
        public List<string> Descripciones { get; set; }
        public List<int> DiasInicio { get; set; }
        public List<int> MesesInicio { get; set; }
        public List<int> AnosInicio { get; set; }
        public List<int> DiasFin { get; set; }
        public List<int> MesesFin { get; set; }
        public List<int> AnosFin { get; set; }
        public List<double> Duraciones { get; set; }
        public List<int> Porcentajes { get; set; }
        public List<int> TiempRestante { get; set; }
        public List<string> Totales { get; set; } = new List<string>();
        public List<Tarea> TareasPrioritarias { get; set; } 
        public string TotalCompletadas { get; set; }
        public string TotalIncompletas { get; set; }
        public string TotalSinIniciar { get; set; }
        #endregion



        public TimeLineModel(IAsignarTareasService servicio)
        {
            _servicio = servicio;
        }

        public void OnGet()
        {
            Proyecto = _servicio.ObtenerProyectoActual(IniciarSesionModel.EmpleadoId);
            if (Proyecto != null)
                CargarDatos();
        }


        #region
        public void CargarDatos()
        {
            var tareasActivas = Proyecto.Tareas.Where(x => x.Estado != Dominio.Enum.EstadoTarea.Terminada);
            Numeros = tareasActivas.Select(t => t.TareaId.ToString()).ToList();
            Descripciones = tareasActivas.Select(t => t.Descripcion).ToList();
            Duraciones = tareasActivas.Select(t => t.HorasDedicacionEstimadas).ToList();

            foreach(var desc in Descripciones)
                QuitarAcentosYReemplazarN(desc);

            DiasInicio = tareasActivas.Select(t => t.FechaInicio.Day).ToList();
            MesesInicio = tareasActivas.Select(t => t.FechaInicio.Month).ToList();
            AnosInicio = tareasActivas.Select(t => t.FechaInicio.Year).ToList();


            DiasFin = tareasActivas.Select(t => t.FechaFinalEstimada.Day).ToList();
            MesesFin = tareasActivas.Select(t => t.FechaFinalEstimada.Month).ToList();
            AnosFin = tareasActivas.Select(t => t.FechaFinalEstimada.Year).ToList();

            Porcentajes = tareasActivas.Select(t => t.Estado == Dominio.Enum.EstadoTarea.Sin_Iniciar? 0 : 50).ToList();
            
            TotalCompletadas = Proyecto.Tareas.Where(t => t.Estado.Equals(Dominio.Enum.EstadoTarea.Terminada)).Count().ToString();
            TotalIncompletas = tareasActivas.Where(t => t.Estado.Equals(Dominio.Enum.EstadoTarea.Incompleta)).Count().ToString();
            TotalSinIniciar = tareasActivas.Where(t => t.Estado.Equals(Dominio.Enum.EstadoTarea.Sin_Iniciar)).Count().ToString();

            Totales.Add(TotalCompletadas);
            Totales.Add(TotalIncompletas);
            Totales.Add(TotalSinIniciar);

            TareasPrioritarias = tareasActivas.Where(t => t.Prioridad == Dominio.Enum.PrioridadTarea.Alta).ToList();
            if(TareasPrioritarias.Count()>3)
                TareasPrioritarias.RemoveRange(3, TareasPrioritarias.Count - 3);
        }

        private string QuitarAcentosYReemplazarN(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    char caracterSinAcento = (c == 'ñ' || c == 'Ñ') ? 'n' : c;
                    sb.Append(caracterSinAcento);
                }
            }

            return sb.ToString();
        }
        #endregion
    }
}
