using System.Diagnostics;
using examenProgra.Models;
using Microsoft.AspNetCore.Mvc;

namespace examenProgra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //ventanas del header
        public IActionResult login()
        {
            return View();
        }

        public IActionResult ofertas()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult contacto()
        {
            return View();
        
        }
        //aqui terminan las ventanas del header
        //lo borro porque no es necsario, no trabaja con el js 


        //[HttpPost]
        //public IActionResult login(string username, string password)
        //{
        //    if (username == "ADMIN" && password == "Adm1n!")
        //    {
        //        // Redirige a la vista Autos
        //        return RedirectToAction("ofertas");
        //    }
        //    else
        //    {
        //        ViewBag.Error = "Usuario o contraseña incorrectos";
        //        return View();

        //    }
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
