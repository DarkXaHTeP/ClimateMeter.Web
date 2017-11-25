using System.IO;
using System.Linq;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace ClimateMeter.Web.Controllers
{
    public class FrontEndController : Controller
    {
        private readonly ClimateMeterContext _dbContext;
        private readonly IHostingEnvironment _env;

        public FrontEndController(ClimateMeterContext dbContext, IHostingEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }
        
        public IActionResult Index()
        {
            IFileInfo file = _env.WebRootFileProvider.GetFileInfo("index.html");

            using (var stream = file.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    return Content(reader.ReadToEnd(), "text/html");
                }
            }
        }

        [Route("sensorreadings")]
        public IActionResult SensorReadings()
        {
            var readings = _dbContext.SensorReadings.ToArray();
            return Ok(readings);
        }
    }
}
