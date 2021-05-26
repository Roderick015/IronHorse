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
    public class OperationExpensesController : Controller
    {
        private readonly EFContext _context;

        public OperationExpensesController(EFContext context)
        {
            _context = context;
        }

        // GET: OperationExpenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Operationexpenses.ToListAsync());
        }

        // GET: OperationExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationexpense = await _context.Operationexpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operationexpense == null)
            {
                return NotFound();
            }

            return View(operationexpense);
        }

        // GET: OperationExpenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperationExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeExpenseId,Date,Description,Amount")] Operationexpense operationexpense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operationexpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operationexpense);
        }

        // GET: OperationExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationexpense = await _context.Operationexpenses.FindAsync(id);
            if (operationexpense == null)
            {
                return NotFound();
            }
            return View(operationexpense);
        }

        // POST: OperationExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeExpenseId,Date,Description,Amount")] Operationexpense operationexpense)
        {
            if (id != operationexpense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operationexpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationexpenseExists(operationexpense.Id))
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
            return View(operationexpense);
        }

        // GET: OperationExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationexpense = await _context.Operationexpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operationexpense == null)
            {
                return NotFound();
            }

            return View(operationexpense);
        }

        // POST: OperationExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operationexpense = await _context.Operationexpenses.FindAsync(id);
            _context.Operationexpenses.Remove(operationexpense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationexpenseExists(int id)
        {
            return _context.Operationexpenses.Any(e => e.Id == id);
        }
    }
}
