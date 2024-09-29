using Prueba.DataAccess;
using Prueba.Interface;
using Prueba.Models;

namespace Prueba.Logic
{
    public class LUsuarios : IUsuarios
    {
        private DAUsuarios _DAUsuarios;

        public LUsuarios() {
            _DAUsuarios = new DAUsuarios();
        }

        public async Task<UsuariosModel> Actualizar(UsuariosModel model) {
            try {
                var Modelo = await _DAUsuarios.Actualizar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<UsuariosModel> Agregar(UsuariosModel model) {
            try {
                var Modelo = await _DAUsuarios.Agregar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<UsuariosModel> Eliminar(int id) {
            try {
                var Modelo = await _DAUsuarios.Eliminar(id);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<List<UsuariosModel>> Listar() {
            try {
                var Modelo = await _DAUsuarios.Listar();
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }
    }
}