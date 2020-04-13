using ParksApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ParksApi.Contracts
{
  public interface IParkRepository : IRepositoryBase<Park>
  {
    Park GetParkById(int id);
    IEnumerable<Park> GetAllParks();
    IEnumerable<Park> GetParksQuery(string parkName, string isNational, IQueryable<State> states);
    void CreatePark(Park park);
    void UpdatePark(int id, Park park);
    void DeletePark(int id);
  }
}