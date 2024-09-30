using Prueba.Models;

namespace Prueba.Interface
{
    public interface IUsuarios
    {
        Task<ResultClass<UsuariosModel>> Agregar(UsuariosModel model);

        Task<ResultClass<UsuariosModel>> Actualizar(UsuariosModel model);

        Task<ResultClass<UsuariosModel>> Eliminar(int id);

        Task<ResultClass<UsuariosModel>> Listar();

        Task<ResultClass<UsuariosModel>> Validar(LoginModel Model);
    }
}