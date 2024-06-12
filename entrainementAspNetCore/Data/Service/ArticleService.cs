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

        public async Task<bool> Create(ArticleForm form, IFormFile file)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(file.OpenReadStream()), "Image", file.FileName);

                content.Add(new StringContent(form.Nom), "Nom");
                content.Add(new StringContent(form.Description), "Description");
                content.Add(new StringContent(form.Categorie), "Categorie");
                content.Add(new StringContent(form.Fournisseur), "Fournisseur");
                content.Add(new StringContent(form.Provenance), "Provenance");
                content.Add(new StringContent(form.MotsCles), "MotsCles");
                content.Add(new StringContent(form.Taille.ToString()), "Taille");
                content.Add(new StringContent(form.Poids.ToString()), "Poids");
                content.Add(new StringContent(form.Quantite.ToString()), "Quantite");
                content.Add(new StringContent(form.Prix.ToString()), "Prix");

                using HttpClient client = _factory.CreateClient("api");
                using HttpResponseMessage response = await client.PostAsync("api/article/create",content);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    return true;
                return false;
            }


            throw new NotImplementedException();
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
