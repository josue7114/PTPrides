using Consumo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prueba.Models;
using Prueba.Models.Models;
using WEB.Utils;

namespace WEB.Controllers
{
    public class InicioController : Controller
    {
        private TiendasLogic LTiendas;
        private PerfilLogic LPerfil;
        private UsuariosLogic LUsuarios;
        private EmpleadosLogic LEmpleados;

        public InicioController() {
            LTiendas = new TiendasLogic();
            LPerfil = new PerfilLogic();
            LUsuarios = new UsuariosLogic();
            LEmpleados = new EmpleadosLogic();
        }

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Ingresar(LoginModel Modelo) {
            Modelo.Contrasena = Utilidades.GetSHA256(Modelo.Contrasena);
            var Result = await LUsuarios.Validar(Modelo, "token");
            if (Result.StatusCode == 200) {
                return Json(new { success = true });
            }
            else {
                return Json(new { success = false, message = Result.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarUsuario(UsuariosModel Modelo) {
            Modelo.Contrasena = Utilidades.GetSHA256(Modelo.Contrasena);
            var Result = await LUsuarios.Agregar(Modelo, "token");
            if (Result.StatusCode == 200) {
                var Result2 = await LEmpleados.Agregar(new EmpleadosModel { Fecha = DateTime.Today, Nombre = Modelo.Nombre, PerfilID = Modelo.PerfilID, Salario = 0 }, "token");
                if (Result2.StatusCode == 200) {
                    return Json(new { success = true });
                }
                else {
                    return Json(new { success = false, message = Result2.Message });
                }
            }
            else {
                return Json(new { success = false, message = Result.Message });
            }
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