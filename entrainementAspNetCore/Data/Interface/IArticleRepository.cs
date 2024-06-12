using entrainementAspNetCore.Model;

namespace entrainementAspNetCore.Data.Interface
{
    public interface IArticleRepository
    {
        Task<IEnumerable<ArticleResume>> GetAll();

        Task<Article> GetByReference(int reference);

        Task<bool> Create(ArticleForm form, IFormFile file);
    }
}
