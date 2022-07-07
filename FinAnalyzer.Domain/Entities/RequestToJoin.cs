namespace FinAnalyzer.Domain.Entities;

public class RequestToJoin : BaseEntity
{
    public Room Room { get; set; }

    public int RoomId { get; set; }

    public Person Person { get; set; }

    public int PersonId { get; set; }
}
