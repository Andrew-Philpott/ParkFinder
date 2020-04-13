using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ParksApi.Entities;
using ParksApi.Models;
using ParksApi.Contracts;
using ParksApi.Helpers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ParksApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ParksController : ControllerBase
  {
    private IRepositoryWrapper _db;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;
    public ParksController(IRepositoryWrapper db, IMapper mapper, IOptions<AppSettings> appSettings)
    {
      _mapper = mapper;
      _db = db;
      _appSettings = appSettings.Value;
    }

    //GET api/parks
    [HttpGet]
    public IActionResult GetAllParks()
    {
      var model = _db.Park.GetAllParks();
      var models = _mapper.Map<IEnumerable<ViewPark>>(model);
      return Ok(models);
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public IActionResult GetParkById(int id)
    {
      var model = _mapper.Map<ViewPark>(_db.Park.GetParkById(id));
      return Ok(model);
    }

    [HttpGet("search")]
    public IActionResult SearchParks(string parkName, string stateName, string isNational, string region)
    {
      var states = _db.State.GetStatesQuery(stateName, region);
      var model = _mapper.Map<IEnumerable<ViewPark>>(_db.Park.GetParksQuery(parkName, isNational, states));
      return Ok(model);
    }

    // POST api/parks
    [HttpPost]
    public IActionResult CreatePark([FromBody]Park park)
    {
      var model = _mapper.Map<Park>(park);
      _db.Park.CreatePark(model);
      _db.Save();
      return Ok();
    }

    // PUT api/parks/8
    [HttpPut("{id}")]
    public IActionResult UpdatePark(int id, [FromBody]Park park)
    {
      var model = _mapper.Map<Park>(park);
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
