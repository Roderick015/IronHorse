using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IronHorseCore.Models;

namespace IronHorseCore.Controllers
{
    public class TypeloadsController : Controller
    {
        private readonly EFContext _context;

        public TypeloadsController(EFContext context)
        {
            _context = context;
        }

        // GET: Typeloads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Typeloads.ToListAsync());
        }

        // GET: Typeloads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeload = await _context.Typeloads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeload == null)
            {
                return NotFound();
            }

            return View(typeload);
        }

        // GET: Typeloads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Typeloads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Enabled")] Typeload typeload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeload);
        }

        // GET: Typeloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeload = await _context.Typeloads.FindAsync(id);
            if (typeload == null)
            {
                return NotFound();
            }
            return View(typeload);
        }

        // POST: Typeloads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Enabled")] Typeload typeload)
        {
            if (id != typeload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeloadExists(typeload.Id))
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
            return View(typeload);
        }

        // GET: Typeloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeload = await _context.Typeloads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeload == null)
            {
                return NotFound();
            }

            return View(typeload);
        }

        // POST: Typeloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeload = await _context.Typeloads.FindAsync(id);
            _context.Typeloads.Remove(typeload);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeloadExists(int id)
        {
            return _context.Typeloads.Any(e => e.Id == id);
        }
    }
}
