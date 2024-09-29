using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAPerfil
    {
        public async Task<List<PerfilModel>> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<PerfilModel> Lista = ContextoBD.Perfil
                                            .Select(s => new PerfilModel() {
                                                NombrePerfil = s.NombrePerfil,
                                                PerfilID = s.PerfilID
                                            }).ToList();
                    return Lista;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}