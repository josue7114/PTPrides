using Prueba.Models.Models;

namespace Prueba.Models
{
    public class TiendasModel
    {
        public TiendasModel() {
        }

        public TiendasModel(Tiendas ObjetoBD) {
            TiendaID = ObjetoBD.TiendaID;
            NombreTienda = ObjetoBD.NombreTienda;
        }

        public int TiendaID { get; set; }
        public string NombreTienda { get; set; }

        public Tiendas ConvertToTiendasBD() {
            return new Tiendas {
                TiendaID = TiendaID,
                NombreTienda = NombreTienda
            };
        }
    }
}