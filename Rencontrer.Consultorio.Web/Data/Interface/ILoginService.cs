using Rencontrer.Consultorio.Web.Models;
using static Rencontrer.Consultorio.Web.Controllers.LoginController;

namespace Rencontrer.Consultorio.Web.Data.Interface
{
    public interface ILoginService
    {
        Task<LoginRequestModel> LoginAutenticacao(LoginRequestModel loginData);
    }
}
