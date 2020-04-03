using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ParksApi.Models;
using ParksApi.Contracts;

namespace ParksApi.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class ParksController : ControllerBase
  {
    private IRepositoryWrapper _db;
    public ParksController(IRepositoryWrapper db)
    {
      _db = db;
    }

    //GET api/parks
    [HttpGet]
    public ActionResult<IEnumerable<Park>> Get()
    {
      return _db.Park.GetParks().ToList();
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public ActionResult<Park> Get(int id)
    {
      return _db.Park.GetPark(id);
    }

    // POST api/parks
    [HttpPost]
    public void Post([FromBody] Park park)
    {
      _db.Park.Create(park);
      _db.Save();
    }

    // PUT api/parks/8
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Park park)
    {
      park.ParkId = id;
      _db.Park.Update(park);
      _db.Save();
    }

    // Delete api/parks/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var park = _db.Park.GetPark(id);
      _db.Park.Delete(park);
      _db.Save();
    }
  }
}
