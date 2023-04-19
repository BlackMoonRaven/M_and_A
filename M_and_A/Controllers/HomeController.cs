using M_and_A.Data;
using Microsoft.AspNetCore.Mvc;

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
            return File(product.ImagePath, product.ImageMimeType);
        }
        else
        {
            return null;
        }
    }
}