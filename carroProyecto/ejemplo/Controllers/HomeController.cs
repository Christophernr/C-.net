using System.Diagnostics;
using ejemplo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ejemplo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Autos()
        {
            return View();
        }

        //  M�todo para mostrar el formulario login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //  M�todo para procesar el formulario login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                // Redirige a la vista Autos
                return RedirectToAction("Autos");
            }
            else
            {
                ViewBag.Error = "Usuario o contrase�a incorrectos";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}      /*algo de c#*/
