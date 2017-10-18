using System.Threading.Tasks;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> SensorReadings()
        {
            var readings = await _dbContext.SensorReadings.ToArrayAsync();
            return Ok(readings);
        }
    }
}
