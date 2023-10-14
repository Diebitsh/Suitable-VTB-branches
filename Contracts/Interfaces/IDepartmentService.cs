using Contracts.Filters;

namespace Contracts.Interfaces
{
    public interface IDepartmentService
    {
        public Task<DepartmentDto> GetById(Guid id);
        public Task<List<DepartmentDto>> GetList(DepartmentFilter filter);
    }
}
