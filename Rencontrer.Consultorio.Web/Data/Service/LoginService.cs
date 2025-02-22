using Rencontrer.Consultorio.Web.Data.Interface;
using Rencontrer.Consultorio.Web.Models;
using static Rencontrer.Consultorio.Web.Controllers.LoginController;

namespace Rencontrer.Consultorio.Web.Data.Service
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Security/authenticate";

        // Construtor necessário para o AddHttpClient funcionar
        public LoginService(HttpClient httpClient)
        {
            _client = httpClient;
        }



        public Task<LoginResponseViewModel> LoginAutenticacao(LoginRequest loginData)
        {
            throw new NotImplementedException();
        }
    }
}
