using Case.Entity;
using Microsoft.EntityFrameworkCore;

namespace Case.DatabaseContext
{
    public class Context : DbContext
    {
        public Context()
        { }
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Demand> Demand { get; set; }
    }
}
