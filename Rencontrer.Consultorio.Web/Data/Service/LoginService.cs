using Rencontrer.Consultorio.Web.Data.Interface;
using Rencontrer.Consultorio.Web.Models;
using static Rencontrer.Consultorio.Web.Controllers.LoginController;

namespace Rencontrer.Consultorio.Web.Data.Service
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Security/";

        // Construtor necessário para o AddHttpClient funcionar
        public LoginService(HttpClient httpClient)
        {
            _client = httpClient;
        }



		public async Task<LoginRequestModel> LoginAutenticacao(LoginRequestModel loginData)
		{
			var response = await _client.PostAsJsonAsync("api/login/authenticate", loginData);

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<LoginRequestModel>();
			}
			else
			{
				return null; // Retorne null se a autenticação falhar
			}
		}

	}
}
