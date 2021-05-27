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
    public class TrucksController : Controller
    {
        private readonly EFContext _context;

        public TrucksController(EFContext context)
        {
            _context = context;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Trucks.Include(t => t.Carrier);
            return View(await eFContext.ToListAsync());
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .Include(t => t.Carrier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name");
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,IsRemolcado,IsSemiremolque,SemiremolqueTipo,Placa,Soatnumero,Soatvigencia,PolizaNro,PolizaVigencia,PolizaAccidentesPersonalesVigencia,PolizaSeguroTrecVigencia,RevisionTecnicaNro,RevisionTecnicaVigencia,CkecklistInspeccionGeneralVigencia,Gpsproveedor,GpscertificadoInstalacion,TarjetaCirualacionVigencia,TarjetaMercaderiaVigencia,Propietario,BonificacionPesosMedidas,BonifacionMatpel,CarrierId")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name", truck.CarrierId);
            return View(truck);
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks.FindAsync(id);
            if (truck == null)
            {
                return NotFound();
            }
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name", truck.CarrierId);
            return View(truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,IsRemolcado,IsSemiremolque,SemiremolqueTipo,Placa,Soatnumero,Soatvigencia,PolizaNro,PolizaVigencia,PolizaAccidentesPersonalesVigencia,PolizaSeguroTrecVigencia,RevisionTecnicaNro,RevisionTecnicaVigencia,CkecklistInspeccionGeneralVigencia,Gpsproveedor,GpscertificadoInstalacion,TarjetaCirualacionVigencia,TarjetaMercaderiaVigencia,Propietario,BonificacionPesosMedidas,BonifacionMatpel,CarrierId")] Truck truck)
        {
            if (id != truck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(truck.Id))
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
            ViewData["CarrierId"] = new SelectList(_context.Carriers, "Id", "Name", truck.CarrierId);
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .Include(t => t.Carrier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
