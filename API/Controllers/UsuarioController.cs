using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarios _IUsuarios;

        public UsuarioController(IUsuarios IUsuarios) {
            _IUsuarios = IUsuarios;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<ResultClass<UsuariosModel>> Agregar(UsuariosModel modelo) {
            var Result = await _IUsuarios.Agregar(modelo);
            return Result;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<ResultClass<UsuariosModel>> Actualizar(UsuariosModel modelo) {
            var Result = await _IUsuarios.Actualizar(modelo);
            return Result;
        }

        [HttpGet]
        [Route("Eliminar")]
        public async Task<ResultClass<UsuariosModel>> Eliminar(int Id) {
            var Result = await _IUsuarios.Eliminar(Id);
            return Result;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ResultClass<UsuariosModel>> Listar() {
            var Lista = await _IUsuarios.Listar();
            return Lista;
        }
    }
}