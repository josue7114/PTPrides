using Prueba.Models;

namespace Prueba.Interface
{
    public interface IPermisos
    {
        Task<ResultClass> Agregar(PermisosModel model);

        Task<ResultClass> Actualizar(PermisosModel model);

        Task<ResultClass> Eliminar(int id);

        Task<ResultClass> Listar();
    }
}