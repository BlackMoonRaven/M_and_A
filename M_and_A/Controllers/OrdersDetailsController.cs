using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M_and_A.Data;
using M_and_A.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace M_and_A.Controllers
{
    public class OrdersDetailsController : Controller
    {
        private readonly ShoppingContext _context;

        public OrdersDetailsController(ShoppingContext context)
        {
            _context = context;
        }

        // GET: OrdersDetails
        [Authorize(Roles = "admin, buyer")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.OrderDetails.ToListAsync());
        }

        // GET: OrdersDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var ordersDetails = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersDetails == null)
            {
                return NotFound();
            }

            return View(ordersDetails);
        }

        // GET: OrdersDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdersDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total,OrderDate")] OrderDetail ordersDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersDetails);
        }

        // GET: OrdersDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var ordersDetails = await _context.OrderDetails.FindAsync(id);
            if (ordersDetails == null)
            {
                return NotFound();
            }
            return View(ordersDetails);
        }

        // POST: OrdersDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total,OrderDate")] OrderDetail ordersDetails)
        {
            if (id != ordersDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersDetailsExists(ordersDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ordersDetails);
        }

        // GET: OrdersDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var ordersDetails = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersDetails == null)
            {
                return NotFound();
            }

            return View(ordersDetails);
        }

        // POST: OrdersDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderDetails == null)
            {
                return Problem("Entity set 'ShoppingContext.OrderDetails'  is null.");
            }
            var ordersDetails = await _context.OrderDetails.FindAsync(id);
            if (ordersDetails != null)
            {
                _context.OrderDetails.Remove(ordersDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersDetailsExists(int id)
        {
          return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
