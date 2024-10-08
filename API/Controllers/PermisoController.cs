﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisos _IPermisos;

        public PermisoController(IPermisos IPermisos) {
            _IPermisos = IPermisos;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<ResultClass<PermisosModel>> Agregar(PermisosModel modelo) {
            var Result = await _IPermisos.Agregar(modelo);
            return Result;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<ResultClass<PermisosModel>> Actualizar(PermisosModel modelo) {
            var Result = await _IPermisos.Actualizar(modelo);
            return Result;
        }

        [HttpGet]
        [Route("Eliminar")]
        public async Task<ResultClass<PermisosModel>> Eliminar(int Id) {
            var Result = await _IPermisos.Eliminar(Id);
            return Result;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ResultClass<PermisosModel>> Listar() {
            var Lista = await _IPermisos.Listar();
            return Lista;
        }
    }
}