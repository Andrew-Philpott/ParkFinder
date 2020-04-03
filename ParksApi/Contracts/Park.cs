using ParksApi.Models;
using System.Collections.Generic;

namespace ParksApi.Contracts
{
  public interface IParkRepository : IRepositoryBase<Park>
  {
    Park GetPark(int id);
    IEnumerable<Park> GetParks();
    IEnumerable<Park> GetParksQuery(string parkName, string stateName, string isNational, string region);
  }
}