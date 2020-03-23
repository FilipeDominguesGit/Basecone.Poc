using Basecone.Poc.Api.Contracts.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Basecone.Poc.Client
{
    public class BaseconePocClient
    {
        private readonly HttpClient _client;

        public BaseconePocClient(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("x-custom-header", "Basecone");

        }

        public async Task<List<Office>> GetAllOffices()
        {
            var response =  await _client.GetStreamAsync("api/Office").ConfigureAwait(false);
            var offices = await JsonSerializer.DeserializeAsync<List<Office>>(response);

            return offices;
        }
    }
}
