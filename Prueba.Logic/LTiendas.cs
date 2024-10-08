﻿using Prueba.DataAccess;
using Prueba.Interface;
using Prueba.Models;

namespace Prueba.Logic
{
    public class LTiendas : ITiendas
    {
        private DATiendas _DATiendas;

        public LTiendas() {
            _DATiendas = new DATiendas();
        }

        public async Task<ResultClass<TiendasModel>> Actualizar(TiendasModel model) {
            try {
                var Modelo = await _DATiendas.Actualizar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<TiendasModel>> Agregar(TiendasModel model) {
            try {
                var Modelo = await _DATiendas.Agregar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<TiendasModel>> Eliminar(int id) {
            try {
                var Modelo = await _DATiendas.Eliminar(id);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<TiendasModel>> Listar() {
            try {
                var Modelo = await _DATiendas.Listar();
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }
    }
}