using Microsoft.EntityFrameworkCore;

namespace EFLib
{
    public interface IEFDBContext
    {
        DbSet<LogEntry> LogEntries { get; set; }
        void SaveChanges();
    }
}