using Prueba.Models;

namespace Prueba.Interface
{
    public interface IEmpleados
    {
        Task<ResultClass> Agregar(EmpleadosModel model);

        Task<ResultClass> Actualizar(EmpleadosModel model);

        Task<ResultClass> Eliminar(int id);

        Task<ResultClass> Listar();
    }
}