using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestCore
{
    class RestAPI
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseURL = "https://pokeapi.co/api/v2";

        public static RestClient SetUrl(string endpoint)
        {

            var url = baseURL + endpoint;

            return client = new RestClient(url);
        }

        public static RestRequest CreateRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");

            return restRequest;
        }
        public static IRestResponse GetRestResponse()
        {
            return client.Execute(restRequest);

        }

    }
}
