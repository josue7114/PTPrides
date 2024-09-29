using Consumo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prueba.Models;
using Prueba.Models.Models;

namespace WEB.Controllers
{
    public class InicioController : Controller
    {
        private TiendasLogic LTiendas;
        private PerfilLogic LPerfil;

        public InicioController() {
            LTiendas = new TiendasLogic();
            LPerfil = new PerfilLogic();
        }

        public async Task<ActionResult> Index() {
            return View();
        }

        public async Task<ActionResult> ObtenerContenidoModal(int Parametro) {
            var Tiendas = await LTiendas.Listar("token");
            var Perfiles = await LPerfil.Listar("token");
            if (Tiendas.StatusCode == 200) {
                ViewBag.Tiendas = Tiendas.ListModel;
            }
            if (Perfiles.StatusCode == 200) {
                ViewBag.Perfil = Perfiles.ListModel;
            }
            return PartialView("_modal", new UsuariosModel());
        }
    }
}