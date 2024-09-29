namespace Consumo
{
    public class ConfigurationAttribute
    {
        public ConfigurationAttribute() {
        }

        public string GetRouteAttribute(string RouteAttribute) {
            return RouteAttribute;
        }

        public string GetRouteAttribute(string RouteAttribute, string Parametro) {
            RouteAttribute = RouteAttribute.Replace("[Parametro1]", Parametro);

            return RouteAttribute;
        }

        public string GetRouteAttribute(string RouteAttribute, string ParametroI, string ParametroII) {
            RouteAttribute = RouteAttribute.Replace("[Parametro1]", ParametroI);
            RouteAttribute = RouteAttribute.Replace("[Y]", "&");
            RouteAttribute = RouteAttribute.Replace("[Parametro2]", ParametroII);

            return RouteAttribute;
        }
    }
}