using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _IPerfil;

        public PerfilController(IPerfil IPerfil) {
            _IPerfil = IPerfil;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<List<PerfilModel>> Listar() {
            var Lista = await _IPerfil.Listar();
            return Lista;
        }
    }
}