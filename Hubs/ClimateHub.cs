using System;
using System.Linq;
using System.Threading.Tasks;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClimateMeter.Web.Hubs
{
    [Authorize]
    public class ClimateHub: Hub
    {
        private readonly ClimateMeterContext _db;
        private readonly ILogger<ClimateHub> _log;

        public ClimateHub(ClimateMeterContext db, ILogger<ClimateHub> log)
        {
            _db = db;
            _log = log;
        }
        
        public async Task RegisterDevice(string name, string description)
        {
            _log.LogInformation($"Registration requested: name - {name}, description - {description}");
            
            var device = await _db.Devices.Where(d => d.Name == name).FirstOrDefaultAsync();

            Guid deviceId;

            if (device == null)
            {
                _log.LogInformation($"Device named {name} is not found, creating new entry");
                
                var newDevice = new Device()
                {
                    Name = name,
                    Description = description
                };
                
                await _db.Devices.AddAsync(newDevice);
                await _db.SaveChangesAsync();

                deviceId = newDevice.DeviceId;
            }
            else
            {
                deviceId = device.DeviceId;
            }
            
            await Clients.Client(Context.ConnectionId).InvokeAsync("DeviceRegistered", deviceId);
            
            _log.LogInformation($"Registration completed, device's id: {deviceId}, name: {name}");
        }

        public void AddSensorReading(Guid id, decimal temperature, decimal humidity)
        {
            Console.WriteLine($"Data received from {id}, temp = {temperature}, humidity = {humidity}");
        }
    }
}
