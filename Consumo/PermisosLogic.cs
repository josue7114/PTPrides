using Newtonsoft.Json;
using Prueba.Models;

namespace Consumo
{
    public class PermisosLogic
    {
        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;

        public PermisosLogic() {
            Configuration = new ConfigurationAttribute();
            ServicesRequest = new WebServiceDataAccess();
        }

        public async Task<ResultClass> Agregar(PermisosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Permisos_Agregar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass> Modificar(PermisosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Permisos_Modificar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass> Eliminar(string Id, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Permisos_Eliminar, Id), accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass> Listar(string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Permisos_Listar), accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass>(objetoJson);
            return objeto;
        }
    }
}