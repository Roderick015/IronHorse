using IronHorseCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IronHorseCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFContext _context;

        public HomeController(ILogger<HomeController> logger, EFContext context)
        {
            _context = context;
            _logger = logger;
        }

		public IActionResult Index()
		{
			return View();
		}

		[Route("Login")]
		public IActionResult Login()
		{
			return View();
		}

		[Route("Login")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(string email, string password)
		{

			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				base.ViewBag.Message = "Email y contraseña son obligatorios";
				return View();
			}

			User user = _context.Users.Where((User u) => u.Email.Equals(email) && u.Password.Equals(password)).FirstOrDefault();

			if (user == null)
			{
				base.ViewBag.Message = "Email y contraseña erroneos";
			}
			else
			{
				if (user.Enabled)
				{
					HttpContext.Session.SetInt32("UserId", user.Id);
					base.HttpContext.Session.SetInt32("IsAdmin", user.IsAdmin ? 1 : 0); // Usuario admin o conciliador
					base.HttpContext.Session.SetString("UserName", user.FirstName + " " + user.LastName);
					return RedirectToAction("Index", "Home");
				}
				base.ViewBag.Message = "Usuario esta inhabilitado";
			}
			return View();
		}

		[Route("Logout")]
		public IActionResult Logout()
		{
			base.HttpContext.Session.Clear();
			return RedirectToAction("Login", "Home", new
			{
				Area = ""
			});
		}

		[Route("ActualizarPassword")]
		public IActionResult CambioContrasena()
		{
			return View();
		}

		[Route("ActualizarPassword")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CambioContrasena(string Contrasena1)
		{
			if (string.IsNullOrEmpty(Contrasena1))
			{
				base.ModelState.AddModelError(string.Empty, "Ingrese contraseña");
			}
			else
			{
				//if (Contrasena1.Equals(Contrasena2))
				//{
				User user = _context.Users.Find(base.HttpContext.Session.GetInt32("UserId"));
				user.Password = Contrasena1;
				_context.Update(user);
				_context.SaveChanges();
				ViewBag.Mensaje = "Contraseña actualizada";
				//}
				//base.ModelState.AddModelError(string.Empty, "Las contraseñas no son iguales");
			}
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
