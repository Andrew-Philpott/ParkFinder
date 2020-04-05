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
    public ActionResult<IEnumerable<Park>> GetAllParks()
    {
      return _db.Park.GetAllParks().ToList();
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public ActionResult<Park> GetParkById(int id)
    {
      return _db.Park.GetParkById(id);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Park>> SearchParks(string parkName, string stateName, string isNational, string region)
    {
      return _db.Park.GetParksQuery(parkName, stateName, isNational, stateName).ToList();
    }

    // POST api/parks
    [HttpPost]
    public void CreatePark([FromBody] Park park)
    {
      _db.Park.CreatePark(park);
      _db.Save();
    }

    // PUT api/parks/8
    [HttpPut("{id}")]
    public void UpdatePark(int id, [FromBody] Park park)
    {
      _db.Park.UpdatePark(id, park);
      _db.Save();
    }

    // Delete api/parks/5
    [HttpDelete("{id}")]
    public void DeletePark(int id)
    {
      _db.Park.DeletePark(id);
      _db.Save();
    }
  }
}
