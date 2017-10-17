using System;

namespace ClimateMeter.Web.DAL
{
    public class SensorReading
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public DateTimeOffset ReceivedOn { get; set; }
    }
}
