using ClimateCodex.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClimateCodex.Server.Data
{
    public class ClimateCodexDbContext : DbContext
    {

        public DbSet<EmissionData> EmissionDatas { get; set; }
        public DbSet<GHGType> GHGTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ClimateData> ClimateData { get; set; }
        public DbSet<User> Users { get; set; }

        public ClimateCodexDbContext(DbContextOptions<ClimateCodexDbContext> options)
           : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-4433O6QKABI\\SQLEXPRESS01;Database=ClimateCodex;integrated security=true;trustservercertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

    }

    
}
