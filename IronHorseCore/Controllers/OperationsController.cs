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
    public class OperationsController : Controller
    {
        private readonly EFContext _context;

        public OperationsController(EFContext context)
        {
            _context = context;
        }

        // GET: Operations
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Operations.Include(o => o.Carreta).Include(o => o.Carrier).Include(o => o.Client).Include(o => o.Destiny).Include(o => o.Driver).Include(o => o.Money).Include(o => o.Source).Include(o => o.Tracto).Include(o => o.TypeLoad).Include(o => o.TypeProduct).Include(o => o.Unit);
            return View(await eFContext.ToListAsync());
        }

        // GET: Operations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _context.Operations
                .Include(o => o.Carreta)
                .Include(o => o.Carrier)
                .Include(o => o.Client)
                .Include(o => o.Destiny)
                .Include(o => o.Driver)
                .Include(o => o.Money)
                .Include(o => o.Source)
                .Include(o => o.Tracto)
                .Include(o => o.TypeLoad)
                .Include(o => o.TypeProduct)
                .Include(o => o.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operation == null)
            {
                return NotFound();
            }

            ViewBag.DiverExpenses = await _context.Driverexpenses
               .Include(d => d.Driver)
               .Include(d => d.TypeExpense)
               .Where(m => m.OperationId == operation.Id).ToListAsync();

            return View(operation);
        }

        // GET: Operations/Create
        public IActionResult Create()
        {
            ViewData["CarretaId"] = new SelectList(_context.Trucks, "Id", "Placa");
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name");
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
            ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Name");
            ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name");
            ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name");
            ViewData["TractoId"] = new SelectList(_context.Trucks, "Id", "Placa");
            ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name");
            ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            return View();
        }

        // POST: Operations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mes,DriverId,TypeLoadId,ClientId,TypeProductId,OutDate,EndDate,SourceId,DestinyId,TractoId,CarretaId,UnitId,MoneyId,LoadDate,CarrierId,OdometerBegin,OdometerEnd,UnitPay")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarretaId"] = new SelectList(_context.Trucks, "Id", "Placa", operation.CarretaId);
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name", operation.CarrierId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", operation.ClientId);
            ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name", operation.DestinyId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Name", operation.DriverId);
            ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name", operation.MoneyId);
            ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name", operation.SourceId);
            ViewData["TractoId"] = new SelectList(_context.Trucks, "Id", "Placa", operation.TractoId);
            ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name", operation.TypeLoadId);
            ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name", operation.TypeProductId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", operation.UnitId);
            return View(operation);
        }

        // GET: Operations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _context.Operations.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            ViewData["CarretaId"] = new SelectList(_context.Trucks, "Id", "Id", operation.CarretaId);
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name", operation.CarrierId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", operation.ClientId);
            ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name", operation.DestinyId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Dni", operation.DriverId);
            ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name", operation.MoneyId);
            ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name", operation.SourceId);
            ViewData["TractoId"] = new SelectList(_context.Trucks, "Id", "Id", operation.TractoId);
            ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name", operation.TypeLoadId);
            ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name", operation.TypeProductId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", operation.UnitId);
            return View(operation);
        }

        // POST: Operations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mes,DriverId,TypeLoadId,ClientId,TypeProductId,OutDate,EndDate,SourceId,DestinyId,TractoId,CarretaId,UnitId,MoneyId,LoadDate,CarrierId,OdometerBegin,OdometerEnd,UnitPay")] Operation operation)
        {
            if (id != operation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationExists(operation.Id))
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
            ViewData["CarretaId"] = new SelectList(_context.Trucks, "Id", "Id", operation.CarretaId);
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name", operation.CarrierId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", operation.ClientId);
            ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name", operation.DestinyId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Dni", operation.DriverId);
            ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name", operation.MoneyId);
            ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name", operation.SourceId);
            ViewData["TractoId"] = new SelectList(_context.Trucks, "Id", "Id", operation.TractoId);
            ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name", operation.TypeLoadId);
            ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name", operation.TypeProductId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", operation.UnitId);
            return View(operation);
        }

        // GET: Operations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _context.Operations
                .Include(o => o.Carreta)
                .Include(o => o.Carrier)
                .Include(o => o.Client)
                .Include(o => o.Destiny)
                .Include(o => o.Driver)
                .Include(o => o.Money)
                .Include(o => o.Source)
                .Include(o => o.Tracto)
                .Include(o => o.TypeLoad)
                .Include(o => o.TypeProduct)
                .Include(o => o.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operation = await _context.Operations.FindAsync(id);
            _context.Operations.Remove(operation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationExists(int id)
        {
            return _context.Operations.Any(e => e.Id == id);
        }
    }
}
