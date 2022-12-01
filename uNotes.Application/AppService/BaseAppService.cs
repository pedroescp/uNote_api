using System.IdentityModel.Tokens.Jwt;

namespace uNotes.Application.AppService
{
    public class BaseAppService
    {
        public static string ObterInformacoesToken(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        }
    }
}
