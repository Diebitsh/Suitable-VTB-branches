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
    public double Distance { get; set; }

    /// <summary>
    /// Почтовый индекс
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// Область
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// Дом
    /// </summary>
    public string Building { get; set; }

    /// <summary>
    /// Этаж
    /// </summary>
    public string? Floor { get; set; }

    /// <summary>
    /// предполагаемое время ождиания в минутках
    /// </summary>
    public double EstimatedWaitingTime { get; set; }
}

public class BusStation
{
    public string Address { get; set; }
    public string[] Buses { get; set; }
}