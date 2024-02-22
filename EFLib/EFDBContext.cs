using Microsoft.EntityFrameworkCore;

namespace EFLib
{
    public class EFDBContext : DbContext, IEFDBContext
    {
        public DbSet<LogEntry> LogEntries { get; set; }

        public EFDBContext()
        {
        }

        public EFDBContext(DbContextOptions<EFDBContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        void IEFDBContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
