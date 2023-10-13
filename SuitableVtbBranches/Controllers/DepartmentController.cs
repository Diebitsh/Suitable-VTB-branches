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
            var result = new List<object>
            {
                new
                {
                    Id = 1,
                    Name = "test",
                    Address = "tes22t",
                }, new
                {
                    Id = 2,
                    Name = "test1",
                    Address = "te222st",
                }, new
                {
                    Id = 3,
                    Name = "test2",
                    Address = "te222st",
                },
            };

            return Ok(result);
        }
        
    }
}
