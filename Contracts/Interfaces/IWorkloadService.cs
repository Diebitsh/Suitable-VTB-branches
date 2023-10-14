namespace Contracts.Interfaces
{
    /// <summary>
    /// Сервис для работы с нагруженностью отделения
    /// </summary>
    public interface IWorkloadService
    {
        public Task FillDepartmentWorkLoads(List<DepartmentDto> departments);
    }
}
