using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Consumo
{
    public class WebServiceDataAccess
    {
        private HttpResponseMessage RespuestaAPI;

        public WebServiceDataAccess() {
            RespuestaAPI = new HttpResponseMessage();
        }

        public async Task<string> DataRequestGET(string URL) {
            using (HttpClient Cliente = new HttpClient()) {
                Cliente.BaseAddress = new Uri(URL);
                Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                RespuestaAPI = await Cliente.GetAsync(URL);
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();
                return ContentResult;
            }
        }

        public async Task<string> DataRequestGET(string URL, string Token) {
            using (HttpClient Cliente = new HttpClient()) {
                Cliente.BaseAddress = new Uri(URL);
                Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                RespuestaAPI = await Cliente.GetAsync(URL);
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();
                return ContentResult;
            }
        }

        public async Task<string> DataRequestPOST(string URL, object Model) {
            using (HttpClient Cliente = new HttpClient()) {
                Cliente.BaseAddress = new Uri(URL);
                HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");
                RespuestaAPI = await Cliente.PostAsync(URL, ContentModel);
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();
                return ContentResult;
            }
        }

        public async Task<string> DataRequestPOST(string URL, object Model, string Token) {
            using (HttpClient Cliente = new HttpClient()) {
                Cliente.BaseAddress = new Uri(URL);
                Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");
                RespuestaAPI = await Cliente.PostAsync(URL, ContentModel);
                string ContentResult = await RespuestaAPI.Content.ReadAsStringAsync();
                return ContentResult;
            }
        }
    }
}