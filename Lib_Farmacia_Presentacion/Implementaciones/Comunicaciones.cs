using Lib_Farmacia_Presentacion.interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
        public async Task<T> Ejecutar<T>(string url, object entidad)
        {
            url = "http://localhost:5000/" + url;

            var body = new StringContent(
                JsonConvert.SerializeObject(entidad),
                Encoding.UTF8, "application/json");

            var cliente_http = new HttpClient();
            cliente_http.Timeout = new TimeSpan(0, 4, 0);

            var message = await cliente_http.PostAsync(url, body);

            if (!message.IsSuccessStatusCode)
            {
                // Leer el mensaje de error que mandó la API
                var error = await message.Content.ReadAsStringAsync();
                var primeraLinea = error.Split('\n')[0].Trim();   // ej: "System.Exception: No se puede borrar..."
                var indice = primeraLinea.IndexOf(": ");
                if (indice >= 0)
                    primeraLinea = primeraLinea.Substring(indice + 2);

                throw new Exception(string.IsNullOrEmpty(primeraLinea) ? "Error Comunicacion" : primeraLinea);
            }

            var respuesta = await message.Content.ReadAsStringAsync();
            cliente_http.Dispose();
            cliente_http = null;

            respuesta = Replace(respuesta);
            return JsonConvert.DeserializeObject<T>(respuesta)!;
        }

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
                .Replace("\\r\\n", "")
                .Replace("\\", "")
                .Replace("\\\"", "\"")
                .Replace("\"", "'")
                .Replace("'[", "[")
                .Replace("]'", "]")
                .Replace("'{'", "{'")
                .Replace("\\\\", "\\")
                .Replace("'}'", "'}")
                .Replace("}'", "}")
                .Replace("\\n", "")
                .Replace("\\r", "")
                .Replace("    ", "")
                .Replace("'{", "{")
                .Replace("\"", "")
                .Replace("  ", "")
                .Replace("null", "''");
        }
    }
}