using Consumo;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using WEB.Utils;

namespace WEB.Controllers
{
    public class PermisosController : Controller
    {
        private PermisosLogic LPermisos;

        public PermisosController() {
            LPermisos = new PermisosLogic();
        }

        public async Task<ActionResult> Index() {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                var Permisos = await LPermisos.Listar(Sesion.accessToken);
                if (Permisos.StatusCode == 200) {
                    return View(Permisos.ListModel);
                }
                return View(new List<PermisosModel>());
            }
            return RedirectToAction("Index", "Inicio");
        }
    }
}