using EfCoreGenericServicesAndSerilogBootstrapRepo.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreGenericServicesAndSerilogBootstrapRepo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }
    }
}
