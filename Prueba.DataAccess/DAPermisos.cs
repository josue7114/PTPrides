using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAPermisos
    {
        public async Task<ResultClass> Agregar(PermisosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToPermisosBD());
                    await ContextoBD.SaveChangesAsync();
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Actualizar(PermisosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToPermisosBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var model = ContextoBD.Permisos.FirstOrDefault(x => x.PermisoID == id);
                    if (model != null) {
                        ContextoBD.Permisos.Remove(model);
                        ContextoBD.SaveChanges();
                    }
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<PermisosModel> Lista = ContextoBD.Permisos
                                            .Select(s => new PermisosModel() {
                                                NombrePermiso = s.NombrePermiso,
                                                PerfilID = s.PerfilID,
                                                PermisoID = s.PermisoID,
                                            }).ToList();
                    return new ResultClass { Model = Lista, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new PermisosModel(), StatusCode = 400, Message = ex.Message };
            }
        }
    }
}