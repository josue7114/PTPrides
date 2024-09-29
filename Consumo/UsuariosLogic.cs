using Newtonsoft.Json;
using Prueba.Models;

namespace Consumo
{
    public class UsuariosLogic
    {
        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;

        public UsuariosLogic() {
            Configuration = new ConfigurationAttribute();
            ServicesRequest = new WebServiceDataAccess();
        }

        public async Task<UsuariosModel> Agregar(UsuariosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Usuarios_Agregar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<UsuariosModel>(objetoJson);
            return objeto;
        }

        public async Task<UsuariosModel> Modificar(UsuariosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Usuarios_Modificar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<UsuariosModel>(objetoJson);
            return objeto;
        }

        public async Task<UsuariosModel> Eliminar(string Id, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Usuarios_Eliminar, Id), accessToken);
            var objeto = JsonConvert.DeserializeObject<UsuariosModel>(objetoJson);
            return objeto;
        }

        public async Task<List<UsuariosModel>> Listar(string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Usuarios_Listar), accessToken);
            var objeto = JsonConvert.DeserializeObject<List<UsuariosModel>>(objetoJson);
            return objeto;
        }
    }
}