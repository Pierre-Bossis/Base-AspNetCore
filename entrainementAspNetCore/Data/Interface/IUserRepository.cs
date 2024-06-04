using entrainementAspNetCore.Model.User;
using Microsoft.AspNetCore.Mvc;

namespace entrainementAspNetCore.Data.Interface
{
    public interface IUserRepository
    {
        Task Register(RegisterForm form);
        Task<string> Login(LoginForm form);
    }
}
