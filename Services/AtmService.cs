using Context;
using Contracts;
using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services {
    public class AtmService: IAtmService
    {
        private readonly DataContext _context;
        private readonly IWorkloadService _workloadService;

        public AtmService(DataContext context, IWorkloadService workloadService) {
            _context = context;
            _workloadService = workloadService;
        }

        public async Task<AtmDto> GetById(Guid id)
        {
            var entity = _context.Atms.SingleOrDefault(x => x.Id == id);

            if (entity == null)
                throw new Exception("Запрашиваемый банкомат не найден!");

            var dto = new AtmDto {
                Id = entity.Id,
                Address = entity.Address,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
            };

            return dto;
        }

        public async Task<List<AtmDto>> GetList(AtmQueryFilter filter)
        {
            var query = _context.Atms;

            var result = await query.Select(x => new AtmDto
            {
                Id = x.Id,
                Address = x.Address,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
            })
            .ToListAsync();

            return result;
        }
    }
}
