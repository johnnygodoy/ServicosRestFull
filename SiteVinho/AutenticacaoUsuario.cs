using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace SiteVinho
{
    public static class AutenticacaoUsuario
    {
        public static string username = "joao.godoy";
        public static string password = "joao.godoy";
        public static string token = "";

        public static async Task<string> getToken()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7215/Login");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress.ToString());

                request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {

                    {"username",username},
                    {"password",password},
                    {"grant_type","password"}
                
                });

                var response = await client.SendAsync(request);

                var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

                var token = payload.Value<string>("access_token");

                return token;
            }
        }
    }
}
