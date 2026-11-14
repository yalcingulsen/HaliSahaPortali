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
    public class TesislerController : Controller
    {
        private readonly AppDbContext _context;

        public TesislerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tesisler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tesisler.ToListAsync());
        }

        // GET: Tesisler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesis = await _context.Tesisler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tesis == null)
            {
                return NotFound();
            }

            return View(tesis);
        }

        // GET: Tesisler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tesisler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Adres,Ilce,Telefon,Aciklama")] Tesis tesis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tesis);
        }

        // GET: Tesisler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesis = await _context.Tesisler.FindAsync(id);
            if (tesis == null)
            {
                return NotFound();
            }
            return View(tesis);
        }

        // POST: Tesisler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Adres,Ilce,Telefon,Aciklama")] Tesis tesis)
        {
            if (id != tesis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesisExists(tesis.Id))
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
            return View(tesis);
        }

        // GET: Tesisler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesis = await _context.Tesisler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tesis == null)
            {
                return NotFound();
            }

            return View(tesis);
        }

        // POST: Tesisler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tesis = await _context.Tesisler.FindAsync(id);
            if (tesis != null)
            {
                _context.Tesisler.Remove(tesis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesisExists(int id)
        {
            return _context.Tesisler.Any(e => e.Id == id);
        }
    }
}
