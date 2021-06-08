using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IronHorseCore.Models;
using IronHorseCore.Helper;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using ClosedXML.Excel;
using ClosedXML.Extensions;

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
            var eFContext = _context.Clientrates.Include(c => c.Client).Include(c => c.Destiny).Include(c => c.Money).Include(c => c.Source).Include(c => c.TypeLoad).Include(c => c.TypeProduct).Include(c => c.TypeService).Include(c => c.Unit);
            return View(await eFContext.ToListAsync());
        }

        // GET: Clientrates/Details/5
        public async Task<IActionResult> Details(String uniqueid)
        {
            var clientrate = await _context.Clientrates
                .Include(c => c.Client)
                .Include(c => c.Destiny)
                .Include(c => c.Money)
                .Include(c => c.Source)
                .Include(c => c.TypeLoad)
                .Include(c => c.TypeProduct)
                .Include(c => c.TypeService)
                .Include(c => c.Unit)
                .FirstOrDefaultAsync(m => m.UniqueId == uniqueid);
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
            ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name");
            ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name");
            ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name");
            ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name");
            ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name");
            ViewData["TypeServiceId"] = new SelectList(_context.Typeservices, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            return View();
        }

        // POST: Clientrates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,TypeServiceId,TypeLoadId,TypeProductId,Description,SourceId,DestinyId,UnitId,MoneyId,PriceWithoutVat,ContractNumber,ContractExpiration,Enabled")] Clientrate clientrate)
        {
            try
            {
                //System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
                //clientrate.PriceWithoutVat = decimal.Parse(strPriceWithoutVat, cultureUS);

                clientrate.UniqueId = Guid.NewGuid().ToString();
                MetaAuth auth = new MetaAuth();
                auth.CreatedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                clientrate.MetaAuth = JsonSerializer.Serialize(auth);
                clientrate.IsRemoved = false;

                ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientrate.ClientId);
                ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name", clientrate.DestinyId);
                ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name", clientrate.MoneyId);
                ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name", clientrate.SourceId);
                ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name", clientrate.TypeLoadId);
                ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name", clientrate.TypeProductId);
                ViewData["TypeServiceId"] = new SelectList(_context.Typeservices, "Id", "Name", clientrate.TypeServiceId);
                ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", clientrate.UnitId);


                _context.Add(clientrate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }
            return View(clientrate);
        }

        // GET: Clientrates/Edit/5
        public async Task<IActionResult> Edit(String uniqueid)
        {
            var clientrate = await _context.Clientrates.FirstOrDefaultAsync(m => m.UniqueId == uniqueid);

            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientrate.ClientId);
            ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name", clientrate.DestinyId);
            ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name", clientrate.MoneyId);
            ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name", clientrate.SourceId);
            ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name", clientrate.TypeLoadId);
            ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name", clientrate.TypeProductId);
            ViewData["TypeServiceId"] = new SelectList(_context.Typeservices, "Id", "Name", clientrate.TypeServiceId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", clientrate.UnitId);
            return View(clientrate);
        }

        // POST: Clientrates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniqueId,ClientId,TypeServiceId,TypeLoadId,TypeProductId,Description,SourceId,DestinyId,UnitId,MoneyId,PriceWithoutVat,ContractNumber,ContractExpiration,Enabled")] Clientrate clientrate/*, String strPriceWithoutVat*/)
        {
            try
            {
                //System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");
                //clientrate.PriceWithoutVat = decimal.Parse(strPriceWithoutVat, cultureUS);

                var clientrateEdit = await _context.Clientrates.FirstOrDefaultAsync(m => m.UniqueId == clientrate.UniqueId);
                clientrateEdit.ClientId = clientrate.ClientId;
                clientrateEdit.TypeServiceId = clientrate.TypeServiceId;
                clientrateEdit.TypeLoadId = clientrate.TypeLoadId;
                clientrateEdit.TypeProductId = clientrate.TypeProductId;
                clientrateEdit.Description = clientrate.Description;
                clientrateEdit.SourceId = clientrate.SourceId;
                clientrateEdit.DestinyId = clientrate.DestinyId;
                clientrateEdit.UnitId = clientrate.UnitId;
                clientrateEdit.MoneyId = clientrate.MoneyId;
                clientrateEdit.PriceWithoutVat = clientrate.PriceWithoutVat;
                clientrateEdit.ContractNumber = clientrate.ContractNumber;
                clientrateEdit.ContractExpiration = clientrate.ContractExpiration;
                clientrateEdit.Enabled = clientrate.Enabled;

                MetaAuth auth = JsonSerializer.Deserialize<MetaAuth>(clientrateEdit.MetaAuth);
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.Modified = DateTime.Now;
                clientrateEdit.MetaAuth = JsonSerializer.Serialize(auth);

                _context.Update(clientrateEdit);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientrate.ClientId);
            ViewData["DestinyId"] = new SelectList(_context.Places, "Id", "Name", clientrate.DestinyId);
            ViewData["MoneyId"] = new SelectList(_context.Money, "Id", "Name", clientrate.MoneyId);
            ViewData["SourceId"] = new SelectList(_context.Places, "Id", "Name", clientrate.SourceId);
            ViewData["TypeLoadId"] = new SelectList(_context.Typeloads, "Id", "Name", clientrate.TypeLoadId);
            ViewData["TypeProductId"] = new SelectList(_context.Typeproducts, "Id", "Name", clientrate.TypeProductId);
            ViewData["TypeServiceId"] = new SelectList(_context.Typeservices, "Id", "Name", clientrate.TypeServiceId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", clientrate.UnitId);
            return View(clientrate);


        }

        // GET: Clientrates/Delete/5
        public async Task<IActionResult> Delete(String uniqueid)
        {


            var clientrate = await _context.Clientrates
                .Include(c => c.Client)
                .Include(c => c.Destiny)
                .Include(c => c.Money)
                .Include(c => c.Source)
                .Include(c => c.TypeLoad)
                .Include(c => c.TypeProduct)
                .Include(c => c.TypeService)
                .Include(c => c.Unit)
                .FirstOrDefaultAsync(m => m.UniqueId == uniqueid);


            return View(clientrate);
        }

        // POST: Clientrates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(String uniqueid)
        {
            var clientrate = await _context.Clientrates.FirstOrDefaultAsync(m => m.UniqueId == uniqueid);
            clientrate.IsRemoved = true;
            _context.Update(clientrate);
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

            var list = _context.Clientrates.Include(c => c.Client).Include(c => c.Destiny).Include(c => c.Money).Include(c => c.Source).Include(c => c.TypeLoad).Include(c => c.TypeProduct).Include(c => c.TypeService).Include(c => c.Unit).OrderBy(m => m.Id).ToList();

            var wb = new ClosedXML.Excel.XLWorkbook();
            var ws = wb.AddWorksheet();
            int cont = 2;


            ws.Range("A" + cont, "M" + cont).Style.Fill.SetBackgroundColor(XLColor.FromArgb(79, 129, 189));
            ws.Range("A" + cont, "M" + cont).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
            ws.Range("A" + cont, "M" + cont).Style.Border.SetOutsideBorderColor(XLColor.FromArgb(149, 179, 215));
            ws.Range("A" + cont, "M" + cont).Style.Font.SetFontColor(XLColor.White);


            ws.Cell("A" + cont).Value = "Id";
            ws.Cell("B" + cont).Value = "Cliente";
            ws.Cell("C" + cont).Value = "Tipo de Servicio";
            ws.Cell("D" + cont).Value = "Tipo de Carga";
            ws.Cell("E" + cont).Value = "Tipo de Producto";
            ws.Cell("F" + cont).Value = "Descripcion tarifa";
            ws.Cell("G" + cont).Value = "Lugar Origen";
            ws.Cell("H" + cont).Value = "Lugar Destino";
            ws.Cell("I" + cont).Value = "Unidad";
            ws.Cell("J" + cont).Value = "Moneda";
            ws.Cell("K" + cont).Value = "Precio sin IGV";
            ws.Cell("L" + cont).Value = "Numero Contrato";
            ws.Cell("M" + cont).Value = "Expiracion de contrato";

            cont++;

            foreach (var item in list)
            {
                ws.Cell("A" + cont).Value = item.Id;
                ws.Cell("B" + cont).Value = item.Client.Name;
                ws.Cell("C" + cont).Value = item.TypeService.Name;
                ws.Cell("D" + cont).Value = item.TypeLoad.Name;
                ws.Cell("E" + cont).Value = item.TypeProduct.Name;
                ws.Cell("F" + cont).Value = item.Description;
                ws.Cell("G" + cont).Value = item.Source.Name;
                ws.Cell("H" + cont).Value = item.Destiny.Name;
                ws.Cell("I" + cont).Value = item.Unit.Name;
                ws.Cell("J" + cont).Value = item.Money.Name;
                ws.Cell("K" + cont).Value = item.PriceWithoutVat;
                ws.Cell("L" + cont).Value = item.ContractNumber;
                ws.Cell("M" + cont).Value = item.ContractExpiration;

                cont++;
            }
            ws.Columns("A", "M").AdjustToContents();

            return wb.Deliver("ReporteDeTarifas.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }


        private bool ClientrateExists(int id)
        {
            return _context.Clientrates.Any(e => e.Id == id);
        }
    }
}
