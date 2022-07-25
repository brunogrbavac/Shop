using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Context
{
    public class AcademyDbContext : DbContext, IAcademyDbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "unknown";
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "unknown";
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "unknown";
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
