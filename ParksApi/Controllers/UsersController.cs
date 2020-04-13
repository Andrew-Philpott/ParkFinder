using System;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using ParksApi.Helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ParksApi.Contracts;
using ParksApi.Entities;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private IRepositoryWrapper _db;

    public UsersController(IRepositoryWrapper db)
    {
      _db = db;
    }

    // [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody]AuthenticateUser model)
    {
      var user = _db.User.AuthenticateByUserNameAndPassword(model.Username, model.Password);

      if (user == null)
        return BadRequest(new { message = "Email or password is incorrect" });

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes("17f48405-05c1-4a26-a801-ad6a21e62d84");
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
            new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      return Ok(new
      {
        Id = user.Id,
        Token = tokenString
      });
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register([FromBody]RegisterUser model)
    {
      ApplicationUser user = new ApplicationUser() { Email = model.Email };
      try
      {
        _db.User.CreateUser(user, model.Password);
        _db.Save();
        return Ok();
      }
      catch (AppException ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _db.User.DeleteUser(id);
      _db.Save();
      return Ok();
    }
  }
}
