using System.ComponentModel.Design;
using System.Text.Json;
using System.Text;

namespace Biblioteca.Client.Services
{
    public class HttpService : IHttpService
    {
        public readonly HttpClient http;

        public HttpService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<HttpRespuesta<B>> Get<B>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DeserealizarRespuesta<B>(response);
                return new HttpRespuesta<B>(respuesta, false, response);

            }
            else
            {
                return new HttpRespuesta<B>(default, true, response);
            }
        }
        public async Task<HttpRespuesta<object>> Post<T>(string url, T enviar)
        {
            try
            {
                var enviarJson = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
                var respuesta = await http.PostAsync(url, enviarContent);
                return new HttpRespuesta<object>(null, !respuesta.IsSuccessStatusCode, respuesta);
            }
            catch (Exception e) { throw; }
        }

        public async Task<HttpRespuesta<object>> Put<T>(string url, T enviar)
        {
            try
            {
                var enviarJson = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
                var respuesta = await http.PutAsync(url, enviarContent);
                return new HttpRespuesta<object>(null, !respuesta.IsSuccessStatusCode, respuesta);

            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var respuesta = await http.DeleteAsync(url);
            return new HttpRespuesta<object>(null, !respuesta.IsSuccessStatusCode, respuesta);
        }
        private async Task<B> DeserealizarRespuesta<B>(HttpResponseMessage response)
        {
            var respuestastring = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<B>(respuestastring, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });



        }
    }
}

