using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParksClient.Services;

namespace ParksClient.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public bool IsNational { get; set; }
    public int StateId { get; set; }

    public static List<Park> GetAll()
    {
      var apiCallTask = ParkApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Park> ParkList = JsonConvert.DeserializeObject<List<Park>>(jsonResponse.ToString());

      return ParkList;
    }

    public static Park Get(int id)
    {
      var apiCallTask = ParkApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      var Park = JsonConvert.DeserializeObject<Park>(jsonResponse.ToString());

      return Park;
    }
    public static List<Park> GetParks(string parkName, string stateName, string isNational, string region)
    {
      var apiCallTask = ParkApiHelper.Query(parkName, stateName, isNational, region);
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Park> ParkList = JsonConvert.DeserializeObject<List<Park>>(jsonResponse.ToString());
      return ParkList;
    }

    public static List<State> GetAllStates()
    {
      var apiCallTask = ParkApiHelper.GetAllStates();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<State> ParkList = JsonConvert.DeserializeObject<List<State>>(jsonResponse.ToString());

      return ParkList;
    }
    public static void Post(Park Park)
    {
      string jsonPark = JsonConvert.SerializeObject(Park);
      var apiCallTask = ParkApiHelper.Post(jsonPark);
    }

    public static void Put(Park Park)
    {
      string jsonPark = JsonConvert.SerializeObject(Park);
      var apiCallTask = ParkApiHelper.Put(Park.ParkId, jsonPark);
    }
    public static void Delete(int id)
    {
      var apiCallTask = ParkApiHelper.Delete(id);
    }
  }

}