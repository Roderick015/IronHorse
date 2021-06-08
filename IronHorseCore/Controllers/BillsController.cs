using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IronHorseCore.Models;
using ClosedXML.Excel;
using ClosedXML.Extensions;

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

        // POST: Meets/Report
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Report()
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;

            var list = _context.Bills.Include(b => b.Operation).OrderBy(m => m.Id).ToList();

            var wb = new ClosedXML.Excel.XLWorkbook();
            var ws = wb.AddWorksheet();
            int cont = 2;


            ws.Range("A" + cont, "G" + cont).Style.Fill.SetBackgroundColor(XLColor.FromArgb(79, 129, 189));
            ws.Range("A" + cont, "G" + cont).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
            ws.Range("A" + cont, "G" + cont).Style.Border.SetOutsideBorderColor(XLColor.FromArgb(149, 179, 215));
            ws.Range("A" + cont, "G" + cont).Style.Font.SetFontColor(XLColor.White);


            ws.Cell("A" + cont).Value = "Id";
            ws.Cell("B" + cont).Value = "Operacion";
            ws.Cell("C" + cont).Value = "Fecha de Creacion";
            ws.Cell("D" + cont).Value = "Total";
            ws.Cell("E" + cont).Value = "Numero de Serie";
            ws.Cell("F" + cont).Value = "Estado de Factura";
            ws.Cell("G" + cont).Value = "Fecha de pago";

            cont++;

            foreach (var item in list)
            {
                ws.Cell("A" + cont).Value = item.Id;
                ws.Cell("B" + cont).Value = item.OperationId;
                ws.Cell("C" + cont).Value = item.Created;
                ws.Cell("D" + cont).Value = item.Total;
                ws.Cell("E" + cont).Value = item.SerialNumber;
                switch (item.Status)
                {
                    case 1:
                        ws.Cell("F" + cont).Value = "Factura Generada";
                        //ws.Range("B" + cont).Style.Font.SetFontColor(XLColor.FromHtml("#A91E2C"));
                        break;
                    case 2:
                        ws.Cell("F" + cont).Value = "Factura Pagada";
                        //ws.Range("B" + cont).Style.Font.SetFontColor(XLColor.FromHtml("#18634B"));
                        break;
                    case 3:
                        ws.Cell("F" + cont).Value = "Factura Anulada";
                        //ws.Range("B" + cont).Style.Font.SetFontColor(XLColor.FromHtml("#0056B3"));
                        break;
                }
                ws.Cell("G" + cont).Value = item.Datepay;

                cont++;
            }
            ws.Columns("A", "H").AdjustToContents();

            return wb.Deliver("ReporteDeCitas.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}
