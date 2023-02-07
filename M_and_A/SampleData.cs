using M_and_A.Data;
using M_and_A.Models;
using Microsoft.EntityFrameworkCore;

namespace M_and_A
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShoppingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ShoppingContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                    new Products
                    {
                        Name = "Thong",
                        Category = "Underwear",
                        Price = 300.0F

                    },

                    new Products
                    {
                        Name = "Jeans",
                        Category = "Pants",
                        Price = 950
                    },

                    new Products
                    {
                        Name = "Top",
                        Category = "T-shirt",
                        Price = 500
                    },

                    new Products
                    {
                        Name = "Long Dress",
                        Category = "Dress",
                        Price = 800
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
