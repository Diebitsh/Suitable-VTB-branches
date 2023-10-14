using Contracts.Filters;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SuitableVtbBranches.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _departmentService.GetById(id);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]string query)
        {
            var filter = Newtonsoft.Json.JsonConvert.DeserializeObject<DepartmentFilter>(query);
            var result = await _departmentService.GetList(filter);
            return Ok(result);
        }
        
    }
}
