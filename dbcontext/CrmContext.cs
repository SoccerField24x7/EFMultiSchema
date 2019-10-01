using webtest.dbcontext.Models;
using Microsoft.EntityFrameworkCore;

namespace webtest.dbcontext
{
    public class CrmContext : DbContext
    {
        public CrmContext(DbContextOptions<CrmContext> options) : base(options)
        {
        }

        public DbSet<Name> Names { get; set; }
    }
}
