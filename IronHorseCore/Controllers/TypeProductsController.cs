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
    public class TypeProductsController : Controller
    {
        private readonly EFContext _context;

        public TypeProductsController(EFContext context)
        {
            _context = context;
        }

        // GET: TypeProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Typeproducts.ToListAsync());
        }

        // GET: TypeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeproduct = await _context.Typeproducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeproduct == null)
            {
                return NotFound();
            }

            return View(typeproduct);
        }

        // GET: TypeProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Enabled")] Typeproduct typeproduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeproduct);
        }

        // GET: TypeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeproduct = await _context.Typeproducts.FindAsync(id);
            if (typeproduct == null)
            {
                return NotFound();
            }
            return View(typeproduct);
        }

        // POST: TypeProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Enabled")] Typeproduct typeproduct)
        {
            if (id != typeproduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeproduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeproductExists(typeproduct.Id))
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
            return View(typeproduct);
        }

        // GET: TypeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeproduct = await _context.Typeproducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeproduct == null)
            {
                return NotFound();
            }

            return View(typeproduct);
        }

        // POST: TypeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeproduct = await _context.Typeproducts.FindAsync(id);
            _context.Typeproducts.Remove(typeproduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeproductExists(int id)
        {
            return _context.Typeproducts.Any(e => e.Id == id);
        }
    }
}
