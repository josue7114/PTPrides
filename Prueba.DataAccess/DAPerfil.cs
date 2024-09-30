using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAPerfil
    {
        public async Task<ResultClass<PerfilModel>> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<PerfilModel> Lista = ContextoBD.Perfil
                                            .Select(s => new PerfilModel() {
                                                NombrePerfil = s.NombrePerfil,
                                                PerfilID = s.PerfilID
                                            }).ToList();
                    return new ResultClass<PerfilModel> { ListModel = Lista, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass<PerfilModel> { Model = new PerfilModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass<PerfilModel> { Model = new PerfilModel(), StatusCode = 400, Message = ex.Message };
            }
        }
    }
}