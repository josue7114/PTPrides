using Prueba.Models.Models;

namespace Prueba.Models
{
    public class PerfilModel
    {
        public PerfilModel() {
        }

        public PerfilModel(Perfil ObjetoBD) {
            PerfilID = ObjetoBD.PerfilID;
            NombrePerfil = ObjetoBD.NombrePerfil;
        }

        public int PerfilID { get; set; }
        public string NombrePerfil { get; set; }
    }
}