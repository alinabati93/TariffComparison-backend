using Microsoft.AspNetCore.Mvc;
using TariffComparison.Model;
using TariffComparison.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TarrifCoparison.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffController : ControllerBase
    {
        private readonly ITariffService _tariffService;
        public TariffController(ITariffService tariffService)
        {
            _tariffService = tariffService;
        }


        //GET: api/<TariffController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }


        // GET api/<TariffController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<TariffController>
        [HttpPost]
        public IEnumerable<TariffViewModel> Post([FromBody] TariffCalculation filters)
        {
            var tariffDefinitions = _tariffService.GetAll();
            var tariffs = _tariffService.CalculateTariffAlgorithm(filters, tariffDefinitions);
            return tariffs;
        }

        // PUT api/<TariffController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<TariffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
