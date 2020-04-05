using ParksApi.Contracts;
using ParksApi.Helpers;

namespace ParksApi.Repository
{
  public class RepositoryWrapper : IRepositoryWrapper
  {
    private ParksApiContext _parksApiContext;
    private IParkRepository _park;
    private IStateRepository _state;
    private IUserRepository _user;
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

    public IUserRepository User
    {
      get
      {
        if (_user == null)
        {
          _user = new UserRepository(_parksApiContext);
        }

        return _user;
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