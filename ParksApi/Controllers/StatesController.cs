using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ParksApi.Contracts;

namespace ParksApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StatesController : ControllerBase
  {
    private IRepositoryWrapper _db;
    public StatesController(IRepositoryWrapper db)
    {
      _db = db;
    }

    //GET api/parks
    [HttpGet]
    public IActionResult GetAllStates()
    {
      return Ok(_db.State.GetAllStates());
    }
  }
}
