using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DATiendas
    {
        public async Task<ResultClass<TiendasModel>> Agregar(TiendasModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToTiendasBD());
                    await ContextoBD.SaveChangesAsync();
                    return new ResultClass<TiendasModel> { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass<TiendasModel>> Actualizar(TiendasModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToTiendasBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return new ResultClass<TiendasModel> { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass<TiendasModel>> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var model = ContextoBD.Tiendas.FirstOrDefault(x => x.TiendaID == id);
                    if (model != null) {
                        ContextoBD.Tiendas.Remove(model);
                        ContextoBD.SaveChanges();
                    }
                    return new ResultClass<TiendasModel> { Model = new TiendasModel(model), StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass<TiendasModel>> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<TiendasModel> Lista = ContextoBD.Tiendas
                                            .Select(s => new TiendasModel() {
                                                TiendaID = s.TiendaID,
                                                NombreTienda = s.NombreTienda,
                                            }).ToList();
                    return new ResultClass<TiendasModel> { ListModel = Lista, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass<TiendasModel> { Model = new TiendasModel(), StatusCode = 400, Message = ex.Message };
            }
        }
    }
}