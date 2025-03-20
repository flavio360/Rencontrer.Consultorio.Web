using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Rencontrer.Consultorio.Web.Data.Interface;
using Rencontrer.Consultorio.Web.Models;
using System.Security.Claims;

namespace Rencontrer.Consultorio.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _Service;
        private readonly IMemoryCache _memoryCache;
        private  int cacheTime = 10;
        public LoginController(ILoginService service, IMemoryCache memoryCache)
        {
            _Service = service;
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login/Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] LoginRequestModel loginData)
        {
            try
            {
                var autenticade = await _Service.LoginAutenticacao(loginData);

                if (autenticade != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, autenticade.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Name, autenticade.Nome),
                        new Claim("Token", autenticade.Email),
                        new Claim("TipoAcesso", autenticade.IdPerfilUsuario.ToString()),
                        new Claim("EmpresaId", autenticade.EmpresaId.ToString())
                    };

                    // Criando a identidade e o principal
                    var identity = new ClaimsIdentity(claims, "CookieAuthentication");
                    var principal = new ClaimsPrincipal(identity);

                    // Salvando o cookie de autenticação
                    await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties
                    {
                        IsPersistent = true, // Se o usuário quer manter a sessão ativa
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30) // Duração do cookie
                    });

                   
                        
                    var cacheKey = "Login_" + (HttpContext.User.Identity.Name?.Replace(" ", "_") ?? "");

                    _memoryCache.Set(cacheKey, autenticade, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheTime)));

                     
					return Json(new { status = "success", msg = "", urlRedirect = "Home" });
                }
                else
                {
                    return Json(new { status = "fail", msg = "Usuário ou senha incorretos", urlRedirect = "Index" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = $"Erro ao autenticar: {ex.Message}", urlRedirect = "Index" });
            }
        }
    }
}
