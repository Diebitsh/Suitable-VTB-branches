namespace Contracts.Interfaces
{
    public interface IDepartmentService
    {
        public Task<DepartmentDto> GetById(Guid id);
    }
}
