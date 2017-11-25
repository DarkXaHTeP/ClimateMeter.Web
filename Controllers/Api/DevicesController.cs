using System;
using System.Linq;
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

        [HttpGet("{deviceId}/sensorreadings")]
        public async Task<IActionResult> SensorReadings(Guid deviceId)
        {
            var readings = await _db.SensorReadings
                .Where(r => r.DeviceId == deviceId)
                .Where(r => r.ReceivedOn > DateTimeOffset.UtcNow.AddDays(-3))
                .ToListAsync();
                                
            return Ok(readings);
        }
    }
}
