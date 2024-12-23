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
    public class PurchaseDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseDetail.Include(p => p.Product).Include(p => p.Purchase);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetail
                .Include(p => p.Product)
                .Include(p => p.Purchase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode");
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "Id");
            return View();
        }

        // POST: PurchaseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseDetail purchaseDetail)
        {
            if (ModelState.IsValid)
            {
                purchaseDetail.Total = purchaseDetail.Quantity * purchaseDetail.UnitPrice;
                _context.Add(purchaseDetail);
                await _context.SaveChangesAsync();

                int stockQuantity = _context.Stock.Where(x => x.ProductId == purchaseDetail.ProductId).Select(u => u.Quantity).First();
                int quantity = stockQuantity + purchaseDetail.Quantity;
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "UPDATE Stock SET Quantity=" + quantity + "WHERE ProductId=" + purchaseDetail.ProductId;
                    _context.Database.OpenConnection();
                    using (var result = command.ExecuteReader()) { }

                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", purchaseDetail.ProductId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "Id", purchaseDetail.PurchaseId);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetail.FindAsync(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", purchaseDetail.ProductId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "Id", purchaseDetail.PurchaseId);
            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,PurchaseId,Quantity,UnitPrice,Total")] PurchaseDetail purchaseDetail)
        {
            if (id != purchaseDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseDetailExists(purchaseDetail.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", purchaseDetail.ProductId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "Id", purchaseDetail.PurchaseId);
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetail
                .Include(p => p.Product)
                .Include(p => p.Purchase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseDetail = await _context.PurchaseDetail.FindAsync(id);
            _context.PurchaseDetail.Remove(purchaseDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseDetailExists(int id)
        {
            return _context.PurchaseDetail.Any(e => e.Id == id);
        }
    }
}
