using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JueriOnlineShop.Context;
using JueriOnlineShop.Models;

namespace JueriOnlineShop.Controllers
{
    public class CantitateController : Controller
    {
        private readonly DatabaseContext _context;

        public CantitateController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Cantitate
        public async Task<IActionResult> Index()
        {
              return View(await _context.CantitateFinala.ToListAsync());
        }

        // GET: Cantitate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CantitateFinala == null)
            {
                return NotFound();
            }

            var cantitate = await _context.CantitateFinala
                .FirstOrDefaultAsync(m => m.idCantitate == id);
            if (cantitate == null)
            {
                return NotFound();
            }

            return View(cantitate);
        }

        // GET: Cantitate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cantitate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCantitate,cantitatateTotala")] Cantitate cantitate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cantitate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cantitate);
        }

        // GET: Cantitate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CantitateFinala == null)
            {
                return NotFound();
            }

            var cantitate = await _context.CantitateFinala.FindAsync(id);
            if (cantitate == null)
            {
                return NotFound();
            }
            return View(cantitate);
        }

        // POST: Cantitate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCantitate,cantitatateTotala")] Cantitate cantitate)
        {
            if (id != cantitate.idCantitate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cantitate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CantitateExists(cantitate.idCantitate))
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
            return View(cantitate);
        }

        // GET: Cantitate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CantitateFinala == null)
            {
                return NotFound();
            }

            var cantitate = await _context.CantitateFinala
                .FirstOrDefaultAsync(m => m.idCantitate == id);
            if (cantitate == null)
            {
                return NotFound();
            }

            return View(cantitate);
        }

        // POST: Cantitate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CantitateFinala == null)
            {
                return Problem("Entity set 'DatabaseContext.CantitateFinala'  is null.");
            }
            var cantitate = await _context.CantitateFinala.FindAsync(id);
            if (cantitate != null)
            {
                _context.CantitateFinala.Remove(cantitate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CantitateExists(int id)
        {
          return _context.CantitateFinala.Any(e => e.idCantitate == id);
        }
    }
}
