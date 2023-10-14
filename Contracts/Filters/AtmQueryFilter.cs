using Contracts.Filters;

namespace Contracts;

public class AtmQueryFilter: BaseQueryFilter
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public Guid? ServiceId { get; set; }

    public decimal? Distance { get; set; }
}
