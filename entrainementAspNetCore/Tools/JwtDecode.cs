using System.IdentityModel.Tokens.Jwt;

namespace entrainementAspNetCore.Tools
{
    public static class JwtDecode
    {
        public static bool IsUserAdmin(string token, string roleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
        {
            if (string.IsNullOrEmpty(token))
                return false;

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            if (jsonToken != null)
            {
                var roleClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == roleClaimType)?.Value;
                return roleClaim == "Admin";
            }

            return false;
        }
    }
}
