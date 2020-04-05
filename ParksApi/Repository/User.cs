using ParksApi.Contracts;
using ParksApi.Entities;
using ParksApi.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Security.Cryptography;

namespace ParksApi.Repository
{
  public class UserRepository : RepositoryBase<User>,
  IUserRepository
  {
    public UserRepository(ParksApiContext parksApiContext) : base(parksApiContext)
    {
    }
    public User GetUserById(int id)
    {
      return FindByCondition(entry => entry.UserId == id).SingleOrDefault();
    }
    public User GetUserByEmail(string email)
    {
      return FindByCondition(x => x.Email == email).SingleOrDefault();
    }
    public User GetUserByUserName(string email)
    {
      return FindByCondition(x => x.Email == email).SingleOrDefault();
    }
    public IEnumerable<User> GetAllUsers()
    {
      return FindAll().OrderBy(x => x.LastName);
    }
    public IEnumerable<User> GetUsersByRole(string role)
    {
      return FindByCondition(x => x.Role == role);
    }
    public User AuthenticateByUserNameAndPassword(string userName, string password)
    {
      if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        return null;

      var user = GetUserByUserName(userName);

      if (user == null)
        return null;

      if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        return null;

      return user;
    }
    public User AuthenticateByEmailAndPassword(string email, string password)
    {
      if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        return null;

      var user = GetUserByEmail(email);

      if (user == null)
        return null;

      if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        return null;

      return user;
    }

    public void CreateUser(User user, string password)
    {
      if (string.IsNullOrWhiteSpace(password))
        throw new AppException("Password is required");

      if (FindAll().Any(x => x.UserName == user.UserName))
        throw new AppException($"Username {user.UserName} is already taken");

      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;

      Create(user);
    }

    public void UpdateUser(User user, string password = null)
    {
      var userToUpdate = GetUserById(user.UserId);

      if (userToUpdate == null)
        throw new AppException("User not found");

      if (!string.IsNullOrWhiteSpace(user.UserName) && user.UserName != user.UserName)
      {
        if (FindAll().Any(x => x.UserName == user.UserName))
          throw new AppException("Username " + user.UserName + " is already taken");

        user.UserName = user.UserName;
      }

      if (!string.IsNullOrWhiteSpace(user.FirstName))
        user.FirstName = user.FirstName;

      if (!string.IsNullOrWhiteSpace(user.LastName))
        user.LastName = user.LastName;

      if (!string.IsNullOrWhiteSpace(password))
      {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
      }

      Update(user);
    }

    public void DeleteUser(int id)
    {
      var user = GetUserById(id);
      if (user != null)
        Delete(user);
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or only whitespace.", "password");

      using (var hmac = new HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
      }
    }

    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
      if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
      if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

      using (var hmac = new HMACSHA512(storedSalt))
      {
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != storedHash[i]) return false;
        }
      }

      return true;
    }
  }
}