using Consumo;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using WEB.Utils;

namespace WEB.Controllers
{
    public class EmpleadosController : Controller
    {
        private EmpleadosLogic LEmpleados;
        private TiendasLogic LTiendas;
        private PerfilLogic LPerfil;

        public EmpleadosController() {
            LEmpleados = new EmpleadosLogic();
            LTiendas = new TiendasLogic();
            LPerfil = new PerfilLogic();
        }

        public async Task<ActionResult> Index() {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                var Empleados = await LEmpleados.Listar(Sesion.accessToken);
                if (Empleados.StatusCode == 200) {
                    return View(Empleados.ListModel);
                }
                return View(new List<EmpleadosModel>());
            }
            return RedirectToAction("Index", "Inicio");
        }

        public async Task<ActionResult> ObtenerContenidoModal(int Parametro) {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                var Perfiles = await LPerfil.Listar(Sesion.accessToken);
                var Supervisores = await LEmpleados.Listar(Sesion.accessToken);
                if (Perfiles.StatusCode == 200) {
                    ViewBag.Perfil = Perfiles.ListModel;
                }
                if (Supervisores.StatusCode == 200) {
                    ViewBag.Supervisores = Supervisores.ListModel.Where(m => m.SupervisorID == 0);
                }
                var Modelo = new EmpleadosModel();
                if (Parametro != 0) {
                    var Empleados = await LEmpleados.Listar(Sesion.accessToken);
                    if (Empleados.StatusCode == 200) {
                        Modelo = Empleados.ListModel.Where(m => m.EmpleadoID == Parametro).FirstOrDefault();
                        return PartialView("_modal", Modelo);
                    }
                }
                return PartialView("_modal", Modelo);
            }
            return RedirectToAction("Index", "Inicio");
        }

        public async Task<ActionResult> Guardar(EmpleadosModel Modelo) {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                var Result = new ResultClass<EmpleadosModel>();
                if (Modelo.SupervisorID == 0) {
                    Modelo.SupervisorID = null;
                }
                if (Modelo.EmpleadoID != 0) {
                    Result = await LEmpleados.Modificar(Modelo, Sesion.accessToken);
                }
                else {
                    Modelo.Fecha = DateTime.Today;
                    Result = await LEmpleados.Agregar(Modelo, Sesion.accessToken);
                }
                if (Result.StatusCode == 200) {
                    return Json(new { success = true, message = "Registro guardado correctamente" });
                }
                else {
                    return Json(new { success = false, message = Result.Message });
                }
            }
            return RedirectToAction("Index", "Inicio");
        }

        public async Task<ActionResult> Eliminar(int id) {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                var Result = await LEmpleados.Eliminar(id, Sesion.accessToken);
                if (Result.StatusCode == 200) {
                    return Json(new { success = true, message = "Registro eliminado correctamente" });
                }
                else {
                    return Json(new { success = false, message = Result.Message });
                }
            }
            return RedirectToAction("Index", "Inicio");
        }

        public async Task<ActionResult> Buscar(string Cedula) {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                var Result = await LEmpleados.Buscar(Cedula, Sesion.accessToken);
                if (Result.StatusCode == 200) {
                    return Json(new { success = true, data = Result.ListModel.FirstOrDefault(), message = string.Empty });
                }
                else {
                    return Json(new { success = false, message = Result.Message });
                }
            }
            return RedirectToAction("Index", "Inicio");
        }

        public ActionResult Consulta() {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
    }
}