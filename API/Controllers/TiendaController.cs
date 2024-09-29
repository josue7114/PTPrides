using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendas _ITiendas;

        public TiendaController(ITiendas ITiendas) {
            _ITiendas = ITiendas;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<TiendasModel> Agregar(TiendasModel modelo) {
            var Result = await _ITiendas.Agregar(modelo);
            return Result;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<TiendasModel> Actualizar(TiendasModel modelo) {
            var Result = await _ITiendas.Actualizar(modelo);
            return Result;
        }

        [HttpGet]
        [Route("Eliminar")]
        public async Task<TiendasModel> Eliminar(int Id) {
            var Result = await _ITiendas.Eliminar(Id);
            return Result;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<List<TiendasModel>> Listar() {
            var Lista = await _ITiendas.Listar();
            return Lista;
        }
    }
}