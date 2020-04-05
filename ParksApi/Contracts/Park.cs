using ParksApi.Entities;
using System.Collections.Generic;

namespace ParksApi.Contracts
{
  public interface IParkRepository : IRepositoryBase<Park>
  {
    Park GetParkById(int id);
    IEnumerable<Park> GetAllParks();
    IEnumerable<Park> GetParksQuery(string parkName, string stateName, string isNational, string region);
    void CreatePark(Park park);
    void UpdatePark(int id, Park park);
    void DeletePark(int id);
  }
}