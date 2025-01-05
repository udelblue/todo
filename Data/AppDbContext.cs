using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todos> Todos { get; set; }
    }
}
