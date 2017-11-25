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
        public IActionResult List()
        {
            var devices = _db.Devices.ToList();
            return Ok(devices);
        }

        [HttpGet("{deviceId}/sensorreadings")]
        public IActionResult SensorReadings(Guid deviceId)
        {
            var readings = _db.SensorReadings
                .Where(r => r.DeviceId == deviceId)
                .Where(r => r.ReceivedOn > DateTimeOffset.UtcNow.AddDays(-3))
                .OrderByDescending(r => r.ReceivedOn)
                .ToList();

            return Ok(readings);
        }
    }
}
