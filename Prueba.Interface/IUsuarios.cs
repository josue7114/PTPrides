using Prueba.Models;

namespace Prueba.Interface
{
    public interface IUsuarios
    {
        Task<UsuariosModel> Agregar(UsuariosModel model);

        Task<UsuariosModel> Actualizar(UsuariosModel model);

        Task<UsuariosModel> Eliminar(int id);

        Task<List<UsuariosModel>> Listar();
    }
}