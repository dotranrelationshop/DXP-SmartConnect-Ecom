using DXP.SmartConnect.Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.Database
{
    public class TestContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public virtual DbSet<RsProduct> RsProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectString = "Data Source=dev-sql1.gothink.local;Initial Catalog=SandboxProduct;persist security info=True;user id=dev-sqlaccess;password=Sysnify5355;";
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectString).EnableSensitiveDataLogging().UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RsProduct>(entity =>
            {
                entity.ToTable("RS_Product");

                entity.Property(e => e.Name).HasMaxLength(500);
            });
        }
    }
}
