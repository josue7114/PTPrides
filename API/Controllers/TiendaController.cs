﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Interface;
using Prueba.Models;

namespace API.Controllers
{
    [Authorize]
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
        public async Task<ResultClass<TiendasModel>> Agregar(TiendasModel modelo) {
            var Result = await _ITiendas.Agregar(modelo);
            return Result;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<ResultClass<TiendasModel>> Actualizar(TiendasModel modelo) {
            var Result = await _ITiendas.Actualizar(modelo);
            return Result;
        }

        [HttpGet]
        [Route("Eliminar")]
        public async Task<ResultClass<TiendasModel>> Eliminar(int Id) {
            var Result = await _ITiendas.Eliminar(Id);
            return Result;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Listar")]
        public async Task<ResultClass<TiendasModel>> Listar() {
            var Lista = await _ITiendas.Listar();
            return Lista;
        }
    }
}