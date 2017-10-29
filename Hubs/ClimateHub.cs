using System;
using System.Threading.Tasks;
using ClimateMeter.Web.DAL;
using Microsoft.AspNetCore.SignalR;

namespace ClimateMeter.Web.Hubs
{
    public class ClimateHub: Hub
    {
        private readonly ClimateMeterContext _db;

        public ClimateHub(ClimateMeterContext db)
        {
            _db = db;
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