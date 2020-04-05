using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using ParksApi.Entities;
using ParksApi.Contracts;

namespace ParksApi.Controllers
{
  [Authorize]
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
    [AllowAnonymous]
    [HttpGet]
    public ActionResult<IEnumerable<State>> GetAllStates()
    {
      return _db.State.GetAllStates().ToList();
    }
  }
}
