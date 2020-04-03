using System.Threading.Tasks;
using RestSharp;
using System;

namespace ParksClient.Services
{
  class ParkApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5005/api");
      RestRequest request = new RestRequest($"parks", Method.GET);
      var response = await client.ExecuteAsync(request);
      return response.Content;
    }
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5005/api");
      RestRequest request = new RestRequest($"parks/{id}", Method.GET);
      var response = await client.ExecuteAsync(request);
      return response.Content;
    }

    public static async Task<string> GetAllStates()
    {
      RestClient client = new RestClient("http://localhost:5005/api");
      RestRequest request = new RestRequest($"states", Method.GET);
      var response = await client.ExecuteAsync(request);
      return response.Content;
    }
    public static async Task<string> Query(string parkName, string stateName, string isNational, string region)
    {
      RestClient client = new RestClient("http://localhost:5005/api");
      RestRequest request = new RestRequest($"parks/search?parkName={parkName}&stateName={stateName}&isNational={isNational}&region={region}", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteAsync(request);
      Console.WriteLine("In apihelper search, response value: " + response);
      return response.Content;
    }
    public static async Task Post(string newDestination)
    {
      RestClient client = new RestClient("http://localhost:5005/api");
      RestRequest request = new RestRequest($"parks", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newDestination);
      var response = await client.ExecuteAsync(request);
    }
    public static async Task Put(int id, string newDestination)
    {
      RestClient client = new RestClient("http://localhost:5005/api");
      RestRequest request = new RestRequest($"parks/{id}", Method.PUT);

      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newDestination);
      var response = await client.ExecuteAsync(request);
    }
    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5005/api");
      RestRequest request = new RestRequest($"parks/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteAsync(request);
    }
  }
}