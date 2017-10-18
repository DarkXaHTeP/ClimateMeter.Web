using Microsoft.EntityFrameworkCore;

namespace ClimateMeter.Web.DAL
{
    public class ClimateMeterContext: DbContext
    {
        public ClimateMeterContext(DbContextOptions<ClimateMeterContext> options): base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var deviceBuilder = modelBuilder.Entity<Device>();
            deviceBuilder.HasKey(d => d.Id);
            deviceBuilder.HasAlternateKey(d => d.Name);
            deviceBuilder.Property(d => d.DeviceId).ValueGeneratedOnAdd();
            deviceBuilder.Property(d => d.Name).IsRequired().HasMaxLength(260);
            deviceBuilder.Property(d => d.Description).IsRequired();

            var sensorReadingBuilder = modelBuilder.Entity<SensorReading>();
            sensorReadingBuilder.HasKey(r => r.Id);
            sensorReadingBuilder
                .HasOne(r => r.Device)
                .WithMany(d => d.SensorReadings)
                .HasForeignKey(r => r.DeviceId)
                .HasPrincipalKey(d => d.DeviceId);
        }
    }
}
