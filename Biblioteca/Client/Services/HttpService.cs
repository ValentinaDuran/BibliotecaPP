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
        public async Task<HttpRespuesta<B>>Get<B>(string url)
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
        private async Task<T> DeserealizarRespuesta<T>(HttpResponseMessage response)
        {
            var respuestaStr = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonSerializer.Deserialize<T>(respuestaStr,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Error de deserialización: {jsonEx.Message}");
                Console.WriteLine($"JSON: {respuestaStr}");
                throw; // Lanza la excepción nuevamente para que cualquier llamador también pueda manejarla si es necesario.
            }
        }

    }
    }


