using Context;
using Contracts;
using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class WorkloadService : IWorkloadService
    {
        private readonly DataContext _context;

        /// <summary>
        /// Средняя скорость обслуживания
        /// </summary>
        private readonly double AvgSpeedService = 10D;

        public WorkloadService(DataContext context)
        {
            _context = context;
        }

        public async Task FillDepartmentWorkLoads(List<DepartmentDto> departments)
        {
            var departmentsIds = departments.Select(x => x.Id);

            var today = DateTime.Now;

            var workloadQuery = _context.Workloads.Where(x => departmentsIds.Contains(x.DepartmentId) && x.LoggingDate.Date == today.Date);

            var workLoadList = await workloadQuery.ToListAsync();

            foreach (var department in departments)
            {
                var depWorkLoads = workLoadList.Where(x => x.DepartmentId == department.Id).OrderByDescending(x => x.LoggingDate).ToList();

                if (depWorkLoads.Count == 0)
                    continue;

                var allEnters = depWorkLoads.Where(x => x.IsEntered == true).Select(x => x.Visitors).Sum();
                var allExits = depWorkLoads.Where(x => x.IsEntered == false).Select(x => x.Visitors).Sum();
                var visitorsNow = allEnters - allExits;
                department.WorkloadPercent = (visitorsNow * 100) / department.MaxVisitors;

                // записи о входах/выходах за последний час
                var lastHourDepWorkload = depWorkLoads.Where(x => (today - x.LoggingDate).TotalMinutes <= 5).ToList();
                // все входы за ласт час
                var allEntersLastHours = lastHourDepWorkload.Where(x => x.IsEntered == true).Select(x => x.Visitors).Sum();

                // Средняя скорость прибытия - Средняя скорость поступления — это среднее количество прибытий за период времени.
                double avgArrivalSpeed = allEntersLastHours / 60D;

                double estimatedWaitingTime = (allEntersLastHours / (AvgSpeedService   * (AvgSpeedService  - allEntersLastHours))) * 10;
                department.EstimatedWaitingTime = estimatedWaitingTime;

                //if (depWorkLoads.Count == 0)
                //    continue;

                //var lastDepWorkLoad = depWorkLoads.FirstOrDefault();

                //var lastHourDepWorkload = depWorkLoads.Where(x => (today - x.LoggingDate).TotalHours <= 1).ToList();

                //var firstEntry = lastHourDepWorkload.First().Visitors;
                //var lastEnrty = lastHourDepWorkload.Last().Visitors;

                //var exitPerHours = firstEntry - lastEnrty > 0 ? firstEntry - lastEnrty : lastEnrty - firstEntry;
                //double exitPerMinute = exitPerHours / 60D;

                //double estimatedWaitingTime = 0D;
                //if (exitPerHours < 0)
                //    estimatedWaitingTime = lastDepWorkLoad == null ? 0 : (lastDepWorkLoad.Visitors / Math.Abs(exitPerMinute));

                //department.WorkloadPercent = lastDepWorkLoad == null ? 0 : (lastDepWorkLoad.Visitors * 100) / department.MaxVisitors;
                //department.EstimatedWaitingTime = estimatedWaitingTime;
            }
        }
    }
}
