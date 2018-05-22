using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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