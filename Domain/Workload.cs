namespace Domain;

public class Workload: IEntity
{
    public Guid DepartmentId { get; set; }
    public DateTime LoggingDate { get; set; }
    public int Visitors { get; set; }
}
