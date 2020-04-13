using System.Threading.Tasks;
using RestSharp;
using System;

namespace ParksClient.Helpers
{
  class UserApi
  {
    public static async Task<string> AuthenticateUser(string email, string password)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"users?{email}&{password}", Method.GET);
      var response = await client.ExecuteAsync(request);
      return response.Content;
    }
    public static async Task Post(string user)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"users/register", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(user);
      var response = await client.ExecuteAsync(request);
    }
    public static async Task Put(int id, string user)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"users/{id}", Method.PUT);

      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(user);
      var response = await client.ExecuteAsync(request);
    }
    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"users/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteAsync(request);
    }
  }
}