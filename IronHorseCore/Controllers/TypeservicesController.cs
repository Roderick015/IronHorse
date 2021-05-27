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
    public class TypeservicesController : Controller
    {
        private readonly EFContext _context;

        public TypeservicesController(EFContext context)
        {
            _context = context;
        }

        // GET: Typeservices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Typeservices.ToListAsync());
        }

        // GET: Typeservices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeservice = await _context.Typeservices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeservice == null)
            {
                return NotFound();
            }

            return View(typeservice);
        }

        // GET: Typeservices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Typeservices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Enabled")] Typeservice typeservice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeservice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeservice);
        }

        // GET: Typeservices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeservice = await _context.Typeservices.FindAsync(id);
            if (typeservice == null)
            {
                return NotFound();
            }
            return View(typeservice);
        }

        // POST: Typeservices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Enabled")] Typeservice typeservice)
        {
            if (id != typeservice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeservice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeserviceExists(typeservice.Id))
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
            return View(typeservice);
        }

        // GET: Typeservices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeservice = await _context.Typeservices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeservice == null)
            {
                return NotFound();
            }

            return View(typeservice);
        }

        // POST: Typeservices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeservice = await _context.Typeservices.FindAsync(id);
            _context.Typeservices.Remove(typeservice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeserviceExists(int id)
        {
            return _context.Typeservices.Any(e => e.Id == id);
        }
    }
}
