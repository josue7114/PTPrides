using Prueba.Models;

namespace Prueba.Interface
{
    public interface IEmpleados
    {
        Task<EmpleadosModel> Agregar(EmpleadosModel model);

        Task<EmpleadosModel> Actualizar(EmpleadosModel model);

        Task<EmpleadosModel> Eliminar(int id);

        Task<List<EmpleadosModel>> Listar();
    }
}