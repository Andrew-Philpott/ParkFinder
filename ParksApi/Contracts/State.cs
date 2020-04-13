using ParksApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ParksApi.Contracts
{
  public interface IStateRepository : IRepositoryBase<State>
  {
    State GetStateById(int id);
    IEnumerable<State> GetAllStates();
    IQueryable<State> GetStatesQuery(string name, string region);
  }
}