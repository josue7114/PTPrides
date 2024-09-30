using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _IPerfil;

        public PerfilController(IPerfil IPerfil) {
            _IPerfil = IPerfil;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Listar")]
        public async Task<ResultClass<PerfilModel>> Listar() {
            var Lista = await _IPerfil.Listar();
            return Lista;
        }
    }
}