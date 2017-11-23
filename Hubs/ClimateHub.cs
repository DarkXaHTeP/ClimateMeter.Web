using System;
using System.Threading.Tasks;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
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
            Console.WriteLine($"registration requested: name - {name}, description - {description}");
            await Clients.Client(Context.ConnectionId).InvokeAsync("DeviceRegistered", Guid.NewGuid());
        }

        public void AddSensorReading(Guid id, decimal temperature, decimal humidity)
        {
            Console.WriteLine($"Data received from {id}, temp = {temperature}, humidity = {humidity}");
        }
    }
}
