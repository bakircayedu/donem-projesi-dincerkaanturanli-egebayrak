using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameMarktDBF2.DAL.Models;

namespace GameMarktDBFF.MVC.Views
{
    public class StoksController : Controller
    {
        private readonly GameMarktContext _context;

        public StoksController(GameMarktContext context)
        {
            _context = context;
        }

        // GET: Stoks
        public async Task<IActionResult> Index()
        {
            var gameMarktContext = _context.Stok.Include(s => s.Urun);
            return View(await gameMarktContext.ToListAsync());
        }

        // GET: Stoks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stok
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stok == null)
            {
                return NotFound();
            }

            return View(stok);
        }

        // GET: Stoks/Create
        public IActionResult Create()
        {
            ViewData["UrunId"] = new SelectList(_context.Urun, "UrunId", "UrunId");
            return View();
        }

        // POST: Stoks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunId,Miktar")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stok);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UrunId"] = new SelectList(_context.Urun, "UrunId", "UrunId", stok.UrunId);
            return View(stok);
        }

        // GET: Stoks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stok.FindAsync(id);
            if (stok == null)
            {
                return NotFound();
            }
            ViewData["UrunId"] = new SelectList(_context.Urun, "UrunId", "UrunId", stok.UrunId);
            return View(stok);
        }

        // POST: Stoks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunId,Miktar")] Stok stok)
        {
            if (id != stok.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stok);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StokExists(stok.Id))
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
            ViewData["UrunId"] = new SelectList(_context.Urun, "UrunId", "UrunId", stok.UrunId);
            return View(stok);
        }

        // GET: Stoks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stok
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stok == null)
            {
                return NotFound();
            }

            return View(stok);
        }

        // POST: Stoks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stok = await _context.Stok.FindAsync(id);
            _context.Stok.Remove(stok);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StokExists(int id)
        {
            return _context.Stok.Any(e => e.Id == id);
        }
    }
}
