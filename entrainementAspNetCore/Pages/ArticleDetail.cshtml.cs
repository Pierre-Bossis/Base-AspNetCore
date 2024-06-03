using entrainementAspNetCore.Data.Interface;
using entrainementAspNetCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace entrainementAspNetCore.Pages
{
    public class ArticleDetailModel : PageModel
    {
        private readonly IArticleRepository _repository;
        public Article article { get; set; }

        public ArticleDetailModel(IArticleRepository repository)
        {
            _repository = repository;
        }
        public async Task OnGet(int reference)
        {
            article = await _repository.GetByReference(reference);
        }
    }
}
