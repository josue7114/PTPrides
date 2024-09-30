using Prueba.Models;

namespace Prueba.Interface
{
    public interface IPermisos
    {
        Task<ResultClass<PermisosModel>> Agregar(PermisosModel model);

        Task<ResultClass<PermisosModel>> Actualizar(PermisosModel model);

        Task<ResultClass<PermisosModel>> Eliminar(int id);

        Task<ResultClass<PermisosModel>> Listar();
    }
}