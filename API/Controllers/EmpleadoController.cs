using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;
using Prueba.Models.Models;

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
        public async Task<ResultClass<EmpleadosModel>> Agregar(EmpleadosModel modelo) {
            var Result = await _IEmpleados.Agregar(modelo);
            return Result;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<ResultClass<EmpleadosModel>> Actualizar(EmpleadosModel modelo) {
            var Result = await _IEmpleados.Actualizar(modelo);
            return Result;
        }

        [HttpGet]
        [Route("Eliminar")]
        public async Task<ResultClass<EmpleadosModel>> Eliminar(int Id) {
            var Result = await _IEmpleados.Eliminar(Id);
            return Result;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ResultClass<EmpleadosModel>> Listar() {
            var Lista = await _IEmpleados.Listar();
            return Lista;
        }

        [HttpGet]
        [Route("Buscar")]
        public async Task<ResultClass<ObtenerEmpleadosResult>> Buscar(string Cedula) {
            var Lista = await _IEmpleados.Buscar(Cedula);
            return Lista;
        }
    }
}