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
    public class CategorieController : Controller
    {
        private readonly DatabaseContext _context;

        public CategorieController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Categorie
        public async Task<IActionResult> Index()
        {
              return View(await _context.CategorieFinala.ToListAsync());
        }

        // GET: Categorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategorieFinala == null)
            {
                return NotFound();
            }

            var categorie = await _context.CategorieFinala
                .FirstOrDefaultAsync(m => m.idCategorie == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categorie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCategorie,denumire")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategorieFinala == null)
            {
                return NotFound();
            }

            var categorie = await _context.CategorieFinala.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCategorie,denumire")] Categorie categorie)
        {
            if (id != categorie.idCategorie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.idCategorie))
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
            return View(categorie);
        }

        // GET: Categorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategorieFinala == null)
            {
                return NotFound();
            }

            var categorie = await _context.CategorieFinala
                .FirstOrDefaultAsync(m => m.idCategorie == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategorieFinala == null)
            {
                return Problem("Entity set 'DatabaseContext.CategorieFinala'  is null.");
            }
            var categorie = await _context.CategorieFinala.FindAsync(id);
            if (categorie != null)
            {
                _context.CategorieFinala.Remove(categorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
          return _context.CategorieFinala.Any(e => e.idCategorie == id);
        }
    }
}
