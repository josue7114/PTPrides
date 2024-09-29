using Prueba.Models;

namespace Prueba.Interface
{
    public interface IEmpleados
    {
        Task<ResultClass<EmpleadosModel>> Agregar(EmpleadosModel model);

        Task<ResultClass<EmpleadosModel>> Actualizar(EmpleadosModel model);

        Task<ResultClass<EmpleadosModel>> Eliminar(int id);

        Task<ResultClass<EmpleadosModel>> Listar();
    }
}