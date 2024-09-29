using Consumo;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;

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
            var Empleados = await LEmpleados.Listar("token");
            if (Empleados.StatusCode == 200) {
                return View(Empleados.ListModel);
            }
            return View(new List<EmpleadosModel>());
        }

        public async Task<ActionResult> ObtenerContenidoModal(int Parametro) {
            //var Tiendas = await LTiendas.Listar("token");
            var Perfiles = await LPerfil.Listar("token");
            var Supervisores = await LEmpleados.Listar("token");
            //if (Tiendas.StatusCode == 200) {
            //    ViewBag.Tiendas = Tiendas.ListModel;
            //}
            if (Perfiles.StatusCode == 200) {
                ViewBag.Perfil = Perfiles.ListModel;
            }
            if (Supervisores.StatusCode == 200) {
                ViewBag.Supervisores = Supervisores.ListModel.Where(m => m.SupervisorID == 0);
            }
            var Modelo = new EmpleadosModel();
            if (Parametro != 0) {
                var Empleados = await LEmpleados.Listar("token");
                if (Empleados.StatusCode == 200) {
                    Modelo = Empleados.ListModel.Where(m => m.EmpleadoID == Parametro).FirstOrDefault();
                    return PartialView("_modal", Modelo);
                }
            }
            return PartialView("_modal", Modelo);
        }

        public async Task<ActionResult> Consulta() {
            return View();
        }
    }
}