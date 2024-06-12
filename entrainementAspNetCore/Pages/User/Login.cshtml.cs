using entrainementAspNetCore.Data.Interface;
using entrainementAspNetCore.Model.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using Microsoft.VisualBasic;

namespace entrainementAspNetCore.Pages.User
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _repository;

        [BindProperty]
        public LoginForm Form { get; set; }
        public LoginModel(IUserRepository repository)
        {
            _repository = repository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            string token = await _repository.Login(Form);

            if (!string.IsNullOrEmpty(token))
            {
                Response.Cookies.Append("token",token);

                return RedirectToPage("/index");
            }
            return Page();
        }
    }
}
