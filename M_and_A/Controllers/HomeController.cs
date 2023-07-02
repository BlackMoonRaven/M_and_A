using M_and_A.Data;
using M_and_A.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

public class HomeController : Controller
{
    private readonly ShoppingContext _context;

    public HomeController(ShoppingContext context)
    {
        _context = context;
    }

    //public IActionResult Index()
    //{
    //    var products = _context.Products.ToList();
    //    return View(products);
    //}
    public async Task<IActionResult> Index(string sortOrder, string searchString)
    {
        ViewData["LNameSort"] = string.IsNullOrEmpty(sortOrder) ? "lastname_list" : "";
        ViewData["AddrSort"] = sortOrder == "address" ? "address_list" : "address";
        ViewData["Filter"] = searchString;

        var customers = _context.Products.Select(p => p);

        if (!String.IsNullOrEmpty(searchString))
        {
            customers = customers.Where(p => p.Name.Contains(searchString));
        }
        customers = sortOrder switch
        {
            "lastname_list" => customers.OrderByDescending(p => p.Name),
            _ => customers.OrderBy(p => p.Name),
        };

        return View(await customers.AsNoTracking().ToListAsync());
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