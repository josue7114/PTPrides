using Prueba.DataAccess;
using Prueba.Interface;
using Prueba.Models;

namespace Prueba.Logic
{
    public class LEmpleados : IEmpleados
    {
        private DAEmpleados _DAEmpleados;

        public LEmpleados() {
            _DAEmpleados = new DAEmpleados();
        }

        public async Task<ResultClass<EmpleadosModel>> Actualizar(EmpleadosModel model) {
            try {
                var Modelo = await _DAEmpleados.Actualizar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<EmpleadosModel>> Agregar(EmpleadosModel model) {
            try {
                var Modelo = await _DAEmpleados.Agregar(model);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<EmpleadosModel>> Eliminar(int id) {
            try {
                var Modelo = await _DAEmpleados.Eliminar(id);
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<ResultClass<EmpleadosModel>> Listar() {
            try {
                var Modelo = await _DAEmpleados.Listar();
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }
    }
}