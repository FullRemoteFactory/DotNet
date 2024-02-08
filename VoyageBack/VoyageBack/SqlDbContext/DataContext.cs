using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoyageBack.Models;

namespace VoyageBack.SqlDbContext
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

      
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Transport> Transports { get; set; }

    }
}
