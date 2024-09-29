using Consumo;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;

namespace WEB.Controllers
{
    public class PermisosController : Controller
    {
        private PermisosLogic LPermisos;

        public PermisosController() {
            LPermisos = new PermisosLogic();
        }

        public async Task<ActionResult> Index() {
            var Permisos = await LPermisos.Listar("token");
            if (Permisos.StatusCode == 200) {
                return View(Permisos.ListModel);
            }
            return View(new List<PermisosModel>());
        }
    }
}