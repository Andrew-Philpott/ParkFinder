using ParksApi.Contracts;
using ParksApi.Entities;
using ParksApi.Helpers;
using ParksApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParksApi.Repository
{
  public class UserRepository : RepositoryBase<User>,
  IUserRepository
  {
    public UserRepository(ParksApiContext parksApiContext) : base(parksApiContext)
    {
    }
    public User GetUser(int id)
    {
      return FindByCondition(entry => entry.UserId == id).FirstOrDefault();
    }
    public IEnumerable<User> GetUsers()
    {
      return FindAll().OrderBy(x => x.LastName);
    }
  }
}