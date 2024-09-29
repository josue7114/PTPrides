using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DATiendas
    {
        public async Task<TiendasModel> Agregar(TiendasModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToTiendasBD());
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<TiendasModel> Actualizar(TiendasModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToTiendasBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<TiendasModel> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var objEliminado = ContextoBD.Tiendas.FirstOrDefault(x => x.TiendaID == id);
                    if (objEliminado != null) {
                        ContextoBD.Tiendas.Remove(objEliminado);
                        ContextoBD.SaveChanges();
                    }
                    return new TiendasModel(objEliminado);
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<List<TiendasModel>> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<TiendasModel> Lista = ContextoBD.Tiendas
                                            .Select(s => new TiendasModel() {
                                                TiendaID = s.TiendaID,
                                                NombreTienda = s.NombreTienda,
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