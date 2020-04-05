using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ParksApi.Entities;
using ParksApi.Contracts;

namespace ParksApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {
    private IRepositoryWrapper _db;

    public UsersController(IRepositoryWrapper db)
    {
      _db = db;
    }


  }
}
