using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace webapp.Data
{
    public class KaiterraService
    {

        public HttpClient Client { get; }

        private string _uuid {get;}

        public KaiterraService(HttpClient client, IConfiguration configuration)
        {
            _uuid = configuration["Kaiterra:UUID"];
            client.BaseAddress = new Uri("https://api.kaiterra.com/");
            // Kaiterra requires an API key
            client.DefaultRequestHeaders.Add("key",
                configuration["Kaiterra:ApiKey"]);

            Client = client;
        }
        public async Task<KaiterraTelemetry[]> GetTelemetry()
        {
            var response = await Client.GetAsync(
                "/v1/devices/" + _uuid + "/top");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <KaiterraTelemetry[]>(responseStream);
        }
    }
}
