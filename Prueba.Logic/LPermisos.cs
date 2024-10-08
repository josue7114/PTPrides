﻿using Prueba.DataAccess;
using Prueba.Interface;
using Prueba.Models;

namespace Prueba.Logic
{
    public class LPermisos : IPermisos
    {
        private DAPermisos _DAPermisos;

        public LPermisos() {
            _DAPermisos = new DAPermisos();
        }

        public async Task<ResultClass<PermisosModel>> Actualizar(PermisosModel model) {
            try {
                var Modelo = await _DAPermisos.Actualizar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<PermisosModel>> Agregar(PermisosModel model) {
            try {
                var Modelo = await _DAPermisos.Agregar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<PermisosModel>> Eliminar(int id) {
            try {
                var Modelo = await _DAPermisos.Eliminar(id);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<PermisosModel>> Listar() {
            try {
                var Modelo = await _DAPermisos.Listar();
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }
    }
}