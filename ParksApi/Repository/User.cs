using ParksApi.Contracts;
using ParksApi.Entities;
using ParksApi.Helpers;
using System.Linq;

namespace ParksApi.Repository
{
  public class UserRepository : RepositoryBase<ApplicationUser>,
  IUserRepository
  {
    public UserRepository(ParksApiContext parksApiContext) : base(parksApiContext)
    {
    }
    public ApplicationUser GetUserById(int id)
    {
      return FindByCondition(entry => entry.Id == id).SingleOrDefault();
    }
    public ApplicationUser AuthenticateByUserNameAndPassword(string userName, string password)
    {
      if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        return null;

      ApplicationUser user = FindByCondition(x => x.Username == userName).FirstOrDefault();

      if (user == null)
        return null;

      if (user.Password != password)
        return null;

      return user;
    }

    public ApplicationUser CreateUser(ApplicationUser user, string password)
    {
      if (string.IsNullOrWhiteSpace(password))
        throw new AppException("Password is required");

      if (FindAll().Any(x => x.Username == user.Username))
        throw new AppException($"Username {user.Username} is already taken");

      user.Password = password;

      Create(user);
      return user;
    }

    public void DeleteUser(int id)
    {
      var user = GetUserById(id);
      if (user != null)
        Delete(user);
    }
  }
}