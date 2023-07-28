using M_and_A.Data;
using M_and_A.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly ShoppingContext _context;

    public HomeController(ShoppingContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string sortOrder, string searchString)
    {
        ViewData["LNameSort"] = string.IsNullOrEmpty(sortOrder) ? "lastname_list" : "";
        ViewData["AddrSort"] = sortOrder == "address" ? "address_list" : "address";
        ViewData["Filter"] = searchString;

        var products = _context.Products.Select(p => p);

        if (!string.IsNullOrEmpty(searchString))
        {
            products = products.Where(p => p.Name.Contains(searchString));
        }
        products = sortOrder switch
        {
            "lastname_list" => products.OrderByDescending(p => p.Name),
            _ => products.OrderBy(p => p.Name),
        };

        var favoriteProducts = GetFavoriteProducts();

        ViewBag.FavoriteProducts = favoriteProducts;

        return View(await products.AsNoTracking().ToListAsync());
    }

    public IActionResult GetImage(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            var imagePath = Path.Combine("~/img", product.ImageName); // Замініть "YourImagePath" на шлях до папки зображень у вашому проекті
            return File(imagePath, "image/jpg"); // Замініть "image/jpeg" на відповідний тип MIME для вашого формату зображення
        }
        else
        {
            return NotFound();
        }
    }

    private List<int> GetFavoriteProducts()
    {
        var favoriteProductIds = _context.Products
            .Where(p => p.IsFavourite)
            .Select(p => p.Id)
            .ToList();

        return favoriteProductIds;
    }
    [HttpPost]
    public IActionResult UpdateFavouriteStatus(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            product.IsFavourite = !product.IsFavourite; // Змінюємо статус улюбленого
            _context.SaveChanges(); // Зберігаємо зміни у базі даних
            return Ok(); // Повертаємо статус 200 OK, щоб підтвердити успішне оновлення
        }
        else
        {
            return NotFound(); // Якщо продукт з таким ідентифікатором не знайдено, повертаємо статус 404 Not Found
        }
    }
}
