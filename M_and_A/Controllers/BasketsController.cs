using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M_and_A.Data;
using M_and_A.Models;

namespace M_and_A.Controllers
{
    //public class BasketsController : Controller
    //{
    //    private readonly ShoppingContext _context;

    //    public BasketsController(ShoppingContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Baskets
    //    public async Task<IActionResult> Index()
    //    {
    //        var favoriteProductIds = _context.Products
    //            .Where(p => p.IsFavourite)
    //            .Select(p => p.Id)
    //            .ToList();

    //        ViewBag.FavoriteProductIds = favoriteProductIds;

    //        return View(await _context.Baskets.ToListAsync());
    //    }

    //    // GET: Baskets/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null || _context.Baskets == null)
    //        {
    //            return NotFound();
    //        }

    //        var basket = await _context.Baskets
    //            .Include(b => b.Product) // Завантажуємо інформацію про продукт, пов'язаний з кошиком
    //            .FirstOrDefaultAsync(m => m.Id == id);

    //        if (basket == null)
    //        {
    //            return NotFound();
    //        }

    //        // Виводимо улюблений продукт
    //        if (basket.Product != null && basket.Product.IsFavourite)
    //        {
    //            // Тут можна вивести необхідні вам властивості продукту, наприклад, його ім'я та ціну
    //            // Замість Console.WriteLine() використовуйте Viewbag або передайте дані у View
    //            Console.WriteLine($"Улюблений продукт: {basket.Product.Name}, Ціна: {basket.Product.Price}");
    //        }
    //        else
    //        {
    //            // Якщо улюблений продукт не знайдено
    //            Console.WriteLine("Улюблений продукт не знайдено.");
    //        }

    //        return View(basket); // Передаємо об'єкт M_and_A.Models.Basket у View для виведення деталей окремої корзини
    //    }

    //    // GET: Baskets/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Baskets/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,UserId")] Basket basket)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(basket);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(basket);
    //    }

    //    // GET: Baskets/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null || _context.Baskets == null)
    //        {
    //            return NotFound();
    //        }

    //        var basket = await _context.Baskets.FindAsync(id);
    //        if (basket == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(basket);
    //    }

    //    // POST: Baskets/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId")] Basket basket)
    //    {
    //        if (id != basket.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(basket);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!BasketExists(basket.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(basket);
    //    }

    //    // GET: Baskets/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null || _context.Baskets == null)
    //        {
    //            return NotFound();
    //        }

    //        var basket = await _context.Baskets
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (basket == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(basket);
    //    }

    //    // POST: Baskets/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        if (_context.Baskets == null)
    //        {
    //            return Problem("Entity set 'ShoppingContext.Baskets'  is null.");
    //        }
    //        var basket = await _context.Baskets.FindAsync(id);
    //        if (basket != null)
    //        {
    //            _context.Baskets.Remove(basket);
    //        }

    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool BasketExists(int id)
    //    {
    //      return (_context.Baskets?.Any(e => e.Id == id)).GetValueOrDefault();
    //    }
    //    // GET: Baskets/AddToFavorite/5?productId=1
    //    //public async Task<IActionResult> AddToFavorite(int? id, int? productId)
    //    //{
    //    //    if (id == null || productId == null || _context.Baskets == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    var basket = await _context.Baskets
    //    //        .Include(b => b.FavoriteItems) // Load the favorite items (products)
    //    //        .FirstOrDefaultAsync(m => m.Id == id);

    //    //    if (basket == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    var product = await _context.Products.FindAsync(productId);
    //    //    if (product != null)
    //    //    {
    //    //        // Associate the product with the basket
    //    //        var newBasketItem = new Basket
    //    //        {
    //    //            UserId = basket.UserId,
    //    //            ProductId = product.Id, // Set the ProductId
    //    //            Product = product // Set the Product navigation property
    //    //        };

    //    //        _context.Baskets.Add(newBasketItem);
    //    //        await _context.SaveChangesAsync();
    //    //    }

    //    //    return RedirectToAction("Details", new { id });
    //    //}

    //    //// GET: Baskets/RemoveFromFavorite/5?productId=1
    //    //public async Task<IActionResult> RemoveFromFavorite(int? id, int? productId)
    //    //{
    //    //    if (id == null || productId == null || _context.Baskets == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    var basket = await _context.Baskets
    //    //        .Include(b => b.FavoriteItems) // Load the favorite items (products)
    //    //        .FirstOrDefaultAsync(m => m.Id == id);

    //    //    if (basket == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    var product = await _context.Products.FindAsync(productId);
    //    //    if (product != null)
    //    //    {
    //    //        // Remove the product from the favorite items (products)
    //    //        basket.FavoriteItems.Remove(product);
    //    //        await _context.SaveChangesAsync();
    //    //    }

    //    //    return RedirectToAction("Details", new { id });
    //    //}

    //}
    public class BasketsController : Controller
    {
        private readonly ShoppingContext _context;

        public BasketsController(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var favoriteProducts = await _context.Products
                .Where(p => p.IsFavourite)
                .ToListAsync();

            return View(favoriteProducts);
        }
    }

}
