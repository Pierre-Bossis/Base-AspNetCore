using entrainementAspNetCore.Data.Interface;
using entrainementAspNetCore.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace entrainementAspNetCore.Pages
{
    public class ArticleIndexModel : PageModel
    {
        private readonly IArticleRepository _articleService;
        public string ErrorMessage { get; set; } = string.Empty;
        public IEnumerable<ArticleResume> Articles { get; set; } = Enumerable.Empty<ArticleResume>();

        public ArticleIndexModel(IArticleRepository articleService)
        {
            _articleService = articleService;
        }

        public async Task OnGetAsync()
        {
            try
            {
                Articles = await _articleService.GetAll();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.Split('.')[0] + ".";
            }
        }
    }
}