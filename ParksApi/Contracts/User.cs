using ParksApi.Entities;
using System.Collections.Generic;

namespace ParksApi.Contracts
{
  public interface IUserRepository : IRepositoryBase<User>
  {
    User GetUserById(int id);
    User GetUserByEmail(string email);
    IEnumerable<User> GetAllUsers();
    IEnumerable<User> GetUsersByRole(string role);
    User AuthenticateByUserNameAndPassword(string userName, string password);
    User AuthenticateByEmailAndPassword(string email, string password);
    void CreateUser(User user, string password);
    void UpdateUser(User user, string password = null);
    void DeleteUser(int id);
  }
}