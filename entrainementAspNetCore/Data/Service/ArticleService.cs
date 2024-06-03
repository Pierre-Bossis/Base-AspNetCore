using entrainementAspNetCore.Data.Interface;
using entrainementAspNetCore.Model;
using System.Text.Json;

namespace entrainementAspNetCore.Data.Service
{
    public class ArticleService : IArticleRepository
    {
        private readonly IHttpClientFactory _factory;

        public ArticleService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<ArticleResume>> GetAll()
        {
            using HttpClient client = _factory.CreateClient("api");

            using HttpResponseMessage response = await client.GetAsync("api/article");

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ArticleResume>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Article> GetByReference(int reference)
        {
            using HttpClient client = _factory.CreateClient("api");

            using HttpResponseMessage response = await client.GetAsync("api/article/" + reference);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Article>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
