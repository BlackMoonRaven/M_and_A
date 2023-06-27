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
                    Name = "Trousers",
                    Type = Product.Category.Underwear,
                    Price = 300.0F,
                    ImageName = SaveImageAndGetFileName("wwwroot/img/trouses.jpg")
                },
                new Product
                {
                    Id = 2,
                    Name = "Jeans",
                    Type = Product.Category.Pants,
                    Price = 950.0F,
                    ImageName = SaveImageAndGetFileName("wwwroot/img/jeans.jpg")              
                },

                new Product
                {
                    Id = 3,
                    Name = "Top",
                    Type = Product.Category.TShirt,
                    Price = 500.0F,
                    ImageName = SaveImageAndGetFileName("wwwroot/img/top.jpg")
                },

                new Product
                {
                    Id = 4,
                    Name = "Long Dress",
                    Type = Product.Category.Dress,
                    Price = 800.0F,
                    ImageName = SaveImageAndGetFileName("wwwroot/img/dress.PNG")
                }
            );
        }

        private static string SaveImageAndGetFileName(string imagePath)
        {
            // Отримання фізичного шляху до папки "wwwroot"
            var webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            // Збереження зображення у папку "wwwroot/img"
            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
            var destinationPath = Path.Combine(webRootPath, "img", imageName);
            File.Copy(imagePath, destinationPath);

            return imageName;
        }



    }
}
