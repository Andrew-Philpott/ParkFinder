namespace ParksApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ParksController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ParksController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // GET api/parks
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {

        }

        // GET api/parks/5
        [HttpGet("{id}")]
        public ActionResult<Destination> Get(int id)
        {

        }

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
