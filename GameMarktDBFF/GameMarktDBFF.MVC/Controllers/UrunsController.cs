﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameMarktDBF2.DAL.Models;

namespace GameMarktDBFF.MVC.Views
{
    public class UrunsController : Controller
    {
        private readonly GameMarktContext _context;

        public UrunsController(GameMarktContext context)
        {
            _context = context;
        }

        // GET: Uruns
        public async Task<IActionResult> Index()
        {
            var gameMarktContext = _context.Urun.Include(u => u.Kategori);
            return View(await gameMarktContext.ToListAsync());
        }

        // GET: Uruns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _context.Urun
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.UrunId == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // GET: Uruns/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "KategoriId", "KategoriId");
            return View();
        }

        // POST: Uruns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrunId,UrunAd,KategoriId,Miktar,Fiyat")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "KategoriId", "KategoriId", urun.KategoriId);
            return View(urun);
        }

        // GET: Uruns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _context.Urun.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "KategoriId", "KategoriId", urun.KategoriId);
            return View(urun);
        }

        // POST: Uruns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrunId,UrunAd,KategoriId,Miktar,Fiyat")] Urun urun)
        {
            if (id != urun.UrunId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunExists(urun.UrunId))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "KategoriId", "KategoriId", urun.KategoriId);
            return View(urun);


        }

        // GET: Uruns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _context.Urun
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.UrunId == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // POST: Uruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urun = await _context.Urun.FindAsync(id);
            _context.Urun.Remove(urun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunExists(int id)
        {
            return _context.Urun.Any(e => e.UrunId == id);
        }
    }
}
