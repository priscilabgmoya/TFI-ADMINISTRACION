using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vista.Pages.Login
{
    public class CerrarSesionModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("MiCookieDeAutenticacion");
            return RedirectToPage("/Index");
        }
    }
}
