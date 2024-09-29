﻿using Newtonsoft.Json;
using Prueba.Models;

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

        public async Task<EmpleadosModel> Agregar(EmpleadosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Agregar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<EmpleadosModel>(objetoJson);
            return objeto;
        }

        public async Task<EmpleadosModel> Modificar(EmpleadosModel model, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestPOST(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Modificar), model, accessToken);
            var objeto = JsonConvert.DeserializeObject<EmpleadosModel>(objetoJson);
            return objeto;
        }

        public async Task<EmpleadosModel> Eliminar(string Id, string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Eliminar, Id), accessToken);
            var objeto = JsonConvert.DeserializeObject<EmpleadosModel>(objetoJson);
            return objeto;
        }

        public async Task<List<EmpleadosModel>> Listar(string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Empleados_Listar), accessToken);
            var objeto = JsonConvert.DeserializeObject<List<EmpleadosModel>>(objetoJson);
            return objeto;
        }
    }
}