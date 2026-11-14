using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HaliSahaPortali.Data;
using HaliSahaPortali.Models;
using Microsoft.AspNetCore.Authorization;

namespace HaliSahaPortali.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SahalarController : Controller
    {
        private readonly AppDbContext _context;

        public SahalarController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sahalar
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Sahalar.Include(s => s.Tesis);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Sahalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saha = await _context.Sahalar
                .Include(s => s.Tesis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saha == null)
            {
                return NotFound();
            }

            return View(saha);
        }

        // GET: Sahalar/Create
        public IActionResult Create()
        {
            ViewData["TesisId"] = new SelectList(_context.Tesisler, "Id", "Ad");
            return View();
        }

        // POST: Sahalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,ZeminTuru,KapaliMi,SaatlikUcret,TesisId")] Saha saha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TesisId"] = new SelectList(_context.Tesisler, "Id", "Ad", saha.TesisId);
            return View(saha);
        }

        // GET: Sahalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saha = await _context.Sahalar.FindAsync(id);
            if (saha == null)
            {
                return NotFound();
            }
            ViewData["TesisId"] = new SelectList(_context.Tesisler, "Id", "Ad", saha.TesisId);
            return View(saha);
        }

        // POST: Sahalar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,ZeminTuru,KapaliMi,SaatlikUcret,TesisId")] Saha saha)
        {
            if (id != saha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SahaExists(saha.Id))
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
            ViewData["TesisId"] = new SelectList(_context.Tesisler, "Id", "Ad", saha.TesisId);
            return View(saha);
        }

        // GET: Sahalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saha = await _context.Sahalar
                .Include(s => s.Tesis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saha == null)
            {
                return NotFound();
            }

            return View(saha);
        }

        // POST: Sahalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saha = await _context.Sahalar.FindAsync(id);
            if (saha != null)
            {
                _context.Sahalar.Remove(saha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SahaExists(int id)
        {
            return _context.Sahalar.Any(e => e.Id == id);
        }
    }
}
