using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using Prueba.Models.Models;

namespace Prueba.DataAccess
{
    public class DAEmpleados
    {
        public async Task<EmpleadosModel> Agregar(EmpleadosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Add(model.ConvertToEmpleadosBD());
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<EmpleadosModel> Actualizar(EmpleadosModel model) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var entry = ContextoBD.Entry(model.ConvertToEmpleadosBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<EmpleadosModel> Eliminar(int id) {
            try {
                using (var ContextoBD = new P1700Context()) {
                    var objEliminado = ContextoBD.Empleados.FirstOrDefault(x => x.EmpleadoID == id);
                    if (objEliminado != null) {
                        ContextoBD.Empleados.Remove(objEliminado);
                        ContextoBD.SaveChanges();
                    }
                    return new EmpleadosModel(objEliminado);
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<List<EmpleadosModel>> Listar() {
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
                    return Lista;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}