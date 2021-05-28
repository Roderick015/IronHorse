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
    public class DriverexpensesController : Controller
    {
        private readonly EFContext _context;

        public DriverexpensesController(EFContext context)
        {
            _context = context;
        }

        // GET: Driverexpenses
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Driverexpenses.Include(d => d.Driver).Include(d => d.Operation).Include(d => d.TypeExpense);
            return View(await eFContext.ToListAsync());
        }

        // GET: Driverexpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverexpense = await _context.Driverexpenses
                .Include(d => d.Driver)
                .Include(d => d.Operation)
                .Include(d => d.TypeExpense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverexpense == null)
            {
                return NotFound();
            }

            return View(driverexpense);
        }

        // GET: Driverexpenses/Create
        public IActionResult Create(int operationid, int driverid)
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Dni", driverid);
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Id", operationid);
            ViewData["TypeExpenseId"] = new SelectList(_context.Typeexpenses, "Id", "Name");
            return View();
        }

        // POST: Driverexpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DriverId,TypeExpenseId,Date,Description,Amount,OperacionDesignada,AprobadoPor,OperationId")] Driverexpense driverexpense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverexpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Operations", new { id = driverexpense.OperationId });
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Dni", driverexpense.DriverId);
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Mes", driverexpense.OperationId);
            ViewData["TypeExpenseId"] = new SelectList(_context.Typeexpenses, "Id", "Name", driverexpense.TypeExpenseId);
            return View(driverexpense);
        }

        // GET: Driverexpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverexpense = await _context.Driverexpenses.FindAsync(id);
            if (driverexpense == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Dni", driverexpense.DriverId);
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Mes", driverexpense.OperationId);
            ViewData["TypeExpenseId"] = new SelectList(_context.Typeexpenses, "Id", "Name", driverexpense.TypeExpenseId);
            return View(driverexpense);
        }

        // POST: Driverexpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DriverId,TypeExpenseId,Date,Description,Amount,OperacionDesignada,AprobadoPor,OperationId")] Driverexpense driverexpense)
        {
            if (id != driverexpense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverexpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverexpenseExists(driverexpense.Id))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Dni", driverexpense.DriverId);
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Mes", driverexpense.OperationId);
            ViewData["TypeExpenseId"] = new SelectList(_context.Typeexpenses, "Id", "Name", driverexpense.TypeExpenseId);
            return View(driverexpense);
        }

        // GET: Driverexpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverexpense = await _context.Driverexpenses
                .Include(d => d.Driver)
                .Include(d => d.Operation)
                .Include(d => d.TypeExpense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverexpense == null)
            {
                return NotFound();
            }

            return View(driverexpense);
        }

        // POST: Driverexpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driverexpense = await _context.Driverexpenses.FindAsync(id);
            _context.Driverexpenses.Remove(driverexpense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverexpenseExists(int id)
        {
            return _context.Driverexpenses.Any(e => e.Id == id);
        }
    }
}
