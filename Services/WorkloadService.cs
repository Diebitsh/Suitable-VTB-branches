using Context;
using Contracts;
using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class WorkloadService : IWorkloadService
    {
        private readonly DataContext _context; 

        public WorkloadService(DataContext context)
        {
            _context = context;
        }

        public async Task FillDepartmentWorkLoads(List<DepartmentDto> departments)
        {
            var departmentsIds = departments.Select(x => x.Id);

            var today = DateTime.Now.Date;

            var workloadQuery = _context.Workloads.Where(x => departmentsIds.Contains(x.DepartmentId) && x.LoggingDate.Date == today);

            var workLoadList = await workloadQuery.ToListAsync();

            foreach (var department in departments)
            {
                var depWorkLoads = workLoadList.Where(x => x.DepartmentId == department.Id).OrderByDescending(x => x.LoggingDate).ToList();
                var lastDepWorkLoad = depWorkLoads.FirstOrDefault();


                department.WorkloadPercent = lastDepWorkLoad == null ? 0 : (lastDepWorkLoad.Visitors * 100) / department.MaxVisitors;
            }
        }
    }
}
