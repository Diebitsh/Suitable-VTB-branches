using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SuitableVtbBranches.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/atm")]
    public class AtmController : ControllerBase
    {
        private readonly IAtmService _atmService;

        public AtmController(IAtmService atmService) {
            _atmService = atmService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _atmService.GetById(id);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]string query)
        {
            var filter = Newtonsoft.Json.JsonConvert.DeserializeObject<AtmQueryFilter>(query);
            var result = await _atmService.GetList(filter);
            return Ok(result);
        }
    }
}