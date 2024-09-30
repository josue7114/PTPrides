using Microsoft.AspNetCore.Mvc;
using WEB.Utils;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
    }
}