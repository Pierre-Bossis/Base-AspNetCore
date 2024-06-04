using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace entrainementAspNetCore.Pages.User
{
    public class LogoutModel : PageModel
    {
        public LogoutModel()
        {

        }
        public IActionResult OnGet()
        {
            HttpContext.Response.Cookies.Delete("token");
            return RedirectToPage("/Index");
        }
    }
}
