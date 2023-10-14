namespace Contracts;

public class DepartmentDto: IEntityDto
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public SheduleDto Schedule { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
    public string MetroStation { get; set; }
    public BusStation BusStation { get; set; }
    public double WorkloadPercent { get; set; }
    public int MaxVisitors { get; set; }
    public List<BankServiceDto> BankServicesDto { get; set; }
}

public class BusStation
{
    public string Address { get; set; }
    public string[] Buses { get; set; }
}