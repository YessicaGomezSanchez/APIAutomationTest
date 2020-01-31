using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using APITestCore.Models;

namespace APITestCore.Steps
{
    [Binding]
    public class PokemonSteps
    {
        [Given(@"I have access to the API (.*)")]
        public void GivenIHaveAccessToTheAPIPokemon(string endpoint)
        {
            RestAPI.SetUrl(endpoint);
        }

        [When(@"I send the request of api")]
        public void WhenISendTheRequestOfApi()
        {
            RestAPI.CreateRequest();
        }

        [Then(@"the result should be the information about the pokemons created")]
        public void ThenTheResultShouldBeTheInformationAboutThePokemonsCreated()
        {
            var apiResponse = RestAPI.GetRestResponse();
           
            Console.WriteLine("Respuesta de la API", apiResponse.Content);

            var expected = "{\"count\":964,\"next\":\"https://pokeapi.co/api/v2/pokemon/?offset=20&limit=20\",\"previous\":null,\"results\":[{\"name\":\"bulbasaur\",\"url\":\"https://pokeapi.co/api/v2/pokemon/1/\"},{\"name\":\"ivysaur\",\"url\":\"https://pokeapi.co/api/v2/pokemon/2/\"},{\"name\":\"venusaur\",\"url\":\"https://pokeapi.co/api/v2/pokemon/3/\"},{\"name\":\"charmander\",\"url\":\"https://pokeapi.co/api/v2/pokemon/4/\"},{\"name\":\"charmeleon\",\"url\":\"https://pokeapi.co/api/v2/pokemon/5/\"},{\"name\":\"charizard\",\"url\":\"https://pokeapi.co/api/v2/pokemon/6/\"},{\"name\":\"squirtle\",\"url\":\"https://pokeapi.co/api/v2/pokemon/7/\"},{\"name\":\"wartortle\",\"url\":\"https://pokeapi.co/api/v2/pokemon/8/\"},{\"name\":\"blastoise\",\"url\":\"https://pokeapi.co/api/v2/pokemon/9/\"},{\"name\":\"caterpie\",\"url\":\"https://pokeapi.co/api/v2/pokemon/10/\"},{\"name\":\"metapod\",\"url\":\"https://pokeapi.co/api/v2/pokemon/11/\"},{\"name\":\"butterfree\",\"url\":\"https://pokeapi.co/api/v2/pokemon/12/\"},{\"name\":\"weedle\",\"url\":\"https://pokeapi.co/api/v2/pokemon/13/\"},{\"name\":\"kakuna\",\"url\":\"https://pokeapi.co/api/v2/pokemon/14/\"},{\"name\":\"beedrill\",\"url\":\"https://pokeapi.co/api/v2/pokemon/15/\"},{\"name\":\"pidgey\",\"url\":\"https://pokeapi.co/api/v2/pokemon/16/\"},{\"name\":\"pidgeotto\",\"url\":\"https://pokeapi.co/api/v2/pokemon/17/\"},{\"name\":\"pidgeot\",\"url\":\"https://pokeapi.co/api/v2/pokemon/18/\"},{\"name\":\"rattata\",\"url\":\"https://pokeapi.co/api/v2/pokemon/19/\"},{\"name\":\"raticate\",\"url\":\"https://pokeapi.co/api/v2/pokemon/20/\"}]}";
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Modelo Respuesta = JsonConvert.DeserializeObject<Modelo>(apiResponse.Content);
                Modelo st = JsonConvert.DeserializeObject<Modelo>(expected);
                var results = Respuesta.results[0];

                Assert.That(apiResponse.Content, Is.EqualTo(expected), "error mensaje");
                

            }
        }
    }
}
