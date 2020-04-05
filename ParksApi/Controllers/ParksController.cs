using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ParksApi.Entities;
using ParksApi.Contracts;

namespace ParksApi.Controllers
{
  [Authorize]
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
    public ActionResult<IEnumerable<Park>> GetParks()
    {
      return _db.Park.GetParks().ToList();
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public ActionResult<Park> GetPark(int id)
    {
      return _db.Park.GetPark(id);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Park>> SearchParks(string parkName, string stateName, string isNational, string region)
    {
      return _db.Park.GetParksQuery(parkName, stateName, isNational, stateName).ToList();
    }

    // POST api/parks
    [HttpPost]
    public void PostPark([FromBody] Park park)
    {
      _db.Park.Create(park);
      _db.Save();
    }

    // PUT api/parks/8
    [HttpPut("{id}")]
    public void PutPark(int id, [FromBody] Park park)
    {
      park.ParkId = id;
      _db.Park.Update(park);
      _db.Save();
    }

    // Delete api/parks/5
    [HttpDelete("{id}")]
    public void DeletePark(int id)
    {
      Park park = _db.Park.GetPark(id);
      _db.Park.Delete(park);
      _db.Save();
    }
  }
}
