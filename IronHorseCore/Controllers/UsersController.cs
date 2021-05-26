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
    public class UsersController : Controller
    {
        private readonly EFContext _context;

        private List<SelectListItem> TypeDocList = new List<SelectListItem>
                {
                        new SelectListItem { Text = "DNI", Value = "DNI"},
                        new SelectListItem { Text = "CE", Value = "CE"},
                };

        private List<SelectListItem> RolList = new List<SelectListItem>
                {
                        new SelectListItem { Text = "Gerente General", Value = "Gerente General"},// ve todo                     
                        
                        
                        
                       
                        new SelectListItem { Text = "Gerente de Operaciones", Value = "Gerente de Operaciones 5"},
                        new SelectListItem { Text = "Jefe de Transportes", Value = "Jefe de Transportes 4"},
                        new SelectListItem { Text = "Supervisor de Transportes", Value = "Supervisor de Transportes 3"},
                        new SelectListItem { Text = "Coordinador de Transportes", Value = "Coordinador de Transportes 2"},
                        new SelectListItem { Text = "Centro de Control", Value = "Centro de Control 1"},

                        new SelectListItem { Text = "Jefe de Administracion", Value = "Jefe de Administración"},// ve todo 
                        new SelectListItem { Text = "Jefe de Contabilidad", Value = "Jefe de Contabilidad"},// ve todo 
                        new SelectListItem { Text = "Asistente Contable", Value = "Asistente Contable"},// Facturacion

                        //new SelectListItem { Text = "Asistente RRHH", Value = "Asistente RRHH"},
                        new SelectListItem { Text = "Conductor", Value = "Conductor"}
                };

        public UsersController(EFContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.Where(m => m.IsRemoved == false).ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(String id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.UniqueId == id);
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.TypeDocList = new SelectList(TypeDocList, "Value", "Text");
            ViewBag.RolList = new SelectList(RolList, "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeDoc,NumberDoc,FirstName,LastName,Email,CellPhone,Phone,Password,Enabled,Rol")] User user)
        {
            try
            {
                user.UniqueId = Guid.NewGuid().ToString();
                MetaAuth auth = new MetaAuth();
                auth.CreatedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                user.MetaAuth = JsonSerializer.Serialize(auth);
                user.IsRemoved = false;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

            }

            ViewBag.TypeDocList = new SelectList(TypeDocList, "Value", "Text", user.TypeDoc);
            ViewBag.RolList = new SelectList(RolList, "Value", "Text", user.Rol);

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(String id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.UniqueId == id);
            ViewBag.TypeDocList = new SelectList(TypeDocList, "Value", "Text", user.TypeDoc);
            ViewBag.RolList = new SelectList(RolList, "Value", "Text", user.Rol);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("UniqueId,TypeDoc,NumberDoc,FirstName,LastName,Email,CellPhone,Phone,Password,Enabled,Rol")] User user)
        {
            var userEdit = await _context.Users.FirstOrDefaultAsync(m => m.UniqueId == user.UniqueId);
            try
            {
                userEdit.TypeDoc = user.TypeDoc;
                userEdit.NumberDoc = user.NumberDoc;
                userEdit.FirstName = user.FirstName;
                userEdit.LastName = user.LastName;
                userEdit.Email = user.Email;
                userEdit.CellPhone = user.CellPhone;
                userEdit.Phone = user.Phone;
                userEdit.Password = user.Password;
                userEdit.Enabled = user.Enabled;
                userEdit.Rol = user.Rol;

                MetaAuth auth = JsonSerializer.Deserialize<MetaAuth>(userEdit.MetaAuth);
                auth.ModifiedUserID = (int)HttpContext.Session.GetInt32("UserId");
                auth.Modified = DateTime.Now;
                userEdit.MetaAuth = JsonSerializer.Serialize(auth);

                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            ViewBag.TypeDocList = new SelectList(TypeDocList, "Value", "Text", user.TypeDoc);
            ViewBag.RolList = new SelectList(RolList, "Value", "Text", user.Rol);

            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(String id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.UniqueId == id);          

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(String id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.UniqueId == id);
            user.IsRemoved = true;
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
