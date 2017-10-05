using Microsoft.AspNetCore.Mvc;

namespace ClimateMeter.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("{*url}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
