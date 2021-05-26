using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IronHorseCore.Models;
using IronHorseCore.Helper;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace IronHorseCore.Controllers
{
    public class DriversController : Controller
    {
        private readonly EFContext _context;

        public DriversController(EFContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drivers.ToListAsync());
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDay,LicenseDriverNumber,LicenseDriverValidaty,LicenseDriver2Number,LicenseDriver2Validaty,Dni,Dnivigencia,Iqpf,Status,CursosPortuarios,CursosPortuariosVigencia,InduccionImpala,InduccionImpalaVigencia,InduccionLogisminsa,InduccionLogisminsaVigencia,InduccionPerubar,InduccionPerubarVigencia,InduccionShouxin,InduccionShouxinVigencia,InduccionTisur,InduccionRansa,InduccionAcerosA,UniqueId,MetaAuth,IsRemoved")] Driver driver)
        {
            try
            {
                driver.UniqueId = Guid.NewGuid().ToString();
                MetaAuth auth = new MetaAuth();
                auth.CreatedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                driver.MetaAuth = JsonSerializer.Serialize(auth);
                driver.IsRemoved = false;

                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,BirthDay,LicenseDriverNumber,LicenseDriverValidaty,LicenseDriver2Number,LicenseDriver2Validaty,Dni,Dnivigencia,Iqpf,Status,CursosPortuarios,CursosPortuariosVigencia,InduccionImpala,InduccionImpalaVigencia,InduccionLogisminsa,InduccionLogisminsaVigencia,InduccionPerubar,InduccionPerubarVigencia,InduccionShouxin,InduccionShouxinVigencia,InduccionTisur,InduccionRansa,InduccionAcerosA")] Driver driver)
        {

            try
            {
                var driverEdit = await _context.Drivers.FindAsync(driver.Id);//.FirstOrDefaultAsync(m => m.UniqueId == client.UniqueId);

                driverEdit.Name = driver.Name;
                driverEdit.BirthDay = driver.BirthDay;
                driverEdit.LicenseDriverNumber = driver.LicenseDriverNumber;
                driverEdit.LicenseDriverValidaty = driver.LicenseDriverValidaty;
                driverEdit.LicenseDriver2Number = driver.LicenseDriver2Number;
                driverEdit.LicenseDriver2Validaty = driver.LicenseDriver2Validaty;
                driverEdit.Dni = driver.Dni;
                driverEdit.Dnivigencia = driver.Dnivigencia;
                driverEdit.Iqpf = driver.Iqpf;
                driverEdit.Status = driver.Status;
                driverEdit.CursosPortuarios = driver.CursosPortuarios;
                driverEdit.CursosPortuariosVigencia = driver.CursosPortuariosVigencia;
                driverEdit.InduccionImpala = driver.InduccionImpala;
                driverEdit.InduccionImpalaVigencia = driver.InduccionImpalaVigencia;
                driverEdit.InduccionLogisminsa = driver.InduccionLogisminsa;
                driverEdit.InduccionLogisminsaVigencia = driver.InduccionLogisminsaVigencia;
                driverEdit.InduccionPerubar = driver.InduccionPerubar;
                driverEdit.InduccionPerubarVigencia = driver.InduccionPerubarVigencia;
                driverEdit.InduccionShouxin = driver.InduccionShouxin;
                driverEdit.InduccionShouxinVigencia = driver.InduccionShouxinVigencia;
                driverEdit.InduccionTisur = driver.InduccionTisur;
                driverEdit.InduccionRansa = driver.InduccionRansa;
                driverEdit.InduccionAcerosA = driver.InduccionAcerosA;

                MetaAuth auth = JsonSerializer.Deserialize<MetaAuth>(driverEdit.MetaAuth);
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.Modified = DateTime.Now;
                driverEdit.MetaAuth = JsonSerializer.Serialize(auth);

                _context.Update(driverEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(driver.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            driver.IsRemoved = true;
            _context.Update(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}
