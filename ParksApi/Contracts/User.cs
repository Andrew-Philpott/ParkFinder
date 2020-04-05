using ParksApi.Entities;
using System.Collections.Generic;

namespace ParksApi.Contracts
{
  public interface IUserRepository : IRepositoryBase<User>
  {
    User GetUser(int id);
    IEnumerable<User> GetUsers();
  }
}