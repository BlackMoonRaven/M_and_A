using M_and_A.Data;
using M_and_A.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace M_and_A
{
    public static class SampleData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            SeedProducts(modelBuilder);
        }

        private static void SeedProducts(ModelBuilder modelBuilder)
        {
            var products = new[]
            {
                new Product
                {
                    Id = 1,
                    Name = "Trousers",
                    Type = Product.Category.Underwear,
                    Price = 300.0F,
                    ImageName = "trouses.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Jeans",
                    Type = Product.Category.Pants,
                    Price = 950.0F,
                    ImageName = "jeans.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Top",
                    Type = Product.Category.TShirt,
                    Price = 500.0F,
                    ImageName = "top.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Long Dress",
                    Type = Product.Category.Dress,
                    Price = 800.0F,
                    ImageName = "dress.PNG"
                }
            };

            foreach (var product in products)
            {
                // Перевірка, чи існує файл зображення у папці "wwwroot/img"
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", product.ImageName);
                if (!File.Exists(imagePath))
                {
                    // Якщо файл не існує, тоді копіюємо його з початкової папки із зображеннями
                    var sourceImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/original_images", product.ImageName);
                    File.Copy(sourceImagePath, imagePath);
                }

                // Додавання продукту до БД
                modelBuilder.Entity<Product>().HasData(product);
            }
        }
    }
}
