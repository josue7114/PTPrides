using Prueba.Models;

namespace Prueba.Interface
{
    public interface IUsuarios
    {
        Task<ResultClass> Agregar(UsuariosModel model);

        Task<ResultClass> Actualizar(UsuariosModel model);

        Task<ResultClass> Eliminar(int id);

        Task<ResultClass> Listar();
    }
}