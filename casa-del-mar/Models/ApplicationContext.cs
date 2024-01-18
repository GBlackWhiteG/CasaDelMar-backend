using Microsoft.EntityFrameworkCore;

namespace casa_del_mar.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
