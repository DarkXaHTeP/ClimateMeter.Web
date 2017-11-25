using System.Threading.Tasks;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClimateMeter.Web.Controllers.Api
{
    [Route("api/devices")]
    public class DevicesController : Controller
    {
        private readonly ClimateMeterContext _db;

        public DevicesController(ClimateMeterContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var devices = await _db.Devices.ToListAsync();
            return Ok(devices);
        }
    }
}