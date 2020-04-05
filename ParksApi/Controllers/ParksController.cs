using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ParksApi.Entities;
using ParksApi.Contracts;
using System;

namespace ParksApi.Controllers
{
  // [Authorize]
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
    public IActionResult GetAllParks()
    {
      var model = _db.Park.GetAllParks();
      return Ok(model);
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public IActionResult GetParkById(int id)
    {
      var model = _db.Park.GetParkById(id);
      return Ok(model);
    }

    [HttpGet("search")]
    public IActionResult SearchParks(string parkName, string stateName, string isNational, string region)
    {
      IQueryable<State> states = _db.State.GetStatesQuery(stateName, region);
      Console.WriteLine(states);
      var model = _db.Park.GetParksQuery(parkName, isNational, states);
      return Ok(model);
    }

    // POST api/parks
    [HttpPost]
    public IActionResult CreatePark([FromBody] Park park)
    {
      _db.Park.CreatePark(park);
      _db.Save();
      return Ok();
    }

    // PUT api/parks/8
    [HttpPut("{id}")]
    public IActionResult UpdatePark(int id, [FromBody] Park park)
    {
      _db.Park.UpdatePark(id, park);
      _db.Save();
      return Ok();
    }

    // Delete api/parks/5
    [HttpDelete("{id}")]
    public IActionResult DeletePark(int id)
    {
      _db.Park.DeletePark(id);
      _db.Save();
      return Ok();
    }
  }
}
