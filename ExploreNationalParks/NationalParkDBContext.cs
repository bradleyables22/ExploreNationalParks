using Microsoft.EntityFrameworkCore;

namespace ExploreNationalParks
{
    public class NationalParkDBContext : DbContext 
    {
        DbSet<NationalPark> nationalParks { get; set; }
        public NationalParkDBContext(DbContextOptions<NationalParkDBContext> options) : base(options) { }
    }
}
