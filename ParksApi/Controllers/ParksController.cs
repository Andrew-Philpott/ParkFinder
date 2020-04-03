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

    public ParksController()
    {

    }

    // GET api/parks
    // [HttpGet]
    // public ActionResult<IEnumerable<Park>> Get()
    // {

    // }

    // // GET api/parks/5
    // [HttpGet("{id}")]
    // public ActionResult<Park> Get(int id)
    // {

    // }

    // POST api/parks
    [HttpPost]
    public void Post([FromBody] Park park)
    {

    }

    // PUT api/parks/8
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Park park)
    {

    }

    // Delete api/parks/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
  }
}
