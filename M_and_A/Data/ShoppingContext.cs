using Microsoft.EntityFrameworkCore;
using M_and_A.Models;

namespace M_and_A.Data
{
    public class ShoppingContext : DbContext
    {

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
