using Prueba.Models;

namespace Prueba.Interface
{
    public interface IPerfil
    {
        Task<List<PerfilModel>> Listar();
    }
}