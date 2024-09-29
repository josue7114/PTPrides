using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAPermisos
    {
        public async Task<PermisosModel> Agregar(PermisosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToPermisosBD());
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<PermisosModel> Actualizar(PermisosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToPermisosBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<PermisosModel> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var objEliminado = ContextoBD.Permisos.FirstOrDefault(x => x.PermisoID == id);
                    if (objEliminado != null) {
                        ContextoBD.Permisos.Remove(objEliminado);
                        ContextoBD.SaveChanges();
                    }
                    return new PermisosModel(objEliminado);
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<List<PermisosModel>> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<PermisosModel> Lista = ContextoBD.Permisos
                                            .Select(s => new PermisosModel() {
                                                NombrePermiso = s.NombrePermiso,
                                                PerfilID = s.PerfilID,
                                                PermisoID = s.PermisoID,
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