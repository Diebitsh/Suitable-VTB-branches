namespace Contracts.Filters
{
    public class DepartmentFilter : BaseQueryFilter
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Guid? ServiceId { get; set; }

        public decimal? Distance { get; set; }
    }
}
