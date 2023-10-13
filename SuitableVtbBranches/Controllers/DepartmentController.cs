using Microsoft.AspNetCore.Mvc;

namespace SuitableVtbBranches.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/department")]
    public class DepartmentController : ControllerBase
    {
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var department = new
            {
                Id = id,
                Nname = "test",
                Address = "test",
            };

            return Ok(department);
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
