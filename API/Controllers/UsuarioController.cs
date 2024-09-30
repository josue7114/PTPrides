using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Prueba.Interface;
using Prueba.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarios _IUsuarios;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarios IUsuarios, IConfiguration configuration) {
            _IUsuarios = IUsuarios;
            _configuration = configuration;
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost]
        [Route("Validar")]
        public async Task<ResultClass<UsuariosModel>> Validar(LoginModel modelo) {
            var Result = await _IUsuarios.Validar(modelo);
            if (Result.StatusCode == 200) {
                Result.Model.Token = GenerateToken(Result.Model.Correo);
            }
            return Result;
        }

        private string GenerateToken(string username) {
            try {
                var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                var TokenGenerado = new JwtSecurityTokenHandler().WriteToken(token);
                return TokenGenerado;
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}