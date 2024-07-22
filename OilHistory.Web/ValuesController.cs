using Microsoft.AspNetCore.Mvc;
using OilHistory.Web.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilHistory
{
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : Controller
    {
        private OilService _oilService;

        public ValuesController(OilService oilService)
        {
            _oilService = oilService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var data = await _oilService.GetOilHistory();
            return data;
        }

        [HttpGet("Get2")]
        public async Task<IEnumerable<string>> Get22()
        {
            var data = await _oilService.GetOilHistory();
            return data;
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
