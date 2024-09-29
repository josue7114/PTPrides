using Prueba.Models.Models;

namespace Prueba.Models
{
    public class EmpleadosModel
    {
        public EmpleadosModel() {
        }

        public EmpleadosModel(Empleados ObjetoBD) {
            EmpleadoID = ObjetoBD.EmpleadoID;
            Nombre = ObjetoBD.Nombre;
            UsuarioID = ObjetoBD.UsuarioID;
            PerfilID = ObjetoBD.PerfilID;
            SupervisorID = ObjetoBD.SupervisorID;
            Telefono = ObjetoBD.Telefono;
            Fecha = ObjetoBD.Fecha;
            TipoEmpleado = ObjetoBD.TipoEmpleado;
            Salario = Convert.ToDouble(ObjetoBD.Salario);
        }

        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public int? UsuarioID { get; set; }
        public int? PerfilID { get; set; }
        public int? SupervisorID { get; set; }
        public string? Telefono { get; set; }
        public DateTime? Fecha { get; set; }
        public string? TipoEmpleado { get; set; }
        public double? Salario { get; set; }

        public Empleados ConvertToEmpleadosBD() {
            return new Empleados {
                EmpleadoID = EmpleadoID,
                Nombre = Nombre,
                UsuarioID = UsuarioID,
                PerfilID = PerfilID,
                SupervisorID = SupervisorID,
                Telefono = Telefono,
                Fecha = Fecha,
                TipoEmpleado = TipoEmpleado,
                Salario = Convert.ToDecimal(Salario)
            };
        }
    }
}