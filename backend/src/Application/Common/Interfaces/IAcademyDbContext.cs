using System.Threading;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IAcademyDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
