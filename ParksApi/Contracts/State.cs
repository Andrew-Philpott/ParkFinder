using ParksApi.Entities;
using System.Collections.Generic;

namespace ParksApi.Contracts
{
  public interface IStateRepository : IRepositoryBase<State>
  {
    State GetStateById(int id);
    IEnumerable<State> GetAllStates();
  }
}