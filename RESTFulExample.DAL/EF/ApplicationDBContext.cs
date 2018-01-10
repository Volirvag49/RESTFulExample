using Microsoft.EntityFrameworkCore;
using RESTFulExample.DAL.Entities;


namespace RESTFulExample.DAL.EF
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
                : base(options)
        {
        }

        public DbSet<Air> Airs { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
