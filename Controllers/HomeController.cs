using Microsoft.AspNetCore.Mvc;

namespace ClimateMeter.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
