using Context;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class BankServicesService : IBankServiceService
{
    private readonly DataContext _context;

    public BankServicesService(DataContext context) {
        _context = context;
    }
    public Task<List<BankServiceDto>> GetList()
    {
        var entities = _context.BankServices.AsQueryable();

        return entities.Select( x => new BankServiceDto {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        }).ToListAsync();
    }
}
