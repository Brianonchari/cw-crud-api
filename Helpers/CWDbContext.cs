using Microsoft.EntityFrameworkCore;
using System;

namespace cw.Helpers
{
    public class CWDbContext:DbContext
    {
        public CWDbContext(DbContextOptions<CWDbContext> options):base(options)
        {


        }

   
        public DbSet<User> users { get; set; }
    }
}
