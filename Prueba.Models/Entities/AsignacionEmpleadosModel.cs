using Prueba.Models.Models;

namespace Prueba.Models
{
    public class AsignacionEmpleadosModel
    {
        public AsignacionEmpleadosModel() {
        }

        public AsignacionEmpleadosModel(AsignacionEmpleados ObjetoBd) {
            AsignacionID = ObjetoBd.AsignacionID;
            EmpleadoID = ObjetoBd.EmpleadoID;
            TiendaID = ObjetoBd.TiendaID;
            Fecha = ObjetoBd.Fecha;
        }

        public int AsignacionID { get; set; }
        public int? EmpleadoID { get; set; }
        public int? TiendaID { get; set; }
        public DateTime Fecha { get; set; }

        public AsignacionEmpleados ConvertToAsignacionBD() {
            return new AsignacionEmpleados {
                Fecha = Convert.ToDateTime(Fecha),
                AsignacionID = AsignacionID,
                EmpleadoID = EmpleadoID,
                TiendaID = TiendaID
            };
        }
    }
}