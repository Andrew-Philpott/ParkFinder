using ParksApi.Contracts;
using ParksApi.Models;
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
    public State GetState(int id)
    {
      return FindByCondition(entry => entry.StateId == id).FirstOrDefault();
    }
    public IEnumerable<State> GetStates()
    {
      return FindAll().OrderBy(x => x.Name);
    }


  }
}