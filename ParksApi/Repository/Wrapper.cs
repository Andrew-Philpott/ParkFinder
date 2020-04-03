using ParksApi.Contracts;
using ParksApi.Models;

namespace ParksApi.Repository
{
  public class RepositoryWrapper : IRepositoryWrapper
  {
    private ParksApiContext _parksApiContext;
    private IParkRepository _park;
    private IStateRepository _state;
    public IParkRepository Park
    {
      get
      {
        if (_park == null)
        {
          _park = new ParkRepository(_parksApiContext);
        }

        return _park;
      }
    }

    public IStateRepository State
    {
      get
      {
        if (_state == null)
        {
          _state = new StateRepository(_parksApiContext);
        }

        return _state;
      }
    }

    public RepositoryWrapper(ParksApiContext parksApiContext)
    {
      _parksApiContext = parksApiContext;
    }

    public void Save()
    {
      _parksApiContext.SaveChanges();
    }
  }
}