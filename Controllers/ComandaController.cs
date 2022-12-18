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
    public class ComandaController : Controller
    {
        private readonly DatabaseContext _context;

        public ComandaController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Comanda
        public async Task<IActionResult> Index()
        {
              return View(await _context.ComandaFinala.ToListAsync());
        }

        // GET: Comanda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ComandaFinala == null)
            {
                return NotFound();
            }

            var comanda = await _context.ComandaFinala
                .FirstOrDefaultAsync(m => m.idComanda == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comanda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comanda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idComanda,statusComanda")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comanda);
        }

        // GET: Comanda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ComandaFinala == null)
            {
                return NotFound();
            }

            var comanda = await _context.ComandaFinala.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }
            return View(comanda);
        }

        // POST: Comanda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idComanda,statusComanda")] Comanda comanda)
        {
            if (id != comanda.idComanda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.idComanda))
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
            return View(comanda);
        }

        // GET: Comanda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ComandaFinala == null)
            {
                return NotFound();
            }

            var comanda = await _context.ComandaFinala
                .FirstOrDefaultAsync(m => m.idComanda == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ComandaFinala == null)
            {
                return Problem("Entity set 'DatabaseContext.ComandaFinala'  is null.");
            }
            var comanda = await _context.ComandaFinala.FindAsync(id);
            if (comanda != null)
            {
                _context.ComandaFinala.Remove(comanda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(int id)
        {
          return _context.ComandaFinala.Any(e => e.idComanda == id);
        }
    }
}
