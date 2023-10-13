﻿using Context;
using Contracts;
using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<DepartmentDto> GetById(Guid id)
        {
            var entity = await _context.Departments
                .Include(x => x.Schedule)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new Exception("Запрашиваемое отделение не найдено");

            var dto = new DepartmentDto
            {
                Id = entity.Id,
                Address = entity.Address,
                Name = entity.Name,
                Shedule = new SheduleDto
                {
                    Monday = entity.Schedule.Monday,
                    Tuesday = entity.Schedule.Tuesday,
                    Wednesday = entity.Schedule.Wednesday,
                    Thursday = entity.Schedule.Thursday,
                    Friday = entity.Schedule.Friday,
                    Saturday = entity.Schedule.Saturday,
                    SunDay = entity.Schedule.Sunday
                }
            };

            return dto;
        }

        public async Task<List<DepartmentDto>> GetList()
        {
            var query = _context.Departments;

            var result = await query.Select(x => new DepartmentDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            })
            .ToListAsync();

            return result;
        }
    }
}