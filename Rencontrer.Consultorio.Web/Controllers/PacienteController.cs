using Microsoft.AspNetCore.Mvc;

namespace Rencontrer.Consultorio.Web.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult NovoPaciente()
        {
            return View();
        }
    }
}
