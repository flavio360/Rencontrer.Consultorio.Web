using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Rencontrer.Consultorio.Web.Data.Interface;
using System.Security.Claims;

namespace Rencontrer.Consultorio.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _Service;
        private readonly IMemoryCache _memoryCache;
        private  int cacheTime = 0;
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
        public async Task<IActionResult> Autenticar([FromBody] LoginRequest loginData)
        {
            try
            {
                var autenticade = await _Service.LoginAutenticacao(loginData);

                if (autenticade != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, autenticade.usuarioId.ToString()),
                        new Claim(ClaimTypes.Name, autenticade.nome),
                        new Claim("Token", autenticade.token),
                        new Claim("TipoAcesso", autenticade.tipoAcesso),
                        new Claim("EmpresaId", autenticade.empresaId.ToString())
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

                    if (autenticade.tipoAcesso =="P")
                    {
                        cacheTime = 10;
                    }
                    else if (autenticade.tipoAcesso == "PA") 
                    {
                        cacheTime = 30;
                    }
                    else
                    {
                        cacheTime = 30;
                    }

                    var cacheKey = "Login" + (HttpContext.User.Identity.Name?.Replace(" ", "_") ?? "");

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

        // Classe auxiliar para receber dados
        public class LoginRequest
        {
            public string User { get; set; }
            public string Password { get; set; }
        }

    }
}
