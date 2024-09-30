using Consumo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prueba.Models;
using Prueba.Models.Models;
using System.Security.Claims;
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
            var Result = await LUsuarios.Validar(Modelo);
            if (Result.StatusCode == 200) {
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, Result.Model.Nombre),
                            new Claim("AccessToken", Result.Model.Token),
                            new Claim("IdUsuario", Result.Model.UsuarioID.ToString()),
                            new Claim("Correo", Modelo.Correo),
                        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties {
                    }
                );
                return Json(new { success = true });
            }
            else {
                return Json(new { success = false, message = Result.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CerrarSesion() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Inicio");
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarUsuario(UsuariosModel Modelo) {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                Modelo.Contrasena = Utilidades.GetSHA256(Modelo.Contrasena);
                var Result = await LUsuarios.Agregar(Modelo, Sesion.accessToken);
                if (Result.StatusCode == 200) {
                    var Result2 = await LEmpleados.Agregar(new EmpleadosModel { Fecha = DateTime.Today, Nombre = Modelo.Nombre, PerfilID = Modelo.PerfilID, Salario = 0 }, Sesion.accessToken);
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
            return RedirectToAction("Index", "Inicio");
        }

        public async Task<ActionResult> ObtenerContenidoModal(int Parametro) {
            var Sesion = Utilidades.ValidarSession(HttpContext);
            if (Sesion.esValida) {
                var Tiendas = await LTiendas.Listar(Sesion.accessToken);
                var Perfiles = await LPerfil.Listar(Sesion.accessToken);
                if (Tiendas.StatusCode == 200) {
                    ViewBag.Tiendas = Tiendas.ListModel;
                }
                if (Perfiles.StatusCode == 200) {
                    ViewBag.Perfil = Perfiles.ListModel;
                }
                return PartialView("_modal", new UsuariosModel());
            }
            return RedirectToAction("Index", "Inicio");
        }
    }
}