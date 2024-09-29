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

        public async Task<TiendasModel> Agregar(TiendasModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Agregar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<TiendasModel>(objetoJson);
            return objeto;
        }

        public async Task<TiendasModel> Modificar(TiendasModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Modificar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<TiendasModel>(objetoJson);
            return objeto;
        }

        public async Task<TiendasModel> Eliminar(string Id, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Eliminar, Id), accessToken);
            var objeto = JsonConvert.DeserializeObject<TiendasModel>(objetoJson);
            return objeto;
        }

        public async Task<List<TiendasModel>> Listar(string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Tiendas_Listar), accessToken);
            var objeto = JsonConvert.DeserializeObject<List<TiendasModel>>(objetoJson);
            return objeto;
        }
    }
}