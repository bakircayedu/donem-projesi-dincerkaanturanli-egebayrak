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
    public class MusterisController : Controller
    {
        private readonly GameMarktContext _context;

        public MusterisController(GameMarktContext context)
        {
            _context = context;
        }

        // GET: Musteris
        public async Task<IActionResult> Index()
        {
            var gameMarktContext = _context.Musteri.Include(m => m.Rol);
            return View(await gameMarktContext.ToListAsync());
        }

        // GET: Musteris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.Musteri
                .Include(m => m.Rol)
                .FirstOrDefaultAsync(m => m.MusteriId == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        // GET: Musteris/Create
        public IActionResult Create()
        {
            ViewData["RolId"] = new SelectList(_context.Rol, "RolId", "RolId");
            return View();
        }

        // POST: Musteris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusteriId,Adi,Soyadi,EmailId,RolId,Password")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolId"] = new SelectList(_context.Rol, "RolId", "RolId", musteri.RolId);
            return View(musteri);
        }

        // GET: Musteris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.Musteri.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            ViewData["RolId"] = new SelectList(_context.Rol, "RolId", "RolId", musteri.RolId);
            return View(musteri);
        }

        // POST: Musteris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusteriId,Adi,Soyadi,EmailId,RolId,Password")] Musteri musteri)
        {
            if (id != musteri.MusteriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusteriExists(musteri.MusteriId))
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
            ViewData["RolId"] = new SelectList(_context.Rol, "RolId", "RolId", musteri.RolId);
            return View(musteri);
        }

        // GET: Musteris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.Musteri
                .Include(m => m.Rol)
                .FirstOrDefaultAsync(m => m.MusteriId == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        // POST: Musteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musteri = await _context.Musteri.FindAsync(id);
            _context.Musteri.Remove(musteri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusteriExists(int id)
        {
            return _context.Musteri.Any(e => e.MusteriId == id);
        }
    }
}
