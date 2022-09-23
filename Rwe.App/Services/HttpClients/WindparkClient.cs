using Microsoft.Extensions.Options;
using Rwe.App.Abstractions;
using Rwe.App.Entities;
using System.Text.Json;

namespace Rwe.App.Services.HttpClients
{
    public class WindparkClient : IWindparkClient
    {
        private readonly HttpClient httpClient;
        private readonly ConfigOptions options;

        public WindparkClient(HttpClient httpClient, IOptions<ConfigOptions> options)
        {
            this.httpClient = httpClient;
            this.options = options.Value;
        }

        public async Task<IEnumerable<Park>> GetParks()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, options.WindparkApiLink);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<IEnumerable<Park>>(contentStream);
        }
    }
}