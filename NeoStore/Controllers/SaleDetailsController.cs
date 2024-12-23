using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NeoStore.Data;
using NeoStore.Models;

namespace NeoStore.Controllers
{
    public class SaleDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SaleDetail.Include(s => s.Product).Include(s => s.Sale);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SaleDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetail
                .Include(s => s.Product)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // GET: SaleDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode");
            ViewData["SaleId"] = new SelectList(_context.Sale, "Id", "Id");
            return View();
        }

        // POST: SaleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaleDetail saleDetail)
        {
            if (ModelState.IsValid)
            {
                saleDetail.Total = saleDetail.Quantity * saleDetail.Price;
                _context.Add(saleDetail);
                await _context.SaveChangesAsync();

                int stockQuantity = _context.Stock.Where(x => x.ProductId == saleDetail.ProductId).Select(u => u.Quantity).First();
                int quantity = stockQuantity - saleDetail.Quantity;
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "UPDATE Stock SET Quantity=" + quantity + "WHERE ProductId=" + saleDetail.ProductId;
                    _context.Database.OpenConnection();
                    using (var result = command.ExecuteReader()) { }

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", saleDetail.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "Id", "Id", saleDetail.SaleId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetail.FindAsync(id);
            if (saleDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", saleDetail.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "Id", "Id", saleDetail.SaleId);
            return View(saleDetail);
        }

        // POST: SaleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SaleId,ProductId,Quantity,Price,Total")] SaleDetail saleDetail)
        {
            if (id != saleDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleDetailExists(saleDetail.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", saleDetail.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "Id", "Id", saleDetail.SaleId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetail
                .Include(s => s.Product)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // POST: SaleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleDetail = await _context.SaleDetail.FindAsync(id);
            _context.SaleDetail.Remove(saleDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleDetailExists(int id)
        {
            return _context.SaleDetail.Any(e => e.Id == id);
        }
    }
}
