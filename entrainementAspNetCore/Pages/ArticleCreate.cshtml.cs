using entrainementAspNetCore.Data.Interface;
using entrainementAspNetCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace entrainementAspNetCore.Pages
{
    public class ArticleCreateModel : PageModel
    {
        private readonly IArticleRepository _repository;

        [BindProperty]
        public ArticleForm Form { get; set; }

        public IFormFile File {  get; set; }

        public ArticleCreateModel(IArticleRepository repository)
        {
            _repository = repository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
           bool success = await _repository.Create(Form,File);

            if (success)
                return RedirectToPage("/articleindex");
            return Page();
        }
    }
}
