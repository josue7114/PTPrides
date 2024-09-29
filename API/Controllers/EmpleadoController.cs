using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleados _IEmpleados;

        public EmpleadoController(IEmpleados IEmpleados) {
            _IEmpleados = IEmpleados;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<EmpleadosModel> Agregar(EmpleadosModel modelo) {
            var Result = await _IEmpleados.Agregar(modelo);
            return Result;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<EmpleadosModel> Actualizar(EmpleadosModel modelo) {
            var Result = await _IEmpleados.Actualizar(modelo);
            return Result;
        }

        [HttpGet]
        [Route("Eliminar")]
        public async Task<EmpleadosModel> Eliminar(int Id) {
            var Result = await _IEmpleados.Eliminar(Id);
            return Result;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<List<EmpleadosModel>> Listar() {
            var Lista = await _IEmpleados.Listar();
            return Lista;
        }
    }
}