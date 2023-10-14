using Context;
using Contracts;
using Contracts.Filters;
using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Helpers;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        private readonly IWorkloadService _workloadService;

        public DepartmentService(DataContext context, IWorkloadService workloadService)
        {
            _context = context;
            _workloadService = workloadService;
        }

        public async Task<DepartmentDto> GetById(Guid id)
        {
            var entity = await _context.Departments
                .Include(x => x.Schedule) 
                .Include(x => x.BankServices)
                .ThenInclude(x => x.BankService)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new Exception("Запрашиваемое отделение не найдено");

            var dto = new DepartmentDto
            {
                Id = entity.Id,
                Address = entity.Address,
                Name = entity.Name,
                Schedule = new SheduleDto
                {
                    Monday = entity.Schedule.Monday,
                    Tuesday = entity.Schedule.Tuesday,
                    Wednesday = entity.Schedule.Wednesday,
                    Thursday = entity.Schedule.Thursday,
                    Friday = entity.Schedule.Friday,
                    Saturday = entity.Schedule.Saturday,
                    SunDay = entity.Schedule.Sunday
                },
            };

            return dto;
        }

        public async Task<List<DepartmentDto>> GetList(DepartmentFilter filter)
        {
            var query = _context.Departments.AsQueryable();

            query = query.OrderBy(x => ((filter.Latitude - x.Latitude) * (filter.Latitude - x.Latitude)) +((filter.Longitude - x.Longitude) * (filter.Longitude - x.Longitude)));

            if (filter.ServiceId.HasValue)
            {
                query = query.Where(x => x.BankServices != null && x.BankServices.Any(z => z.BankServiceId == filter.ServiceId.Value));
            }

            await query.Select(x => x.Workloads).LoadAsync();

            var result = await query
                .Select(x => new DepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    MaxVisitors = x.MaxVisitors,

                })
                .ToListAsync();

            await _workloadService.FillDepartmentWorkLoads(result);

            result.ForEach(x => 
                x.Distance = double.Round(DistanceRangeCalculateHelper.GetDistanceFromLatLonInKm(filter.Latitude, filter.Longitude, x.Latitude, x.Longitude), 3)
            );


            result = result
                .OrderBy(x => x.Distance)
                .ToList();

            return result;
        }
        
    }
}
