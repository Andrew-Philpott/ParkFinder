using ParksApi.Contracts;
using ParksApi.Helpers;
using ParksApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ParksApi.Repository
{
  public class StateRepository : RepositoryBase<State>,
  IStateRepository
  {
    public StateRepository(ParksApiContext parksApiContext) : base(parksApiContext)
    {
    }
    public State GetStateById(int id)
    {
      return FindByCondition(entry => entry.StateId == id).FirstOrDefault();
    }
    public IEnumerable<State> GetAllStates()
    {
      return FindAll().OrderBy(x => x.Name);
    }

    public void CreateState(State state)
    {
      Create(state);
    }

    public void UpdateState(State state)
    {
      Update(state);
    }

    public void DeleteState(State state)
    {
      Delete(state);
    }
  }
}