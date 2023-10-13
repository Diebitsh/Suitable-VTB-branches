using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetList()
        {
            var result = await _departmentService.GetList();
            return Ok(result);
        }
        
    }
}
