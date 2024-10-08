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

        public async Task<ResultClass<PerfilModel>> Listar() {
            var objetoJson = await ServicesRequest.DataRequestGET(
                Configuration.GetRouteAttribute(AppSettings.Perfiles_Listar));
            var objeto = JsonConvert.DeserializeObject<ResultClass<PerfilModel>>(objetoJson);
            return objeto;
        }
    }
}