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
    public class TollsController : Controller
    {
        private readonly EFContext _context;

        public TollsController(EFContext context)
        {
            _context = context;
        }

        // GET: Tolls
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Tolls.Include(t => t.Operations);
            return View(await eFContext.ToListAsync());
        }

        // GET: Tolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toll = await _context.Tolls
                .Include(t => t.Operations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toll == null)
            {
                return NotFound();
            }

            return View(toll);
        }

        // GET: Tolls/Create
        public IActionResult Create()
        {
            ViewData["OperationsId"] = new SelectList(_context.Operations, "Id", "Id");
            return View();
        }

        // POST: Tolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OperationsId,DatePay,Pay")] Toll toll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OperationsId"] = new SelectList(_context.Operations, "Id", "Id", toll.OperationsId);
            return View(toll);
        }

        // GET: Tolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toll = await _context.Tolls.FindAsync(id);
            if (toll == null)
            {
                return NotFound();
            }
            ViewData["OperationsId"] = new SelectList(_context.Operations, "Id", "Id", toll.OperationsId);
            return View(toll);
        }

        // POST: Tolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OperationsId,DatePay,Pay")] Toll toll)
        {
            if (id != toll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TollExists(toll.Id))
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
            ViewData["OperationsId"] = new SelectList(_context.Operations, "Id", "Id", toll.OperationsId);
            return View(toll);
        }

        // GET: Tolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toll = await _context.Tolls
                .Include(t => t.Operations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toll == null)
            {
                return NotFound();
            }

            return View(toll);
        }

        // POST: Tolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toll = await _context.Tolls.FindAsync(id);
            _context.Tolls.Remove(toll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TollExists(int id)
        {
            return _context.Tolls.Any(e => e.Id == id);
        }
    }
}
