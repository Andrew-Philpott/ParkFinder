using ParksApi.Entities;

namespace ParksApi.Contracts
{
  public interface IUserRepository : IRepositoryBase<ApplicationUser>
  {
    ApplicationUser GetUserById(int id);
    ApplicationUser AuthenticateByUserNameAndPassword(string userName, string password);
    ApplicationUser CreateUser(ApplicationUser user, string password);
    void DeleteUser(int id);
  }
}