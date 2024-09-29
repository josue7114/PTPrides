using Prueba.DataAccess;
using Prueba.Interface;
using Prueba.Models;

namespace Prueba.Logic
{
    public class LPerfil : IPerfil
    {
        private DAPerfil _DAPerfil;

        public LPerfil() {
            _DAPerfil = new DAPerfil();
        }

        public async Task<ResultClass<PerfilModel>> Listar() {
            try {
                var Modelo = await _DAPerfil.Listar();
                return Modelo;
            }
            catch (Exception) {
                throw;
            }
        }
    }
}