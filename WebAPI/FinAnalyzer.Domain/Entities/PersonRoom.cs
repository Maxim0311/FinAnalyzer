namespace FinAnalyzer.Domain.Entities;

public class PersonRoom
{
    public Person Person { get; set; }

    public int PersonId { get; set; }

    public Room Room { get; set; }

    public int RoomId { get; set; }

    public RoomRole RoomRole { get; set; }

    public int RoomRoleId { get; set; }

    public DateTime? DeleteDate { get; set; }
}

