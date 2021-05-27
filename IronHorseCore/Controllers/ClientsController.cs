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

namespace IronHorseCore.Controllers
{
    public class ClientsController : Controller
    {
        private readonly EFContext _context;

        public ClientsController(EFContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.Where(m => m.IsRemoved == false).ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(String uniqueid)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(m => m.UniqueId == uniqueid);
            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,Address,Contact,ContactPhone,ContactEmail,Enabled")] Client client)
        {
            try
            {
                client.UniqueId = Guid.NewGuid().ToString();
                MetaAuth auth = new MetaAuth();
                auth.CreatedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                client.MetaAuth = JsonSerializer.Serialize(auth);
                client.IsRemoved = false;
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(String id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(m => m.UniqueId == id);
            return View(client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("UniqueId,Name,Code,Address,Contact,ContactPhone,ContactEmail,Enabled")] Client client)
        {
            try
            {
                var clientEdit = await _context.Clients.FirstOrDefaultAsync(m => m.UniqueId == client.UniqueId);
                clientEdit.Name = client.Name;
                clientEdit.Code = client.Code;
                clientEdit.Address = client.Address;
                clientEdit.Contact = client.Contact;
                clientEdit.ContactPhone = client.ContactPhone;
                clientEdit.ContactEmail = client.ContactEmail;
                clientEdit.Enabled = client.Enabled;

                MetaAuth auth = JsonSerializer.Deserialize<MetaAuth>(clientEdit.MetaAuth);
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.Modified = DateTime.Now;
                clientEdit.MetaAuth = JsonSerializer.Serialize(auth);

                _context.Update(clientEdit);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(String id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(m => m.UniqueId == id);
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(String id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(m => m.UniqueId == id);
            client.IsRemoved = true;
            _context.Update(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
