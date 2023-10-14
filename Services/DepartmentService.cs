using Context;
using Contracts;
using Contracts.Filters;
using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                throw new Exception("Запрашиваемое отделение не найдено!");

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
                BankServicesDto = entity.BankServices.Select( x => new BankServiceDto {
                    Id = x.BankServiceId,
                    Name = x.BankService.Name,
                    Description = x.BankService.Description
                }).ToList()
            };

            return dto;
        }

        public async Task<List<DepartmentDto>> GetList(DepartmentFilter filter)
        {
            var query = _context.Departments;

            var result = await query.Select(x => new DepartmentDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                MaxVisitors = x.MaxVisitors
            })
            .ToListAsync();

            //await _workloadService.FillDepartmentWorkLoads(result);

            return result;
        }
    }
}
