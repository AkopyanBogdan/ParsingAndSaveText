using System.Data.Entity;

namespace ParsingAndSaveTextInDb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FileInformation> FileInformation { get; set; }

        public ApplicationDbContext()
        {
        }
    }
}