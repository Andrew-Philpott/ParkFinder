using ParksApi.Contracts;
using ParksApi.Helpers;
using ParksApi.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
      return FindByCondition(entry => entry.StateId == id).SingleOrDefault();
    }
    public IEnumerable<State> GetAllStates()
    {
      return FindAll().OrderBy(x => x.Name);
    }

    public IQueryable<State> GetStatesQuery(string name, string region)
    {
      if (name != null)
        return FindByCondition(entry => entry.Name == name);
      if (region != null)
        return FindByCondition(entry => entry.Region == region);
      return null;
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