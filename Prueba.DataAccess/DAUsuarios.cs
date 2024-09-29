using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAUsuarios
    {
        public async Task<UsuariosModel> Agregar(UsuariosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToUsuariosBD());
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<UsuariosModel> Actualizar(UsuariosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToUsuariosBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<UsuariosModel> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var objEliminado = ContextoBD.Usuarios.FirstOrDefault(x => x.UsuarioID == id);
                    if (objEliminado != null) {
                        ContextoBD.Usuarios.Remove(objEliminado);
                        ContextoBD.SaveChanges();
                    }
                    return new UsuariosModel(objEliminado);
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<List<UsuariosModel>> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<UsuariosModel> Lista = ContextoBD.Usuarios
                                            .Select(s => new UsuariosModel() {
                                                UsuarioID = s.UsuarioID,
                                                Correo = s.Correo,
                                                Nombre = s.Nombre,
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