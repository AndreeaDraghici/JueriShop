using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JueriOnlineShop.Context;
using JueriOnlineShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JueriOnlineShop.Controllers
{
    [Authorize(Roles = "Admin,Client")]
    public class ProdusController : Controller
    {
        private readonly DatabaseContext _context;

        public ProdusController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Produs
        [Authorize(Roles = "Admin,Client")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProdusFinal.ToListAsync());
        }

        // GET: Produs/Details/5
        [Authorize(Roles = "Admin,Client")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProdusFinal == null)
            {
                return NotFound();
            }

            var produs = await _context.ProdusFinal
                .FirstOrDefaultAsync(m => m.idProdus == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // GET: Produs/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("idProdus,numeProdus,descriereProdus,pretProdus,photoURL")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produs);
        }

        // GET: Produs/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProdusFinal == null)
            {
                return NotFound();
            }

            var produs = await _context.ProdusFinal.FindAsync(id);
            if (produs == null)
            {
                return NotFound();
            }
            return View(produs);
        }

        // POST: Produs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("idProdus,numeProdus,descriereProdus,pretProdus,photoURL")] Produs produs)
        {
            if (id != produs.idProdus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdusExists(produs.idProdus))
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
            return View(produs);
        }

        // GET: Produs/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProdusFinal == null)
            {
                return NotFound();
            }

            var produs = await _context.ProdusFinal
                .FirstOrDefaultAsync(m => m.idProdus == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // POST: Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProdusFinal == null)
            {
                return Problem("Entity set 'DatabaseContext.ProdusFinal'  is null.");
            }
            var produs = await _context.ProdusFinal.FindAsync(id);
            if (produs != null)
            {
                _context.ProdusFinal.Remove(produs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdusExists(int id)
        {
          return _context.ProdusFinal.Any(e => e.idProdus == id);
        }
    }
}
