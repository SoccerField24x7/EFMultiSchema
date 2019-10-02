using webtest.dbcontext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace webtest.dbcontext
{
    public class CrmContext : DbContext
    {
        public string SchemaName { get; set; }

        public CrmContext(DbContextOptions<CrmContext> options) : base(options)
        {
        }

        public CrmContext(string schemaname) : base()
        {
            SchemaName = schemaname;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var serviceProvider = new ServiceCollection().AddEntityFrameworkSqlServer()
                .AddSingleton<IModelCustomizer, SchemaContextCustomize>()
                .BuildServiceProvider();

            optionsBuilder.UseSqlServer(Startup.Configuration.GetConnectionString("DbService")).UseInternalServiceProvider(serviceProvider);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            if (!string.IsNullOrEmpty(SchemaName))
            {
                modelBuilder.HasDefaultSchema(SchemaName);
            }

            base.OnModelCreating(modelBuilder);
        }

        public class SchemaContextCustomize : ModelCustomizer
        {
            public SchemaContextCustomize(ModelCustomizerDependencies dependencies)
                : base(dependencies)
            {

            }
            public override void Customize(ModelBuilder modelBuilder, DbContext dbContext)
            {
                base.Customize(modelBuilder, dbContext);

                string schemaName = (dbContext as CrmContext).SchemaName;
                (dbContext as CrmContext).SchemaName = schemaName;

            }
        }

        /* add your table models here */
        public DbSet<Name> Name { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
    }
}
