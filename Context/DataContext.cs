using Microsoft.EntityFrameworkCore;

namespace Context;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
}
