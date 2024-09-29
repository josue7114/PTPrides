using Prueba.Models;

namespace Prueba.Interface
{
    public interface IPermisos
    {
        Task<PermisosModel> Agregar(PermisosModel model);

        Task<PermisosModel> Actualizar(PermisosModel model);

        Task<PermisosModel> Eliminar(int id);

        Task<List<PermisosModel>> Listar();
    }
}