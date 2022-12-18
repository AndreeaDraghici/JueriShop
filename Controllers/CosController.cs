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
    public class CosController : Controller
    {
        private readonly DatabaseContext _context;

        public CosController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Cos
        public async Task<IActionResult> Index()
        {
              return View(await _context.CosFinal.ToListAsync());
        }


        // GET: Cos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CosFinal == null)
            {
                return NotFound();
            }

            var cos = await _context.CosFinal
                .FirstOrDefaultAsync(m => m.idCos == id);
            if (cos == null)
            {
                return NotFound();
            }

            return View(cos);
        }

        // GET: Cos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCos")] Cos cos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cos);
        }

        // GET: Cos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CosFinal == null)
            {
                return NotFound();
            }

            var cos = await _context.CosFinal.FindAsync(id);
            if (cos == null)
            {
                return NotFound();
            }
            return View(cos);
        }

        // POST: Cos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCos")] Cos cos)
        {
            if (id != cos.idCos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosExists(cos.idCos))
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
            return View(cos);
        }

        // GET: Cos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CosFinal == null)
            {
                return NotFound();
            }

            var cos = await _context.CosFinal
                .FirstOrDefaultAsync(m => m.idCos == id);
            if (cos == null)
            {
                return NotFound();
            }

            return View(cos);
        }

        // POST: Cos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CosFinal == null)
            {
                return Problem("Entity set 'DatabaseContext.CosFinal'  is null.");
            }
            var cos = await _context.CosFinal.FindAsync(id);
            if (cos != null)
            {
                _context.CosFinal.Remove(cos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CosExists(int id)
        {
          return _context.CosFinal.Any(e => e.idCos == id);
        }
    }
}
