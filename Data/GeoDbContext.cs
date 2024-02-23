using GeoCRON.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoCRON.Data
{
    public class GeoDbContext : DbContext
    {
        public GeoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GeoInfo> GeoInfos { get; set; }
    }
}
