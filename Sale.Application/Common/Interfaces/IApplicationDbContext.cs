using Microsoft.EntityFrameworkCore;
using Sale.Domain.Entity;

namespace Sale.Application.Common.Interfaces
{
    public interface IApplicationDbContext: IDisposable
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
