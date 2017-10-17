using System;
using System.Collections.Generic;

namespace ClimateMeter.Web.DAL
{
    public class Device
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SensorReading> SensorReadings { get; set; }
    }
}
