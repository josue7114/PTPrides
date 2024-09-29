using Prueba.Models;

namespace Prueba.Interface
{
    public interface ITiendas
    {
        Task<TiendasModel> Agregar(TiendasModel model);

        Task<TiendasModel> Actualizar(TiendasModel model);

        Task<TiendasModel> Eliminar(int id);

        Task<List<TiendasModel>> Listar();
    }
}