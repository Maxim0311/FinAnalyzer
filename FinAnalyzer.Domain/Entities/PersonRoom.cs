using FinAnalyzer.Domain.Enums;

namespace FinAnalyzer.Domain.Entities;

public class PersonRoom
{
    public Person Person { get; set; }

    public int PersonId { get; set; } 

    public Room Room { get; set; }

    public int RoomId { get; set; }

    public RoomRole Role { get; set; }
}

