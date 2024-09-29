using Prueba.Models;

namespace Prueba.Interface
{
    public interface ITiendas
    {
        Task<ResultClass<TiendasModel>> Agregar(TiendasModel model);

        Task<ResultClass<TiendasModel>> Actualizar(TiendasModel model);

        Task<ResultClass<TiendasModel>> Eliminar(int id);

        Task<ResultClass<TiendasModel>> Listar();
    }
}