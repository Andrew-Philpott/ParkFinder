using ParksApi.Entities;
using System.Collections.Generic;

namespace ParksApi.Contracts
{
  public interface IStateRepository : IRepositoryBase<State>
  {
    State GetState(int id);
    IEnumerable<State> GetStates();
  }
}