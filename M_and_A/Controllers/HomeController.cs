using M_and_A.Data;
using Microsoft.AspNetCore.Mvc;
using System.IO;

public class HomeController : Controller
{
    private readonly ShoppingContext _context;

    public HomeController(ShoppingContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
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
}