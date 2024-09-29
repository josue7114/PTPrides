using Prueba.Models.Models;

namespace Prueba.Models
{
    public class PermisosModel
    {
        public PermisosModel() {
        }

        public PermisosModel(Permisos ObjetoBD) {
            PermisoID = ObjetoBD.PermisoID;
            NombrePermiso = ObjetoBD.NombrePermiso;
            PerfilID = ObjetoBD.PerfilID;
        }

        public int PermisoID { get; set; }
        public string NombrePermiso { get; set; }
        public int? PerfilID { get; set; }

        public Permisos ConvertToPermisosBD() {
            return new Permisos {
                PerfilID = PerfilID,
                PermisoID = PermisoID,
                NombrePermiso = NombrePermiso
            };
        }
    }
}