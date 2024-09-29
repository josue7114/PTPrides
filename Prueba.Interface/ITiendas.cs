using Prueba.Models;

namespace Prueba.Interface
{
    public interface ITiendas
    {
        Task<ResultClass> Agregar(TiendasModel model);

        Task<ResultClass> Actualizar(TiendasModel model);

        Task<ResultClass> Eliminar(int id);

        Task<ResultClass> Listar();
    }
}