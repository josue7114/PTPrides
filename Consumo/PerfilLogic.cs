﻿using Newtonsoft.Json;
using Prueba.Models;

namespace Consumo
{
    public class PerfilLogic
    {
        private WebServiceDataAccess ServicesRequest;
        private ConfigurationAttribute Configuration;

        public PerfilLogic() {
            Configuration = new ConfigurationAttribute();
            ServicesRequest = new WebServiceDataAccess();
        }

        public async Task<List<PerfilModel>> Listar(string? accessToken) {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Perfiles_Listar), accessToken);
            var objeto = JsonConvert.DeserializeObject<List<PerfilModel>>(objetoJson);
            return objeto;
        }
    }
}