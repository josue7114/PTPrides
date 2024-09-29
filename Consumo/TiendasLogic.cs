using Newtonsoft.Json;
using Prueba.Models;

namespace Consumo
{
    public class TiendasLogic
    {
        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;

        public TiendasLogic() {
            Configuration = new ConfigurationAttribute();
            ServicesRequest = new WebServiceDataAccess();
        }

        public async Task<ResultClass> Agregar(TiendasModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Agregar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass> Modificar(TiendasModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Modificar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass> Eliminar(string Id, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Eliminar, Id), accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass> Listar(string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Listar), accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }
    }
}