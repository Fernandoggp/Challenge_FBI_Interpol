using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet.Repository.Context
{
    public class DataBaseContext : DbContext
    { 
        public DbSet<WantedModel> Wanted { get; set; }

        public DbSet<InterpolModel> Interpol { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

    }
}
