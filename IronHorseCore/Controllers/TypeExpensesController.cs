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
    public class TypeExpensesController : Controller
    {
        private readonly EFContext _context;

        public TypeExpensesController(EFContext context)
        {
            _context = context;
        }

        // GET: TypeExpenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Typeexpenses.ToListAsync());
        }

        // GET: TypeExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeexpense = await _context.Typeexpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeexpense == null)
            {
                return NotFound();
            }

            return View(typeexpense);
        }

        // GET: TypeExpenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Typeexpense typeexpense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeexpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeexpense);
        }

        // GET: TypeExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeexpense = await _context.Typeexpenses.FindAsync(id);
            if (typeexpense == null)
            {
                return NotFound();
            }
            return View(typeexpense);
        }

        // POST: TypeExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Typeexpense typeexpense)
        {
            if (id != typeexpense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeexpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeexpenseExists(typeexpense.Id))
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
            return View(typeexpense);
        }

        // GET: TypeExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeexpense = await _context.Typeexpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeexpense == null)
            {
                return NotFound();
            }

            return View(typeexpense);
        }

        // POST: TypeExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeexpense = await _context.Typeexpenses.FindAsync(id);
            _context.Typeexpenses.Remove(typeexpense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeexpenseExists(int id)
        {
            return _context.Typeexpenses.Any(e => e.Id == id);
        }
    }
}
