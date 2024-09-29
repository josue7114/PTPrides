using Prueba.Models.Models;

namespace Prueba.Models
{
    public class UsuariosModel
    {
        public UsuariosModel() {
        }

        public UsuariosModel(Usuarios ObjetoBd) {
            UsuarioID = ObjetoBd.UsuarioID;
            Nombre = ObjetoBd.Nombre;
            Correo = ObjetoBd.Correo;
            Contrasena = ObjetoBd.Contrasena;
        }

        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public Usuarios ConvertToUsuariosBD() {
            return new Usuarios {
                Contrasena = Contrasena,
                UsuarioID = UsuarioID,
                Nombre = Nombre,
                Correo = Correo
            };
        }
    }
}