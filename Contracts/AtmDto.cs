namespace Contracts;

public class AtmDto: IEntityDto
{
     public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
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
}
