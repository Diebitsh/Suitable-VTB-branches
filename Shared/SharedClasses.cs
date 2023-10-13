namespace Shared;

public class Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class WorkDay
{
    public string WorkHourFrom { get; set; }
    public string WorkHourTo { get; set; }
}

public class BusStation 
{
    public string StationName { get; set; }
    public string[] Buses { get; set; }
}
