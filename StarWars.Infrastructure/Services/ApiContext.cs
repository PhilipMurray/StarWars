using RestSharp;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Infrastructure.Services
{
    public class ApiContext : IApiContext
    {
        private readonly Uri baseUri = new Uri("https://swapi.dev/api/");

        readonly IRestClient _client;

        public ApiContext(IRestClient restClient)
        {
            _client = restClient;
            _client.BaseUrl = baseUri;
        }

        public string Get(string apiResource) 
        {
            var request = new RestRequest(apiResource, Method.GET);

            var response = _client.Execute(request);

            return response.Content;

        }
    }
}
