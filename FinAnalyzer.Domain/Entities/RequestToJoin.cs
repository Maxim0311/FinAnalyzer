namespace FinAnalyzer.Domain.Entities;

public class RequestToJoin : BaseEntity
{
    public Room Room { get; set; }

    public int RoomId { get; set; }

    public User User { get; set; }

    public int UserId { get; set; }
}
