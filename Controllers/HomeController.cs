using System.Linq;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ClimateMeter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClimateMeterContext _dbContext;

        public HomeController(ClimateMeterContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("sensorreadings")]
        public IActionResult SensorReadings()
        {
            var readings = _dbContext.SensorReadings.ToArray();
            return Ok(readings);
        }
    }
}
