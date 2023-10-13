namespace Domain;

public class Departament: IEntity
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Shedule CommonShedule { get; set; }
    public Shedule IndividualShedule { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
}
