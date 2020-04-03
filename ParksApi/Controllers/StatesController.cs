using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ParksApi.Models;
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
    public ActionResult<IEnumerable<State>> Get()
    {
      return _db.State.GetStates().ToList();
    }
  }
}
