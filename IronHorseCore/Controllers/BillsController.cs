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
    public class BillsController : Controller
    {
        private readonly EFContext _context;

        private List<SelectListItem> TypeBillStatus = new List<SelectListItem>
                {
                        new SelectListItem { Text = "Factura Generada", Value = "1"},
                        new SelectListItem { Text = "Factura Pagada", Value = "2"},
                        new SelectListItem { Text = "Factura Anulada", Value = "3"},
                };

        public BillsController(EFContext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Bills.Include(b => b.Operation);
            //Mostrar lista de estados de factura
            ViewBag.TypeBillStatus = TypeBillStatus;
            return View(await eFContext.ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Operation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bill == null)
            {
                return NotFound();
            }

            ViewBag.TypeBillStatus = TypeBillStatus;

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            //Crear Lista con etiqueta select
            ViewBag.TypeBillStatus = new SelectList(TypeBillStatus, "Value", "Text");
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Id");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OperationId,Total,SerialNumber,Status,Datepay")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                bill.Created = DateTime.Now;
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TypeBillStatus = new SelectList(TypeBillStatus, "Value", "Text", bill.Status);
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Id", bill.OperationId);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var bill = await _context.Bills.FindAsync(id);
            ViewBag.TypeBillStatus = new SelectList(TypeBillStatus, "Value", "Text", bill.Status);
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Id", bill.OperationId);

            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OperationId,Created,Total,SerialNumber,Status")] Bill bill, String strDatepay)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bill.Datepay = DateTime.ParseExact(strDatepay, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Id))
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

            ViewBag.TypeBillStatus = new SelectList(TypeBillStatus, "Value", "Text", bill.Status);
            ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Id", bill.OperationId);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Operation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bill == null)
            {
                return NotFound();
            }

            ViewBag.TypeBillStatus = TypeBillStatus;

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}
