using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAUsuarios
    {
        public async Task<ResultClass> Agregar(UsuariosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToUsuariosBD());
                    await ContextoBD.SaveChangesAsync();
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Actualizar(UsuariosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToUsuariosBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var model = ContextoBD.Usuarios.FirstOrDefault(x => x.UsuarioID == id);
                    if (model != null) {
                        ContextoBD.Usuarios.Remove(model);
                        ContextoBD.SaveChanges();
                    }
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<UsuariosModel> Lista = ContextoBD.Usuarios
                                            .Select(s => new UsuariosModel() {
                                                UsuarioID = s.UsuarioID,
                                                Correo = s.Correo,
                                                Nombre = s.Nombre,
                                            }).ToList();
                    return new ResultClass { Model = Lista, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new UsuariosModel(), StatusCode = 400, Message = ex.Message };
            }
        }
    }
}