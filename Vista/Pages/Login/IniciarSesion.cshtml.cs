using Dominio.Entidades;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio.Contratos;
using Microsoft.AspNetCore.Authentication;

namespace Vista.Pages.Login
{
    [BindProperties]
    public class IniciarSesionModel : PageModel
    {
        private ISesionService _servicio;

        public Usuario Usuario { get; set; }
        public Empleado Empleado { get; set; }
        public static int EmpleadoId { get; set; }


        public IniciarSesionModel(ISesionService servicio)
        {
            _servicio = servicio;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            Empleado = _servicio.AutenticarDatos(Usuario);
            if (Empleado != null)
            {
                EmpleadoId = Empleado.Legajo;
                List<Claim> claims = new List<Claim>() 
                { 
                    new Claim(ClaimTypes.Name, Empleado.Usuario.NombreDeUsuario) 
                };

                if(Empleado.Puesto.Descripcion == "Administrativo")
                        claims.Add(new Claim("Empleado", "Administrativo"));
                else if(Empleado.LiderDeProyecto)
                    claims.Add(new Claim("Empleado", "LiderDeProyecto"));
                else
                    claims.Add(new Claim("Empleado", "Normal"));

                var identity = new ClaimsIdentity(claims, "MiCookieDeAutenticacion");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MiCookieDeAutenticacion", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
