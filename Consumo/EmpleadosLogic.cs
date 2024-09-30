using Newtonsoft.Json;
using Prueba.Models;
using Prueba.Models.Models;

namespace Consumo
{
    public class EmpleadosLogic
    {
        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;

        public EmpleadosLogic() {
            Configuration = new ConfigurationAttribute();
            ServicesRequest = new WebServiceDataAccess();
        }

        public async Task<ResultClass<EmpleadosModel>> Agregar(EmpleadosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Agregar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass<EmpleadosModel>>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass<EmpleadosModel>> Modificar(EmpleadosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Modificar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass<EmpleadosModel>>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass<EmpleadosModel>> Eliminar(int Id, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Eliminar, Id.ToString()), accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass<EmpleadosModel>>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass<EmpleadosModel>> Listar(string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Listar), accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass<EmpleadosModel>>(objetoJson);
            return objeto;
        }

        public async Task<ResultClass<ObtenerEmpleadosResult>> Buscar(string Cedula, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Buscar, Cedula), accessToken);
            var objeto = JsonConvert.DeserializeObject<ResultClass<ObtenerEmpleadosResult>>(objetoJson);
            return objeto;
        }
    }
}