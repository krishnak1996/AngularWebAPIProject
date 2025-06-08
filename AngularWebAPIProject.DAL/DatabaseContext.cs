using Microsoft.EntityFrameworkCore;

namespace AngularWebAPIProject.DAL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<RecordOpening> RecordOpening { get; set; }
        public DbSet<Buyers> Buyers { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; } 
    }
}
