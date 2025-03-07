using Microsoft.AspNetCore.Mvc;

namespace Rencontrer.Consultorio.Web.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
