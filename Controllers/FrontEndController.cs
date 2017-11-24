using System.Linq;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ClimateMeter.Web.Controllers
{
    public class FrontEndController : Controller
    {
        private readonly ClimateMeterContext _dbContext;

        public FrontEndController(ClimateMeterContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }

        [Route("sensorreadings")]
        public IActionResult SensorReadings()
        {
            var readings = _dbContext.SensorReadings.ToArray();
            return Ok(readings);
        }
    }
}
