using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment
{
    internal class AssetTrackingDBContext : DbContext
    {
        // DbContext is building class
        string connectionString = "Data Source=DESKTOP-FMM8SET\\MSSQLSERVER01;Initial Catalog=AssetTracking_DB;Integrated Security=True;TrustServerCertificate=True";

        public DbSet<AssetTrack_ItemInfo> Assets { get; set; } //For creating Users table in DB

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Warning);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
        }
    }
}
