using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAEmpleados
    {
        public async Task<ResultClass> Agregar(EmpleadosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToEmpleadosBD());
                    await ContextoBD.SaveChangesAsync();

                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Actualizar(EmpleadosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToEmpleadosBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var model = ContextoBD.Empleados.FirstOrDefault(x => x.EmpleadoID == id);
                    if (model != null) {
                        ContextoBD.Empleados.Remove(model);
                        ContextoBD.SaveChanges();
                    }
                    return new ResultClass { Model = model, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 400, Message = ex.Message };
            }
        }

        public async Task<ResultClass> Listar() {
            try {
                using (var ContextoBD = new P1700Context()) {
                    List<EmpleadosModel> Lista = ContextoBD.Empleados
                                            .Select(s => new EmpleadosModel() {
                                                EmpleadoID = s.EmpleadoID,
                                                Nombre = s.Nombre,
                                                UsuarioID = s.UsuarioID,
                                                PerfilID = s.PerfilID,
                                                SupervisorID = s.SupervisorID,
                                                Telefono = s.Telefono,
                                                Fecha = s.Fecha,
                                                TipoEmpleado = s.TipoEmpleado,
                                                Salario = Convert.ToDouble(s.Salario),
                                            }).ToList();
                    return new ResultClass { Model = Lista, StatusCode = 200, Message = string.Empty };
                }
            }
            catch (DbUpdateException ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 500, Message = ex.Message };
            }
            catch (Exception ex) {
                return new ResultClass { Model = new EmpleadosModel(), StatusCode = 400, Message = ex.Message };
            }
        }
    }
}