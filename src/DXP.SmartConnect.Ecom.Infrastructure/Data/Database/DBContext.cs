using DXP.SmartConnect.Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DXP.SmartConnect.Ecom.Infrastructure.Data.Database
{
    /// <summary>
    /// How to disable log for the Context: https://entityframeworkcore.com/knowledge-base/55715877/how-to-disable-log-for-the-context
    /// </summary>
    public class DBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public virtual DbSet<RsProduct> RsProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
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
