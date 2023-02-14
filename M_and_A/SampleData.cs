using M_and_A.Data;
using M_and_A.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace M_and_A
{
    public static class SampleData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Thong",
                    Category = "Underwear",
                    Price = 300.0F

                },
                
                new Product
                {
                    Id = 2,
                    Name = "Jeans",
                    Category = "Pants",
                    Price = 950.0F
                },

                new Product
                {
                    Id = 3,
                    Name = "Top",
                    Category = "T-shirt",
                    Price = 500.0F
                },

                new Product
                {
                    Id = 4,
                    Name = "Long Dress",
                    Category = "Dress",
                    Price = 800.0F
                }
            );
        }
    }
}
