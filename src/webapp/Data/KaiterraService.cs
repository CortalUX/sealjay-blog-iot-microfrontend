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

        private string _uuid { get; }
        private string _apikey { get; }

        public KaiterraService(HttpClient client, IConfiguration configuration)
        {
            _uuid = configuration["Kaiterra:UUID"];
            _apikey = configuration["Kaiterra:ApiKey"];
            client.BaseAddress = new Uri("https://api.kaiterra.com/");

            Client = client;
        }
        public async Task<KaiterraResponse> GetTelemetry()
        {
            var response = await Client.GetAsync(
                "/v1/devices/" + _uuid + "/top?key=" + _apikey
                );

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var deserializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return await JsonSerializer.DeserializeAsync
                <KaiterraResponse>(responseStream, deserializeOptions);
        }
    }
}
