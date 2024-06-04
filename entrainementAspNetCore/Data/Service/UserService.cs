using entrainementAspNetCore.Data.Interface;
using entrainementAspNetCore.Model;
using entrainementAspNetCore.Model.User;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace entrainementAspNetCore.Data.Service
{
    public class UserService : IUserRepository
    {
        private readonly IHttpClientFactory _factory;

        public UserService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<string> Login(LoginForm form)
        {
            using HttpClient client = _factory.CreateClient("api");

            JsonContent content = JsonContent.Create(form);

            using HttpResponseMessage response = await client.PostAsync("api/auth/login", content);

            try
            {
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public async Task Register(RegisterForm form)
        {
            throw new NotImplementedException();
        }
    }
}
