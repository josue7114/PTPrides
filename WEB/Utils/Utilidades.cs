using Prueba.Models;
using System.Security.Cryptography;
using System.Text;

namespace WEB.Utils
{
    public class Utilidades
    {
        public static ValidaSessionModel ValidarSession(HttpContext HttpContext) {
            var claims = HttpContext.User.Claims;
            var accessToken = claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value;

            if (HttpContext.User.Identity.IsAuthenticated) {
                if (accessToken != null) {
                    return new ValidaSessionModel { esValida = true, accessToken = accessToken };
                }
                else {
                    return new ValidaSessionModel { esValida = false, accessToken = accessToken };
                }
            }
            else {
                return new ValidaSessionModel { esValida = false, accessToken = accessToken };
            }
        }

        public static string GetSHA256(string str) {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}