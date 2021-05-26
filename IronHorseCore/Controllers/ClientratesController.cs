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
    public class ClientratesController : Controller
    {
        private readonly EFContext _context;

        public ClientratesController(EFContext context)
        {
            _context = context;
        }

        // GET: Clientrates
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Clientrates.Include(c => c.Client);
            return View(await eFContext.ToListAsync());
        }

        // GET: Clientrates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientrate = await _context.Clientrates
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientrate == null)
            {
                return NotFound();
            }

            return View(clientrate);
        }

        // GET: Clientrates/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
            return View();
        }

        // POST: Clientrates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,TypeService,BillableUnit,CollectionUnit,PriceWithoutVat,ContractNumber,ContractExpiration,Currency")] Clientrate clientrate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientrate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientrate.ClientId);
            return View(clientrate);
        }

        // GET: Clientrates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientrate = await _context.Clientrates.FindAsync(id);
            if (clientrate == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientrate.ClientId);
            return View(clientrate);
        }

        // POST: Clientrates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,TypeService,BillableUnit,CollectionUnit,PriceWithoutVat,ContractNumber,ContractExpiration,Currency")] Clientrate clientrate)
        {
            if (id != clientrate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientrate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientrateExists(clientrate.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientrate.ClientId);
            return View(clientrate);
        }

        // GET: Clientrates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientrate = await _context.Clientrates
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientrate == null)
            {
                return NotFound();
            }

            return View(clientrate);
        }

        // POST: Clientrates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientrate = await _context.Clientrates.FindAsync(id);
            _context.Clientrates.Remove(clientrate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientrateExists(int id)
        {
            return _context.Clientrates.Any(e => e.Id == id);
        }
    }
}
